namespace CENTASMS.BLL
{
    using CENTASMS;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using FirebirdSql.Data.FirebirdClient;

    public class SmsSchContents : IDisposable
    {
        public const string CREATE_DATE_PARM = "@CREATE_DATE";
        public const string CSENDER_PARM = "@CSENDER";
        public const string CTITLE_PARM = "@CTITLE";
        public const string CSMSMSG_PARM = "@CSMSMSG";
        private FbCommand deleteCommand;
        private FbDataAdapter dsCommand = new FbDataAdapter();
        public const string ID_PARM = "@ID";
        public const string IMSGLEN_PARM = "@IMSGLEN";
        private FbCommand insertCommand;
        public const string ISMSMSGNO_PARM = "@ISMSMSGNO";
        private FbCommand loadCommand;
        public const string STATUS_PARM = "@STATUS";
        private FbCommand updateCommand;

        public SmsSchContents()
        {
            this.dsCommand.SelectCommand = new FbCommand();
            this.dsCommand.SelectCommand.Connection = new FbConnection(AppFlag.CENTASMSINTEConn);
            this.dsCommand.TableMappings.Add("Table", "SMS_MSGSCH_CONTENT");
        }

        public bool DeleteSmsSchContent(SmsSchContentData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.DeleteCommand = this.GetDeleteCommand();
                this.dsCommand.Update(data, "SMS_MSGSCH_CONTENT");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsSchContentData  " + exception.ToString());
            }
            if (data.HasErrors)
            {
                data.Tables["SMS_MSGSCH_CONTENT"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
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

        private FbCommand GetDeleteCommand()
        {
            if (this.deleteCommand == null)
            {
                string cmdText = "DELETE FROM  SMS_MSGSCH_CONTENT   where ID=? ";
                this.deleteCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.deleteCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.deleteCommand.Parameters;
                parameters.Add(new FbParameter("@ID", FbDbType.Integer));
                parameters["@ID"].SourceColumn = "ID";
                parameters["@ID"].SourceVersion = DataRowVersion.Original;
            }
            return this.deleteCommand;
        }

        private FbCommand GetInsertCommand()
        {
            if (this.insertCommand == null)
            {
                string cmdText = "INSERT INTO  SMS_MSGSCH_CONTENT  (STATUS,CTITLE,CSMSMSG,IMSGLEN,ISMSMSGNO,CSENDER,CREATE_DATE ) VALUES (?,?,?,?,?,?,?)";
                this.insertCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new FbParameter("@STATUS", FbDbType.VarChar, 10));
                parameters.Add(new FbParameter("@CTITLE", FbDbType.VarChar, 1000));
                parameters.Add(new FbParameter("@CSMSMSG", FbDbType.VarChar));
                parameters.Add(new FbParameter("@IMSGLEN", FbDbType.Integer));
                parameters.Add(new FbParameter("@ISMSMSGNO", FbDbType.Integer));
                parameters.Add(new FbParameter("@CSENDER", FbDbType.VarChar, 0x18));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters["@STATUS"].SourceColumn = "STATUS";
                parameters["@CTITLE"].SourceColumn = "CTITLE";
                parameters["@CSMSMSG"].SourceColumn = "CSMSMSG";
                parameters["@IMSGLEN"].SourceColumn = "IMSGLEN";
                parameters["@ISMSMSGNO"].SourceColumn = "ISMSMSGNO";
                parameters["@CSENDER"].SourceColumn = "CSENDER";
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

        private FbCommand GetUpdateCommand()
        {
            if (this.updateCommand == null)
            {
                string cmdText = "UPDATE   SMS_MSGSCH_CONTENT SET   STATUS=?  , CTITLE=? , CSMSMSG=? , IMSGLEN=?, ISMSMSGNO=? ,CREATE_DATE=? where ID=?";
                this.updateCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.updateCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.updateCommand.Parameters;
                parameters.Add(new FbParameter("@STATUS", FbDbType.VarChar, 10));
                parameters.Add(new FbParameter("@CTITLE", FbDbType.VarChar, 1000));
                parameters.Add(new FbParameter("@CSMSMSG", FbDbType.VarChar));
                parameters.Add(new FbParameter("@IMSGLEN", FbDbType.Integer));
                parameters.Add(new FbParameter("@ISMSMSGNO", FbDbType.Integer));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters.Add(new FbParameter("@ID", FbDbType.Integer));
                parameters["@STATUS"].SourceColumn = "STATUS";
                parameters["@CTITLE"].SourceColumn = "CTITLE";
                parameters["@CSMSMSG"].SourceColumn = "CSMSMSG";
                parameters["@IMSGLEN"].SourceColumn = "IMSGLEN";
                parameters["@ISMSMSGNO"].SourceColumn = "ISMSMSGNO";
                parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
                parameters["@ID"].SourceColumn = "ID";
            }
            return this.updateCommand;
        }

        public bool InsertSmsSchContent(SmsSchContentData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.InsertCommand = this.GetInsertCommand();
                this.dsCommand.Update(data, "SMS_MSGSCH_CONTENT");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsSchContentData  " + exception.ToString());
            }
            if (data.HasErrors)
            {
                data.Tables["SMS_MSGSCH_CONTENT"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
            return true;
        }

        public SmsSchContentData LoadActionByCondition(string starttime)
        {
            SmsSchContentData dataSet = new SmsSchContentData();
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.SelectCommand = this.GetLoadCommand();
                this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSGSCH_CONTENT    WHERE ACTION_STARTTIME= '" + starttime + "'";
                this.dsCommand.Fill(dataSet);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsSchContentData.LoadActionByCondition  " + exception.ToString());
                return dataSet;
            }
            return dataSet;
        }

        public SmsSchContentData LoadActionByConditionIrecno(int irecno)
        {
            SmsSchContentData dataSet = new SmsSchContentData();
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.SelectCommand = this.GetLoadCommand();
                this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSGSCH_CONTENT    WHERE ISMS_IREC_NO= " + irecno.ToString();
                this.dsCommand.Fill(dataSet);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsSchContentData.LoadActionByConditionIrecno  " + exception.ToString());
                return dataSet;
            }
            return dataSet;
        }

        public SmsSchContentData LoadAllSchData()
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsSchContentData dataSet = new SmsSchContentData();
            try
            {
                this.dsCommand.SelectCommand = this.GetLoadCommand();
                this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSGSCH_CONTENT order by create_date  desc ";
                this.dsCommand.Fill(dataSet);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsSchContentData.LoadActionByCondition  " + exception.ToString());
            }
            finally
            {
                if (this.dsCommand.SelectCommand.Connection.State == ConnectionState.Open)
                {
                    this.dsCommand.SelectCommand.Connection.Close();
                }
            }
            return dataSet;
        }

        public SmsSchContentData LoadSchDataByStatusAndSender(string strsender)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsSchContentData dataSet = new SmsSchContentData();
            try
            {
                this.dsCommand.SelectCommand = this.GetLoadCommand();
                this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSGSCH_CONTENT  where status ='Normal' and csender ='" + strsender + "' order by create_date  desc ";
                this.dsCommand.Fill(dataSet);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsSchContentData.LoadActionByCondition  " + exception.ToString());
            }
            finally
            {
                if (this.dsCommand.SelectCommand.Connection.State == ConnectionState.Open)
                {
                    this.dsCommand.SelectCommand.Connection.Close();
                }
            }
            return dataSet;
        }

        public SmsSchContentData LoadSmsSchContentByID(string id)
        {
            SmsSchContentData dataSet = new SmsSchContentData();
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.SelectCommand = this.GetLoadCommand();
                this.dsCommand.SelectCommand.CommandText = "select * from SMS_MSGSCH_CONTENT where ID=" + id;
                this.dsCommand.Fill(dataSet);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsSchContentData.LoadActionByCondition  " + exception.ToString());
                return dataSet;
            }
            return dataSet;
        }

        public bool UpdateSmsSchContent(SmsSchContentData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.UpdateCommand = this.GetUpdateCommand();
                this.dsCommand.Update(data, "SMS_MSGSCH_CONTENT");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsSchContentData  " + exception.ToString());
            }
            if (data.HasErrors)
            {
                data.Tables["SMS_MSGSCH_CONTENT"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
            return true;
        }
    }
}

