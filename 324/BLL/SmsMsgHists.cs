namespace CENTASMS.BLL
{
    using CENTASMS;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using FirebirdSql.Data.FirebirdClient;

    public class SmsMsgHists
    {
        public const string CALLER_PARM = "@CALLER";
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

        public SmsMsgHists()
        {
            this.dsCommand.SelectCommand = new FbCommand();
            this.dsCommand.SelectCommand.Connection = new FbConnection(AppFlag.CENTASMSINTEConn);
            this.dsCommand.TableMappings.Add("Table", "SMS_MSG_HIST");
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

        public SmsMsgHistData GetAllSmsHistData(string strCondition)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgHistData dataSet = new SmsMsgHistData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSG_HIST   " + strCondition + " order by CREATE_DATE desc";
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
                string cmdText = "INSERT INTO  SMS_MSG_HIST  ( CBATCHID ,  CSMSMSG  ,  CTYPE ,  IPRIORITY  ,  CREATE_DATE,CSENDER,CALLER,IMSGLEN,ISMSMSGNO,IMOBILETOTAL ) VALUES (?,?,?,?,?,?,?,?,?,?)";
               
               // string cmdText = "INSERT INTO  SMS_MSG_HIST  ( CBATCHID ,  CSMSMSG  ,CMMSSUBJECT,CMMSATTACH,  CTYPE ,  IPRIORITY  ,  CREATE_DATE,CSENDER,CALLER,IMSGLEN,ISMSMSGNO,IMOBILETOTAL ) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)";
                this.insertCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new FbParameter("@CBATCHID", FbDbType.VarChar, 10));
                parameters.Add(new FbParameter("@CSMSMSG", FbDbType.VarChar, 6120));
                //parameters.Add(new FbParameter("@CMMSSUBJECT", FbDbType.VarChar, 0x9c4));
                //parameters.Add(new FbParameter("@CMMSATTACH", FbDbType.VarChar, 0x9c4));
                parameters.Add(new FbParameter("@CTYPE", FbDbType.VarChar, 1));
                parameters.Add(new FbParameter("@IPRIORITY", FbDbType.Integer ));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters.Add(new FbParameter("@CSENDER", FbDbType.VarChar, 15));
                parameters.Add(new FbParameter("@CALLER", FbDbType.VarChar, 15));
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
                parameters["@CALLER"].SourceColumn = "CALLER";
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

        public string GetNewBatchid()
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgHistData dataSet = new SmsMsgHistData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "select  max(CBATCHID) CBATCHID from SMS_MSG_HIST where CBATCHID   like 'B%' order by CBATCHID desc";
            this.dsCommand.Fill(dataSet);
            if (dataSet.Tables["SMS_MSG_HIST"].Rows[0][0] == DBNull.Value)
            {
                return ("B" + AppFlag.WEBSITELABEL + "00000001");
            }
            int num = Convert.ToInt32(dataSet.Tables["SMS_MSG_HIST"].Rows[0][0].ToString().Trim().Substring(2, 8)) + 1;
            return (dataSet.Tables["SMS_MSG_HIST"].Rows[0][0].ToString().Trim().Substring(0, 2) + GetIDNO(num.ToString()));
        }

        public SmsMsgHistData GetSmsDatabyBatchid(string batchid)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgHistData dataSet = new SmsMsgHistData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "select  * from SMS_MSG_HIST where CBATCHID='" + batchid + "'";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public bool InsertSmsMsgHist(SmsMsgHistData smsmsg)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.InsertCommand = this.GetInsertCommand();
                this.dsCommand.Update(smsmsg, "SMS_MSG_HIST");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SmsMsgHistData  " + exception.ToString());
            }
            if (smsmsg.HasErrors)
            {
                smsmsg.Tables["SMS_MSG_HIST"].GetErrors()[0].ClearErrors();
                return false;
            }
            smsmsg.AcceptChanges();
            return true;
        }

        public SmsMsgHistData LoadByIREC_NO(string irec_no)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgHistData dataSet = new SmsMsgHistData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSG_HIST    WHERE IREC_NO= '" + irec_no + "'  ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public SmsMsgHistData LoadSmsHisDataBy(string strCondition)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgHistData dataSet = new SmsMsgHistData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from SMS_MSG_HIST    WHERE  " + strCondition;
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }
    }
}

