namespace CENTASMS.UserControl
{
    using Anthem;
    using CENTASMS;
    using System;
    using System.Collections;
    using System.Web.UI;
    using CENTASMS.BLL;

    public class SendTabs : UserControl
    {
        protected DataList tabs;

        private void InitializeComponent()
        {
            this.tabs.Load += new EventHandler(this.Page_Load);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            int num = (base.Request["csIndex"] == null) ? 0 : Convert.ToInt32(base.Request["csIndex"]);
            if ((!Users.UserAgentCheck(this.Context.User.Identity.Name.ToUpper())) && (!Users.UserBulkAgentCheck(this.Context.User.Identity.Name.ToUpper())))
            // if (Users.UserCheck(this.Context.User.Identity.Name.ToUpper()))
            {
                list.Add(new TabItem("群發短訊", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
                list.Add(new TabItem("即時發送記錄", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
                list.Add(new TabItem("預設發送記錄", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
                list.Add(new TabItem("落CALL記錄", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
                if (AppFlag.BulkFunction ==true)
                {
                    list.Add(new TabItem("上載發送", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
                }
                if (AppFlag.AccountActionUrl != "")
                {
                    list.Add(new TabItem("Account Action",string.Concat(new object[] {"SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count})));
                }
                if (AppFlag.AgentFunction == true)
                {
                    list.Add(new TabItem("SMS Agent", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
                    list.Add(new TabItem("Bulk Upload", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
                }
            }
            //else
            //{
            //    list.Add(new TabItem("SMS Agent", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
            //}
            // if (Users.UserCheck(this.Context.User.Identity.Name.ToUpper()))
            //{
            //    list.Add(new TabItem("預設發送記錄", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
            //    list.Add(new TabItem("落CALL記錄", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
            //    list.Add(new TabItem("上載發送", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
            //    list.Add(new TabItem("Account Action", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
            //}
            //else
            //{
            //    list.Add(new TabItem("", ""));
            //    list.Add(new TabItem("", ""));
            //    list.Add(new TabItem("", ""));
            //    list.Add(new TabItem("", ""));
            //}
            if (Users.UserAgentCheck(this.Context.User.Identity.Name.ToUpper()) && AppFlag.AgentFunction == true)
            {
                list.Add(new TabItem("SMS Agent", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
                list.Add(new TabItem("即時發送記錄", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
            }
            if (Users.UserBulkAgentCheck(this.Context.User.Identity.Name.ToUpper()) && AppFlag.AgentFunction == true)
            {
                list.Add(new TabItem("Bulk Upload", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
                list.Add(new TabItem("即時發送記錄", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
            }
            if ((!Users.UserAgentCheck(this.Context.User.Identity.Name.ToUpper())) && (!Users.UserBulkAgentCheck(this.Context.User.Identity.Name.ToUpper())))
            {
                if (AppFlag.DefineMessage)
                {
                    list.Add(new TabItem("定義預設短訊內容", string.Concat(new object[] { "SendByGroup.aspx?csindex=", num, "&sIndex=", list.Count })));
                }
            }
            //else
            //{
            //    list.Add(new TabItem("", ""));
            //}
            this.tabs.DataSource = list;
            this.tabs.SelectedIndex = (base.Request["sIndex"] == null) ? 0 : Convert.ToInt32(base.Request["sIndex"]);
            this.tabs.DataBind();
        }
    }
}

