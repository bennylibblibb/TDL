namespace CENTASMS.BLL
{
    using CENTASMS;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    //using FirebirdSql.Data.FirebirdClient;
   // using System.Data.OleDb;
    using System.Data.OleDb ;

    public class SmsMsgReces
    {
        public const string CBATCHID_PARM = "@CBATCHID";
        public const string CMOBILENO_PARM = "@CMOBILENO";
        private OleDbDataAdapter dsCommand = new OleDbDataAdapter();
        private OleDbCommand insertCommand;
        public const string IPRIORITY_PARM = "@IPRIORITY";
        public const string IREC_NO_PARM = "@IREC_NO";
        private OleDbCommand loadCommand;

        public SmsMsgReces()
        {
            this.dsCommand.SelectCommand = new OleDbCommand();
            this.dsCommand.SelectCommand.Connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn);
            this.dsCommand.TableMappings.Add("Table", SmsMsgReceData.SMS_MSG_RECEIVER);
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

        private OleDbCommand GetInsertCommand()
        {
            if (this.insertCommand == null)
            {
                string cmdText = " INSERT INTO   " + AppFlag.SMS_MSG_RECEIVER_TABLE + "    ( IREC_NO ,  CBATCHID ,  CMOBILENO ,  IPRIORITY   ) VALUES (?,?,?,?) ";
                this.insertCommand = new OleDbCommand(cmdText, new OleDbConnection(AppFlag.CENTASMSMAININTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                OleDbParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new OleDbParameter("@IREC_NO", OleDbType.Integer));
                parameters.Add(new OleDbParameter("@CBATCHID", OleDbType.VarChar, 10));
                parameters.Add(new OleDbParameter("@CMOBILENO", OleDbType.VarChar,15));
                parameters.Add(new OleDbParameter("@IPRIORITY", OleDbType.Integer));
                parameters["@IREC_NO"].SourceColumn = "IREC_NO";
                parameters["@CBATCHID"].SourceColumn = "CBATCHID";
                parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
                parameters["@IPRIORITY"].SourceColumn = "IPRIORITY";
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

        public bool InsertSmsMsgRece(SmsMsgReceData smsmsg)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.InsertCommand = this.GetInsertCommand();
                this.dsCommand.Update(smsmsg, SmsMsgReceData.SMS_MSG_RECEIVER);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsMsgReceData  " + exception.ToString());
            }
            if (smsmsg.HasErrors)
            {
                smsmsg.Tables[SmsMsgReceData.SMS_MSG_RECEIVER].GetErrors()[0].ClearErrors();
                return false;
            }
            smsmsg.AcceptChanges();
            return true;
        }
    }
}

