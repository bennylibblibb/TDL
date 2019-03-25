namespace CENTASMS
{
    using Anthem;
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Text;
    
    public class AlertSmsData : Page
    {
        protected Anthem.Button btnUpdate;
        protected Anthem.Label lbLen;
        protected Anthem.Label lbMsg;
        protected Anthem.Label lbNum;
        protected System.Web .UI.WebControls .TextBox txtoldcontent;
        protected Anthem.TextBox txtSmsContent; 
        protected System.Web.UI.HtmlControls.HtmlInputButton btnCannel;
        
        //protected string GetText(object str)
        //{
        //    string strMSG = "";
        //    if (str.ToString().Trim() == "") return "";
        //    try
        //    {
        //        string[] strSplit = str.ToString().Split('-');
        //        byte[] bytTemp2 = new byte[strSplit.Length];
        //        for (int i = 0; i < strSplit.Length; i++)
        //            bytTemp2[i] = byte.Parse(strSplit[i], System.Globalization.NumberStyles.AllowHexSpecifier);
        //        strMSG = System.Text.Encoding.Unicode.GetString(bytTemp2);
        //    }
        //    catch
        //    {
        //        strMSG = str.ToString().Trim();
        //    }
        //    return strMSG;
        //}

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


        protected string GetText(object str)
        {
            return base.Server.UrlDecode(str.ToString());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int num = -1;
            int ilen = -1;
            int maxlen = -1;
            string str = this.txtoldcontent.Text.Trim();
            num = ConfigManager.CheckSmsData(this.txtSmsContent.Text.Trim(), out ilen, out maxlen);
            if (num == -1)
            {
                this.lbMsg.Text = (Session["LanguageEn"] == "en-US") ? "The no. of characters exceeds " : "超過最大字符數 " + maxlen.ToString() + "！";
            }
            else
            {
                SmsMsgSchs schs = new SmsMsgSchs();
                SmsMsgSchData allSmsSchData = schs.GetAllSmsSchData(" where   cbatchid='" + base.Request.QueryString["ID"].ToString().Trim() + "'");
                DataRow row = allSmsSchData.Tables[0].Rows[0];
                //row["CSMSMSG"] = this.txtSmsContent.Text.Trim();// BitConverter.ToString(Encoding.Unicode.GetBytes(this.txtSmsContent.Text.Trim() + " "));
                row["CSMSMSG"] = ("%" + BitConverter.ToString(Encoding.UTF8.GetBytes(this.txtSmsContent.Text.Trim()))).Replace("-", "%");
                row["IMSGLEN"] = ilen;
                row["ISMSMSGNO"] = num;
                if (schs.UpdateSchedule(allSmsSchData))
                {
                    this.lbMsg.Text = (Session["LanguageEn"] == "en-US") ? "Update success！" : "更新成功！";// "更新成功！";
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.Context.User.Identity.Name + ")  更新 " + base.Request.QueryString["ID"].ToString().Trim() + " 發送內容 " + str + " 至 " + this.txtSmsContent.Text.Trim());
                }
                else
                {
                    this.lbMsg.Text = (Session["LanguageEn"] == "en-US") ? "Update failed！" : "更新失敗！";// "更新失敗！"; 
                }
            }
            this.lbMsg.UpdateAfterCallBack = true;
        }

        private void InitializeComponent()
        {
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
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
                string batchid = base.Request.QueryString["ID"].ToString().Trim();
                SmsMsgSchData schSmsDatabyBatchid = new SmsMsgSchs().GetSchSmsDatabyBatchid(batchid);
                this.txtSmsContent.Text = GetText(schSmsDatabyBatchid.Tables[0].Rows[0]["CSMSMSG"].ToString());
                this.lbLen.Text = schSmsDatabyBatchid.Tables[0].Rows[0]["IMSGLEN"].ToString();
                this.lbNum.Text = schSmsDatabyBatchid.Tables[0].Rows[0]["ISMSMSGNO"].ToString();
                this.txtoldcontent.Text = this.txtSmsContent.Text;
                this.btnCannel.Value = (Session["LanguageEn"] == "en-US") ? "Close" : "關閉";
            }
        }
    }
}

