namespace CENTASMS.BLL
{
    using CENTASMS;
    using CENTASMS.DAL;
    using System;
    using System.Collections;
    using System.Data;
    using FirebirdSql.Data.FirebirdClient;
    //using System.Data.OleDb;
    using System.Data.OleDb;
    using System.Runtime.InteropServices;
    using System.Text;

    public class SmsMsgs
    {
        public const string CBATCHID_PARM = "@CBATCHID";
        public const string CMOBILENO_PARM = "@CMOBILENO";
        public const string CREATE_DATE_PARM = "@CREATE_DATE";
        public const string CSMSMSG_PARM = "@CSMSMSG";
        //public const string CCMMSSUBJECT_PARM = "@CMMSSUBJECT";
        //public const string CCMMSATTACH_PARM = "@CMMSATTACH";
        public const string CTYPE_PARM = "@CTYPE";
        private OleDbCommand  deleteCommand;
        private OleDbDataAdapter dsCommand = new OleDbDataAdapter();
        private OleDbCommand insertCommand;
        public const string IPRIORITY_PARM = "@IPRIORITY";
        public const string IREC_NO_PARM = "@IREC_NO";
        private OleDbCommand loadCommand;

        public SmsMsgs()
        {
            this.dsCommand.SelectCommand = new OleDbCommand();
            this.dsCommand.SelectCommand.Connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn);
            this.dsCommand.TableMappings.Add("Table", SmsMsgData.SMS_MSG);
        } 

        public bool CreateSmsMsg(string csmsmsg, string ctype, int ipriority, string create_date, ArrayList cmoblieno, string csender, string strcaller, int imsglen, int ismsmsgno, int imobiletotal, out string cbatchid)
        {
            bool flag = false;
            cbatchid = "";
            SmsMsgData smsmsg = new SmsMsgData();
            try
            {
                DataTable table = new DataTable();
                cbatchid = new SmsMsgHists().GetNewBatchid();
                if (Users.UserExtraGroup(csender))
                {
                    string str = cmoblieno[0].ToString();
                    int index = str.IndexOf("[");
                    string str2 = str.Substring(index + 1, (str.IndexOf("]") - index) - 1).Replace("(私人組別)", "").Replace("(共享組別)", "").Replace("(Private)", "").Replace("(Share)", "");
                }
                else
                {
                    strcaller = "";
                }
                table = smsmsg.Tables[SmsMsgData.SMS_MSG];
                DataRow row = table.NewRow();
                row["CBATCHID"] = cbatchid;
              //row["CSMSMSG"] = csmsmsg;
                row["CSMSMSG"] = BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(csmsmsg)).Replace("-", "");
                row["CTYPE"] = ctype;
                row["IPRIORITY"] = ipriority;
                row["CREATE_DATE"] = create_date;
                table.Rows.Add(row);
                ArrayList list = new ArrayList();
                ArrayList list2 = new ArrayList();
                for (int i = 0; i < cmoblieno.Count; i++)
                {
                    string str3 = cmoblieno[i].ToString();
                    string item = "";
                    string str5 = "";
                    int length = str3.IndexOf("[");
                    if (length > -1)
                    {
                        item = str3.Substring(0, length);
                        str5 = str3.Substring(length + 1, (str3.IndexOf("]") - length) - 1).Replace("(私人組別)", "").Replace("(共享組別)", "").Replace("(Private)", "").Replace("(Share)", "");
                        if (AppFlag.DuplicateSending)
                        {
                            list.Add(item);
                            list2.Add(str5);
                        }
                        else
                        {
                            if (!list.Contains(item))
                            {
                                list.Add(item);
                                list2.Add(str5);
                            }
                        }
                    }
                    else
                    {
                        item = str3;
                        str5 = "";
                        if (AppFlag.DuplicateSending)
                        {
                            list.Add(item);
                            list2.Add(str5);
                        }
                        else
                        {
                            if (!list.Contains(item))
                            {
                                list.Add(item);
                                list2.Add(str5);
                            }
                        }
                    }
                }
                SmsMsgHistData data2 = new SmsMsgHistData();
                table = data2.Tables["SMS_MSG_HIST"];
                row = table.NewRow();
                row["CBATCHID"] = cbatchid;
                //row["CSMSMSG"] = csmsmsg;
                row["CSMSMSG"] = ("%" + BitConverter.ToString(Encoding.UTF8.GetBytes(csmsmsg))).Replace("-", "%");
                row["CTYPE"] = ctype;
                row["IPRIORITY"] = ipriority;
                row["CREATE_DATE"] = create_date;
                row["CSENDER"] = csender;
                row["CALLER"] = strcaller;
                row["IMSGLEN"] = imsglen;
                row["ISMSMSGNO"] = ismsmsgno;
                row["IMOBILETOTAL"] = list.Count;
                table.Rows.Add(row);
                if (new SmsMsgs().InsertSmsMsg(smsmsg) && new SmsMsgHists().InsertSmsMsgHist(data2))
                {
                    int num4 = 1;
                    SmsMsgReceData data3 = new SmsMsgReceData();
                    SmsMsgReceHistData data4 = new SmsMsgReceHistData();
                    for (int j = 0; j < list.Count; j++)
                    {
                        table = data3.Tables[SmsMsgReceData.SMS_MSG_RECEIVER];
                        row = table.NewRow();
                        row["IREC_NO"] = num4;
                        row["CBATCHID"] = cbatchid;
                        row["CMOBILENO"] = list[j].ToString() + "                        ";
                        row["IPRIORITY"] = ipriority;
                        if (list[j].ToString() != "")
                        {
                            table.Rows.Add(row);
                        }
                        table = data4.Tables["SMS_MSGRCV_HIST"];
                        row = table.NewRow();
                        row["IREC_NO"] = num4;
                        row["CBATCHID"] = cbatchid;
                        row["CMOBILENO"] = list[j].ToString() + "                        ";
                        row["CGROUP_NAME"] = list2[j].ToString().Trim() + "                              ";
                        row["IPRIORITY"] = ipriority;
                        if (list[j].ToString() != "")
                        {
                            table.Rows.Add(row);
                        }
                        num4++;
                    }
                    if (new SmsMsgReces().InsertSmsMsgRece(data3) && new SmsMsgReceHists().InsertSmsMsgReceHist(data4))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                else
                {
                    flag = false;
                }
                if (!flag)
                {
                    this.DeletelSmsData(cbatchid);
                }
            }
            catch (Exception exception)
            {
                string str6 = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " CreateSmsMsg   " + exception.ToString());
                flag = false;
            }
            return flag;
        }
        //public bool CreateSmsMsg(string csmsmsg,string cMmsSubject,string cMmsAttach, string ctype, int ipriority, string create_date, ArrayList cmoblieno, string csender, string strcaller, int imsglen, int ismsmsgno, int imobiletotal, out string cbatchid)
        //{
        //    bool flag = false;
        //    cbatchid = "";
        //    SmsMsgData smsmsg = new SmsMsgData();
        //    try
        //    {
        //        DataTable table = new DataTable();
        //        cbatchid = new SmsMsgHists().GetNewBatchid();
        //        if (Users.UserExtraGroup(csender))
        //        {
        //            string str = cmoblieno[0].ToString();
        //            int index = str.IndexOf("[");
        //            string str2 = str.Substring(index + 1, (str.IndexOf("]") - index) - 1).Replace("(私人組別)", "").Replace("(共享組別)", "");
        //        }
        //        else
        //        {
        //            strcaller = "";
        //        }
        //        table = smsmsg.Tables[SmsMsgData.SMS_MSG];
        //        DataRow row = table.NewRow();
        //        row["CBATCHID"] = cbatchid;
        //        row["CSMSMSG"] = csmsmsg;// BitConverter.ToString(Encoding.Unicode.GetBytes(csmsmsg+" "));
        //        row["CMMSSUBJECT"] = cMmsSubject;// BitConverter.ToString(Encoding.Unicode.GetBytes(cMmsSubject + " "));
        //        row["CMMSATTACH"] = cMmsAttach;
        //        row["CTYPE"] = ctype;
        //        row["IPRIORITY"] = ipriority;
        //        row["CREATE_DATE"] = create_date;
        //        table.Rows.Add(row);
        //        ArrayList list = new ArrayList();
        //        ArrayList list2 = new ArrayList();
        //        bool bInsertMMS = false;
        //        for (int i = 0; i < cmoblieno.Count; i++)
        //        {
        //            string str3 = cmoblieno[i].ToString();
        //            string num = "";
        //            string group = "";
        //            int length = str3.IndexOf("[");
        //            if (length > -1)
        //            {
        //                num = str3.Substring(0, length) + str3.Substring(str3.IndexOf(","), str3.ToString().Length - str3.ToString().IndexOf(","));
        //                group = str3.Substring(length + 1, (str3.IndexOf("]") - length) - 1).Replace("(私人組別)", "").Replace("(共享組別)", "");

        //                if (!list.Contains(num))
        //                {
        //                    if (num.IndexOf(",1") > -1||num.IndexOf(",0") >-1 )
        //                    {
        //                        bInsertMMS = true;
        //                    }
        //                    list.Add(num);
        //                    list2.Add(group);
        //                }
        //            }
        //            else
        //            {
        //                num = str3;
        //                group = "";
        //                if (!list.Contains(num))
        //                {
        //                    if (num.IndexOf(",1") > -1 || num.IndexOf(",0") > -1)
        //                    {
        //                        bInsertMMS = true;
        //                    }
        //                    list.Add(num);
        //                    list2.Add(group);
        //                }
        //            }
        //        }
        //        SmsMsgHistData data2 = new SmsMsgHistData();
        //        table = data2.Tables["SMS_MSG_HIST"];
        //        row = table.NewRow();
        //        row["CBATCHID"] = cbatchid;
        //        row["CSMSMSG"] = csmsmsg;// BitConverter.ToString(Encoding.Unicode.GetBytes(csmsmsg));
        //        row["CMMSSUBJECT"] = cMmsSubject;// BitConverter.ToString(Encoding.Unicode.GetBytes(cMmsSubject));
        //        row["CMMSATTACH"] = cMmsAttach;
        //        row["CTYPE"] = ctype;
        //        row["IPRIORITY"] = ipriority;
        //        row["CREATE_DATE"] = create_date;
        //        row["CSENDER"] = csender;
        //        row["CALLER"] = strcaller;
        //        row["IMSGLEN"] = imsglen;
        //        row["ISMSMSGNO"] = ismsmsgno;
        //        row["IMOBILETOTAL"] = list.Count;
        //        table.Rows.Add(row);
        //        if (new SmsMsgs().InsertSmsMsg(smsmsg, bInsertMMS) && new SmsMsgHists().InsertSmsMsgHist(data2))
        //        {
        //            int num4 = 1;
        //            SmsMsgReceData data3 = new SmsMsgReceData();
        //            SmsMsgReceHistData data4 = new SmsMsgReceHistData();
        //            for (int j = 0; j < list.Count; j++)
        //            {
        //                string no = list[j].ToString().Substring(0,list[j].ToString().IndexOf(",")) + "                        ";
        //                int priority = Convert.ToInt32(list[j].ToString().Substring(list[j].ToString().IndexOf(",") + 1, list[j].ToString().Length - list[j].ToString().IndexOf(",") - 1));
        //                table = data3.Tables[SmsMsgReceData.SMS_MSG_RECEIVER];
        //                row = table.NewRow();
        //                row["IREC_NO"] = num4;
        //                row["CBATCHID"] = cbatchid;
        //                row["CMOBILENO"] = no;
        //                row["IPRIORITY"] = priority;
        //                if (list[j].ToString() != "")
        //                {
        //                    if (priority != -1)
        //                    {
        //                        table.Rows.Add(row);
        //                    }
        //                }
        //                table = data4.Tables["SMS_MSGRCV_HIST"];
        //                row = table.NewRow();
        //                row["IREC_NO"] = num4;
        //                row["CBATCHID"] = cbatchid;
        //                row["CMOBILENO"] = no;
        //                row["CGROUP_NAME"] = list2[j].ToString().Trim() + "                              ";
        //                row["IPRIORITY"] = priority;
        //                if (list[j].ToString() != "")
        //                {
        //                    table.Rows.Add(row);
        //                }
        //                num4++;
        //            }
        //            if (new SmsMsgReces().InsertSmsMsgRece(data3) && new SmsMsgReceHists().InsertSmsMsgReceHist(data4))
        //            {
        //                flag = true;
        //                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + csender + ")  發送號碼 " + data3.Tables[0].Rows.Count.ToString() + "個;");
                   
        //            }
        //            else
        //            {
        //                flag = false;
        //            }
        //        }
        //        else
        //        {
        //            flag = false;
        //        }
        //        if (!flag)
        //        {
        //            this.DeletelSmsData(cbatchid);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        string str6 = exception.ToString();
        //        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "CreateSmsMsg   " + exception.ToString());
        //        flag = false;
        //    }
        //    return flag;
        //}

        public void DeletelSmsData(string id)
        {
            OleDbCommand command = new OleDbCommand();
            FbCommand command2 = new FbCommand();
             
            OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn);
            FbConnection connection2 = new FbConnection(AppFlag.CENTASMSINTEConn);
            string str = "Delete error:";
            try
            {
                command.Connection = connection;
                connection.Open();
                str = "DELETE FROM  " + AppFlag.SMS_MSG_TABLE + "   WHERE CBATCHID='" + id + "'";
                command.CommandText = str;
                command.ExecuteNonQuery();
                str = "DELETE FROM   " + AppFlag.SMS_MSG_RECEIVER_TABLE + "    WHERE CBATCHID='" + id + "'";
                command.CommandText = str;
                command.ExecuteNonQuery();
                connection.Close();
                command2.Connection = connection2;
                connection2.Open();
                str = "DELETE FROM SMS_MSG_HIST WHERE CBATCHID='" + id + "'";
                command2.CommandText = str;
                command2.ExecuteNonQuery();
                str = "DELETE FROM SMS_MSGRCV_HIST WHERE CBATCHID='" + id + "'";
                command2.CommandText = str;
                command2.ExecuteNonQuery();
                connection2.Close();
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  Callback(DELETE)   " + id + " ");
            }
            catch (Exception exception)
            {
                string str2 = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  DeletelSmsData Callback   " + str + " " + exception.ToString());
            }
        }

        public void DeleteSentMmsById(string ids)
        {
            OleDbCommand command = new OleDbCommand();
            OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn); 
            string str = "Delete error:";
            try
            {
                command.Connection = connection;
                connection.Open();
                str = "DELETE FROM  " + AppFlag.SMS_MSG_TABLE + "   WHERE CBATCHID IN '" + ids + "'";
                command.CommandText = str;
                command.ExecuteNonQuery();
                str = "DELETE FROM   " + AppFlag.SMS_MSG_RECEIVER_TABLE + "    WHERE CBATCHID IN '" + ids + "'";
                command.CommandText = str;
                command.ExecuteNonQuery();
                connection.Close(); 
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " DeleteSentMmsById   " + ids + " ");
            }
            catch (OleDbException exception)
            {
                string str2 = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "DeleteSentMmsById   " + str + " " + exception.ToString());
            }
        }

        public bool DeleteSmsMsg(SmsMsgData smsmsg)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.DeleteCommand = this.GetDeleteCommand();
                this.dsCommand.Update(smsmsg, SmsMsgData.SMS_MSG);
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  Delete from  " + SmsMsgData.SMS_MSG);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + " Delete  SmsMsgData  " + exception.ToString());
            }
            if (smsmsg.HasErrors)
            {
                smsmsg.Tables[SmsMsgData.SMS_MSG].GetErrors()[0].ClearErrors();
                return false;
            }
            smsmsg.AcceptChanges();
            return true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (this.dsCommand != null))
            {
                if (this.dsCommand.SelectCommand != null)
                {
                    if (this.dsCommand.SelectCommand.Connection != null)
                    {
                        this.dsCommand.SelectCommand.Connection.Dispose();
                    }
                    this.dsCommand.SelectCommand.Dispose();
                }
                this.dsCommand.Dispose();
                this.dsCommand = null;
            }
        }

        public SmsMsgData GetAllSmsData(string strCondition)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgData dataSet = new SmsMsgData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from  " + AppFlag.SMS_MSG_TABLE + "    " + strCondition + " order by CREATE_DATE desc";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public SmsMsgData GetAllSmsData()
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgData dataSet = new SmsMsgData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            //this.dsCommand.SelectCommand.CommandText = "SELECT distinct(CBATCHID) ,CSMSMSG, CMMSSUBJECT,CREATE_DATE FROM " + AppFlag.SMS_MSG_TABLE+" order by CREATE_DATE asc";
            this.dsCommand.SelectCommand.CommandText = "SELECT distinct(CBATCHID) ,CSMSMSG,CREATE_DATE FROM " + AppFlag.SMS_MSG_TABLE + " order by CREATE_DATE asc";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        private OleDbCommand GetDeleteCommand()
        {
            if (this.deleteCommand == null)
            {
                string cmdText = "DELETE FROM   " + AppFlag.SMS_MSG_TABLE + "   WHERE CBATCHID=? and  CSMSMSG=? and   CTYPE=? and   IPRIORITY =? and   CREATE_DATE=?   ";
                this.deleteCommand = new OleDbCommand(cmdText, new OleDbConnection(AppFlag.CENTASMSMAININTEConn ));
                this.deleteCommand.CommandType = CommandType.Text;
                OleDbParameterCollection parameters = this.deleteCommand.Parameters;
                parameters.Add(new OleDbParameter("@CBATCHID", OleDbType.VarChar, 10));
                parameters.Add(new OleDbParameter("@CSMSMSG", OleDbType.VarChar,4000));
                parameters.Add(new OleDbParameter("@CTYPE", OleDbType.VarChar, 1));
                parameters.Add(new OleDbParameter("@IPRIORITY", OleDbType.Integer));
                parameters.Add(new OleDbParameter("@CREATE_DATE", OleDbType.Date));
                parameters["@CBATCHID"].SourceColumn = "CBATCHID";
                parameters["@CSMSMSG"].SourceColumn = "CSMSMSG";
                parameters["@CTYPE"].SourceColumn = "CTYPE";
                parameters["@IPRIORITY"].SourceColumn = "IPRIORITY";
                parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
            }
            return this.deleteCommand;
        }

        private OleDbCommand GetInsertCommand()
        {
            if (this.insertCommand == null)
            {
                //string cmdText = "INSERT INTO   " + AppFlag.SMS_MSG_TABLE + "    ( CBATCHID ,  CSMSMSG ,CMMSSUBJECT,CMMSATTACH,  CTYPE ,  IPRIORITY  ,  CREATE_DATE ) VALUES (?,?,?,?,?,?,?)";
                string cmdText = "INSERT INTO   " + AppFlag.SMS_MSG_TABLE + "    ( CBATCHID ,  CSMSMSG ,  CTYPE ,  IPRIORITY  ,  CREATE_DATE ) VALUES (?,?,?,?,?)";
                this.insertCommand = new OleDbCommand(cmdText, new OleDbConnection(AppFlag.CENTASMSMAININTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                OleDbParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new OleDbParameter("@CBATCHID", OleDbType.VarChar, 10));
                parameters.Add(new OleDbParameter("@CSMSMSG", OleDbType.VarChar, 4000));
                //parameters.Add(new OleDbParameter("@CMMSSUBJECT", OleDbType.VarChar, 0x9c4));
                //parameters.Add(new OleDbParameter("@CMMSATTACH", OleDbType.VarChar, 0x9c4));
                parameters.Add(new OleDbParameter("@CTYPE", OleDbType.VarChar, 1));
                parameters.Add(new OleDbParameter("@IPRIORITY", OleDbType.Integer));
                parameters.Add(new OleDbParameter("@CREATE_DATE", OleDbType.Date));
                parameters["@CBATCHID"].SourceColumn = "CBATCHID";
                parameters["@CSMSMSG"].SourceColumn = "CSMSMSG";
                //parameters["@CMMSSUBJECT"].SourceColumn = "CMMSSUBJECT";
                //parameters["@CMMSATTACH"].SourceColumn = "CMMSATTACH";
                parameters["@CTYPE"].SourceColumn = "CTYPE";
                parameters["@IPRIORITY"].SourceColumn = "IPRIORITY";
                parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
            }
            return this.insertCommand;
        }

        private OleDbCommand GetLoadCommand()
        {
            if (this.loadCommand == null)
            {
                this.loadCommand = new OleDbCommand();
                this.loadCommand.Connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn);
                this.loadCommand.CommandType = CommandType.Text;
            }
            return this.loadCommand;
        }

        //public bool InsertSmsMsg(SmsMsgData smsmsg,bool insertMMS)
        //{
        //    if (insertMMS == false) return true;
        //    try
        //    {
        //        if (this.dsCommand == null)
        //        {
        //            throw new ObjectDisposedException(base.GetType().FullName);
        //        }
        //        this.dsCommand.InsertCommand = this.GetInsertCommand();
        //        this.dsCommand.Update(smsmsg, SmsMsgData.SMS_MSG);
        //    }
        //    catch (Exception exception)
        //    {
        //        string str = exception.ToString();
        //        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsMsgData  " + exception.ToString());
        //    }
        //    if (smsmsg.HasErrors)
        //    {
        //        smsmsg.Tables[SmsMsgData.SMS_MSG].GetErrors()[0].ClearErrors();
        //        return false;
        //    }
        //    smsmsg.AcceptChanges();
        //    return true;
        //}

        public bool InsertSmsMsg(SmsMsgData smsmsg)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.InsertCommand = this.GetInsertCommand();
                this.dsCommand.Update(smsmsg, SmsMsgData.SMS_MSG);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "   SmsMsgData  " + exception.ToString());
            }
            if (smsmsg.HasErrors)
            {
                smsmsg.Tables[SmsMsgData.SMS_MSG].GetErrors()[0].ClearErrors();
                return false;
            }
            smsmsg.AcceptChanges();
            return true;
        }

        public SmsMsgData LoadByIREC_NO(string irec_no)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgData dataSet = new SmsMsgData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from  " + AppFlag.SMS_MSG_TABLE + "  WHERE IREC_NO= '" + irec_no + "'  ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public int GetUnSendSmsCount(string id)
        {
            int count = -1;
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgData dataSet = new SmsMsgData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT count(*) from  " + AppFlag.SMS_MSG_RECEIVER_TABLE  + " where  CBATCHID='" + id + "'";
            this.dsCommand.Fill(dataSet);
            return ((int)dataSet.Tables [0].Rows[0][5]);
        }


        public bool DeleteMmsInfo(string id)
        {
            bool bResult = false;
            string deleteString = "";
            using (OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn))
            {
                deleteString = "delete from  "+AppFlag.SMS_MSG_TABLE +" where  CBATCHID='" + id + "'";
                OleDbCommand cmd = new OleDbCommand(deleteString, connection);
                connection.Open();
                cmd.ExecuteNonQuery(); 
                deleteString = "delete from  " + AppFlag.SMS_MSG_RECEIVER_TABLE  + " where  CBATCHID='" + id + "'";
                cmd.CommandText = deleteString;
                cmd.ExecuteNonQuery();
                bResult = true;
            }
            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss ") + " Execute sql:" + deleteString + "\r\n");
            return bResult;
        }

        public static int GetUnSendSms(string id)
        {
            int count = -1;
            string selectString = "";
            using (OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn))
            {
                selectString = "select count(*) from  " + AppFlag.SMS_MSG_TABLE + " where  CBATCHID='" + id + "'";
                OleDbCommand cmd = new OleDbCommand(selectString, connection);
                connection.Open();
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }
    }

    public class SmsMsgsAction
    {
        public const string CID_PARM = "@CID";
        public const string CMOBILENO_PARM = "@CMOBILENO";
        public const string CSMSACTION_PARM = "@CSMSACTION";
        public const string CSTATUS_PARM = "@CSTATUS";
        public const string CREATE_DATE_PARM = "@CREATE_DATE";  
        private FbCommand deleteCommand;
        private FbDataAdapter dsCommand = new FbDataAdapter();
        private FbCommand insertCommand; 
        private FbCommand loadCommand; 
        private FbCommand updateCommand;

        public SmsMsgsAction()
        {
            this.dsCommand.SelectCommand = new FbCommand();
            this.dsCommand.SelectCommand.Connection = new FbConnection(AppFlag.CENTASMSINTEConn);
            this.dsCommand.TableMappings.Add("Table", SmsMsgActionData.SMS_MSG_ACTION );
        }

        public bool CreateSmsMsgAction(string ID,ArrayList cmoblieno, ArrayList cmoblienoAction)
        {
            bool flag;
            SmsMsgActionData data = new SmsMsgActionData(); 
            DataTable table = new DataTable();
            for (int j = 0; j < cmoblieno.Count; j++)
            {
                table = data.Tables[SmsMsgActionData.SMS_MSG_ACTION];
                DataRow row = table.NewRow();
                row["CID"] = ID;// j + 1;
                row["CMOBILENO"] = cmoblieno[j].ToString().Trim();
                row["CSMSACTION"] = cmoblienoAction[j].ToString();
                row["CSTATUS"] = "0";
                row["CREATE_DATE"] =  DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");;
                if (cmoblieno[j].ToString() != "")
                {
                    table.Rows.Add(row);
                } 
            }
            if (new SmsMsgsAction().InsertSmsMsg(data) )
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
         
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (this.dsCommand != null))
            {
                if (this.dsCommand.SelectCommand != null)
                {
                    if (this.dsCommand.SelectCommand.Connection != null)
                    {
                        this.dsCommand.SelectCommand.Connection.Dispose();
                    }
                    this.dsCommand.SelectCommand.Dispose();
                }
                this.dsCommand.Dispose();
                this.dsCommand = null;
            }
        }

        public SmsMsgActionData GetAllSmsData(string strCondition)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgActionData dataSet = new SmsMsgActionData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from  " + SmsMsgActionData.SMS_MSG_ACTION  + "    " + strCondition + " order by CREATE_DATE desc";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public SmsMsgActionData GetAllSmsData()
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgActionData dataSet = new SmsMsgActionData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            //this.dsCommand.SelectCommand.CommandText = "SELECT distinct(CBATCHID) ,CSMSMSG, CMMSSUBJECT,CREATE_DATE FROM " + AppFlag.SMS_MSG_TABLE+" order by CREATE_DATE asc";
            this.dsCommand.SelectCommand.CommandText = "SELECT * FROM SMS_MSG_ACTION  order by CREATE_DATE asc";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        //private OleDbCommand GetDeleteCommand()
        //{
        //    if (this.deleteCommand == null)
        //    {
        //        string cmdText = "DELETE FROM   " + AppFlag.SMS_MSG_TABLE + "   WHERE CBATCHID=? and  CSMSMSG=? and   CTYPE=? and   IPRIORITY =? and   CREATE_DATE=?   ";
        //        this.deleteCommand = new OleDbCommand(cmdText, new OleDbConnection(AppFlag.CENTASMSMAININTEConn));
        //        this.deleteCommand.CommandType = CommandType.Text;
        //        OleDbParameterCollection parameters = this.deleteCommand.Parameters;
        //        parameters.Add(new OleDbParameter("@CBATCHID", OleDbType.VarChar, 10));
        //        parameters.Add(new OleDbParameter("@CSMSMSG", OleDbType.VarChar));
        //        parameters.Add(new OleDbParameter("@CTYPE", OleDbType.VarChar, 1));
        //        parameters.Add(new OleDbParameter("@IPRIORITY", OleDbType.Integer));
        //        parameters.Add(new OleDbParameter("@CREATE_DATE", OleDbType.Date));
        //        parameters["@CBATCHID"].SourceColumn = "CBATCHID";
        //        parameters["@CSMSMSG"].SourceColumn = "CSMSMSG";
        //        parameters["@CTYPE"].SourceColumn = "CTYPE";
        //        parameters["@IPRIORITY"].SourceColumn = "IPRIORITY";
        //        parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
        //    }
        //    return this.deleteCommand;
        //}

        private FbCommand GetInsertCommand()
        {
            if (this.insertCommand == null)
            {
                string cmdText = "INSERT INTO   SMS_MSG_ACTION    ( CID , CMOBILENO, CSMSACTION ,  CSTATUS   ,  CREATE_DATE ) VALUES (?,?,?,?,?)";
                this.insertCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new FbParameter("@CID", FbDbType.VarChar, 10));
                parameters.Add(new FbParameter("@CMOBILENO", FbDbType.VarChar, 15));
                parameters.Add(new FbParameter("@CSMSACTION", FbDbType.VarChar, 1000));
                parameters.Add(new FbParameter("@CSTATUS", FbDbType.VarChar, 1));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters["@CID"].SourceColumn = "CID";
                parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
                parameters["@CSMSACTION"].SourceColumn = "CSMSACTION";
                parameters["@CSTATUS"].SourceColumn = "CSTATUS"; 
                parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
            }
            return this.insertCommand;
        }

        private FbCommand GetLoadCommand()
        {
            if (this.loadCommand == null)
            {
                this.loadCommand = new FbCommand();
                this.loadCommand.Connection = new FbConnection(AppFlag.CENTASMSINTEConn);
                this.loadCommand.CommandType = CommandType.Text;
            }
            return this.loadCommand;
        }


        public bool InsertSmsMsg(SmsMsgActionData smsmsg)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.InsertCommand = this.GetInsertCommand();
                this.dsCommand.Update(smsmsg, SmsMsgActionData.SMS_MSG_ACTION );
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "   SmsMsgActionData  " + exception.ToString());
            }
            if (smsmsg.HasErrors)
            {
                smsmsg.Tables[SmsMsgActionData.SMS_MSG_ACTION ].GetErrors()[0].ClearErrors();
                return false;
            }
            smsmsg.AcceptChanges();
            return true;
        }

        public bool UpdateSchedule(SmsMsgActionData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.UpdateCommand = this.GetUpdateCommand();
                this.dsCommand.Update(data, "SMS_MSG_ACTION");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsMsgActionData  " + exception.ToString());
            }
            if (data.HasErrors)
            {
                data.Tables["SMS_MSG_ACTION"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
            return true;
        }
        private FbCommand GetUpdateCommand()
        {
            if (this.updateCommand == null)
            {
                string cmdText = "UPDATE   SMS_MSG_ACTION SET    CSTATUS =? where CID=?";
                this.updateCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.updateCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.updateCommand.Parameters;
                parameters.Add(new FbParameter("@CSTATUS", FbDbType.VarChar, 1));
                parameters.Add(new FbParameter("@CID_PARM", FbDbType.VarChar, 10));
                parameters["@CSTATUS"].SourceColumn = "CSTATUS";
                parameters["@OLDCID_PARM"].SourceColumn = "CID";
                parameters["@OLDCID_PARM"].SourceVersion = DataRowVersion.Original;
            }
            return this.updateCommand;
        }



        //public SmsMsgData LoadByIREC_NO(string irec_no)
        //{
        //    if (this.dsCommand == null)
        //    {
        //        throw new ObjectDisposedException(base.GetType().FullName);
        //    }
        //    SmsMsgData dataSet = new SmsMsgData();
        //    this.dsCommand.SelectCommand = this.GetLoadCommand();
        //    this.dsCommand.SelectCommand.CommandText = "SELECT * from  " + AppFlag.SMS_MSG_TABLE + "  WHERE IREC_NO= '" + irec_no + "'  ";
        //    this.dsCommand.Fill(dataSet);
        //    return dataSet;
        //}

    
        //public bool DeleteMmsInfo(string id)
        //{
        //    bool bResult = false;
        //    string deleteString = "";
        //    using (OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn))
        //    {
        //        deleteString = "delete from  " + AppFlag.SMS_MSG_TABLE + " where  CBATCHID='" + id + "'";
        //        OleDbCommand cmd = new OleDbCommand(deleteString, connection);
        //        connection.Open();
        //        cmd.ExecuteNonQuery();
        //        deleteString = "delete from  " + AppFlag.SMS_MSG_RECEIVER_TABLE + " where  CBATCHID='" + id + "'";
        //        cmd.CommandText = deleteString;
        //        cmd.ExecuteNonQuery();
        //        bResult = true;
        //    }
        //    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss ") + " Execute sql:" + deleteString + "\r\n");
        //    return bResult;
        //}

        //public static int GetUnSendSms(string id)
        //{
        //    int count = -1;
        //    string selectString = "";
        //    using (OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn))
        //    {
        //        selectString = "select count(*) from  " + AppFlag.SMS_MSG_TABLE + " where  CBATCHID='" + id + "'";
        //        OleDbCommand cmd = new OleDbCommand(selectString, connection);
        //        connection.Open();
        //        count = (int)cmd.ExecuteScalar();
        //    }
        //    return count;
        //}
    }
}

