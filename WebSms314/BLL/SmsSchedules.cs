namespace CENTASMS.BLL
{
    using CENTASMS;
    using CENTASMS.DAL;
    using System;
    using System.Collections;
    using System.Data;
    using FirebirdSql.Data.FirebirdClient;
    using System.Runtime.InteropServices;
    using System.Text;

    public class SmsSchedules
    {
        public const string CBATCHID_PARM = "@CBATCHID";
        public const string CREATE_DATE_PARM = "@CREATE_DATE";
        public const string CSEND_DATE_PARM = "@CSEND_DATE";
        public const string CSENDER_PARM = "@CSENDER";
        private FbDataAdapter dsCommand = new FbDataAdapter();
        private FbCommand insertCommand;
        private FbCommand loadCommand;
        public const string STATUS_PARM = "@STATUS";
        private FbCommand updateCommand;

        public SmsSchedules()
        {
            this.dsCommand.SelectCommand = new FbCommand();
            this.dsCommand.SelectCommand.Connection = new FbConnection(AppFlag.CENTASMSINTEConn);
            this.dsCommand.TableMappings.Add("Table", "SMS_SCHEDULE");
        }

        public bool CreateSmsScheduleMsg(
                    string csender,
                    string send_date,
                    string create_date,
                    String status,
                    String csmsmsg,
                    String ctype,
                    int ipriority,
            //string[] cmoblieno,
                    ArrayList cmoblieno,
                    int imsglen,
                    int ismsmsgno,
                    int imobiletotal,
                    out string m_CBATCHID
                    )
        {
            bool insertrece = false;
            DataTable table = new DataTable();
            m_CBATCHID = GetNewBatchid();

            //SMS_SCHEDULE
            SmsScheduleData sms_msgscheduledata = new SmsScheduleData();
            table = sms_msgscheduledata.Tables[SmsScheduleData.SMS_SCHEDULE];
            DataRow row = table.NewRow();
            row[SmsScheduleData.CBATCHID] = m_CBATCHID;
            row[SmsScheduleData.CSENDER] = csender;
            row[SmsScheduleData.CSEND_DATE] = send_date;
            row[SmsScheduleData.CREATE_DATE] = create_date;
            row[SmsScheduleData.STATUS] = status;
            table.Rows.Add(row);

            if ((new SmsSchedules()).InsertSmsScheduleMsg(sms_msgscheduledata))
            {
                //SMS_MSG_SCH
                ArrayList mobile = new ArrayList();
                ArrayList group = new ArrayList();
                for (int i = 0; i < cmoblieno.Count; i++)
                {
                    string strnum = cmoblieno[i].ToString();
                    string mobileno = "";
                    string groupname = "";
                    int isign = strnum.IndexOf("[");
                    if (isign > -1)
                    {
                        mobileno = strnum.Substring(0, isign);
                        groupname = strnum.Substring(isign + 1, strnum.IndexOf("]") - isign - 1).Replace("(私人組別)", "").Replace("(共享組別)", "");
                        //if (!mobile.Contains(mobileno))
                        //{
                        //    mobile.Add(mobileno);
                        //    group.Add(groupname);
                        //}
                        if (AppFlag.DuplicateSending)
                        {
                            mobile.Add(mobileno);
                            group.Add(groupname);
                        }
                        else
                        {
                            if (!mobile.Contains(mobileno))
                            {
                                mobile.Add(mobileno);
                                group.Add(groupname);
                            }
                        }
                    }
                    else
                    {
                        mobileno = strnum;
                        groupname = "";
                        //if (!mobile.Contains(mobileno))
                        //{
                        //    mobile.Add(mobileno);
                        //    group.Add(groupname);
                        //}
                        if (AppFlag.DuplicateSending)
                        {
                            mobile.Add(mobileno);
                            group.Add(groupname);
                        }
                        else
                        {
                            if (!mobile.Contains(mobileno))
                            {
                                mobile.Add(mobileno);
                                group.Add(groupname);
                            }
                        }
                    }
                }
                SmsMsgSchData sms_msgschdata = new SmsMsgSchData();
                table = sms_msgschdata.Tables[SmsMsgSchData.SMS_MSG_SCH];
                row = table.NewRow();
                row[SmsMsgSchData.CBATCHID] = m_CBATCHID;
              //  row[SmsMsgSchData.CSMSMSG] = csmsmsg;
              //  row[SmsMsgSchData.CSMSMSG] = BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(csmsmsg)).Replace("-", "");
                row[SmsMsgSchData.CSMSMSG] = ("%" + BitConverter.ToString(Encoding.UTF8.GetBytes(csmsmsg))).Replace("-", "%"); row[SmsMsgSchData.CTYPE] = ctype;
                row[SmsMsgSchData.IPRIORITY] = ipriority;
                row[SmsMsgSchData.CREATE_DATE] = create_date;

                row[SmsMsgSchData.CSENDER] = csender;
                row[SmsMsgSchData.IMSGLEN] = imsglen;
                row[SmsMsgSchData.ISMSMSGNO] = ismsmsgno;
                row[SmsMsgSchData.IMOBILETOTAL] = mobile.Count;
                table.Rows.Add(row);

                if ((new SmsMsgSchs()).InsertSmsMsgSch(sms_msgschdata))
                {
                    //					ArrayList mobile = new ArrayList();
                    //					ArrayList group = new ArrayList();
                    //					for (int i = 0; i < cmoblieno.Count; i++)
                    //					{
                    //						string strnum=cmoblieno[i].ToString();
                    //						string mobileno="";
                    //						string groupname="";
                    //						int isign=strnum .IndexOf("[");
                    //						if(isign>-1)
                    //						{   
                    //							mobileno=strnum .Substring(0,isign) ;
                    //							groupname=strnum .Substring(isign+1,strnum .IndexOf("]")-isign-1).Replace("(私人組別)", "").Replace("(共享組別)", "") ;
                    //							if (!mobile.Contains(mobileno))
                    //							{
                    //								mobile.Add(mobileno);group.Add(groupname);
                    //							}
                    //						}
                    //						else
                    //						{
                    //							mobileno=strnum;
                    //							groupname="";
                    //							if (!mobile.Contains(mobileno))
                    //							{
                    //								mobile.Add(mobileno);group.Add(groupname);
                    //							}
                    //						}
                    //					}

                    //  int irec_no = new SmsMsgSchReces().GetNewIrec_No();// 20/04/2010 irec_no 
                    //int irec_no = new SmsMsgReceHists().GetNewIrec_No(); // irec_no, increase by degrees
                    int irec_no = 1; // cbatchid and irec_no , 1 start
                    SmsMsgSchReceData sms_msgschrecedata = new SmsMsgSchReceData();
                    //for (int i = 0; i < cmoblieno.Count; i++)
                    for (int i = 0; i < mobile.Count; i++)
                    {
                        //SMS_MSGRCV_SCH
                        //						string strnum=cmoblieno[i].ToString();
                        //						string mobileno="";
                        //						string groupname="";
                        //						int isign=strnum .IndexOf("[");
                        //						if(isign>-1)
                        //						{   
                        //							mobileno=strnum .Substring(0,isign) ;
                        //							groupname=strnum .Substring(isign+1,strnum .IndexOf("]")-isign-1).Replace("(私人組別)", "").Replace("(共享組別)", "") ;
                        //						}
                        //						else
                        //						{
                        //							mobileno=strnum;
                        //							groupname="";
                        //						}

                        //SmsMsgSchReceData sms_msgschrecedata = new SmsMsgSchReceData();
                        table = sms_msgschrecedata.Tables[SmsMsgSchReceData.SMS_MSGRCV_SCH];
                        row = table.NewRow();
                        row[SmsMsgSchReceData.IREC_NO] = irec_no;
                        row[SmsMsgSchReceData.CBATCHID] = m_CBATCHID;
                        row[SmsMsgSchReceData.CMOBILENO] = mobile[i].ToString();
                        row[SmsMsgSchReceData.CGROUP_NAME] = group[i].ToString() + "            " + "            " + "      ";
                        row[SmsMsgSchReceData.IPRIORITY] = ipriority;
                        //	if (cmoblieno[i].ToString().Trim() != "") table.Rows.Add(row);
                        if (mobile[i].ToString().Trim() != "") table.Rows.Add(row);
                        irec_no++;
                        //						if (!(new SmsMsgSchReces().InsertSmsMsgSchRece(sms_msgschrecedata)))
                        //						{
                        //							insertrece = false;
                        //							break;
                        //						}
                        //						else
                        //						{
                        //							insertrece = true;
                        //						}
                    }
                    if (!(new SmsMsgSchReces().InsertSmsMsgSchRece(sms_msgschrecedata)))
                    {
                        insertrece = false;
                        //	break;
                    }
                    else
                    {
                        insertrece = true;
                    }
                }
                if (!insertrece)
                {
                    string delid = m_CBATCHID;
                    //del inserted msg receiver by   (no receiver)
                }
            }

            if (!insertrece)
            {
                string delid = m_CBATCHID;
                //del inserted SMS_SCHEDULE and  SMS_MSGRCV_SCH  by   (no msg)
            }
            return insertrece;
        }
        //public bool CreateSmsScheduleMsg(string csender, string send_date, string create_date, string status, string csmsmsg,string cMmsSubject,string cMmsAttach,  string ctype, int ipriority, ArrayList cmoblieno, int imsglen, int ismsmsgno, int imobiletotal, out string m_CBATCHID)
        //{
        //    bool flag = false;
        //    DataTable table = new DataTable();
        //    m_CBATCHID = this.GetNewBatchid();
        //    SmsScheduleData smsmsg = new SmsScheduleData();
        //    table = smsmsg.Tables["SMS_SCHEDULE"];
        //    DataRow row = table.NewRow();
        //    row["CBATCHID"] = m_CBATCHID;
        //    row["CSENDER"] = csender;
        //    row["CSEND_DATE"] = send_date;
        //    row["CREATE_DATE"] = create_date;
        //    row["STATUS"] = status;
        //    table.Rows.Add(row);
        //    if (new SmsSchedules().InsertSmsScheduleMsg(smsmsg))
        //    {
        //        ArrayList list = new ArrayList();
        //        ArrayList list2 = new ArrayList();
        //        bool bInsertMMS = false;
        //        for (int i = 0; i < cmoblieno.Count; i++)
        //        {
        //            string str = cmoblieno[i].ToString();
        //            //string item = "";
        //            //string str3 = ""; 
        //            string num = "";
        //            string group = "";
        //            int length = str.IndexOf("[");
        //            if (length > -1)
        //            {
        //                //item = str.Substring(0, index);
        //                //str3 = str.Substring(index + 1, (str.IndexOf("]") - index) - 1).Replace("(私人組別)", "").Replace("(共享組別)", "");
        //                num = str.Substring(0, length) + str.Substring(str.IndexOf(","), str.ToString().Length - str.ToString().IndexOf(","));
        //                group = str.Substring(length + 1, (str.IndexOf("]") - length) - 1).Replace("(私人組別)", "").Replace("(共享組別)", "");

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
        //            else
        //            {
        //                num = str;
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
        //        SmsMsgSchData data2 = new SmsMsgSchData();
        //        table = data2.Tables["SMS_MSG_SCH"];
        //        row = table.NewRow();
        //        row["CBATCHID"] = m_CBATCHID;
        //        row["CSMSMSG"] = csmsmsg;// BitConverter.ToString(Encoding.Unicode.GetBytes(csmsmsg + " "));
        //        row["CMMSSUBJECT"] = cMmsSubject; //BitConverter.ToString(Encoding.Unicode.GetBytes(cMmsSubject + " "));
        //        row["CMMSATTACH"] = cMmsAttach;
        //        row["CTYPE"] = ctype;
        //        row["IPRIORITY"] = (bInsertMMS == true)? 0:-1; //ipriority;
        //        row["CREATE_DATE"] = create_date;
        //        row["CSENDER"] = csender;
        //        row["IMSGLEN"] = imsglen;
        //        row["ISMSMSGNO"] = ismsmsgno;
        //        row["IMOBILETOTAL"] = list.Count;
        //        table.Rows.Add(row);
        //        if (new SmsMsgSchs().InsertSmsMsgSch(data2))
        //        {
        //            int num3 = 1;
        //            SmsMsgSchReceData data3 = new SmsMsgSchReceData();
        //            for (int j = 0; j < list.Count; j++)
        //            {
        //                string no = list[j].ToString().Substring(0, list[j].ToString().IndexOf(",")) + "                        ";
        //                int priority = Convert.ToInt32(list[j].ToString().Substring(list[j].ToString().IndexOf(",") + 1, list[j].ToString().Length - list[j].ToString().IndexOf(",") - 1));
                        

        //                table = data3.Tables["SMS_MSGRCV_SCH"];
        //                row = table.NewRow();
        //                row["IREC_NO"] = num3;
        //                row["CBATCHID"] = m_CBATCHID;
        //                row["CMOBILENO"] = no;// list[j].ToString() + "                        ";
        //                row["CGROUP_NAME"] = list2[j].ToString() + "                              ";
        //                row["IPRIORITY"] = priority; // ipriority;
        //                if (list[j].ToString().Trim() != "")
        //                {
        //                    table.Rows.Add(row);
        //                }
        //                num3++;
        //            }
        //            if (!new SmsMsgSchReces().InsertSmsMsgSchRece(data3))
        //            {
        //                flag = false;
        //            }
        //            else
        //            {
        //                flag = true;
        //            }
        //        }
        //        if (!flag)
        //        {
        //            string str4 = m_CBATCHID;
        //        }
        //    }
        //    if (!flag)
        //    {
        //        string str5 = m_CBATCHID;
        //    }
        //    return flag;
        //}

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

        public SmsScheduleData GetAllSmsScheduleData(string strCondition)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsScheduleData dataSet = new SmsScheduleData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_SCHEDULE   " + strCondition + " order by CREATE_DATE desc";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        private static string GetIDNO(string strno)
        {
            while (strno.Length < 8)
            {
                strno = "0" + strno;
            }
            return strno;
        }

        private FbCommand GetInsertCommand()
        {
            if (this.insertCommand == null)
            {
                string cmdText = "INSERT INTO  SMS_SCHEDULE  ( CBATCHID ,  CSENDER ,  CSEND_DATE   ,  CREATE_DATE,STATUS ) VALUES (?,?,?,?,?)";
                this.insertCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new FbParameter("@CBATCHID", FbDbType.VarChar, 10));
                parameters.Add(new FbParameter("@CSENDER", FbDbType.VarChar, 15));
                parameters.Add(new FbParameter("@CSEND_DATE", FbDbType.Date));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters.Add(new FbParameter("@STATUS", FbDbType.VarChar));
                parameters["@CBATCHID"].SourceColumn = "CBATCHID";
                parameters["@CSENDER"].SourceColumn = "CSENDER";
                parameters["@CSEND_DATE"].SourceColumn = "CSEND_DATE";
                parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
                parameters["@STATUS"].SourceColumn = "STATUS";
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

        public string GetNewBatchid()
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsScheduleData dataSet = new SmsScheduleData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "select  max(CBATCHID) CBATCHID from SMS_SCHEDULE WHERE  CBATCHID like 'S%' order by CBATCHID desc";
            this.dsCommand.Fill(dataSet);
            if (dataSet.Tables["SMS_SCHEDULE"].Rows[0][0] == DBNull.Value)
            {
                return ("S" + AppFlag.WEBSITELABEL + "00000001");
            }
            int num = Convert.ToInt32(dataSet.Tables["SMS_SCHEDULE"].Rows[0][0].ToString().Trim().Substring(2, 8)) + 1;
            return (dataSet.Tables["SMS_SCHEDULE"].Rows[0][0].ToString().Trim().Substring(0, 2) + GetIDNO(num.ToString()));
        }

        public string GetSchSmsStatusbyBatchid(string batchid)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsScheduleData dataSet = new SmsScheduleData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "select  * from SMS_SCHEDULE where CBATCHID='" + batchid + "'";
            this.dsCommand.Fill(dataSet);
            return dataSet.Tables["SMS_SCHEDULE"].Rows[0]["STATUS"].ToString().Trim();
        }

        private FbCommand GetUpdateCommand()
        {
            if (this.updateCommand == null)
            {
                string cmdText = "UPDATE   SMS_SCHEDULE SET   CBATCHID=?  , CSENDER=?, CSEND_DATE=?, CREATE_DATE=?,STATUS=? where CBATCHID=?";
                this.updateCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.updateCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.updateCommand.Parameters;
                parameters.Add(new FbParameter("@CBATCHID", FbDbType.VarChar, 10));
                parameters.Add(new FbParameter("@CSENDER", FbDbType.VarChar, 15));
                parameters.Add(new FbParameter("@CSEND_DATE", FbDbType.Date));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters.Add(new FbParameter("@STATUS", FbDbType.VarChar, 1));
                parameters.Add(new FbParameter("@OLDCBATCHID_PARM", FbDbType.VarChar, 10));
                parameters["@CBATCHID"].SourceColumn = "CBATCHID";
                parameters["@CSENDER"].SourceColumn = "CSENDER";
                parameters["@CSEND_DATE"].SourceColumn = "CSEND_DATE";
                parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
                parameters["@STATUS"].SourceColumn = "STATUS";
                parameters["@OLDCBATCHID_PARM"].SourceColumn = "CBATCHID";
                parameters["@OLDCBATCHID_PARM"].SourceVersion = DataRowVersion.Original;
            }
            return this.updateCommand;
        }

        public bool InsertSmsScheduleMsg(SmsScheduleData smsmsg)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.InsertCommand = this.GetInsertCommand();
                this.dsCommand.Update(smsmsg, "SMS_SCHEDULE");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsMsgSchData   " + exception.ToString());
            }
            if (smsmsg.HasErrors)
            {
                smsmsg.Tables["SMS_SCHEDULE"].GetErrors()[0].ClearErrors();
                return false;
            }
            smsmsg.AcceptChanges();
            return true;
        }

        public SmsScheduleData LoadGroupByName(string CBATCHID)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsScheduleData dataSet = new SmsScheduleData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_SCHEDULE    WHERE CBATCHID= '" + CBATCHID + "' ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public bool UpdateSchedule(SmsScheduleData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.UpdateCommand = this.GetUpdateCommand();
                this.dsCommand.Update(data, "SMS_SCHEDULE");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsScheduleData  " + exception.ToString());
            }
            if (data.HasErrors)
            {
                data.Tables["SMS_SCHEDULE"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
            return true;
        }
    }
}

