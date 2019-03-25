namespace CENTASMS.DAL
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;

    public class SmsMsgHistData : DataSet
    {
        public const string CALLER = "CALLER";
        public const string CBATCHID = "CBATCHID";
        public const string CREATE_DATE = "CREATE_DATE";
        public const string CSENDER = "CSENDER";
        public const string CSMSMSG = "CSMSMSG";
        //public const string CMMSSUBJECT = "CMMSSUBJECT";
        //public const string CMMSATTACH = "CMMSATTACH";
        public const string CTYPE = "CTYPE";
        public const string IMOBILETOTAL = "IMOBILETOTAL";
        public const string IMSGLEN = "IMSGLEN";
        public const string IPRIORITY = "IPRIORITY";
        public const string ISMSMSGNO = "ISMSMSGNO";
        public const string CountData = "UnSendCount";
        public const string SMS_MSG_HIST = "SMS_MSG_HIST";

        public SmsMsgHistData()
        {
            this.BuildDataTables();
        }

        private SmsMsgHistData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private void BuildDataTables()
        {
            DataTable table = new DataTable("SMS_MSG_HIST");
            DataColumnCollection columns = table.Columns;
            columns.Add("CBATCHID", typeof(string));
            columns.Add("CSMSMSG", typeof(string));
            //columns.Add("CMMSSUBJECT", typeof(string));
            //columns.Add("CMMSATTACH", typeof(string));
            columns.Add("CTYPE", typeof(string));
            columns.Add("IPRIORITY", typeof(int));
            columns.Add("CREATE_DATE", typeof(DateTime));
            columns.Add("CSENDER", typeof(string));
            columns.Add("CALLER", typeof(string));
            columns.Add("IMSGLEN", typeof(int));
            columns.Add("ISMSMSGNO", typeof(int));
            columns.Add("IMOBILETOTAL", typeof(int));
            columns.Add("UnSendCount", typeof(string));
            base.Tables.Add(table);
        }
    }
}

