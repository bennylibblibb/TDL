namespace CENTASMS
{
    using Anthem;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class InputSendByTime : Page
    {
        protected Anthem.Button btnSaveData;
        protected Sendload doload;
        protected SchSendload schsendload;
        protected int SendRefresh = AppFlag.SendRefresh;
        protected System.Web.UI.WebControls.TextBox tbScheduleDate;
        protected System.Web.UI.WebControls.TextBox tbTime;

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            string str = this.tbScheduleDate.Text.Trim() + " " + this.tbTime.Text.Trim();
            if (this.doload.State != 1)
            {
                this.schsendload.txtSmsContent = this.doload.txtSmsContent;
                this.schsendload.tbNum = this.doload.tbNum;
                this.schsendload.lbGroupIDContent = this.doload.lbGroupIDContent;
                this.schsendload.ilen = this.doload.ilen;
                this.schsendload.ipart = this.doload.ipart;
                this.schsendload.lbUser = this.Context.User.Identity.Name;
                this.schsendload.strScheduleDatetime = str;
                if (Convert.ToDateTime(str + ":00") > DateTime.Now.AddMinutes((double)AppFlag.CentaSmsSendTime))
                {
                    this.btnSaveData.Enabled = false;
                    string str2 = "sendonframe.window.location.reload();";
                    Manager.AddScriptForClientSideEval(str2);
                    this.schsendload.runload();
                }
                else
                {
                    this.Page.RegisterStartupScript("", "<script>alert('請正確輸入預設發送時間(提前" + AppFlag.CentaSmsSendTime + "分鐘!)');</script>");
                }
            }
        }

        private void InitializeComponent()
        {
            this.btnSaveData.Click += new EventHandler(this.btnSaveData_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                DateTime time = DateTime.Now.AddMinutes((double)(AppFlag.CentaSmsSendTime + 1));
                this.tbScheduleDate.Text = time.ToString("yyyy-MM-dd ");
                this.tbTime.Text = time.ToString("HH:mm");
                ((Anthem.Button)this.FindControl("btnSaveData")).Attributes.Add("onclick", "return confirm('確定預設發送短訊？');");
            }
            this.doload = new Sendload();
            if (this.Session["sendload"] != null)
            {
                this.doload = (Sendload)this.Session["sendload"];
            }
            if (this.Session["schsendload"] == null)
            {
                this.schsendload = new SchSendload();
                this.Session["schsendload"] = this.schsendload;
            }
            else
            {
                this.schsendload = (SchSendload)this.Session["schsendload"];
            }
            switch (this.schsendload.State)
            {
                case 1:
                    this.btnSaveData.Enabled = false;
                    this.tbScheduleDate.Text = this.schsendload.strScheduleDatetime.Substring(0, 10);
                    this.tbTime.Text = this.schsendload.strScheduleDatetime.Substring(11, 5);
                    break;

                case 2:
                    this.btnSaveData.Enabled = false;
                    this.tbScheduleDate.Text = this.schsendload.strScheduleDatetime.Substring(0, 10);
                    this.tbTime.Text = this.schsendload.strScheduleDatetime.Substring(11, 5);
                    this.Session["schsendload"] = null;
                    break;

                case 3:
                    this.btnSaveData.Enabled = false;
                    this.Session["schsendload"] = null;
                    break;
            }
        }
    }
}

