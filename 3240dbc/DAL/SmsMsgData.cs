namespace CENTASMS.DAL
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;

    public class SmsMsgData : DataSet
    {
        public const string CBATCHID = "CBATCHID";
        public const string CREATE_DATE = "CREATE_DATE";
        public const string CSMSMSG = "CSMSMSG";
        //public const string CMMSSUBJECT = "CMMSSUBJECT";
        //public const string CMMSATTACH = "CMMSATTACH";
        public const string CTYPE = "CTYPE";
        public const string IPRIORITY = "IPRIORITY";
        public static string SMS_MSG = AppFlag.SMS_MSG_TABLE;

        public SmsMsgData()
        {
            this.BuildDataTables();
        }

        private SmsMsgData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private void BuildDataTables()
        {
            DataTable table = new DataTable(SMS_MSG);
            DataColumnCollection columns = table.Columns;
            columns.Add("CBATCHID", typeof(string));
            columns.Add("CSMSMSG", typeof(string));
            //columns.Add("CMMSSUBJECT", typeof(string));
            //columns.Add("CMMSATTACH", typeof(string));
            columns.Add("CTYPE", typeof(string));
            columns.Add("IPRIORITY", typeof(int));
            columns.Add("CREATE_DATE", typeof(DateTime));
            base.Tables.Add(table);
        }
    }


    public class SmsMsgActionData : DataSet
    {
        public const string CID = "CID";
        public const string CMOBILENO = "CMOBILENO";
        public const string CSMSACTION = "CSMSACTION";
        public const string CSTATUS = "CSTATUS";
        public const string CREATE_DATE = "CREATE_DATE";
        public static string SMS_MSG_ACTION = "SMS_MSG_ACTION";

        public SmsMsgActionData()
        {
            this.BuildDataTables();
        }

        private SmsMsgActionData(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        private void BuildDataTables()
        {
            DataTable table = new DataTable(SMS_MSG_ACTION);
            DataColumnCollection columns = table.Columns;
            columns.Add("CID", typeof(string));
            columns.Add("CMOBILENO", typeof(string));
            columns.Add("CSMSACTION", typeof(string));
            columns.Add("CSTATUS", typeof(string));
            columns.Add("CREATE_DATE", typeof(DateTime));
            base.Tables.Add(table);
        }
    }
}

