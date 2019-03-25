namespace CENTASMS.BLL
{
    using CENTASMS;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    //using FirebirdSql.Data.FirebirdClient;
   // using System.Data.OleDb;
   // using System.Data.OleDb ;
    using System.Data.Odbc; 

    public class SmsMsgReces
    {
        public const string CBATCHID_PARM = "@CBATCHID";
        public const string CMOBILENO_PARM = "@CMOBILENO";
       // private OdbcDataAdapter dsCommand = new OdbcDataAdapter();
       // private OdbcCommand insertCommand;
        public const string IPRIORITY_PARM = "@IPRIORITY";
        public const string IREC_NO_PARM = "@IREC_NO";
      //  private OdbcCommand loadCommand;

        private OdbcDataAdapter dsCommand = new OdbcDataAdapter();
        private OdbcCommand insertCommand;
        private OdbcCommand loadCommand;


        public SmsMsgReces()
        {
            this.dsCommand.SelectCommand = new OdbcCommand();
            this.dsCommand.SelectCommand.Connection = new OdbcConnection(AppFlag.CENTASMSMAININTEConn);
             this.dsCommand.SelectCommand.CommandTimeout = 60 * 2;
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

        private OdbcCommand GetInsertCommand()
        {
            if (this.insertCommand == null)
            {
                string cmdText = " INSERT INTO   " + AppFlag.SMS_MSG_RECEIVER_TABLE + "    ( IREC_NO ,  CBATCHID ,  CMOBILENO ,  IPRIORITY   ) VALUES (?,?,?,?) ";
                this.insertCommand = new OdbcCommand(cmdText, new OdbcConnection(AppFlag.CENTASMSMAININTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                this.insertCommand.CommandTimeout = 60*2;
                OdbcParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new OdbcParameter("@IREC_NO", OdbcType.Int));
                parameters.Add(new OdbcParameter("@CBATCHID", OdbcType.VarChar, 10));
                parameters.Add(new OdbcParameter("@CMOBILENO", OdbcType.VarChar,15));
                parameters.Add(new OdbcParameter("@IPRIORITY", OdbcType.Int));
                parameters["@IREC_NO"].SourceColumn = "IREC_NO";
                parameters["@CBATCHID"].SourceColumn = "CBATCHID";
                parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
                parameters["@IPRIORITY"].SourceColumn = "IPRIORITY";
            }
            return this.insertCommand;
        }

        private OdbcCommand GetLoadCommand()
        {
            if (this.loadCommand == null)
            {
                this.loadCommand = new OdbcCommand();
                this.loadCommand.Connection = new OdbcConnection(AppFlag.CENTASMSMAININTEConn);
                this.loadCommand.CommandTimeout = 60 * 2;
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

