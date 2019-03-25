namespace CENTASMS
{
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class MemberofSent : Page
    {
        protected DataGrid dgMembers;
        protected Label lbGroupNameP;

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

        private void dgMembers_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgMembers.CurrentPageIndex = e.NewPageIndex;
            if (base.Request.QueryString["Type"].ToString().Trim() == "B")
            {
                SmsMsgReceHistData data = (SmsMsgReceHistData) this.Session["smsmemberdata"];
                this.dgMembers.DataSource = data.Tables["SMS_MSGRCV_HIST"].DefaultView;
            }
            else
            {
                SmsMsgSchReceData data2 = (SmsMsgSchReceData) this.Session["smsmemberdata"];
                this.dgMembers.DataSource = data2.Tables["SMS_MSGRCV_SCH"].DefaultView;
            }
            this.dgMembers.PageSize = AppFlag.iPageSize;
            this.dgMembers.DataBind();
        }

        private void InitializeComponent()
        {
            this.dgMembers.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgMembers_PageIndexChanged);
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
                string str = base.Request.QueryString["ID"].ToString().Trim();
                string str2 = base.Request.QueryString["Type"].ToString().Trim();
                string STATUS = (base.Request.QueryString["STATUS"] == null) ? "" : base.Request.QueryString["STATUS"].ToString().Trim();
                string strCondition = "where CBATCHID='" + str + "'";
                if (str2 == "B")
                {
                    SmsMsgReceHistData allSmsReceHistData = new SmsMsgReceHistData();
                    allSmsReceHistData = new SmsMsgReceHists().GetAllSmsReceHistData(strCondition);
                    this.dgMembers.DataSource = allSmsReceHistData.Tables["SMS_MSGRCV_HIST"].DefaultView;
                    this.Session["smsmemberdata"] = allSmsReceHistData;
                }
                else
                {
                    if (STATUS == "C")
                    {
                        SmsMsgReceHistData allSmsReceHistData = new SmsMsgReceHistData();
                        allSmsReceHistData = new SmsMsgReceHists().GetAllSmsReceHistData(strCondition);
                        this.dgMembers.DataSource = allSmsReceHistData.Tables["SMS_MSGRCV_HIST"].DefaultView;
                        this.Session["smsmemberdata"] = allSmsReceHistData;
                    }
                    else
                    {

                        SmsMsgReceHistData allSmsReceHistData = new SmsMsgReceHistData();
                        allSmsReceHistData = new SmsMsgReceHists().GetAllSmsReceHistData(strCondition);
                        if (allSmsReceHistData.Tables["SMS_MSGRCV_HIST"].Rows.Count == 0)
                        {
                            SmsMsgSchReceData allSmsSchReceData = new SmsMsgSchReceData();
                            allSmsSchReceData = new SmsMsgSchReces().GetAllSmsSchReceData(strCondition);
                            this.dgMembers.DataSource = allSmsSchReceData.Tables["SMS_MSGRCV_SCH"].DefaultView;
                            this.Session["smsmemberdata"] = allSmsSchReceData;
                        }
                        else
                        {
                            this.dgMembers.DataSource = allSmsReceHistData.Tables["SMS_MSGRCV_HIST"].DefaultView;
                            this.Session["smsmemberdata"] = allSmsReceHistData;
                        }

                    }
                }
                this.dgMembers.PageSize = AppFlag.iPageSize;
                this.dgMembers.DataBind();
            }
        }
        
         public string StringStatus(object status)
        {
            if (status.ToString() == "1")
            {
                status = "已發送";
            }
            else if (status.ToString() == "0")
            {
                status = "等待發送";
            }
            else if (status.ToString() == "-1")
            {
                status = "DNC";
            }
            else if (status.ToString() == "-2")
            {
                status = "DNC ERROR";
            }
            else if (status.ToString() == "-3")
            {
                status = "ERROR";
            }
            else
            {
                status = "";
            }
            return status.ToString();
        }
    }
}

