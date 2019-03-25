namespace CENTASMS.DAL
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;

    public class SmsScheduleData : DataSet
    {
        public const string CBATCHID = "CBATCHID";
        public const string CREATE_DATE = "CREATE_DATE";
        public const string CSEND_DATE = "CSEND_DATE";
        public const string CSENDER = "CSENDER";
        public const string SMS_SCHEDULE = "SMS_SCHEDULE";
        public const string STATUS = "STATUS";

        public SmsScheduleData()
        {
            this.BuildDataTables();
        }

        private SmsScheduleData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private void BuildDataTables()
        {
            DataTable table = new DataTable("SMS_SCHEDULE");
            DataColumnCollection columns = table.Columns;
            columns.Add("CBATCHID", typeof(string));
            columns.Add("CSENDER", typeof(string));
            columns.Add("CSEND_DATE", typeof(DateTime));
            columns.Add("CREATE_DATE", typeof(DateTime));
            columns.Add("STATUS", typeof(string));
            base.Tables.Add(table);
        }
    }
}

