namespace CENTASMS
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Refresh : Page
    {
        protected Image imgLoad;
        protected Label lab_state;
        protected Label lbResult;
        protected HtmlGenericControl Rdiv_load;

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
                Doload doload = new Doload();
                if (this.Session["doload"] != null)
                {
                    doload = (Doload) this.Session["doload"];
                }
                switch (doload.State)
                {
                    case 0:
                        this.imgLoad.Visible = false;
                        break;

                    case 1:
                        if (doload.Total != 0)
                        {
                            object[] objArray = new object[5];
                            objArray[0] = "Sec.: ";
                            TimeSpan span2 = (TimeSpan) (DateTime.Now - doload.StartTime);
                            objArray[1] = span2.TotalSeconds.ToString("0");
                            objArray[2] = "s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Per: ";
                            objArray[3] = (doload.Percent * 100) / doload.Total;
                            objArray[4] = "%";
                            this.lab_state.Text = string.Concat(objArray);
                        }
                        else
                        {
                            TimeSpan span = (TimeSpan) (DateTime.Now - doload.StartTime);
                            this.lab_state.Text = "Sec.: " + span.TotalSeconds.ToString("0") + "s&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Per: 0%";
                        }
                        this.Page.RegisterStartupScript("key", " <script language='javascript'>window.setTimeout(\"location.href=location.href\"," + AppFlag.UploadRefresh + ");</script>");
                        return;

                    case 2:
                        this.imgLoad.Visible = false;
                        this.lbResult.Text = doload.StartTime.ToString("yyyy/MM/dd HH:mm:ss") + "─" + doload.FinishTime.ToString("yyyy/MM/dd HH:mm:ss") + " " + doload.FileName + " " + doload.dolbUploadResult;
                        this.Session["doload"] = null;
                        break;

                    case 3:
                        this.imgLoad.Visible = false;
                        this.lbResult.Text = string.Concat(new object[] { DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), " ", doload.ErrorTime, " ", doload.FileName, " 上傳出錯！" });
                        this.Session["doload"] = null;
                        break;
                }
            }
        }
    }
}

