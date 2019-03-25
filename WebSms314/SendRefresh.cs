namespace CENTASMS
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class SendRefresh : Page
    {
        protected Image imgLoad;
        protected Label lab_state;

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
            if (base.Request.IsAuthenticated)
            {
                Sendload sendload = new Sendload();
                if (this.Session["sendload"] != null)
                {
                    sendload = (Sendload) this.Session["sendload"];
                }
                switch (sendload.State)
                {
                    case 0:
                        this.imgLoad.Visible = false;
                        this.lab_state.Text = "";
                        break;

                    case 1:
                    {
                        this.imgLoad.Visible = true;
                        TimeSpan span = (TimeSpan) (DateTime.Now - sendload.StartTime);
                        this.lab_state.Text = "Sec.: " + span.TotalSeconds.ToString("0") + "s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                        this.Page.RegisterStartupScript("key", " <script language='javascript'>window.setTimeout(\"location.href=location.href\"," + AppFlag.SendRefresh + ");</script>");
                        break;
                    }
                    case 2:
                    {
                        this.imgLoad.Visible = false;
                        TimeSpan span2 = (TimeSpan) (DateTime.Now - sendload.StartTime);
                        this.lab_state.Text = sendload.lbMsg + " Sec.: " + span2.TotalSeconds.ToString("0") + "s&nbsp;&nbsp;";
                        this.Session["sendload"] = null;
                        break;
                    }
                    case 3:
                        this.imgLoad.Visible = false;
                        this.lab_state.Text = sendload.lbMsg;
                        this.Session["sendload"] = null;
                        break;
                }
            }
        }
    }
}

