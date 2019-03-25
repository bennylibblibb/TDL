namespace CENTASMS.DAL
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;

    public class SmsMsgSchReceData : DataSet
    {
        public const string CBATCHID = "CBATCHID";
        public const string CGROUP_NAME = "CGROUP_NAME";
        public const string CMOBILENO = "CMOBILENO";
        public const string IPRIORITY = "IPRIORITY";
        public const string IREC_NO = "IREC_NO";
        public const string SMS_MSGRCV_SCH = "SMS_MSGRCV_SCH";

        public SmsMsgSchReceData()
        {
            this.BuildDataTables();
        }

        private SmsMsgSchReceData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private void BuildDataTables()
        {
            DataTable table = new DataTable("SMS_MSGRCV_SCH");
            DataColumnCollection columns = table.Columns;
            columns.Add("IREC_NO", typeof(int));
            columns.Add("CBATCHID", typeof(string));
            columns.Add("CMOBILENO", typeof(string));
            columns.Add("CGROUP_NAME", typeof(string));
            columns.Add("IPRIORITY", typeof(int));
            base.Tables.Add(table);
        }
    }
}

