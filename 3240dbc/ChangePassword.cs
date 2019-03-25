namespace CENTASMS
{
    using Anthem;
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using System.Web.UI.WebControls;

    public class ChangePassword : CommonPage
    {
        protected System.Web.UI.WebControls.CompareValidator cvPW;
        protected System.Web.UI.WebControls.Label lbConfirm;
        protected Anthem.Label lbMsg;
        protected System.Web.UI.WebControls.Label lbpw;
        protected System.Web.UI.WebControls.Label lbUser;
        protected Anthem.Panel plSendMsg;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvPW;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvPW2;
        protected Anthem.Button Save;
        protected System.Web.UI.WebControls.TextBox txtPW;
        protected System.Web.UI.WebControls.TextBox txtPW2;
        protected System.Web.UI.HtmlControls.HtmlInputButton btnCannel;

        protected override void InitializeCulture()
        {
            var languageCookie = Session["LanguageEn"];

            if (languageCookie != null)
            {
                Page.UICulture = languageCookie.ToString();
            }
            else
            {
                Session["LanguageEn"] = "zh-HK";
                Page.UICulture = "zh-HK";
            }

            base.InitializeCulture();
        }
        
        private void InitializeComponent()
        {
            this.Save.Click += new EventHandler(this.Save_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.IsAuthenticated && !this.Page.IsPostBack)
            {
                this.lbUser.Text = this.Context.User.Identity.Name;

                this.btnCannel.Value = (Session["LanguageEn"] == "en-US") ? "Reset" : "重置";
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            UserData userdata = new UserData();
            userdata = new Users().LoadUserByUSER_ID(this.Context.User.Identity.Name.Trim().ToUpper());
            DataRow row = userdata.Tables[0].Rows[0];
            string str = row["USER_PWD"].ToString();
            row["USER_PWD"] = this.txtPW.Text.Trim();
            row["CREATE_DATE"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (new Users().UpdateUser(userdata))
            {
                this.lbMsg.Text = (Session["LanguageEn"] == "en-US") ? "Update success！" : "更新密碼成功";// "更新密碼成功!";
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss ") + this.Context.User.Identity.Name.Trim().ToUpper() + " 更新密碼 " + str + " to " + this.txtPW.Text.Trim() + ".\r\n");
            }
            else
            {
                this.lbMsg.Text = (Session["LanguageEn"] == "en-US") ? "Update failed！" : "更新密碼失敗";// "更新密碼失敗!";
            }
            this.lbMsg.UpdateAfterCallBack = true;
        }
    }
}

