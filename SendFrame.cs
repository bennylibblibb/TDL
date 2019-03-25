namespace CENTASMS
{
    using Anthem;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class SendFrame : Page
    {
        protected Sendload doload;
        protected System.Web.UI.WebControls.Image imgLoad;
        protected Anthem. Label lbMsg;
        protected SchSendload schsendload;
        protected int SendRefresh = AppFlag.SendRefresh;

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
            this.doload = new Sendload();
            if (this.Session["sendload"] != null)
            {
                this.doload = (Sendload) this.Session["sendload"];
            }
            if (this.Session["schsendload"] == null)
            {
                this.schsendload = new SchSendload();
                this.Session["schsendload"] = this.schsendload;
            }
            else
            {
                this.schsendload = (SchSendload) this.Session["schsendload"];
            }
            switch (this.schsendload.State)
            {
                case 0:
                    this.imgLoad.Visible = false;
                    this.lbMsg.Text = "";
                    break;

                case 1:
                {
                    this.imgLoad.Visible = true;
                    TimeSpan span = (TimeSpan) (DateTime.Now - this.schsendload.StartTime);
                    this.lbMsg.Text = "Sec.: " + span.TotalSeconds.ToString("0") + "s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                    this.Page.RegisterStartupScript("", " <script language='javascript'>window.setTimeout(\"location.href=location.href\"," + AppFlag.SendRefresh + ");</script>");
                    break;
                }
                case 2:
                {
                    this.imgLoad.Visible = false;
                    string[] strArray = new string[5];
                    strArray[0] = "Sec.: ";
                    TimeSpan span2 = (TimeSpan) (this.schsendload.FinishTime - this.schsendload.StartTime);
                    strArray[1] = span2.TotalSeconds.ToString("0");
                    strArray[2] = "s&nbsp;&nbsp;";
                    strArray[3] = this.schsendload.lbMsg;
                    strArray[4] = " ";
                    this.lbMsg.Text = string.Concat(strArray);
                    this.Session["schsendload"] = null;
                    break;
                }
                case 3:
                    this.imgLoad.Visible = false;
                    this.lbMsg.Text = this.schsendload.lbMsg;
                    this.Session["schsendload"] = null;
                    break;
            }
        }
    }
}

