namespace CENTASMS
{
    using Anthem;
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using System.Drawing;

    public class MmsTool : CommonPage
    {  
        protected System.Web.UI.WebControls.Label lbUser; 
        protected Anthem.DataGrid dgSchedule; 
          protected Anthem.Label lbMsg;

        private void InitializeComponent()
        { 
            base.Load += new EventHandler(this.Page_Load);
            this.dgSchedule.DeleteCommand += new DataGridCommandEventHandler(this.dgSchedule_DeleteCommand);
            this.dgSchedule.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgSchedule_PageIndexChanged); 
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        { 
            if (!base.Request.IsAuthenticated)
            {
                base.Response.Redirect("Default.aspx", false);
            }
            else
            {
                this.lbUser.Text = this.Context.User.Identity.Name;
                GetSmsData();
            }
        }

        private void dgSchedule_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgSchedule.EditItemIndex = -1; 
            string text = ((Anthem.Label)this.dgSchedule.Items[e.Item.ItemIndex].FindControl("lbBatchidD")).Text;
            if (new SmsMsgs().DeleteMmsInfo(text))
            { 
                this.dgSchedule.Columns[5].HeaderText = "刪除成功";
            }
            else 
            {
                this.dgSchedule.Columns[5].HeaderText = "刪除失敗";
            }
            this.dgSchedule.Columns[5].HeaderStyle.ForeColor = Color.Red;
            this.lbMsg.UpdateAfterCallBack = true; 
            this.GetSmsData();
        }
         
        private void dgSchedule_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            try{
            this.dgSchedule.CurrentPageIndex = e.NewPageIndex;
            SmsMsgData data = (SmsMsgData)this.Session["smsdata"];
            this.dgSchedule.DataSource = data.Tables[AppFlag.SMS_MSG_TABLE].DefaultView;
             this.dgSchedule.DataBind();  
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
            }
            this.dgSchedule.UpdateAfterCallBack = true;
        }

        private void GetSmsData()
        {
            try
            {
                SmsMsgData  allSmsData;
                allSmsData = new SmsMsgs().GetAllSmsData() ;
                this.dgSchedule.DataSource = allSmsData.Tables[AppFlag.SMS_MSG_TABLE].DefaultView;
                this.dgSchedule.DataBind();
                this.dgSchedule.UpdateAfterCallBack = true;
                this.Session["smsdata"] = allSmsData; 
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
            }
        }

        protected string GetText(object str)
        {
            string strMSG = "";
            if (str.ToString().Trim() == "") return "";
            try
            {
                string[] strSplit = str.ToString().Split('-');
                byte[] bytTemp2 = new byte[strSplit.Length];
                for (int i = 0; i < strSplit.Length; i++)
                    bytTemp2[i] = byte.Parse(strSplit[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                strMSG = System.Text.Encoding.Unicode.GetString(bytTemp2);

            }
            catch
            {
                strMSG = str.ToString().Trim();
            }
            return strMSG;
        }
    }
}

