namespace CENTASMS.DAL
{
    using System;
    using System.Data;
    using System.Runtime.Serialization;

    public class GroupData : DataSet
    {
        public const string CGROUP_ID = "CGROUP_ID";
        public const string CGROUP_NAME = "CGROUP_NAME";
        public const string CGROUP_OWNER = "CGROUP_OWNER";
        public const string CGROUP_PWD = "CGROUP_PWD";
        public const string CGROUP_TYPE = "CGROUP_TYPE";
        public const string CREATE_DATE = "CREATE_DATE";
        public const string CREATE_COUNT = "CREATE_COUNT";
        public const string GROUP_INFO = "GROUP_INFO";

        public GroupData()
        {
            this.BuildDataTables();
        }

        private GroupData(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private void BuildDataTables()
        {
            DataTable table = new DataTable("GROUP_INFO");
            DataColumnCollection columns = table.Columns;
            columns.Add("CGROUP_ID", typeof(string));
            columns.Add("CGROUP_NAME", typeof(string));
            columns.Add("CGROUP_OWNER", typeof(string));
            columns.Add("CGROUP_TYPE", typeof(string));
            columns.Add("CGROUP_PWD", typeof(string));
            columns.Add("CREATE_DATE", typeof(DateTime));
            columns.Add("CREATE_COUNT", typeof(int));
            base.Tables.Add(table);
        }
    }
}

