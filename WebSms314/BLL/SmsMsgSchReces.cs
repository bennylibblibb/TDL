namespace CENTASMS.BLL
{
    using CENTASMS;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using FirebirdSql.Data.FirebirdClient;

    public class SmsMsgSchReces
    {
        public const string CBATCHID_PARM = "@CBATCHID";
        public const string CGROUP_NAME_PARM = "@CGROUP_NAME";
        public const string CMOBILENO_PARM = "@CMOBILENO";
        private FbDataAdapter dsCommand = new FbDataAdapter();
        private FbCommand insertCommand;
        public const string IPRIORITY_PARM = "@IPRIORITY";
        public const string IREC_NO_PARM = "@IREC_NO";
        private FbCommand loadCommand;

        public SmsMsgSchReces()
        {
            this.dsCommand.SelectCommand = new FbCommand();
            this.dsCommand.SelectCommand.Connection = new FbConnection(AppFlag.CENTASMSINTEConn);
            this.dsCommand.TableMappings.Add("Table", "SMS_MSGRCV_SCH");
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

        public SmsMsgSchReceData GetAllSmsSchReceData(string strCondition)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgSchReceData dataSet = new SmsMsgSchReceData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSGRCV_SCH   " + strCondition + " order by IREC_NO asc";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        private FbCommand GetInsertCommand()
        {
            if (this.insertCommand == null)
            {
                string cmdText = " INSERT INTO  SMS_MSGRCV_SCH  ( IREC_NO ,  CBATCHID ,  CMOBILENO ,CGROUP_NAME,  IPRIORITY   ) VALUES (?,?,?,?,?) ";
                this.insertCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new FbParameter("@IREC_NO", FbDbType.Integer));
                parameters.Add(new FbParameter("@CBATCHID", FbDbType.VarChar, 10));
                parameters.Add(new FbParameter("@CMOBILENO", FbDbType.VarChar,15));
                parameters.Add(new FbParameter("@CGROUP_NAME", FbDbType.VarChar, 30));
                parameters.Add(new FbParameter("@IPRIORITY", FbDbType.Integer));
                parameters["@IREC_NO"].SourceColumn = "IREC_NO";
                parameters["@CBATCHID"].SourceColumn = "CBATCHID";
                parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
                parameters["@CGROUP_NAME"].SourceColumn = "CGROUP_NAME";
                parameters["@IPRIORITY"].SourceColumn = "IPRIORITY";
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

        public int GetNewIrec_No()
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgSchReceData dataSet = new SmsMsgSchReceData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "select  max(IREC_NO) IREC_NO from SMS_MSGRCV_SCH order by IREC_NO desc";
            this.dsCommand.Fill(dataSet);
            if (dataSet.Tables["SMS_MSGRCV_SCH"].Rows[0][0] == DBNull.Value)
            {
                return 1;
            }
            return (Convert.ToInt32(dataSet.Tables["SMS_MSGRCV_SCH"].Rows[0][0]) + 1);
        }

        public bool InsertSmsMsgSchRece(SmsMsgSchReceData smsmsg)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.InsertCommand = this.GetInsertCommand();
                this.dsCommand.Update(smsmsg, "SMS_MSGRCV_SCH");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsMsgSchReceData   " + exception.ToString());
            }
            if (smsmsg.HasErrors)
            {
                smsmsg.Tables["SMS_MSGRCV_SCH"].GetErrors()[0].ClearErrors();
                return false;
            }
            smsmsg.AcceptChanges();
            return true;
        }

        public SmsMsgSchReceData LoadMsgReceDataByIREC_NO(string irec_no)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgSchReceData dataSet = new SmsMsgSchReceData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSGRCV_SCH    WHERE IREC_NO= '" + irec_no + "'  ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }
    }
}

