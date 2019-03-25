namespace CENTASMS.DAL
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;

    public class SmsSchContentData : DataSet
    {
        public const string CREATE_DATE = "CREATE_DATE";
        public const string CSENDER = "CSENDER";
        public const string CTITLE = "CTITLE";
        public const string CSMSMSG = "CSMSMSG";
        public const string ID = "ID";
        public const string IMSGLEN = "IMSGLEN";
        public const string ISMSMSGNO = "ISMSMSGNO";
        public const string SMS_MSGSCH_CONTENT = "SMS_MSGSCH_CONTENT";
        public const string STATUS = "STATUS";

        public SmsSchContentData()
        {
            this.BuildDataTables();
        }

        private SmsSchContentData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private void BuildDataTables()
        {
            DataTable table = new DataTable("SMS_MSGSCH_CONTENT");
            DataColumnCollection columns = table.Columns;
            columns.Add("ID", typeof(int));
            columns.Add("STATUS", typeof(string));
            columns.Add("CTITLE", typeof(string));
            columns.Add("CSMSMSG", typeof(string));
            columns.Add("IMSGLEN", typeof(int));
            columns.Add("ISMSMSGNO", typeof(int));
            columns.Add("CSENDER", typeof(string));
            columns.Add("CREATE_DATE", typeof(DateTime));
            base.Tables.Add(table);
        }
    }
}

