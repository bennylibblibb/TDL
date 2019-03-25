namespace CENTASMS.BLL
{
    using CENTASMS;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using FirebirdSql.Data.FirebirdClient;

    public class SmsMsgSchs
    {
        public const string CBATCHID_PARM = "@CBATCHID";
        public const string CREATE_DATE_PARM = "@CREATE_DATE";
        public const string CSENDER_PARM = "@CSENDER";
        public const string CSMSMSG_PARM = "@CSMSMSG";
        //public const string CCMMSSUBJECT_PARM = "@CMMSSUBJECT";
        //public const string CCMMSATTACH_PARM = "@CMMSATTACH";
        public const string CTYPE_PARM = "@CTYPE";
        private FbDataAdapter dsCommand = new FbDataAdapter();
        public const string IMOBILETOTAL_PARM = "@IMOBILETOTAL";
        public const string IMSGLEN_PARM = "@IMSGLEN";
        private FbCommand insertCommand;
        public const string IPRIORITY_PARM = "@IPRIORITY";
        public const string ISMSMSGNO_PARM = "@ISMSMSGNO";
        private FbCommand loadCommand;
        private FbCommand updateCommand;

        public SmsMsgSchs()
        {
            this.dsCommand.SelectCommand = new FbCommand();
            this.dsCommand.SelectCommand.Connection = new FbConnection(AppFlag.CENTASMSINTEConn);
            this.dsCommand.TableMappings.Add("Table", "SMS_MSG_SCH");
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

        public SmsMsgSchData GetAllSmsSchData(string strCondition)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgSchData dataSet = new SmsMsgSchData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSG_SCH   " + strCondition + " order by CREATE_DATE desc";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        private FbCommand GetInsertCommand()
        {
            if (this.insertCommand == null)
            {
                //string cmdText = "INSERT INTO  SMS_MSG_SCH  ( CBATCHID ,  CSMSMSG  ,CMMSSUBJECT,CMMSATTACH,  CTYPE ,  IPRIORITY  ,  CREATE_DATE,CSENDER,IMSGLEN,ISMSMSGNO,IMOBILETOTAL  ) VALUES (?,?,?,?,?,?,?,?,?,?,?)";
                string cmdText = "INSERT INTO  SMS_MSG_SCH  ( CBATCHID ,  CSMSMSG  ,  CTYPE ,  IPRIORITY  ,  CREATE_DATE,CSENDER,IMSGLEN,ISMSMSGNO,IMOBILETOTAL  ) VALUES (?,?,?,?,?,?,?,?,?)";
                this.insertCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new FbParameter("@CBATCHID", FbDbType.VarChar, 10));
                parameters.Add(new FbParameter("@CSMSMSG", FbDbType.VarChar, 6120));
                //parameters.Add(new FbParameter("@CMMSSUBJECT", FbDbType.VarChar, 0x9c4));
                //parameters.Add(new FbParameter("@CMMSATTACH", FbDbType.VarChar, 0x9c4));
                parameters.Add(new FbParameter("@CTYPE", FbDbType.VarChar, 1));
                parameters.Add(new FbParameter("@IPRIORITY", FbDbType.Integer));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters.Add(new FbParameter("@CSENDER", FbDbType.VarChar, 15));
                parameters.Add(new FbParameter("@IMSGLEN", FbDbType.Integer));
                parameters.Add(new FbParameter("@ISMSMSGNO", FbDbType.Integer));
                parameters.Add(new FbParameter("@IMOBILETOTAL", FbDbType.Integer));
                parameters["@CBATCHID"].SourceColumn = "CBATCHID";
                parameters["@CSMSMSG"].SourceColumn = "CSMSMSG";
                //parameters["@CMMSSUBJECT"].SourceColumn = "CMMSSUBJECT";
                //parameters["@CMMSATTACH"].SourceColumn = "CMMSATTACH";
                parameters["@CTYPE"].SourceColumn = "CTYPE";
                parameters["@IPRIORITY"].SourceColumn = "IPRIORITY";
                parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
                parameters["@CSENDER"].SourceColumn = "CSENDER";
                parameters["@IMSGLEN"].SourceColumn = "IMSGLEN";
                parameters["@ISMSMSGNO"].SourceColumn = "ISMSMSGNO";
                parameters["@IMOBILETOTAL"].SourceColumn = "IMOBILETOTAL";
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

        public SmsMsgSchData GetSchSmsDatabyBatchid(string batchid)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgSchData dataSet = new SmsMsgSchData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "select  * from SMS_MSG_SCH where CBATCHID='" + batchid + "'";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        private FbCommand GetUpdateCommand()
        {
            if (this.updateCommand == null)
            {
                string cmdText = "UPDATE   SMS_MSG_SCH SET    CSMSMSG =?,IMSGLEN=?,ISMSMSGNO=? where CBATCHID=?";
                this.updateCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.updateCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.updateCommand.Parameters;
                parameters.Add(new FbParameter("@CSMSMSG", FbDbType.VarChar, 6120));
                parameters.Add(new FbParameter("@IMSGLEN", FbDbType.Integer));
                parameters.Add(new FbParameter("@ISMSMSGNO", FbDbType.Integer));
                parameters.Add(new FbParameter("@OLDCBATCHID_PARM", FbDbType.VarChar, 10));
                parameters["@CSMSMSG"].SourceColumn = "CSMSMSG";
                parameters["@IMSGLEN"].SourceColumn = "IMSGLEN";
                parameters["@ISMSMSGNO"].SourceColumn = "ISMSMSGNO";
                parameters["@OLDCBATCHID_PARM"].SourceColumn = "CBATCHID";
                parameters["@OLDCBATCHID_PARM"].SourceVersion = DataRowVersion.Original;
            }
            return this.updateCommand;
        }

        public bool InsertSmsMsgSch(SmsMsgSchData smsmsg)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.InsertCommand = this.GetInsertCommand();
                this.dsCommand.Update(smsmsg, "SMS_MSG_SCH");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsMsgSchData  " + exception.ToString());
            }
            if (smsmsg.HasErrors)
            {
                smsmsg.Tables["SMS_MSG_SCH"].GetErrors()[0].ClearErrors();
                return false;
            }
            smsmsg.AcceptChanges();
            return true;
        }

        public SmsMsgSchData LoadByIREC_NO(string irec_no)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgSchData dataSet = new SmsMsgSchData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSG_SCH    WHERE IREC_NO= '" + irec_no + "'  ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public bool UpdateSchedule(SmsMsgSchData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.UpdateCommand = this.GetUpdateCommand();
                this.dsCommand.Update(data, "SMS_MSG_SCH");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsMsgSchData  " + exception.ToString());
            }
            if (data.HasErrors)
            {
                data.Tables["SMS_MSG_SCH"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
            return true;
        }

        public void DeletelSmsSchData(string id)
        {
            FbCommand command = new FbCommand();
            FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn);
            string str = "Delete error:";
            try
            {
                command.Connection = connection;
                connection.Open();
                str = "DELETE FROM SMS_SCHEDULE WHERE CBATCHID='" + id + "'";
                command.CommandText = str;
                command.ExecuteNonQuery();
                str = "DELETE FROM   SMS_MSG_SCH   WHERE CBATCHID='" + id + "'";
                command.CommandText = str;
                command.ExecuteNonQuery();
                str = "DELETE FROM   SMS_MSGRCV_SCH   WHERE CBATCHID='" + id + "'";
                command.CommandText = str;
                command.ExecuteNonQuery();
                connection.Close();
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  Callback(DELETE SCHEDULE)   " + id + " ");
            }
            catch (FbException exception)
            {
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  DeletelSmsSchData Callback   " + str + " " + exception.ToString());
            }
        }

    }
}

