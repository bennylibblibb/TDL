namespace CENTASMS
{
    using Anthem;
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class UploadSmsRefresh : Page
    {
        protected System.Web.UI.WebControls.DataGrid dgAcions;
        protected System.Web.UI.WebControls.DataGrid dgActions;
        protected HtmlGenericControl divStatus;
        protected HtmlGenericControl divView;
        protected System.Web.UI.WebControls.Label lbResult;
        protected System.Web.UI.WebControls.LinkButton LbtnRefresh;
        protected System.Web.UI.WebControls.LinkButton lbtnView;

        private void dgActions_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgActions.CurrentPageIndex = e.NewPageIndex;
            SmsActionData data = new SmsActionData();
            data = new SmsActions().LoadAllAction("SMS");
            this.dgActions.DataSource = data.Tables["SMS_ACTIONS"].DefaultView;
            this.dgActions.PageSize = 5;
            this.dgActions.DataBind();
        }

        private void InitializeComponent()
        {
            this.lbtnView.Click += new EventHandler(this.lbtnView_Click);
            this.LbtnRefresh.Click += new EventHandler(this.LbtnRefresh_Click);
            this.dgActions.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgActions_PageIndexChanged);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LbtnRefresh_Click(object sender, EventArgs e)
        {
            string str = "UploadFrom.window.location.reload();";
            Manager.AddScriptForClientSideEval(str);
        }

        private void lbtnView_Click(object sender, EventArgs e)
        {
            SmsActionData data = new SmsActionData();
            data = new SmsActions().LoadAllAction("SMS");
            this.dgActions.DataSource = data.Tables["SMS_ACTIONS"].DefaultView;
            this.dgActions.PageSize = 5;
            this.dgActions.DataBind();
            this.lbResult.Text = "";
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DoSmsLoad doload;
                Manager.Register(this);
                if (base.Request.IsAuthenticated && base.Request.IsAuthenticated)
                {
                    doload = new DoSmsLoad();
                    if (this.Session["doSmsLoad"] != null)
                    {
                        doload = (DoSmsLoad)this.Session["doSmsLoad"];
                    }
                    switch (doload.State)
                    {
                        case 0:
                            this.divStatus.Visible = false;
                            this.divView.Visible = true;
                            break;

                        case 1:
                        {
                            this.divView.Visible = false;
                            this.divStatus.Visible = true;
                            SmsActionData data = new SmsActionData();
                            data = new SmsActions().LoadActionByCondition(doload.strcondtion,"SMS");
                            this.dgActions.DataSource = data.Tables["SMS_ACTIONS"].DefaultView;
                            this.dgActions.PageSize = AppFlag.iPageSize;
                            this.dgActions.DataBind();
                            if (doload.Total != 0)
                            {
                                goto Label_0114;
                            }
                            goto Label_0218;
                        }
                        case 2:
                            this.divView.Visible = true;
                            this.divStatus.Visible = false;
                            this.lbResult.Text = "備註：Sec.: " + ((TimeSpan)(DateTime.Now - doload.StartTime)).TotalSeconds.ToString("0") + "s&nbsp;&nbsp;&nbsp;&nbsp;Per: " + doload.Percent.ToString() + "/" + doload.Total.ToString() + "  &nbsp;&nbsp;&nbsp;  Finished.";
                            this.Page.RegisterStartupScript("key", " <script language='javascript'>parent.location.reload();</script>");
                            doload.State = 4;
                            break;

                        case 3:
                        {
                            this.divView.Visible = true;
                            this.divStatus.Visible = false;
                            SmsActionData data2 = new SmsActionData();
                            data2 = new SmsActions().LoadActionByCondition(doload.strcondtion, "SMS");
                            this.dgActions.DataSource = data2.Tables["SMS_ACTIONS"].DefaultView;
                            this.dgActions.PageSize = AppFlag.iPageSize;
                            this.dgActions.DataBind();
                            if (data2.Tables["SMS_ACTIONS"].Rows.Count <= 0)
                            {
                                goto Label_0364;
                            }
                            this.lbResult.Text = data2.Tables["SMS_ACTIONS"].Rows[0]["ACTION_REMARKS"].ToString();
                            goto Label_0375;
                        }
                        case 4:
                            this.divView.Visible = true;
                            this.divStatus.Visible = false;
                            this.lbResult.Text = "備註：Sec.: " + ((TimeSpan)(DateTime.Now - doload.StartTime)).TotalSeconds.ToString("0") + "s&nbsp;&nbsp;&nbsp;&nbsp;Per: " + doload.Percent.ToString() + "/" + doload.Total.ToString() + "  &nbsp;&nbsp;&nbsp;  Finished.";
                            this.Session["doSmsLoad"] = null;
                            break;

                        case 5:
                        {
                            this.divView.Visible = true;
                            this.divStatus.Visible = false;
                            SmsActionData data3 = new SmsActionData();
                            data3 = new SmsActions().LoadActionByCondition(doload.strcondtion,"SMS");
                            this.dgActions.DataSource = data3.Tables["SMS_ACTIONS"].DefaultView;
                            this.dgActions.PageSize = AppFlag.iPageSize;
                            this.dgActions.DataBind();
                            if (data3.Tables["SMS_ACTIONS"].Rows.Count <= 0)
                            {
                                goto Label_0493;
                            }
                            this.lbResult.Text = data3.Tables["SMS_ACTIONS"].Rows[0]["ACTION_REMARKS"].ToString();
                            goto Label_04A4;
                        }
                    }
                }
                return;
            Label_0114:
                if (doload.Percent == doload.Total)
                {
                    object[] objArray = new object[5];
                    objArray[0] = "備註：Sec.: ";
                    TimeSpan span = (TimeSpan) (DateTime.Now - doload.StartTime);
                    objArray[1] = span.TotalSeconds.ToString("0");
                    objArray[2] = "s&nbsp;&nbsp;&nbsp;&nbsp;Per: ";
                    //objArray[3] = ((doload.Percent * 100) / doload.Total) - 1;
                    //objArray[4] = "%";
                   // this.lbResult.Text = string.Concat(objArray) + "  &nbsp;&nbsp;&nbsp;  " + ((objArray[3].ToString() == "0") ? "Filtering.." : "") + ((objArray[3].ToString() == "99") ? "Inserting..." : "");
                    objArray[3] = doload.Percent.ToString() + "/" + doload.Total.ToString();
                    objArray[4] = "";
                    this.lbResult.Text = string.Concat(objArray) + "  &nbsp;&nbsp;" + doload.dolbUploadResult + " &nbsp;&nbsp;   Handling ..";
                }
                else
                {
                    object[] objArray2 = new object[5];
                    objArray2[0] = "備註：Sec.: ";
                    TimeSpan span2 = (TimeSpan) (DateTime.Now - doload.StartTime);
                    objArray2[1] = span2.TotalSeconds.ToString("0");
                    objArray2[2] = "s&nbsp;&nbsp;&nbsp;&nbsp;Per: ";
                    //objArray2[3] = (doload.Percent * 100) / doload.Total;
                    //objArray2[4] = "%";
                    objArray2[3] = doload.Percent.ToString () +"/" +doload.Total.ToString ();
                    objArray2[4] = "";
                    //this.lbResult.Text = string.Concat(objArray2) + "  &nbsp;&nbsp;&nbsp;  " + ((objArray2[3].ToString() == "0") ? "Filtering..." : "" + ((objArray2[3].ToString() == "99") ? "Inserting..." : ""));
                    this.lbResult.Text = string.Concat(objArray2) + "  &nbsp;&nbsp;" + doload.dolbUploadResult + " &nbsp;&nbsp;   Handling ...";
                  
                }
            Label_0218:
                if (AppFlag.RefreshMode.ToUpper() == "AUTO")
                {
                    this.Page.RegisterStartupScript("key", " <script language='javascript'>window.setTimeout(\"location.href=location.href\"," + AppFlag.UploadRefresh + ");</script>");
                }
                return;
            Label_0364:
                this.lbResult.Text = doload.dolbUploadResult;
            Label_0375:
                this.Page.RegisterStartupScript("key", " <script language='javascript'>parent.location.reload();</script>");
                doload.State = 5;
                return;
            Label_0493:
                this.lbResult.Text = doload.dolbUploadResult;
            Label_04A4:
            this.Session["doSmsLoad"] = null;
            }
            catch (Exception exception)
            {
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   UploadSmsRefresh.Page_Load  " + exception.ToString());
            }
        }
    }
}

