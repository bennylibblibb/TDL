namespace CENTASMS.DAL
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;

    public class GroupMemberData : DataSet
    {
        public const string CGROUP_ID = "CGROUP_ID";
        public const string CMEMBER_NAME = "CMEMBER_NAME";
        public const string CMOBILENO = "CMOBILENO";
        public const string CREATE_DATE = "CREATE_DATE";
        public const string GROUP_MEMBER = "GROUP_MEMBER";
        public const string IITEM_NO = "IITEM_NO";

        public GroupMemberData()
        {
            this.BuildDataTables();
        }

        private GroupMemberData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private void BuildDataTables()
        {
            DataTable table = new DataTable("GROUP_MEMBER");
            DataColumnCollection columns = table.Columns;
            columns.Add("IITEM_NO", typeof(int));
            columns.Add("CGROUP_ID", typeof(string));
            columns.Add("CMEMBER_NAME", typeof(string));
            columns.Add("CMOBILENO", typeof(string));
            columns.Add("CREATE_DATE", typeof(DateTime));
            base.Tables.Add(table);
        }
    }
}

