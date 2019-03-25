namespace CENTASMS.DAL
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;

    public class SmsMsgReceData : DataSet
    {
        public const string CBATCHID = "CBATCHID";
        public const string CMOBILENO = "CMOBILENO";
        public const string IPRIORITY = "IPRIORITY";
        public const string IREC_NO = "IREC_NO";
        public static string SMS_MSG_RECEIVER = AppFlag.SMS_MSG_RECEIVER_TABLE;

        public SmsMsgReceData()
        {
            this.BuildDataTables();
        }

        private SmsMsgReceData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private void BuildDataTables()
        {
            DataTable table = new DataTable(SMS_MSG_RECEIVER);
            DataColumnCollection columns = table.Columns;
            columns.Add("IREC_NO", typeof(int));
            columns.Add("CBATCHID", typeof(string));
            columns.Add("CMOBILENO", typeof(string));
            columns.Add("IPRIORITY", typeof(int));
            base.Tables.Add(table);
        }
    }
}

