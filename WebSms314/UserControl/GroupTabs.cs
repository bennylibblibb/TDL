namespace CENTASMS.UserControl
{
    using Anthem;
    using CENTASMS;
    using CENTASMS.BLL;
    using System;
    using System.Collections;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class GroupTabs : UserControl
    {
        protected  Anthem.DataList tabs;

        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (Users.UserAdminCheck(this.Context.User.Identity.Name))
            {
                int num = (base.Request["csIndex"] == null) ? 0 : Convert.ToInt32(base.Request["csIndex"]);
                ArrayList list = new ArrayList();
                list.Add(new TabItem("私人組別", string.Concat(new object[] { Global.GetApplicationPath(base.Request), "/GroupAdmin.aspx?csindex=", num, "&sIndex=", list.Count })));
                if (Users.UserAdminCheck(this.Context.User.Identity.Name) || Users.UserShareGroup(this.Context.User.Identity.Name))
                {
                    list.Add(new TabItem("共享組別", string.Concat(new object[] { Global.GetApplicationPath(base.Request), "/GroupAdmin.aspx?csindex=", num, "&sIndex=", list.Count })));
                }
                else
                {
                    list.Add(new TabItem("", ""));
                }
                if (Users.UserAdminCheck(this.Context.User.Identity.Name))
                {
                    list.Add(new TabItem("共享組別許可權", string.Concat(new object[] { Global.GetApplicationPath(base.Request), "/GroupAdmin.aspx?csindex=", num, "&sIndex=", list.Count })));
                }
                else
                {
                    list.Add(new TabItem("", ""));
                }
                list.Add(new TabItem("組別號碼列表", string.Concat(new object[] { Global.GetApplicationPath(base.Request), "/GroupAdmin.aspx?csindex=", num, "&sIndex=", list.Count })));
                list.Add(new TabItem("組別上傳", string.Concat(new object[] { Global.GetApplicationPath(base.Request), "/GroupAdmin.aspx?csindex=", num, "&sIndex=", list.Count })));
                list.Add(new TabItem("添加聯絡人", string.Concat(new object[] { Global.GetApplicationPath(base.Request), "/GroupAdmin.aspx?csindex=", num, "&sIndex=", list.Count })));
                this.tabs.DataSource = list;
                this.tabs.SelectedIndex = (base.Request["sIndex"] == null) ? 0 : Convert.ToInt32(base.Request["sIndex"]);
                this.tabs.DataBind();
            }
        }

        private void tabs_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) && ((((e.Item.ItemIndex == 2) && !Users.UserAdminCheck(this.Context.User.Identity.Name)) || ((e.Item.ItemIndex == 1) && !Users.UserAdminCheck(this.Context.User.Identity.Name))) || ((e.Item.ItemIndex == 1) && !Users.UserShareGroup(this.Context.User.Identity.Name))))
            {
              //  e.Item.Width = 0;
            }
        }
    }
}

