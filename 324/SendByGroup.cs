namespace CENTASMS
{
    using Anthem;
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Globalization;
    using System.Collections;
    using System.Data;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    //using System.Data.Odbc; 
    using System.Data.OleDb;
    using System.IO;
    using FirebirdSql.Data.FirebirdClient;
    using System.Text;

    public class SendByGroup : CommonPage
    {
        protected Anthem.Button btnAddMsg;
        protected System.Web.UI.WebControls.Button btnCannel;
        protected System.Web.UI.WebControls.Button btnCount;
        protected Anthem.Button btnDetailSch;
        protected System.Web.UI.WebControls.Button btnExportSms1;
        protected System.Web.UI.WebControls.Button btnExportSms2;
        protected System.Web.UI.WebControls.Button btnExportSms3;
        protected Anthem.Button btnLoginOut;
        protected Anthem.Button btnlstGroupClear;
        protected Anthem.Button btnSearch;
        protected Anthem.Button btnSearchCall;
        protected Anthem.Button btnSearchGroup;
        protected Anthem.Button btnSearchSch;
        protected Anthem.Button btnSend;
        protected Anthem.Button btnAgentSend;
        protected System.Web.UI.WebControls.CheckBox chkDefault;
        protected System.Web.UI.WebControls.CheckBox chkAction;
        private IFormatProvider culture = new CultureInfo("en-GB", true);
        protected Anthem.DataGrid dgData2;
        protected Anthem.DataGrid dgSchedule;
        protected Anthem.DataGrid dgSchedule2;
        protected Anthem.DataGrid dgSmsData;
        protected Anthem.DataGrid dgSmsDataCall;
        protected HtmlGenericControl div_load;
        protected Sendload doload;
        protected Anthem.DropDownList dplUser2;
        protected Anthem.DropDownList dplUsers;
        protected Anthem.DropDownList dplUsersCall;
        protected Anthem.DropDownList dplAgentSmsNum;
        protected System.Web.UI.WebControls.Image imgLoad;
        //protected Label lbExtraGroup;
        protected Anthem.Label lbGroupIDContent;
        protected Anthem.Label lbLen;
        protected Anthem.Label lbMsg;
        protected Anthem.Label lbMsgError;
        protected Anthem.Label lbMsgLogin;
        protected Anthem.Label lbmsgRP;
        protected Anthem.Label lbMsgSch;
        protected Anthem.Label lbNum;
        protected Anthem.Label lbrfvContent;
        protected Anthem.Label lbrfvNum;
        protected Anthem.Label lbSearchStatus;
        protected Anthem.Label lbSendGroup;
        protected Anthem.Label lbAgentSmsResult;
        protected System.Web.UI.WebControls.Label lbUser;
        protected Anthem.ListBox lstGroup;
        protected Anthem.ListBox lstGroupMember;
        protected System.Web.UI.WebControls.Panel plCallHist;
        protected System.Web.UI.WebControls.Panel plDefineScheduleMsg;
        protected System.Web.UI.WebControls.Panel plMsgData;
        protected System.Web.UI.WebControls.Panel plSendHist;
        protected System.Web.UI.WebControls.Panel plUploadSms;
        protected System.Web.UI.WebControls.Panel plUploadSmsAction;
        protected System.Web.UI.WebControls.Panel plAgentSMS;
        protected System.Web.UI.WebControls.Panel plUploadSmsAgent;
        protected Anthem.Panel plSendLogion;
        protected Anthem.Panel plSendMsg;
        protected Anthem.RadioButton rbSendbyTime;
        protected Anthem.RadioButton rbSendontime;
        protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
        protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
        protected System.Web.UI.WebControls.RequiredFieldValidator reqbtnUploadMode3;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfv;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvCall;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvMsg;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvNum;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvPW;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvPW2;
        protected Anthem.Button SaveLogin;
        protected Anthem.TextBox tbNum;
        protected Anthem.TextBox txtAgentSmsContent;
        protected Anthem.TextBox txtSmsPhone;
        protected Anthem.TextBox txtAgentPhone;
        protected Anthem.TextBox txtSalePhone;
        protected Anthem.TextBox txtSaleName;
        protected System.Web.UI.WebControls.TextBox txtEndDate;
        protected System.Web.UI.WebControls.TextBox txtEndDate2;
        protected System.Web.UI.WebControls.TextBox txtEndDateCall;
        protected Anthem.TextBox txtScheduleMsg;
        protected Anthem.TextBox txtScheduleMsgTitle;
        protected Anthem.TextBox txtSearchGroup;
        protected Anthem.TextBox txtSmsContent;
        protected System.Web.UI.WebControls.TextBox txtStartDate;
        protected System.Web.UI.WebControls.TextBox txtStartDate2;
        protected System.Web.UI.WebControls.TextBox txtStartDateCall;
        protected System.Web.UI.WebControls.TextBox txtUserLogion;
        protected System.Web.UI.WebControls.TextBox txtUserPWLogion;
        protected Anthem.Button btnUpload;
        protected HtmlInputButton Submit1;
        protected HtmlInputButton Submit2;
        protected HtmlInputButton subUploadAgentSms;

        protected HtmlInputFile btnUploadMode;
        protected Anthem.Label lbUploadResult;
        protected HtmlInputFile btnUploadMode2;
        protected Anthem.Label lbUploadResult2;
        protected HtmlInputFile btnUploadMode3;
        protected Anthem.Label lbUploadResult3;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvUplaod;
        protected Anthem.Label lbrfvUpload;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvUplaod2;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvUplaod3;
        protected Anthem.Label lbrfvUpload2;
        protected Anthem.Label lbrfvUpload3;
        protected DoSmsLoad doSmsLoad;
        protected DoSmsActionLoad doSmsActionLoad;
        protected DoSmsAgentLoad doSmsAgentLoad;
        protected Anthem.DropDownList dplUploadAgentSmsNum;
        protected Anthem.TextBox txtUploadAgentSmsContent;

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
        

        private void btnAddMsg_Click(object sender, EventArgs e)
        {
            if (this.txtScheduleMsg.Text.Trim() == "")
            {
                this.lbmsgRP.Text = "*";
                this.lbmsgRP.UpdateAfterCallBack = true;
            }
            else
            {
                int num = 0;
                int ilen = 0;
                int maxlen = 0;
                num = ConfigManager.CheckSmsData(this.txtScheduleMsg.Text.Trim(), out ilen, out maxlen);
                if (num == -1)
                {
                    this.lbmsgRP.Text =(Session["LanguageEn"] == "en-US") ? "The no. of characters exceeds " : "超過最大字符數 "+ maxlen.ToString() + "！";
                    this.lbmsgRP.UpdateAfterCallBack = true;
                }
                else
                {
                    string str = this.chkDefault.Checked ? "Normal" : "Suspend";
                    SmsSchContentData data = new SmsSchContentData();
                    SmsSchContents contents = new SmsSchContents();
                    DataRow row = data.Tables["SMS_MSGSCH_CONTENT"].NewRow();
                    row["STATUS"] = str;
                    row["CTITLE"] = this.txtScheduleMsgTitle.Text.Trim();
                    row["CSMSMSG"] = this.txtScheduleMsg.Text.Trim();
                    row["IMSGLEN"] = ilen;
                    row["ISMSMSGNO"] = num;
                    row["CSENDER"] = this.Context.User.Identity.Name.ToUpper();
                    row["CREATE_DATE"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ");
                    data.Tables["SMS_MSGSCH_CONTENT"].Rows.Add(row);
                    string str2 = "";
                    if (str == "Normal")
                    {
                        SmsSchContentData data2 = contents.LoadSchDataByStatusAndSender(this.Context.User.Identity.Name);
                        foreach (DataRow row2 in data2.Tables[0].Select())
                        {
                            row2.BeginEdit();
                            row2["STATUS"] = "Suspend";
                            row2.EndEdit();
                        }
                        contents.UpdateSmsSchContent(data2);
                        str2 = "並設為默認";
                    }
                    if (contents.InsertSmsSchContent(data))
                    {
                        this.lbmsgRP.Text = (Session["LanguageEn"] == "en-US") ? "Success！" : "成功!" ;//"成功!";
                        Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  預設短訊內容: " + this.txtScheduleMsg.Text.Trim() + " " + str2 + "！");
                        this.GetSmsSchData();
                    }
                    else
                    {
                        this.lbmsgRP.Text =(Session["LanguageEn"] == "en-US") ? "Failed！" : "失敗!" ;// "失敗!";
                    }
                    this.lbmsgRP.UpdateAfterCallBack = true;
                    this.lbmsgRP.UpdateAfterCallBack = true;
                    this.dgData2.Columns[7].HeaderText = "";
                    this.dgData2.Columns[8].HeaderText = "";
                    this.dgData2.UpdateAfterCallBack = true;
                    Manager.AddScriptForClientSideEval("Focus( 'txtScheduleMsg');");
                }
            }
        }

        private void btnCannel_Click(object sender, EventArgs e)
        {
            this.btnSend.Enabled = true;
            this.btnSend.UpdateAfterCallBack = true;
            this.lstGroup.Items.Clear();
            ////ListItem item = new ListItem("▼私人組別", "P");
            ////this.lstGroup.Items.Add(item);
            ////item = new ListItem("▼共享組別", "S");
            ListItem item = new ListItem("▼" + (Session["LanguageEn"] == "zh-HK" ? "私人組別" : "Private"), "P");
            this.lstGroup.Items.Add(item);
            item = new ListItem("▼" + (Session["LanguageEn"] == "zh-HK" ? "共享組別" : "Share"), "S");

            this.lstGroup.Items.Add(item);
            this.lstGroup.UpdateAfterCallBack = true;
            this.txtSmsContent.Text = "";
            this.tbNum.Text = "";
            this.lbNum.Text = "0";
            this.lbLen.Text = "0";
            this.lbMsg.Text = "";
            this.lbrfvNum.Visible = false;
            this.lbrfvNum.UpdateAfterCallBack = true;
            this.lbrfvContent.Visible = false;
            this.lbrfvContent.UpdateAfterCallBack = true;
            this.txtSmsContent.UpdateAfterCallBack = true;
            this.tbNum.UpdateAfterCallBack = true;
            this.lbNum.UpdateAfterCallBack = true;
            this.lbLen.UpdateAfterCallBack = true;
            this.lbMsg.UpdateAfterCallBack = true;
            this.lbGroupIDContent.Text = "";
            this.lbGroupIDContent.UpdateAfterCallBack = true;
            //string str = "sendiframe.window.location.reload();";
            string str = "sendiframeReload();";
            Manager.AddScriptForClientSideEval(str);
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            try
            {
                int num = 0;
                int ilen = 0;
                int maxlen = 0;
                if (ConfigManager.CheckSmsData(this.txtSmsContent.Text.Trim(), out ilen, out maxlen) == 11)
                {
                    throw new Exception("SMS exceeds 10.");
                }
                num = ConfigManager.CheckSmsData(this.txtSmsContent.Text.Trim(), out ilen, out maxlen);
                this.lbLen.Text = ilen.ToString();
                this.lbNum.Text = num.ToString();
            }
            catch (Exception exception)
            {
                if (exception.ToString().IndexOf("SMS exceeds 10.") > 1)
                {
                    this.lbMsg.Text = (Session["LanguageEn"] == "en-US") ? "The no. of characters exceeds " : "超過最大字符數 " ; //"超過最大字符數!";
                }
                else
                {
                    this.lbMsg.Text = (Session["LanguageEn"] == "en-US") ? "Please try a later " : "請稍后再試 ";//+ "請稍后再試！";
                }
            }
            this.lbMsg.UpdateAfterCallBack = true;
            this.lbNum.UpdateAfterCallBack = true;
            this.lbLen.UpdateAfterCallBack = true;
        }

        private void btnDetailSch_Click(object sender, EventArgs e)
        {
            try
            {
                SmsMsgSchData allSmsSchData;
                this.Session["datagrid"] = "dgSchedule2";
                this.dgSchedule2.CurrentPageIndex = 0;
                if (this.btnDetailSch.Text == (Session["LanguageEn"] == "zh-HK" ? "詳情" : "Detail"))
                {
                    if (this.dplUser2.SelectedItem.Text.Trim() == "All")
                    {
                        allSmsSchData = new SmsMsgSchs().GetAllSmsSchData("");
                    }
                    else
                    {
                        allSmsSchData = new SmsMsgSchs().GetAllSmsSchData(" where csender ='" + this.dplUser2.SelectedItem.Text.Trim() + "' ");
                    }
                    this.btnDetailSch.Text = Session["LanguageEn"] == "zh-HK" ? "詳情查詢" : "Detail Enquiry";// "詳情查詢";


                }
                else if (this.dplUser2.SelectedItem.Text.Trim() == "All")
                {
                    allSmsSchData = new SmsMsgSchs().GetAllSmsSchData(" where   '" + this.txtStartDate2.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDate2.Text.Trim() + " 23:59:59'");
                }
                else
                {
                    allSmsSchData = new SmsMsgSchs().GetAllSmsSchData(" where csender ='" + this.dplUser2.SelectedItem.Text.Trim() + "' AND '" + this.txtStartDate2.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDate2.Text.Trim() + " 23:59:59'");
                }

                //using (OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn))
                //{
                //    connection.Open();
                //    foreach (DataRow dr in allSmsSchData.Tables[0].Rows)
                //    {
                //        string selectString = "select count(*) from  " + AppFlag.SMS_MSG_RECEIVER_TABLE + " where  CBATCHID='" + dr[0].ToString() + "'";
                //        OleDbCommand cmd = new OleDbCommand(selectString, connection);
                //        dr.BeginEdit();
                //        dr[9] = (int)cmd.ExecuteScalar();
                //        dr.EndEdit();
                //    }
                //    connection.Close();
                //}
                //using (OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn))
                //{
                //    connection.Open();
                //    foreach (DataRow dr in allSmsSchData.Tables[0].Rows)
                //    {
                //        string selectString = "select count(*) from  SMS_MSG_HIST where  CBATCHID='" + dr[0].ToString() + "'";

                //        OleDbCommand cmd = new OleDbCommand(selectString, connection);
                //        if ((int)cmd.ExecuteScalar() == 0)
                //        {
                //            dr.BeginEdit();
                //            dr[9] = -1;// Convert.ToInt32(dr["IMSGLEN"]) * Convert.ToInt32(dr["ISMSMSGNO"]);
                //            dr.EndEdit(); 
                //        }
                //        else
                //        {
                //            selectString = "select count(*) from  " + AppFlag.SMS_MSG_RECEIVER_TABLE + " where  CBATCHID='" + dr[0].ToString() + "'";
                //            cmd = new OleDbCommand(selectString, connection);
                //            dr.BeginEdit();
                //            //dr[9] = Convert.ToInt32(dr["IMSGLEN"]) * Convert.ToInt32(dr["ISMSMSGNO"]) - (int)cmd.ExecuteScalar();
                //            dr[9] = (int)cmd.ExecuteScalar();
                //            dr.EndEdit();
                //        }
                //    }
                //    connection.Close();
                //}
                using (OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn))
                {
                    connection.Open();
                    OleDbCommand cmd;
                    using (FbConnection connection2 = new FbConnection(AppFlag.CENTASMSINTEConn))
                    {
                        connection2.Open();
                        FbCommand cmd2;
                        foreach (DataRow dr in allSmsSchData.Tables[0].Rows)
                        {
                            string selectString = "select count(*) from  SMS_MSG_HIST where  CBATCHID='" + dr[0].ToString() + "'";

                            cmd2 = new FbCommand(selectString, connection2);
                            if ((int)cmd2.ExecuteScalar() == 0)
                            {
                                dr.BeginEdit();
                                dr[9] = -1;// Convert.ToInt32(dr["IMSGLEN"]) * Convert.ToInt32(dr["ISMSMSGNO"]);
                                dr.EndEdit();
                            }
                            else
                            {
                                selectString = "select count(*) from  " + AppFlag.SMS_MSG_RECEIVER_TABLE + " where  CBATCHID='" + dr[0].ToString() + "'";
                                cmd = new OleDbCommand(selectString, connection);
                                dr.BeginEdit();
                                //dr[9] = Convert.ToInt32(dr["IMSGLEN"]) * Convert.ToInt32(dr["ISMSMSGNO"]) - (int)cmd.ExecuteScalar();
                                dr[9] = (int)cmd.ExecuteScalar();
                                dr.EndEdit();
                            }
                        }
                        connection2.Close();
                    }
                    connection.Close();
                }
                this.Session["smssch2data"] = allSmsSchData;
                this.dgSchedule2.DataSource = allSmsSchData.Tables["SMS_MSG_SCH"].DefaultView;
                this.dgSchedule2.PageSize = AppFlag.iPageSize;
                this.dgSchedule2.DataBind();
                this.btnDetailSch.UpdateAfterCallBack = true;
                this.dgSchedule.Visible = false;
                this.dgSchedule.UpdateAfterCallBack = true;
                this.dgSchedule2.Visible = true;
                this.dgSchedule2.UpdateAfterCallBack = true;
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
            }
        }

        private void btnExportSms1_Click(object sender, EventArgs e)
        {
            if (this.Session["smshistdata"] != null)
            {
                string path = HttpContext.Current.Request.ApplicationPath + "/Temp/";
                string str2 = HttpContext.Current.Server.MapPath(path);
                string s = "即時發送記錄" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + this.lbUser.Text + ".csv";
                string filePath = "";
                filePath = str2 + s;
                DataSet ds = (SmsMsgHistData)this.Session["smshistdata"];
                string sHead = "CBATCHID,短訊內容,發送日期, 發送用戶, 字符數, 分段數, 號碼數 ";
                if (ds.Tables[0].Columns.Count != 7)
                {
                    ds.Tables[0].Columns.Remove("CTYPE");
                    ds.Tables[0].Columns.Remove("IPRIORITY");
                    ds.Tables[0].Columns.Remove("CALLER");
                }
                Files.WriteCSVFile(filePath, sHead, ds, 7);
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.WriteFile(str2 + s);
                response.ContentType = "application/csv";
                string str6 = "attachment;filename=" + base.Server.UrlEncode(s);
                response.AppendHeader("Content-Disposition", str6);
                response.Flush();
                response.End();
            }
        }

        private void btnExportSms2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string path = HttpContext.Current.Request.ApplicationPath + "/Temp/";
            string str2 = HttpContext.Current.Server.MapPath(path);
            string s = "預設發送記錄" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + this.lbUser.Text + ".csv";
            string filePath = "";
            filePath = str2 + s;
            ds = (SmsMsgSchData)this.Session["smssch2data"];
            string sHead = "CBATCHID,短訊內容,發送日期, 發送用戶, 字符數, 分段數, 號碼數 ";
            if (ds.Tables[0].Columns.Count != 7)
            {
                ds.Tables[0].Columns.Remove("CTYPE");
                ds.Tables[0].Columns.Remove("IPRIORITY");
            }
            Files.WriteCSVFile(filePath, sHead, ds, 7);
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.WriteFile(str2 + s);
            response.ContentType = "application/csv";
            string str6 = "attachment;filename=" + base.Server.UrlEncode(s);
            response.AppendHeader("Content-Disposition", str6);
            response.Flush();
            response.End();
        }

        private void btnExportSms3_Click(object sender, EventArgs e)
        {
            if (this.Session["smscalldata"] != null)
            {
                string path = HttpContext.Current.Request.ApplicationPath + "/Temp/";
                string str2 = HttpContext.Current.Server.MapPath(path);
                string s = "落CALL發送記錄" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + this.lbUser.Text + ".csv";
                string filePath = "";
                filePath = str2 + s;
                DataSet ds = (SmsMsgHistData)this.Session["smscalldata"];
                string sHead = "CBATCHID,短訊內容,發送日期, 發送用戶,落CALL用戶, 字符數, 分段數, 號碼數 ";
                if (ds.Tables[0].Columns.Count != 8)
                {
                    ds.Tables[0].Columns.Remove("CTYPE");
                    ds.Tables[0].Columns.Remove("IPRIORITY");
                }
                Files.WriteCSVFile(filePath, sHead, ds, 8);
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.WriteFile(str2 + s);
                response.ContentType = "application/csv";
                string str6 = "attachment;filename=" + base.Server.UrlEncode(s);
                response.AppendHeader("Content-Disposition", str6);
                response.Flush();
                response.End();
            }
        }

        private void btnLoginOut_Click(object sender, EventArgs e)
        {
            this.plSendLogion.Visible = true;
            this.plSendMsg.Visible = false;
            this.plSendLogion.UpdateAfterCallBack = true;
            this.plSendMsg.UpdateAfterCallBack = true;
            this.lstGroup.Items.Clear();
            ////ListItem item = new ListItem("▼私人組別", "P");
            ////this.lstGroup.Items.Add(item);
            ////item = new ListItem("▼共享組別", "S");
            ListItem item = new ListItem("▼" + (Session["LanguageEn"] == "zh-HK" ? "私人組別" : "Private"), "P");
            this.lstGroup.Items.Add(item);
            item = new ListItem("▼" + (Session["LanguageEn"] == "zh-HK" ? "共享組別" : "Share"), "S");
             
            this.lstGroup.Items.Add(item);
            this.lstGroup.UpdateAfterCallBack = true;
            this.txtSmsContent.Text = "";
            this.tbNum.Text = "";
            this.txtSmsContent.UpdateAfterCallBack = true;
            this.tbNum.UpdateAfterCallBack = true;
            Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.Context.User.Identity.Name + "  登出用戶：" + ((string)this.Session["Operator"]) + ")");
            Manager.AddScriptForClientSideEval("Focus( 'txtUserLogion');");
            this.Session["Operator"] = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SmsMsgHistData allSmsHistData;
                this.dgSmsData.CurrentPageIndex = 0;
                if (Users.UserExtraGroup(this.Context.User.Identity.Name))
                {
                    if (this.dplUsers.SelectedItem.Text.Trim() == "All")
                    {
                        allSmsHistData = new SmsMsgHists().GetAllSmsHistData(" where   CBATCHID like 'B%'   AND '" + this.txtStartDate.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDate.Text.Trim() + " 23:59:59' and caller<>'' ");
                    }
                    else
                    {
                        allSmsHistData = new SmsMsgHists().GetAllSmsHistData(" where csender ='" + this.dplUsers.SelectedItem.Text.Trim() + "' and  CBATCHID like 'B%'  AND '" + this.txtStartDate.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDate.Text.Trim() + " 23:59:59'");
                    }
                }
                else if (this.dplUsers.SelectedItem.Text.Trim() == "All")
                {
                    allSmsHistData = new SmsMsgHists().GetAllSmsHistData(" where   CBATCHID like 'B%'   AND '" + this.txtStartDate.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDate.Text.Trim() + " 23:59:59'");
                }
                else
                {
                    allSmsHistData = new SmsMsgHists().GetAllSmsHistData(" where csender ='" + this.dplUsers.SelectedItem.Text.Trim() + "' and  CBATCHID like 'B%'  AND '" + this.txtStartDate.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDate.Text.Trim() + " 23:59:59'");
                }
                //smshist count
                using (OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn))
                {
                    connection.Open();
                    foreach (DataRow dr in allSmsHistData.Tables[0].Rows)
                    {
                        string selectString = "select count(*) from  " + AppFlag.SMS_MSG_RECEIVER_TABLE + " where  CBATCHID='" + dr[0].ToString() + "'";
                        OleDbCommand cmd = new OleDbCommand(selectString, connection);
                        dr.BeginEdit();
                        dr[10] = (int)cmd.ExecuteScalar();
                        dr.EndEdit();
                    }
                    connection.Close();
                }

                this.dgSmsData.DataSource = allSmsHistData.Tables["SMS_MSG_HIST"].DefaultView;
                this.dgSmsData.PageSize = AppFlag.iPageSize;
                this.dgSmsData.DataBind();
                this.Session["smshistdata"] = allSmsHistData;
                this.dgSmsData.UpdateAfterCallBack = true;
            }
            catch
            {

            }
        }

        private void btnSearchCall_Click(object sender, EventArgs e)
        {
            SmsMsgHistData allSmsHistData;
            this.dgSmsDataCall.CurrentPageIndex = 0;
            if (this.dplUsersCall.SelectedItem.Text.Trim() == "All")
            {
                allSmsHistData = new SmsMsgHists().GetAllSmsHistData("where caller<>''   AND '" + this.txtStartDateCall.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDateCall.Text.Trim() + " 23:59:59'");
            }
            else
            {
                allSmsHistData = new SmsMsgHists().GetAllSmsHistData(" where caller ='" + this.dplUsersCall.SelectedItem.Text.Trim() + "'   AND '" + this.txtStartDateCall.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDateCall.Text.Trim() + " 23:59:59'");
            }
            this.dgSmsDataCall.DataSource = allSmsHistData.Tables["SMS_MSG_HIST"].DefaultView;
            this.dgSmsDataCall.PageSize = AppFlag.iPageSize;
            this.dgSmsDataCall.DataBind();
            this.Session["smscalldata"] = allSmsHistData;
            this.dgSmsDataCall.UpdateAfterCallBack = true;
        }

        private void btnSearchGroup_Click(object sender, EventArgs e)
        {
            string str = "";
            Groups groups = new Groups();
            GroupData data = new GroupData();
            data = groups.LoadGroupByPWD(this.txtSearchGroup.Text.Trim());
            if (data.Tables[0].Rows.Count > 0)
            {
                str = data.Tables[0].Rows[0]["CGROUP_NAME"].ToString();
                if (data.Tables[0].Rows[0]["CGROUP_TYPE"].ToString() == "P")
                {
                  ////  str = str + "(私人組別)" ;
                       str = str + "("+(Session["LanguageEn"] == "zh-HK" ? "私人組別" : "Private")+")" ;
                     
                }
                else
                {
                  ////  str = str + "(共享組別)";
                    str = str + "(" + (Session["LanguageEn"] == "zh-HK" ? "共享組別" : "Share") + ")";
                    
                }
                this.tbNum.Text = str;
                this.lbGroupIDContent.Text = data.Tables[0].Rows[0]["CGROUP_ID"].ToString() + "," + str;
                this.tbNum.UpdateAfterCallBack = true;
                this.lbSearchStatus.Text = "";
                this.lbSearchStatus.UpdateAfterCallBack = true;
                this.lbMsg.Text = "";
                this.lbMsg.UpdateAfterCallBack = true;
            }
            else
            {
                this.tbNum.Text = "";
                this.tbNum.UpdateAfterCallBack = true;
                this.lbSearchStatus.Text = "不存在！";
                this.lbSearchStatus.UpdateAfterCallBack = true;
            }
        }

        private void btnSearchSch_Click(object sender, EventArgs e)
        {
            SmsScheduleData allSmsScheduleData;
            this.GetSmsSchedule2Data();
            this.btnDetailSch.Text = Session["LanguageEn"] == "zh-HK" ? "詳情查詢" : "Detail Enquiry";// "詳情查詢";
            this.btnDetailSch.UpdateAfterCallBack = true;
            this.Session["datagrid"] = "dgSchedule";
            this.dgSchedule.CurrentPageIndex = 0;
            if (this.dplUser2.SelectedItem.Text.Trim() == "All")
            {
                allSmsScheduleData = new SmsSchedules().GetAllSmsScheduleData("WHERE  '" + this.txtStartDate2.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDate2.Text.Trim() + " 23:59:59'");
            }
            else
            {
                allSmsScheduleData = new SmsSchedules().GetAllSmsScheduleData(" where csender ='" + this.dplUser2.SelectedItem.Text.Trim() + "' AND '" + this.txtStartDate2.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDate2.Text.Trim() + " 23:59:59'");
            }
            this.dgSchedule.DataSource = allSmsScheduleData.Tables["SMS_SCHEDULE"].DefaultView;
            this.dgSchedule.PageSize = AppFlag.iPageSize;
            this.dgSchedule.DataBind();
            this.Session["smsschdata"] = allSmsScheduleData;
            this.dgSchedule2.Visible = false;
            this.dgSchedule2.UpdateAfterCallBack = true;
            this.dgSchedule.Visible = true;
            this.dgSchedule.UpdateAfterCallBack = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string input = this.lbGroupIDContent.Text.Trim();
            string[] strArray =null;
            if (this.tbNum.Text.Trim().IndexOf("\r\n") > -1)
            {
                strArray = Regex.Split(this.tbNum.Text.Trim(), "\r\n", RegexOptions.IgnoreCase);
            }
            else
            {
                strArray = Regex.Split(this.tbNum.Text.Trim(), "\n", RegexOptions.IgnoreCase);
            }
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list3 = new ArrayList();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (((strArray[i].ToString().IndexOf("組別") > -1) || (strArray[i].ToString().IndexOf("(Private)") > -1) || (strArray[i].ToString().IndexOf("(Share)") > -1)) && !list.Contains(strArray[i].ToString()))
                {
                    list.Add(strArray[i].ToString());
                }

            }
            string[] strArray2 = Regex.Split(input, ",", RegexOptions.IgnoreCase);
            for (int j = 0; j < (strArray2.Length / 2); j++)
            {
                if (!list2.Contains(strArray2[(2 * j) + 1].ToString()))
                {
                    list2.Add(strArray2[(2 * j) + 1].ToString());
                }
            }
            for (int k = 0; k < list2.Count; k++)
            {
                if (list.Contains(list2[k].ToString()))
                {
                    list3.Add(strArray2[2 * k].ToString());
                }
            }
            string str3 = "";
            if (list3.Count == list.Count)
            {
                for (int m = 0; m < list3.Count; m++)
                {
                    string str7 = str3;
                    str3 = str7 + list3[m].ToString() + "," + list[m].ToString() + ",";
                }
            }
            this.doload.lbGroupIDContent = str3;
            this.lbGroupIDContent.Text = str3;
            this.Session["schsendload"] = null;
            int num5 = 0;
            int ilen = 0;
            int maxlen = 0;
            try
            {
                if ((this.tbNum.Text.Trim() == "") && (this.txtSmsContent.Text.Trim() == ""))
                {
                    this.lbrfvContent.Visible = true;
                    this.lbrfvContent.UpdateAfterCallBack = true;
                    this.lbrfvNum.Visible = true;
                    this.lbrfvNum.UpdateAfterCallBack = true;
                }
                if ((this.tbNum.Text.Trim() == "") && (this.txtSmsContent.Text.Trim() != ""))
                {
                    this.lbrfvNum.Visible = true;
                    this.lbrfvNum.UpdateAfterCallBack = true;
                }
                if ((this.tbNum.Text.Trim() != "") && (this.txtSmsContent.Text.Trim() == ""))
                {
                    this.lbrfvContent.Visible = true;
                    this.lbrfvContent.UpdateAfterCallBack = true;
                }
                if ((this.tbNum.Text.Trim() != "") && (this.txtSmsContent.Text.Trim() != ""))
                {
                    num5 = ConfigManager.CheckSmsData(this.txtSmsContent.Text.Trim(), out ilen, out maxlen);
                    if (num5 == -1)
                    {
                        throw new Exception("SMS exceeds 10.");
                    }
                    if (this.doload.State != 1)
                    {
                        this.doload.lang = Session["LanguageEn"].ToString();
                        this.doload.retVal = false;
                        this.doload.strBatchid = "";
                        this.doload.Operator = (this.Session["Operator"] == null) ? "" : ((string)this.Session["Operator"]);
                        this.doload.stropr = (this.Session["Operator"] == null) ? "" : ("  登入用戶：" + ((string)this.Session["Operator"]));
                        this.doload.txtSmsContent = this.txtSmsContent.Text.Trim();
                        this.doload.type = "A";
                        this.doload.ipriority = 0;
                        this.doload.DateTimenow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        this.doload.ilen = ilen;
                        this.doload.ipart = num5;
                        this.doload.lbLen = ilen.ToString();
                        this.doload.lbNum = num5.ToString();
                        this.doload.tbNum = this.tbNum.Text.Trim();
                        this.doload.lbUser = this.lbUser.Text.Trim();
                        this.doload.strBatchid = "";
                        this.doload.maxlen = maxlen;
                        if (this.rbSendontime.Checked && !this.rbSendbyTime.Checked)
                        {
                            this.btnSend.Enabled = true;
                            this.div_load.Visible = true;
                            this.Page.RegisterStartupScript("", "<script>location.href=location.href;</script>");
                            this.doload.runload();
                        }
                        else if (this.rbSendbyTime.Checked && !this.rbSendontime.Checked)
                        {
                            this.lbLen.Text = ilen.ToString();
                            this.lbNum.Text = num5.ToString();
                            this.lbrfvNum.Visible = false;
                            this.lbrfvContent.Visible = false;
                            int num8 = 430;
                            int num9 = 0xd7;
                            string str4 = "InputSendByTime.aspx";
                            string str5 = string.Concat(new object[] { "help: 0;0;dialogWidth:", num8, "px;dialogHeight:", num9, "px;center=1" });
                            Manager.AddScriptForClientSideEval("ShowInputMiddle('" + str4 + "', '" + str5 + "');");
                        }
                    }
                }
                this.tbNum.Text = "";
                this.tbNum.UpdateAfterCallBack = true;
                this.lbGroupIDContent.Text = "";
                this.lbGroupIDContent.UpdateAfterCallBack = true;
            }
            catch (Exception exception)
            {
                this.tbNum.Text = "";
                this.tbNum.UpdateAfterCallBack = true;
                this.lbGroupIDContent.Text = "";
                this.lbGroupIDContent.UpdateAfterCallBack = true;
                if (exception.ToString().IndexOf("SMS exceeds 10.") > 1)
                {
                    this.lbMsg.Text =(Session["LanguageEn"] == "en-US") ? "The no. of characters exceeds " : "超過最大字符數 "+ maxlen.ToString() + "！";
                    this.lbLen.Text = this.txtSmsContent.Text.Length.ToString();
                }
                else
                {
                    this.lbMsg.Text = (Session["LanguageEn"] == "en-US") ? "Please Try Again Later！" : "請稍后再試！";//"請稍后再試！";
                    Files.CicsWriteError(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  設置即時發送失敗!  " + exception.ToString());
                }
            }
            finally
            {
                this.tbNum.Text = "";
                this.tbNum.UpdateAfterCallBack = true;
                this.lbGroupIDContent.Text = "";
                this.lbGroupIDContent.UpdateAfterCallBack = true;
                this.lstGroup.UpdateAfterCallBack = true;
                this.txtSmsContent.UpdateAfterCallBack = true;
                this.lbrfvContent.UpdateAfterCallBack = true;
                this.lbrfvNum.UpdateAfterCallBack = true;
                this.lbMsg.UpdateAfterCallBack = true;
                this.lbNum.UpdateAfterCallBack = true;
                this.lbLen.UpdateAfterCallBack = true;
            }
        }

        private void dgData2_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgData2.Columns[7].HeaderText = "";
            this.dgData2.Columns[8].HeaderText = "";
            this.dgData2.UpdateAfterCallBack = true;
            this.dgData2.EditItemIndex = -1;
            this.GetSmsSchData();
        }

        private void dgData2_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            this.lbmsgRP.Text = "";
            this.lbmsgRP.UpdateAfterCallBack = true;
            string text = ((System.Web.UI.WebControls.Label)this.dgData2.Items[e.Item.ItemIndex].FindControl("lbStatusID")).Text;
            SmsSchContents contents = new SmsSchContents();
            SmsSchContentData data = contents.LoadSmsSchContentByID(text);
            data.Tables[0].Rows[0].Delete();
            if (contents.DeleteSmsSchContent(data))
            {
                this.dgData2.Columns[8].HeaderText = (Session["LanguageEn"] == "en-US")? "Update success！" : "刪除成功";// "刪除成功";
                this.dgData2.Columns[8].HeaderStyle.ForeColor = Color.Red;
                Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  刪除預設短訊內容成功！");
                this.dgData2.Columns[7].HeaderText = "";
                this.dgData2.UpdateAfterCallBack = true;
                this.GetSmsSchData();
            }
            else
            {
                this.dgData2.Columns[8].HeaderText = (Session["LanguageEn"] == "en-US")?"Update failed！" : "刪除失敗";// "刪除失敗";
                this.dgData2.Columns[8].HeaderStyle.ForeColor = Color.Red;
            }
        }

        private void dgData2_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgData2.EditItemIndex = e.Item.ItemIndex;
            this.dgData2.Columns[7].HeaderText = "";
            this.dgData2.Columns[8].HeaderText = "";
            this.dgData2.UpdateAfterCallBack = true;
            this.GetSmsSchData();
        }

        private void dgData2_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                ((System.Web.UI.WebControls.DropDownList)e.Item.FindControl("dplStatus")).Items.Add("Normal");
                ((System.Web.UI.WebControls.DropDownList)e.Item.FindControl("dplStatus")).Items.Add("Suspend");
            }
        }

        private void dgData2_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                string text = ((System.Web.UI.WebControls.Label)e.Item.FindControl("lbStatus")).Text.Trim();
                ListItem item = ((System.Web.UI.WebControls.DropDownList)e.Item.FindControl("dplStatus")).Items.FindByText(text);
                if (item != null)
                {
                    ((System.Web.UI.WebControls.DropDownList)e.Item.FindControl("dplStatus")).ClearSelection();
                    item.Selected = true;
                }
            }
        }

        private void dgData2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgData2.Columns[7].HeaderText = "";
            this.dgData2.Columns[8].HeaderText = "";
            this.dgData2.CurrentPageIndex = e.NewPageIndex;
            SmsSchContentData data = (SmsSchContentData)this.Session["smsschcontent"];
            this.dgData2.DataSource = data.Tables["SMS_MSGSCH_CONTENT"].DefaultView;
            this.dgData2.PageSize = AppFlag.iPageSize;
            this.dgData2.DataBind();
            this.dgData2.UpdateAfterCallBack = true;
        }

        private void dgData2_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgData2.EditItemIndex = -1;
            string text = ((System.Web.UI.WebControls.Label)this.dgData2.Items[e.Item.ItemIndex].FindControl("lbStatusID")).Text;
            string str2 = ((System.Web.UI.WebControls.DropDownList)this.dgData2.Items[e.Item.ItemIndex].FindControl("dplStatus")).SelectedItem.Text.Trim();
            string strTemp = ((System.Web.UI.WebControls.TextBox)this.dgData2.Items[e.Item.ItemIndex].FindControl("txtCSMSMSG")).Text.Trim();
            string str4 = ((System.Web.UI.WebControls.Label)this.dgData2.Items[e.Item.ItemIndex].FindControl("lbCSMSMSG")).Text;

            string strTempTitle = ((System.Web.UI.WebControls.TextBox)this.dgData2.Items[e.Item.ItemIndex].FindControl("txtCTITLE")).Text.Trim();
            string strTitle = ((System.Web.UI.WebControls.Label)this.dgData2.Items[e.Item.ItemIndex].FindControl("lbCTITLE")).Text;

            int num = 0;
            int ilen = 0;
            int maxlen = 0;
            num = ConfigManager.CheckSmsData(strTemp, out ilen, out maxlen);
            if (num == -1)
            {
                this.dgData2.Columns[7].HeaderText = (Session["LanguageEn"] == "en-US") ? "Update failed！The no. of characters exceeds " : "更新失敗,超過最大字符數 " + maxlen.ToString() + "！";
                this.dgData2.Columns[7].HeaderStyle.ForeColor = Color.Red;
                this.dgData2.UpdateAfterCallBack = true;
            }
            else
            {
                SmsSchContents contents = new SmsSchContents();
                SmsSchContentData data = contents.LoadSmsSchContentByID(text);
                DataRow row = data.Tables[0].Rows[0];
                row["STATUS"] = str2;
                row["CTITLE"] = strTempTitle;
                row["CSMSMSG"] = strTemp;
                row["IMSGLEN"] = ilen;
                row["ISMSMSGNO"] = num;
                row["CSENDER"] = this.Context.User.Identity.Name.ToUpper();
                row["CREATE_DATE"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                string str5 = "";
                if (str2 == "Normal")
                {
                    SmsSchContentData data2 = contents.LoadSchDataByStatusAndSender(this.Context.User.Identity.Name);
                    foreach (DataRow row2 in data2.Tables[0].Select())
                    {
                        row2.BeginEdit();
                        row2["STATUS"] = "Suspend";
                        row2.EndEdit();
                    }
                    contents.UpdateSmsSchContent(data2);
                    str5 = "並設為默認";
                }
                if (contents.UpdateSmsSchContent(data))
                {
                    this.dgData2.Columns[7].HeaderText = (Session["LanguageEn"] == "en-US") ? "Update success！" : "更新成功!"; //"更新成功";
                    this.dgData2.Columns[7].HeaderStyle.ForeColor = Color.Red;
                    Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  更新預設短訊,標題:" + strTitle + " 至 " + strTempTitle + "; " + "內容: " + str4 + " 至 " + strTemp + " " + str5 + "！");
                }
                else
                {
                    this.dgData2.Columns[7].HeaderText = (Session["LanguageEn"] == "en-US") ? "Update failed！" : "更新失敗!";// "更新失敗";
                    this.dgData2.Columns[7].HeaderStyle.ForeColor = Color.Red;
                }
                this.dgData2.Columns[8].HeaderText = "";
                this.dgData2.UpdateAfterCallBack = true;
                this.lbmsgRP.Text = "";
                this.lbmsgRP.UpdateAfterCallBack = true;
                this.GetSmsSchData();
            }
        }

        private void dgSchedule_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgSchedule.EditItemIndex = -1;
            this.GetSmsScheduleData();
        }

        private void dgSchedule_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgSchedule.EditItemIndex = -1;
            SmsScheduleData data = new SmsScheduleData();
            string text = ((Anthem.Label)this.dgSchedule.Items[e.Item.ItemIndex].FindControl("lbBatchidD")).Text;
            data = new SmsSchedules().LoadGroupByName(text);
            DataRow row = data.Tables[0].Rows[0];
            row["STATUS"] = "D";
            row["CREATE_DATE"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (new SmsSchedules().UpdateSchedule(data))
            {
                this.lbMsgSch.Text = (Session["LanguageEn"] == "en-US") ? "Upload success ！" : "刪除預設發送成功 ！" ;//"刪除預設發送成功!";
                Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser.Text + ")  刪除 " + text + " 預設發送! ");
            }
            else
            {
                this.lbMsgSch.Text = (Session["LanguageEn"] == "en-US") ? "Upload failed ！" : "刪除預設發送失敗 ！";// "刪除預設發送失敗!";
            }
            this.lbMsgSch.UpdateAfterCallBack = true;
            this.GetSmsScheduleData();
        }

        private void dgSchedule_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgSchedule.EditItemIndex = e.Item.ItemIndex;
            this.GetSmsScheduleData();
        }

        private void dgSchedule_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            for (int i = 0; i < this.dgSchedule.Items.Count; i++)
            {
                if ((((Anthem.Label)this.dgSchedule.Items[i].FindControl("lbdgSTATUS")).Text == "C") || (((Anthem.Label)this.dgSchedule.Items[i].FindControl("lbdgSTATUS")).Text == "D"))
                {
                    this.dgSchedule.Items[i].Cells[6].Visible = false;
                    this.dgSchedule.Items[i].Cells[7].Visible = false;
                }
            }
        }

        private void dgSchedule_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgSchedule.CurrentPageIndex = e.NewPageIndex;
            SmsScheduleData data = (SmsScheduleData)this.Session["smsschdata"];
            this.dgSchedule.DataSource = data.Tables["SMS_SCHEDULE"].DefaultView;
            this.dgSchedule.PageSize = AppFlag.iPageSize;
            this.dgSchedule.DataBind();
            this.dgSchedule2.Visible = false;
            this.dgSchedule2.UpdateAfterCallBack = true;
            this.dgSchedule.Visible = true;
            this.dgSchedule.UpdateAfterCallBack = true;
        }

        private void dgSchedule_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgSchedule.EditItemIndex = -1;
            SmsScheduleData data = new SmsScheduleData();
            string text = ((Anthem.Label)this.dgSchedule.Items[e.Item.ItemIndex].FindControl("lbdgCBATCHID")).Text;
            string str2 = ((Anthem.Label)this.dgSchedule.Items[e.Item.ItemIndex].FindControl("lbdgOldSendDate")).Text;
            string str3 = Convert.ToDateTime(((Anthem.TextBox)this.dgSchedule.Items[e.Item.ItemIndex].FindControl("txtdgSendDate")).Text).ToString("yyyy-MM-dd HH:mm");
            data = new SmsSchedules().LoadGroupByName(text);
            DataRow row = data.Tables[0].Rows[0];
            row["CSEND_DATE"] = Convert.ToDateTime(((Anthem.TextBox)this.dgSchedule.Items[e.Item.ItemIndex].FindControl("txtdgSendDate")).Text).ToString("yyyy-MM-dd HH:mm");
            row["CREATE_DATE"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (new SmsSchedules().UpdateSchedule(data))
            {
                Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser.Text + ")  更新 " + text + " 預設發送時間 " + str2 + " 至 " + str3);
                this.lbMsgSch.Text = (Session["LanguageEn"] == "en-US") ? "Update success！" :  "更新發送時間成功!";  //"更新發送時間成功!";
            }
            else
            {
                this.lbMsgSch.Text = (Session["LanguageEn"] == "en-US") ? "Update failed！" : "更新發送時間失敗!"; //"更新發送時間失敗!";
            }
            this.lbMsgSch.UpdateAfterCallBack = true;
            this.GetSmsScheduleData();
        }

        private void dgSchedule2_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgSchedule2.EditItemIndex = -1;
        }

        private void dgSchedule2_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgSchedule2.EditItemIndex = e.Item.ItemIndex;
        }

        private void dgSchedule2_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            SmsSchedules schedules = new SmsSchedules();
            for (int i = 0; i < this.dgSchedule2.Items.Count; i++)
            {
                string batchid = ((Anthem.Label)this.dgSchedule2.Items[i].FindControl("lbdgSchedule2Batchid")).Text.Trim();
                if (schedules.GetSchSmsStatusbyBatchid(batchid) != "N")
                {
                    this.dgSchedule2.Items[i].Cells[9].Visible = false;
                }
            }
        }

        private void dgSchedule2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgSchedule2.CurrentPageIndex = e.NewPageIndex;
            SmsMsgSchData data = (SmsMsgSchData)this.Session["smssch2data"];
            this.dgSchedule2.DataSource = data.Tables["SMS_MSG_SCH"].DefaultView;
            this.dgSchedule2.PageSize = AppFlag.iPageSize;
            this.dgSchedule2.DataBind();
            this.dgSchedule.Visible = false;
            this.dgSchedule.UpdateAfterCallBack = true;
            this.dgSchedule2.Visible = true;
            this.dgSchedule2.UpdateAfterCallBack = true;
        }

        private void dgSmsData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgSmsData.CurrentPageIndex = e.NewPageIndex;
            try
            {
                SmsMsgHistData data = (SmsMsgHistData)this.Session["smshistdata"];
                this.dgSmsData.DataSource = data.Tables["SMS_MSG_HIST"].DefaultView;
                this.dgSmsData.PageSize = AppFlag.iPageSize;
                this.dgSmsData.DataBind();
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
            }
            this.dgSmsData.UpdateAfterCallBack = true;
        }

        private void dgSmsDataCall_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgSmsDataCall.CurrentPageIndex = e.NewPageIndex;
            SmsMsgHistData data = (SmsMsgHistData)this.Session["smscalldata"];
            this.dgSmsDataCall.DataSource = data.Tables["SMS_MSG_HIST"].DefaultView;
            this.dgSmsDataCall.PageSize = AppFlag.iPageSize;
            this.dgSmsDataCall.DataBind();
            this.dgSmsDataCall.UpdateAfterCallBack = true;
        }

        private void dplUser2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnDetailSch.Text = Session["LanguageEn"] == "zh-HK" ? "詳情" : "Detail"; //"詳情";
            this.btnDetailSch.UpdateAfterCallBack = true;
            this.dgSchedule.Visible = true;
            this.dgSchedule2.Visible = false;
            this.dgSchedule.UpdateAfterCallBack = true;
            this.dgSchedule2.UpdateAfterCallBack = true;
            this.GetSmsScheduleData();
            this.GetSchedule2Details();
        }

        private void dplUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetSmsHisData();
        }

        private void dplUsersCall_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetSmsCallData();
        }

        private void GetdplUserData(Anthem.DropDownList dplname)
        {
            UserData userDataBy;
            string name = this.Context.User.Identity.Name;
            if (Users.UserExtraGroup(name))
            {
                userDataBy = new Users().GetUserDataBy(" where USER_RIGHT='" + AppFlag.CentaSmsExtra + "'");
                dplname.DataSource = userDataBy.Tables[0].DefaultView;
                dplname.DataTextField = "USER_ID";
                dplname.DataBind();
                dplname.Items.Insert(0, "All");
                ListItem item = dplname.Items.FindByText(name);
                dplname.ClearSelection();
                item.Selected = true;
            }
            else if (Users.UserAdminCheck(name))
            {
                userDataBy = new Users().GetUserDataBy("");
                dplname.DataSource = userDataBy.Tables[0].DefaultView;
                dplname.DataTextField = "USER_ID";
                dplname.DataBind();
                dplname.Items.Insert(0, "All");
                ListItem item2 = dplname.Items.FindByText(name);
                dplname.ClearSelection();
                item2.Selected = true;
            }
            else
            {
                dplname.SelectedItem.Text = name;
            }
            if (Users.UserAdminCheck(name) || Users.UserExtraGroup(name))
            {
                dplname.Enabled = true;
            }
            else
            {
                dplname.Enabled = false;
            }
        }

        private void GetSchedule2Details()
        {
            SmsMsgSchData allSmsSchData;
            if (this.dplUser2.SelectedItem.Text.Trim() == "All")
            {
                allSmsSchData = new SmsMsgSchs().GetAllSmsSchData(" ");
            }
            else
            {
                allSmsSchData = new SmsMsgSchs().GetAllSmsSchData(" where csender ='" + this.dplUser2.SelectedItem.Text.Trim() + "'  ");
            }
            this.Session["smssch2data"] = allSmsSchData;
        }

        private void GetSmsCallData()
        {
            SmsMsgHistData allSmsHistData;
            this.dgSmsDataCall.CurrentPageIndex = 0;
            if (this.dplUsersCall.SelectedItem.Text.Trim() == "All")
            {
                allSmsHistData = new SmsMsgHists().GetAllSmsHistData("where caller<>'' ");
            }
            else
            {
                allSmsHistData = new SmsMsgHists().GetAllSmsHistData(" where caller ='" + this.dplUsersCall.SelectedItem.Text.Trim() + "'");
            }
            this.dgSmsDataCall.DataSource = allSmsHistData.Tables["SMS_MSG_HIST"].DefaultView;
            this.dgSmsDataCall.PageSize = AppFlag.iPageSize;
            this.dgSmsDataCall.DataBind();
            this.Session["smscalldata"] = allSmsHistData;
            this.dgSmsDataCall.UpdateAfterCallBack = true;
        }

        private void GetSmsHisData()
        {
            SmsMsgHistData allSmsHistData;
            this.dgSmsData.CurrentPageIndex = 0;
            if (Users.UserExtraGroup(this.Context.User.Identity.Name))
            {
                if (this.dplUsers.SelectedItem.Text.Trim() == "All")
                {
                    allSmsHistData = new SmsMsgHists().GetAllSmsHistData(" where   CBATCHID like 'B%' and  CALLER<>'' ");
                }
                else
                {
                    allSmsHistData = new SmsMsgHists().GetAllSmsHistData(" where csender ='" + this.dplUsers.SelectedItem.Text.Trim() + "' and  CBATCHID like 'B%' ");
                }
            }
            else if (this.dplUsers.SelectedItem.Text.Trim() == "All")
            {
                allSmsHistData = new SmsMsgHists().GetAllSmsHistData(" where   CBATCHID like 'B%' ");
            }
            else
            {
                allSmsHistData = new SmsMsgHists().GetAllSmsHistData(" where csender ='" + this.dplUsers.SelectedItem.Text.Trim() + "' and  CBATCHID like 'B%' ");
            }

            try
            {
                using (OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn))
                {
                    connection.Open();
                    foreach (DataRow dr in allSmsHistData.Tables[0].Rows)
                    {
                        string selectString = "select count(*) from  " + AppFlag.SMS_MSG_RECEIVER_TABLE + " where  CBATCHID='" + dr[0].ToString() + "'";
                        OleDbCommand cmd = new OleDbCommand(selectString, connection);
                        dr.BeginEdit();
                        dr[10] = (int)cmd.ExecuteScalar();
                        dr.EndEdit();
                    }
                    connection.Close();
                }
            }
            catch
            {

            }

            this.dgSmsData.DataSource = allSmsHistData.Tables["SMS_MSG_HIST"].DefaultView;
            this.dgSmsData.PageSize = AppFlag.iPageSize;
            this.dgSmsData.DataBind();
            this.Session["smshistdata"] = allSmsHistData;
            this.dgSmsData.UpdateAfterCallBack = true;
        }

        private void GetSmsSchData()
        {
            this.dgSmsData.CurrentPageIndex = 0;
            SmsSchContentData data = new SmsSchContents().LoadAllSchData();
            this.dgData2.DataSource = data.Tables["SMS_MSGSCH_CONTENT"].DefaultView;
            this.dgData2.PageSize = AppFlag.iPageSize;
            this.dgData2.DataBind();
            this.Session["smsschcontent"] = data;
            this.dgData2.UpdateAfterCallBack = true;
        }

        private void GetSmsSchedule2Data()
        {
            try
            {
                SmsMsgSchData allSmsSchData;
                if (this.btnDetailSch.Text == (Session["LanguageEn"] == "zh-HK" ? "詳情" : "Detail"))
                {
                    if (this.dplUser2.SelectedItem.Text.Trim() == "All")
                    {
                        allSmsSchData = new SmsMsgSchs().GetAllSmsSchData("");
                    }
                    else
                    {
                        allSmsSchData = new SmsMsgSchs().GetAllSmsSchData(" where csender ='" + this.dplUser2.SelectedItem.Text.Trim() + "'");
                    }

                }
                else if (this.dplUser2.SelectedItem.Text.Trim() == "All")
                {
                    allSmsSchData = new SmsMsgSchs().GetAllSmsSchData(" where   '" + this.txtStartDate2.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDate2.Text.Trim() + " 23:59:59'");
                }
                else
                {
                    allSmsSchData = new SmsMsgSchs().GetAllSmsSchData(" where csender ='" + this.dplUser2.SelectedItem.Text.Trim() + "' AND '" + this.txtStartDate2.Text.Trim() + " 00:00:01'<= create_date AND  create_date<='" + this.txtEndDate2.Text.Trim() + " 23:59:59'");
                }

                using (OleDbConnection connection = new OleDbConnection(AppFlag.CENTASMSMAININTEConn))
                {
                    connection.Open();
                    OleDbCommand cmd;
                    using (FbConnection connection2 = new FbConnection(AppFlag.CENTASMSINTEConn))
                    {
                        connection2.Open();
                        FbCommand cmd2;
                        foreach (DataRow dr in allSmsSchData.Tables[0].Rows)
                        {
                            string selectString = "select count(*) from  SMS_MSG_HIST where  CBATCHID='" + dr[0].ToString() + "'";

                            cmd2 = new FbCommand(selectString, connection2);
                            if ((int)cmd2.ExecuteScalar() == 0)
                            {
                                dr.BeginEdit();
                                dr[9] = -1;// Convert.ToInt32(dr["IMSGLEN"]) * Convert.ToInt32(dr["ISMSMSGNO"]);
                                dr.EndEdit();
                            }
                            else
                            {
                                selectString = "select count(*) from  " + AppFlag.SMS_MSG_RECEIVER_TABLE + " where  CBATCHID='" + dr[0].ToString() + "'";
                                cmd = new OleDbCommand(selectString, connection);
                                dr.BeginEdit();
                                //dr[9] = Convert.ToInt32(dr["IMSGLEN"]) * Convert.ToInt32(dr["ISMSMSGNO"]) - (int)cmd.ExecuteScalar();
                                dr[9] = (int)cmd.ExecuteScalar();
                                dr.EndEdit();
                            }
                        }
                        connection2.Close();
                    }
                    connection.Close();
                }

                this.Session["smssch2data"] = allSmsSchData;
                this.dgSchedule2.DataSource = allSmsSchData.Tables["SMS_MSG_SCH"].DefaultView;
                this.dgSchedule2.CurrentPageIndex = 0;
                this.dgSchedule2.PageSize = AppFlag.iPageSize;
                this.dgSchedule2.DataBind();
                this.dgSchedule.Visible = false;
                this.dgSchedule.UpdateAfterCallBack = true;
                this.dgSchedule2.Visible = true;
                this.dgSchedule2.UpdateAfterCallBack = true;
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
            }
        }

        private void GetSmsScheduleData()
        {
            try
            {
                SmsScheduleData allSmsScheduleData;
                if (this.dplUser2.SelectedItem.Text.Trim() == "All")
                {
                    allSmsScheduleData = new SmsSchedules().GetAllSmsScheduleData("");
                }
                else
                {
                    allSmsScheduleData = new SmsSchedules().GetAllSmsScheduleData(" where csender ='" + this.dplUser2.SelectedItem.Text.Trim() + "'");
                }
                this.dgSchedule.DataSource = allSmsScheduleData.Tables["SMS_SCHEDULE"].DefaultView;
                this.dgSchedule.PageSize = AppFlag.iPageSize;
                this.dgSchedule.DataBind();
                this.dgSchedule.UpdateAfterCallBack = true;
                this.Session["smsschdata"] = allSmsScheduleData;
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
            }
        }

        private void InitializeComponent()
        {
            this.btnAddMsg.Click += new EventHandler(this.btnAddMsg_Click);
            this.SaveLogin.Click += new EventHandler(this.SaveLogin_Click);
            this.lstGroup.SelectedIndexChanged += new EventHandler(this.lstGroup_SelectedIndexChanged);
            this.lstGroupMember.SelectedIndexChanged += new EventHandler(this.lstGroupMember_SelectedIndexChanged);
            this.btnCount.Click += new EventHandler(this.btnCount_Click);
            this.rbSendontime.CheckedChanged += new EventHandler(this.rbSendontime_CheckedChanged);
            this.rbSendbyTime.CheckedChanged += new EventHandler(this.rbSendbyTime_CheckedChanged);
            this.btnSend.Click += new EventHandler(this.btnSend_Click);
            this.btnCannel.Click += new EventHandler(this.btnCannel_Click);
            this.dplUsers.SelectedIndexChanged += new EventHandler(this.dplUsers_SelectedIndexChanged);
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);
            this.btnExportSms1.Click += new EventHandler(this.btnExportSms1_Click);
            this.btnExportSms2.Click += new EventHandler(this.btnExportSms2_Click);
            this.btnExportSms3.Click += new EventHandler(this.btnExportSms3_Click);
            this.btnLoginOut.Click += new EventHandler(this.btnLoginOut_Click);
            this.dgSmsData.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgSmsData_PageIndexChanged);
            this.dplUser2.SelectedIndexChanged += new EventHandler(this.dplUser2_SelectedIndexChanged);
            this.btnSearchSch.Click += new EventHandler(this.btnSearchSch_Click);
            this.btnDetailSch.Click += new EventHandler(this.btnDetailSch_Click);
            this.dgSchedule.DeleteCommand += new DataGridCommandEventHandler(this.dgSchedule_DeleteCommand);
            this.dgSchedule.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgSchedule_PageIndexChanged);
            this.dgSchedule.UpdateCommand += new DataGridCommandEventHandler(this.dgSchedule_UpdateCommand);
            this.dgSchedule.CancelCommand += new DataGridCommandEventHandler(this.dgSchedule_CancelCommand);
            this.dgSchedule2.CancelCommand += new DataGridCommandEventHandler(this.dgSchedule2_CancelCommand);
            this.dgSchedule.ItemDataBound += new DataGridItemEventHandler(this.dgSchedule_ItemDataBound);
            this.dgSchedule2.ItemDataBound += new DataGridItemEventHandler(this.dgSchedule2_ItemDataBound);
            this.dgSchedule.EditCommand += new DataGridCommandEventHandler(this.dgSchedule_EditCommand);
            this.dgSchedule2.EditCommand += new DataGridCommandEventHandler(this.dgSchedule2_EditCommand);
            this.dgSchedule2.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgSchedule2_PageIndexChanged);
            this.dplUsersCall.SelectedIndexChanged += new EventHandler(this.dplUsersCall_SelectedIndexChanged);
            this.btnSearchCall.Click += new EventHandler(this.btnSearchCall_Click);
            this.dgSmsDataCall.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgSmsDataCall_PageIndexChanged);
            this.dgData2.ItemCreated += new DataGridItemEventHandler(this.dgData2_ItemCreated);
            this.dgData2.ItemDataBound += new DataGridItemEventHandler(this.dgData2_ItemDataBound);
            this.dgData2.DeleteCommand += new DataGridCommandEventHandler(this.dgData2_DeleteCommand);
            this.dgData2.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgData2_PageIndexChanged);
            this.dgData2.UpdateCommand += new DataGridCommandEventHandler(this.dgData2_UpdateCommand);
            this.dgData2.CancelCommand += new DataGridCommandEventHandler(this.dgData2_CancelCommand);
            this.dgData2.EditCommand += new DataGridCommandEventHandler(this.dgData2_EditCommand);
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            this.Submit2.ServerClick += new EventHandler(this.Submit2_ServerClick);
            this.dplAgentSmsNum.SelectedIndexChanged += new EventHandler(this.dpldplAgentSmsNum_SelectedIndexChanged);
            this.btnAgentSend.Click += new EventHandler(this.btnAgentSend_Click);
            this.subUploadAgentSms.ServerClick += new EventHandler(this.subUploadAgentSms_ServerClick);
            this.dplUploadAgentSmsNum.SelectedIndexChanged += new EventHandler(this.dplUploadAgentSmsNum_SelectedIndexChanged);

            base.Load += new EventHandler(this.Page_Load);
        }
        private void subUploadAgentSms_ServerClick(object sender, EventArgs e)
        {   //string SmsUploadFolder = AppFlag.CentaSmsBatchUploadFolder ;
            string strFileName = this.btnUploadMode3.PostedFile.FileName.ToUpper();
            string strName = Path.GetFileName(strFileName).ToUpper();
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName;
             
            bool bUpload = true;
            string str4 = "";
            if (strName != "" && txtUploadAgentSmsContent.Text.Trim() != "")
            {
                try
                {
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder);
                    }
                    if (File.Exists(path))
                    {

                        if (strFileName.LastIndexOf("XLS") == strFileName.Length - 3)
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName.Substring(0, strName.LastIndexOf(".XLS")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".XLS";
                        }
                        else if (strFileName.LastIndexOf("XLSX") == strFileName.Length - 4)
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName.Substring(0, strName.LastIndexOf(".XLSX")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".XLSX";
                        }
                        else
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName + "_" + DateTime.Now.ToString("MMddHHmm");
                        }
                    }
                    this.btnUploadMode3.PostedFile.SaveAs(path);

                }
                catch (Exception exception)
                {
                    bUpload = false;
                    str4 = strName + " Error: " + exception.ToString();
                }
                Files.CicsWriteLog("\r\n" + DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  開始上載Agent Sms " + strName + "！");
                if (bUpload)
                {
                    try
                    {
                        if (this.doSmsAgentLoad.State != 1)
                        {
                            SmsActions actions = new SmsActions();
                            SmsActionData data = new SmsActionData();
                            string strStartTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
                            DataRow row = data.Tables["SMS_ACTIONS"].NewRow();
                            row["CSMS_ACTION_CONTENT"] = strName;
                            row["CSMS_ACTION_TYPE"] = "AGENT";
                            row["CSMS_ACTION_STATUS"] = "進行中";
                            row["CACTION_HANDLER"] = this.Context.User.Identity.Name;
                            row["ACTION_STARTTIME"] = strStartTime;
                            row["ACTION_ENDTIME"] = "";
                            row["ACTION_REMARKS"] = "";
                            data.Tables["SMS_ACTIONS"].Rows.Add(row);
                            if (actions.InsertAction(data))
                            {
                                this.doSmsAgentLoad.strcondtion = strStartTime;
                                this.doSmsAgentLoad.dolbUploadResult = "";
                                this.doSmsAgentLoad.dolbUser = this.Context.User.Identity.Name;
                                this.doSmsAgentLoad.FileName = strName;
                                this.doSmsAgentLoad.dobtnUploadMode = path;
                                this.doSmsAgentLoad.doSmsContent = this.txtUploadAgentSmsContent.Text.Trim();
                                this.div_load.Visible = true;
                                this.Page.RegisterStartupScript("", "<script>location.href=location.href;</script>");
                                this.doSmsAgentLoad.Runload();
                               // this.subUploadAgentSms.Disabled = true;
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  Uploaded Agent Sms " + strName + " Error: " + exp.ToString());
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  停止上載Agent Sms " + strName + "！");
                    }
                }
                else
                {
                    this.lbUploadResult3.Text =  (Session["LanguageEn"] == "en-US") ? "Upload failed ！" : "上載失敗 ！" ;//"上載失敗 ！";
                    this.doSmsAgentLoad.dolbUploadResult = (Session["LanguageEn"] == "en-US") ? "Upload failed ！" : "上載失敗 ！" ;// "上載失敗 ！";
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  Upload Agent Sms" + str4);
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  上載失敗,停止上載Agent Sms " + strName + "！");
                    this.lbUploadResult3.UpdateAfterCallBack = true;
                }
                 this.lbrfvUpload3.Visible = false;
                this.lbrfvUpload3.UpdateAfterCallBack = true;
            }
            else
            {
                this.lbrfvUpload3.Visible = true;
                 this.lbrfvUpload3.UpdateAfterCallBack = true;
                this.lbUploadResult3.Text = "";
                this.lbUploadResult3.UpdateAfterCallBack = true;
            }

        }
        private void btnAgentSend_Click(object sender, EventArgs e)
        {
            SmsMsgs smsMsgs = new SmsMsgs();
            int ilen = 0;
            int maxlen = 0;
            string msg = txtAgentSmsContent.Text.Trim();
            string dateNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            int ipart = ConfigManager.CheckSmsData(msg, out ilen, out maxlen);
            string strBatchid = "";
            string strUser = this.Context.User.Identity.Name;
            bool bResult = smsMsgs.CreateSmsMsg(msg, "B", 0, dateNow, new ArrayList { txtSmsPhone.Text.Trim() }, strUser, "", ilen, ipart, 1, out strBatchid);

            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + strUser + ") " + strBatchid + "  \r\n 短訊內容：\r\n " + msg + "\r\n Unicode Msg: \r\n " + BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(msg)).Replace("-", ""));
            Files.CicsWriteLog(" 發送號碼： " + txtSmsPhone.Text.Trim());
            Files.CicsWriteLog(" 轉台號碼： " + txtAgentPhone.Text.Trim());
            if (ConfigManager.SendWinMsg(AppFlag.WinMsgID))
            {
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + strUser + ") 發送SMS " + "成功! （RemoteService）");
                this.lbAgentSmsResult.Text = "發送SMS " + "成功! （RemoteService）";
            }
            else
            {
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + strUser + ") 發送SMS " + "成功! （No RemoteService）");
                this.lbAgentSmsResult.Text = "發送SMS " + "成功! （No RemoteService）"; ;
            }
            // this.txtAgentSmsContent.Text = txtAgentSmsContent.Text.Replace(txtSmsPhone.Text.Trim(), "(MRT)");
            this.txtAgentSmsContent.Text = "";
            this.dplAgentSmsNum.SelectedIndex = 0;
            this.txtSmsPhone.Text = "";
            this.txtAgentPhone.Text = "";
            this.txtSaleName .Text = "";
            this.txtSalePhone .Text = "";
            this.lbAgentSmsResult.UpdateAfterCallBack = true;
            this.txtAgentSmsContent.UpdateAfterCallBack = true;
            this.dplAgentSmsNum.UpdateAfterCallBack = true;
            this.txtSmsPhone.UpdateAfterCallBack = true;
            this.txtAgentPhone.UpdateAfterCallBack = true;
            this.txtSalePhone.UpdateAfterCallBack = true;
            this.txtSaleName.UpdateAfterCallBack = true;
        }

        private void Submit2_ServerClick(object sender, EventArgs e)
        {
            //string SmsUploadFolder = AppFlag.CentaSmsBatchUploadFolder ;
            string strFileName = this.btnUploadMode2.PostedFile.FileName.ToUpper();
            string strName = Path.GetFileName(strFileName).ToUpper();
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName;


            bool bUpload = true;
            string str4 = "";
            if (strName != "")
            {
                try
                {
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder);
                    }
                    if (File.Exists(path))
                    {

                        if (strFileName.LastIndexOf("XLSX") == strFileName.Length - 4)
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName.Substring(0, strName.LastIndexOf(".XLSX")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".XLSX";
                        }
                        else if (strFileName.LastIndexOf("XLS") == strFileName.Length - 3)
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName.Substring(0, strName.LastIndexOf(".XLS")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".XLS";
                        }

                        else
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName + "_" + DateTime.Now.ToString("MMddHHmm");
                        }
                    }
                    this.btnUploadMode2.PostedFile.SaveAs(path);

                }
                catch (Exception exception)
                {
                    bUpload = false;
                    str4 = strName + " Error: " + exception.ToString();
                }
                Files.CicsWriteLog("\r\n" + DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  開始上載Action " + strName + "！");
                if (bUpload)
                {
                    try
                    {
                        if (this.doSmsActionLoad.State != 1)
                        {
                            SmsActions actions = new SmsActions();
                            SmsActionData data = new SmsActionData();
                            string strStartTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
                            DataRow row = data.Tables["SMS_ACTIONS"].NewRow();
                            row["CSMS_ACTION_CONTENT"] = strName;
                            row["CSMS_ACTION_TYPE"] = "ACTION";
                            row["CSMS_ACTION_STATUS"] = "進行中";
                            row["CACTION_HANDLER"] = this.Context.User.Identity.Name;
                            row["ACTION_STARTTIME"] = strStartTime;
                            row["ACTION_ENDTIME"] = "";
                            row["ACTION_REMARKS"] = "";
                            data.Tables["SMS_ACTIONS"].Rows.Add(row);
                            if (actions.InsertAction(data))
                            {
                                this.doSmsActionLoad.strcondtion = strStartTime;
                                this.doSmsActionLoad.dolbUploadResult = "";
                                this.doSmsActionLoad.dolbUser = this.Context.User.Identity.Name;
                                this.doSmsActionLoad.FileName = strName;
                                this.doSmsActionLoad.dobtnUploadMode = path;

                                this.div_load.Visible = true;
                                this.Page.RegisterStartupScript("", "<script>location.href=location.href;</script>");
                                this.doSmsActionLoad.Runload();
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  Uploaded Action " + strName + " Error: " + exp.ToString());
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  停止上載Action " + strName + " ！");
                    }
                }
                else
                {
                    this.doSmsActionLoad.dolbUploadResult = "上載Action失敗 ！";
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  Upload Action" + str4);
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  上載失敗,停止上載Action " + strName + "！");
                    this.lbUploadResult2.UpdateAfterCallBack = true;
                }
                this.lbrfvUpload2.Visible = false;
                this.lbrfvUpload2.UpdateAfterCallBack = true;
            }
            else
            {
                this.lbrfvUpload2.Visible = true;
                this.lbrfvUpload2.UpdateAfterCallBack = true;
                this.lbUploadResult2.Text = "";
                this.lbUploadResult2.UpdateAfterCallBack = true;
            }
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            //string SmsUploadFolder = AppFlag.CentaSmsBatchUploadFolder ;
            string strFileName = this.btnUploadMode.PostedFile.FileName.ToUpper();
            string strName = Path.GetFileName(strFileName).ToUpper();
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName;


            bool bUpload = true;
            string str4 = "";
            if (strName != "")
            {
                try
                {
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder);
                    }
                    if (File.Exists(path))
                    {

                        if (strFileName.LastIndexOf("XLS") == strFileName.Length - 3)
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName.Substring(0, strName.LastIndexOf(".XLS")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".XLS";
                        }
                        else if (strFileName.LastIndexOf("XLSX") == strFileName.Length - 4)
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName.Substring(0, strName.LastIndexOf(".XLSX")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".XLSX";
                        }
                        else
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + strName + "_" + DateTime.Now.ToString("MMddHHmm");
                        }
                    }
                    this.btnUploadMode.PostedFile.SaveAs(path);

                }
                catch (Exception exception)
                {
                    bUpload = false;
                    str4 = strName + " Error: " + exception.ToString();
                }
                Files.CicsWriteLog("\r\n" + DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  開始上載Sms " + strName + "！");
                if (bUpload)
                {
                    try
                    {
                        if (this.doSmsLoad.State != 1)
                        {
                            SmsActions actions = new SmsActions();
                            SmsActionData data = new SmsActionData();
                            string strStartTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
                            DataRow row = data.Tables["SMS_ACTIONS"].NewRow();
                            row["CSMS_ACTION_CONTENT"] = strName;
                            row["CSMS_ACTION_TYPE"] = "SMS";
                            row["CSMS_ACTION_STATUS"] = "進行中";
                            row["CACTION_HANDLER"] = this.Context.User.Identity.Name;
                            row["ACTION_STARTTIME"] = strStartTime;
                            row["ACTION_ENDTIME"] = "";
                            row["ACTION_REMARKS"] = "";
                            data.Tables["SMS_ACTIONS"].Rows.Add(row);
                            if (actions.InsertAction(data))
                            {
                                this.doSmsLoad.strcondtion = strStartTime;
                                this.doSmsLoad.dolbUploadResult = "";
                                this.doSmsLoad.dolbUser = this.Context.User.Identity.Name;
                                this.doSmsLoad.FileName = strName;
                                this.doSmsLoad.dobtnUploadMode = path;
                                this.doSmsLoad.DoAction = this.chkAction.Checked;
                                this.div_load.Visible = true;
                                this.Page.RegisterStartupScript("", "<script>location.href=location.href;</script>");
                                this.doSmsLoad.Runload();
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  Uploaded Sms " + strName + " Error: " + exp.ToString());
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  停止上載Sms " + strName + "！");
                    }
                }
                else
                {
                    this.doSmsLoad.dolbUploadResult = (Session["LanguageEn"] == "en-US") ? "Upload failed！" : "上載失敗" ;// "上載失敗 ！";
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  Upload Sms" + str4);
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  上載失敗,停止上載Sms " + strName + "！");
                    this.lbUploadResult.UpdateAfterCallBack = true;
                }
                this.lbrfvUpload.Visible = false;
                this.lbrfvUpload.UpdateAfterCallBack = true;
            }
            else
            {
                this.lbrfvUpload.Visible = true;
                this.lbrfvUpload.UpdateAfterCallBack = true;
                this.lbUploadResult.Text = "";
                this.lbUploadResult.UpdateAfterCallBack = true;
            }
        }

        private void lstGroupMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string username = this.Context.User.Identity.Name;
                int selectedIndex = this.lstGroupMember.SelectedIndex;
                string type = this.lstGroupMember.SelectedItem.Value;
                string type2 = this.lstGroupMember.SelectedItem.Text;
                ListItem item = null;

                GroupData groupDataByType = new GroupData();
                GroupMemberData GroupMemberData = new GroupMemberData();

                if (this.lstGroupMember.SelectedItem.Text.IndexOf("▲") > -1)
                {
                    item = this.lstGroupMember.SelectedItem;
                    item.Text = this.lstGroupMember.SelectedItem.Text.Replace("▲", "▼");
                    // if (this.lstGroupMember.SelectedItem.Text.IndexOf("私人組別") > -1)
                    if (this.lstGroupMember.SelectedItem.Text.IndexOf( (Session["LanguageEn"] == "zh-HK" ? "私人組別" : "Private")) > -1)
                    {
                        for (int j = this.lstGroupMember.SelectedIndex; j < this.lstGroupMember.Items.Count - this.lstGroupMember.SelectedIndex; )
                        {
                           // if (this.lstGroupMember.Items[j + 1].Text.IndexOf("共享組別") < 0)
                            if (this.lstGroupMember.Items[j + 1].Text.IndexOf((Session["LanguageEn"] == "zh-HK" ? "共享組別" : "Share")) < 0)
                             {
                                this.lstGroupMember.Items.Remove(this.lstGroupMember.Items[j + 1]);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                   // else if (this.lstGroupMember.SelectedItem.Text.IndexOf("共享組別") > -1)
                     else if (this.lstGroupMember.SelectedItem.Text.IndexOf( (Session["LanguageEn"] == "zh-HK" ? "共享組別" : "Share")) > -1)
                    {
                        for (int j = this.lstGroupMember.SelectedIndex; j < this.lstGroupMember.Items.Count - 1; )
                        {
                            this.lstGroupMember.Items.Remove(this.lstGroupMember.Items[j + 1]);
                        }
                    } 
                    else
                    {
                        //for (int j = this.lstGroupMember.SelectedIndex; j < this.lstGroupMember.Items.Count; )
                        //{
                        //    if (this.lstGroupMember.Items[j+1].Text.IndexOf("←") > 0)
                        //    {
                        //        this.lstGroupMember.Items.Remove(this.lstGroupMember.Items[j+1]);
                        //    }
                        //    else
                        //    {
                        //        break;
                        //    }
                        //}

                        for (int j = this.lstGroupMember.SelectedIndex; j < this.lstGroupMember.Items.Count - 1; )
                        {
                            if (this.lstGroupMember.Items[j + 1].Value.IndexOf (this.lstGroupMember.SelectedItem.Value)==0)
                            {
                                this.lstGroupMember.Items.Remove(this.lstGroupMember.Items[j + 1]);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    this.lstGroupMember.SelectedIndex = -1;
                    this.lstGroupMember.UpdateAfterCallBack = true;
                }
                else if (this.lstGroupMember.SelectedItem.Text.IndexOf("←") > -1)
                {
                    string strMobile ="\r\n"+ this.lstGroupMember.SelectedItem.Text.Trim().Replace("←", "")+"\r\n"; 
                   // this.lbGroupIDContent.Text += strMobile+",";
                    //this.tbNum.Text += strMobile;
                    //this.lbGroupIDContent.UpdateAfterCallBack = true; 
                    this.tbNum.Text = (this.tbNum.Text + strMobile).Replace("\r\n\r\n", "\r\n").Replace("\n\n", "\n").Replace("\n\r\n", "\n");
                    this.tbNum.UpdateAfterCallBack = true;
                }
                else
                {
                    switch (type)
                    {
                        case "S":
                            ///Get Share goup by Name
                            if (Users.UserShareGroup(username))
                            {
                                groupDataByType = new Groups().GetGroupDataByType(type);
                                if (groupDataByType != null)
                                {
                                    foreach (DataRow row in groupDataByType.Tables[0].Select())
                                    {
                                        selectedIndex++;
                                        ListItem item4 = new ListItem(Server.HtmlDecode("&nbsp;&nbsp;&nbsp;") + "▼" + row[1].ToString(), row[0].ToString());
                                        this.lstGroupMember.Items.Insert(selectedIndex, item4);
                                    }
                                    item = this.lstGroupMember.SelectedItem;
                                    item.Text = this.lstGroupMember.SelectedItem.Text.Replace("▼", "▲");
                                }
                            }
                            break;
                        case "P":
                            groupDataByType = new Groups().GetGroupDatabyOwnerAndType(username, "P");
                            if (groupDataByType != null)
                            {
                                foreach (DataRow row in groupDataByType.Tables[0].Select())
                                {
                                    selectedIndex++;
                                    ListItem item4 = new ListItem(Server.HtmlDecode("&nbsp;&nbsp;&nbsp;") + "▼" + row[1].ToString(), row[0].ToString());
                                    this.lstGroupMember.Items.Insert(selectedIndex, item4);
                                }
                                item = this.lstGroupMember.SelectedItem;
                                item.Text = this.lstGroupMember.SelectedItem.Text.Replace("▼", "▲");
                            }
                            break;
                        default:
                            GroupMemberData = new GroupMembers().GetMemberDataByGroupID(type);
                            if (GroupMemberData != null)
                            {
                                foreach (DataRow row in GroupMemberData.Tables[0].Select())
                                {
                                    selectedIndex++;
                                    ListItem item4 = new ListItem(Server.HtmlDecode("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;") + "←" + row["CMOBILENO"].ToString(), row["CGROUP_ID"].ToString() + "-" + row["CMOBILENO"].ToString());
                                    this.lstGroupMember.Items.Insert(selectedIndex, item4);
                                }
                                item = this.lstGroupMember.SelectedItem;
                                item.Text = this.lstGroupMember.SelectedItem.Text.Replace("▼", "▲");
                            }

                            break;
                    }

                    this.lstGroupMember.SelectedIndex = -1;
                    this.lstGroupMember.UpdateAfterCallBack = true;
                }

            }
            catch (Exception EXP)
            {
                string stds = EXP.Message.ToString();
            }
        }

        private void lstGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string username = this.Context.User.Identity.Name;
                int selectedIndex = this.lstGroup.SelectedIndex;
                string type = this.lstGroup.SelectedItem.Value;
                ListItem item = null;

                GroupData groupDataByType = new GroupData();

                if (this.lstGroup.SelectedItem.Text.IndexOf("▲") > -1)
                {
                    item = this.lstGroup.SelectedItem;
                    item.Text = this.lstGroup.SelectedItem.Text.Replace("▲", "▼");

                   // if (this.lstGroup.SelectedItem.Text.IndexOf("私人組別") > -1)
                    if (this.lstGroup.SelectedItem.Text.IndexOf((Session["LanguageEn"] == "zh-HK" ? "私人組別" : "Private")) > -1)
                    {
                        for (int j = this.lstGroup.SelectedIndex; j < this.lstGroup.Items.Count - this.lstGroup.SelectedIndex; )
                        {
                            //if (this.lstGroup.Items[j + 1].Text.IndexOf("共享組別") < 0)
                            if (this.lstGroup.Items[j + 1].Text.IndexOf((Session["LanguageEn"] == "zh-HK" ? "共享組別" : "Share")) < 0)
                            {
                                this.lstGroup.Items.Remove(this.lstGroup.Items[j + 1]);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    //else if (this.lstGroup.SelectedItem.Text.IndexOf("共享組別") > -1)
                    else if (this.lstGroup.SelectedItem.Text.IndexOf((Session["LanguageEn"] == "zh-HK" ? "共享組別" : "Share")) > -1)
                    {
                        for (int j = this.lstGroup.SelectedIndex; j < this.lstGroup.Items.Count - 1; )
                        {
                            this.lstGroup.Items.Remove(this.lstGroup.Items[j + 1]);
                        }
                    }
                    else
                    {

                        for (int j = this.lstGroup.SelectedIndex; j < this.lstGroup.Items.Count - 1; )
                        {
                            if (this.lstGroup.Items[j + 1].Value.IndexOf(this.lstGroup.SelectedItem.Value) == 0)
                            {
                                this.lstGroup.Items.Remove(this.lstGroup.Items[j + 1]);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    this.lstGroup.SelectedIndex = -1;
                    this.lstGroup.UpdateAfterCallBack = true;
                }
                else if (this.lstGroup.SelectedItem.Text.IndexOf("←") > -1)
                {
                    string strGroupID = this.lstGroup.SelectedItem.Value.Replace("-P", "").Replace("-S", "");
                    //string strType = (this.lstGroup.SelectedItem.Value.IndexOf("-P") > -1 ? "(私人組別)" : this.lstGroup.SelectedItem.Value.IndexOf("-S") > -1 ? "(共享組別)" : "");
                    string strType = (this.lstGroup.SelectedItem.Value.IndexOf("-P") > -1 ? "(" + (Session["LanguageEn"] == "zh-HK" ? "私人組別" : "Private") + ")" : this.lstGroup.SelectedItem.Value.IndexOf("-S") > -1 ? "(" + (Session["LanguageEn"] == "zh-HK" ? "共享組別" : "Share") + ")" : "");
                    string strGroup = this.lstGroup.SelectedItem.Text.Trim().Replace("←", "");

                    if (this.lbGroupIDContent.Text.IndexOf(strGroupID + ",") < 0)
                    {
                        this.tbNum.Text = (this.tbNum.Text + "\r\n" + strGroup + strType + "\r\n").Replace("\r\n\r\n", "\r\n").Replace("\n\n", "\n").Replace("\n\r\n", "\n");
                        this.lbGroupIDContent.Text += strGroupID + "," + strGroup + strType + ",";
                    }
                }
                else
                {
                    switch (type)
                    {
                        case "S":
                            ///Get Share goup by Name
                            if (Users.UserShareGroup(username))
                            {
                                groupDataByType = new Groups().GetGroupDataByType(type);
                                if (groupDataByType != null)
                                {
                                    foreach (DataRow row in groupDataByType.Tables[0].Select())
                                    {
                                        selectedIndex++;
                                        ListItem item4 = new ListItem(Server.HtmlDecode("&nbsp;&nbsp;&nbsp;") + "←" + row[1].ToString(), row[0].ToString() + "-" + type);
                                        this.lstGroup.Items.Insert(selectedIndex, item4);
                                    }
                                    item = this.lstGroup.SelectedItem;
                                    item.Text = this.lstGroup.SelectedItem.Text.Replace("▼", "▲");
                                }
                            }
                            break;
                        case "P":
                            groupDataByType = new Groups().GetGroupDatabyOwnerAndType(username, "P");
                            if (groupDataByType != null)
                            {
                                foreach (DataRow row in groupDataByType.Tables[0].Select())
                                {
                                    selectedIndex++;
                                    ListItem item4 = new ListItem(Server.HtmlDecode("&nbsp;&nbsp;&nbsp;") + "←" + row[1].ToString(), row[0].ToString() + "-" + type);
                                    this.lstGroup.Items.Insert(selectedIndex, item4);
                                } 
                                item = this.lstGroup.SelectedItem;
                                item.Text = this.lstGroup.SelectedItem.Text.Replace("▼", "▲");
                            }
                            break;
                        default:

                            break;
                    }

                    this.lstGroup.SelectedIndex = -1;
                    this.lstGroup.UpdateAfterCallBack = true;
                }
                this.tbNum.UpdateAfterCallBack = true;
                this.lbGroupIDContent.UpdateAfterCallBack = true;
            }
            catch (Exception EXP)
            {
                string stds = EXP.Message.ToString();
            }
        //    string str5;
        //    string username = "";
        //    if (Users.UserExtraGroup(this.Context.User.Identity.Name))
        //    {
        //        if (this.Session["Operator"] == null)
        //        {
        //            username = this.lbUser.Text.ToUpper();
        //        }
        //        else
        //        {
        //            username = (string)this.Session["Operator"];
        //        }
        //    }
        //    else
        //    {
        //        username = this.lbUser.Text.ToUpper();
        //    }
        //    if (this.lbMsg.Text.Trim().IndexOf("最大字符") <= -1)
        //    {
        //        this.lbMsg.Text = "";
        //    }
        //    this.lbMsg.UpdateAfterCallBack = true;
        //    int selectedIndex = this.lstGroup.SelectedIndex;
        //    string type = this.lstGroup.SelectedItem.Value;
        //    GroupData groupDataByType = new GroupData();
        //    switch (type)
        //    {
        //        case "S":
        //            if (Users.UserShareGroup(username))
        //            {
        //                groupDataByType = new Groups().GetGroupDataByType(type);
        //                for (int i = 0; i < this.lstGroup.Items.Count; i++)
        //                {
        //                    if (this.lstGroup.Items[i].Text.IndexOf("←") == 0)
        //                    {
        //                        this.lstGroup.Items.Remove(this.lstGroup.Items[i]);
        //                        i = 0;
        //                    }
        //                }
        //                this.lstGroup.Items.FindByValue("S").Selected = true;
        //                selectedIndex = this.lstGroup.SelectedIndex;
        //                this.lstGroup.Items.Remove(this.lstGroup.Items[selectedIndex]);
        //                ListItem item = new ListItem("▲共享組別", "S");
        //                this.lstGroup.Items.Insert(selectedIndex, item);
        //                this.lstGroup.Items.FindByValue("P").Selected = true;
        //                selectedIndex = this.lstGroup.SelectedIndex;
        //                this.lstGroup.Items.Remove(this.lstGroup.Items[selectedIndex]);
        //                item = new ListItem("▼私人組別", "P");
        //                this.lstGroup.Items.Insert(selectedIndex, item);
        //                this.lstGroup.Items.FindByText("▼私人組別").Attributes.Add("style", "color:red;");
        //                this.lstGroup.Items.FindByValue("S").Selected = true;
        //                selectedIndex = this.lstGroup.SelectedIndex;
        //            }
        //            else
        //            {
        //                groupDataByType = null;
        //            }
        //            goto Label_0620;

        //        case "P":
        //            {
        //                groupDataByType = new Groups().GetGroupDatabyOwnerAndType(username, "P");
        //                for (int j = 0; j < this.lstGroup.Items.Count; j++)
        //                {
        //                    if (this.lstGroup.Items[j].Text.IndexOf("←") == 0)
        //                    {
        //                        this.lstGroup.Items.Remove(this.lstGroup.Items[j]);
        //                        j = 0;
        //                    }
        //                }
        //                this.lstGroup.Items.FindByValue("P").Selected = true;
        //                selectedIndex = this.lstGroup.SelectedIndex;
        //                this.lstGroup.Items.Remove(this.lstGroup.Items[selectedIndex]);
        //                ListItem item3 = new ListItem("▲私人組別", "P");
        //                this.lstGroup.Items.Insert(selectedIndex, item3);
        //                this.lstGroup.Items.FindByValue("S").Selected = true;
        //                selectedIndex = this.lstGroup.SelectedIndex;
        //                this.lstGroup.Items.Remove(this.lstGroup.Items[selectedIndex]);
        //                item3 = new ListItem("▼共享組別", "S");
        //                this.lstGroup.Items.Insert(selectedIndex, item3);
        //                this.lstGroup.Items.FindByValue("P").Selected = true;
        //                selectedIndex = this.lstGroup.SelectedIndex;
        //                goto Label_0620;
        //            }
        //        default:
        //            str5 = "";
        //            for (int k = 0; k < this.lstGroup.Items.Count; k++)
        //            {
        //                string text = this.lstGroup.Items[k].Text;
        //                if (text.IndexOf("▼共享組別") == 0)
        //                {
        //                    str5 = "(私人組別)";
        //                    break;
        //                }
        //                if (text.IndexOf("▼私人組別") == 0)
        //                {
        //                    str5 = "(共享組別)";
        //                    break;
        //                }
        //            }
        //            break;
        //    }

        //    string strNums = this.tbNum.Text.Trim() + "\r\n";
        //    string str8 = this.lstGroup.SelectedItem.Text.Trim().Replace("←　", "") + str5;

        //    strNums += this.lstGroup.SelectedItem.Text.Trim().Replace("←　", "") + str5 + "\r\n";
        //    string str9 = this.lbGroupIDContent.Text;
        //    this.lbGroupIDContent.Text = str9 + this.lstGroup.SelectedItem.Value + "," + this.lstGroup.SelectedItem.Text.Trim().Replace("←　", "") + str5 + ",";

        //    if (strNums.IndexOf("\r\n") == 0)
        //    {
        //        this.tbNum.Text = strNums.Substring(2, strNums.Length - 2);
        //    }
        //    else
        //    {
        //        this.tbNum.Text = strNums;
        //    }

        //    //string str7 = this.tbNum.Text.Trim() + "\r\n省";
        //    //string str8 = this.lstGroup.SelectedItem.Text.Trim().Replace("←　", "") + str5;
        //    //if (str7.IndexOf(str8.Substring(1, str8.Length - 1)) <= -1)
        //    //{
        //    //    str7 = str7 + "\r\n" + this.lstGroup.SelectedItem.Text.Trim().Replace("←　", "") + str5;
        //    //    string str9 = this.lbGroupIDContent.Text;
        //    //    this.lbGroupIDContent.Text = str9 + this.lstGroup.SelectedItem.Value + "," + this.lstGroup.SelectedItem.Text.Trim().Replace("←　", "") + str5 + ",";
        //    //}
        //    //if (str7.IndexOf("\r\n") == 0)
        //    //{
        //    //    this.tbNum.Text = str7.Substring(4, str7.Length - 4).Replace("省\r\n", "").Replace("省", "");
        //    //}
        //    //else
        //    //{
        //    //    this.tbNum.Text = str7.Replace("省\r\n", "").Replace("省", "");
        //    //}
        //Label_0620:
        //    if (groupDataByType != null)
        //    {
        //        foreach (DataRow row in groupDataByType.Tables[0].Select())
        //        {
        //            selectedIndex++;
        //            ListItem item4 = new ListItem("←　" + row[1].ToString(), row[0].ToString());
        //            this.lstGroup.Items.Insert(selectedIndex, item4);
        //        }
        //        this.lbGroupIDContent.UpdateAfterCallBack = true;
        //        this.lstGroup.UpdateAfterCallBack = true;
        //        this.tbNum.UpdateAfterCallBack = true;
        //    }
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
                this.txtAgentSmsContent.Enabled  =AppFlag.CentaEditAgentSms;
                this.txtUploadAgentSmsContent.Enabled =AppFlag.CentaEditAgentSms;
                string str = (base.Request["sIndex"] == null) ? "0" : base.Request["sIndex"];
                if (!this.Page.IsPostBack)
                {
                    ((Anthem.Button)this.FindControl("btnSend")).Attributes.Add("onclick", "return confirm('"+(Session["LanguageEn"].ToString () == "en-US"? "Are you sure？" : "確定發送短訊？")+"');");
                    this.lbUser.Text = this.Context.User.Identity.Name;
                    string batchid = (base.Request["CBATCHID"] == null) ? "" : base.Request["CBATCHID"];
                    if (Users.UserAgentCheck(this.lbUser.Text))
                    {
                        switch (str)
                        {
                            case "1":
                                this.btnDetailSch.Text =Session["LanguageEn"] == "zh-HK" ? "詳情" : "Detail";// "詳情";
                                this.btnDetailSch.UpdateAfterCallBack = true;
                                this.GetdplUserData(this.dplUsers);
                                this.GetSmsHisData();
                                this.txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                this.txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                this.plDefineScheduleMsg.Visible = false;
                                this.plSendMsg.Visible = false;
                                this.plSendHist.Visible = false;
                                this.plCallHist.Visible = false;
                                this.plMsgData.Visible = true;
                                this.plSendLogion.Visible = false;
                                this.plUploadSms.Visible = false;
                                this.plUploadSmsAction.Visible = false;
                                this.plAgentSMS.Visible = false;
                                this.plUploadSmsAgent.Visible = false;
                                break;
                            case "0":
                                this.plSendLogion.Visible = false;
                                this.plSendMsg.Visible = false;
                                this.plMsgData.Visible = false;
                                this.plSendHist.Visible = false;
                                this.plCallHist.Visible = false;
                                this.plDefineScheduleMsg.Visible = false;
                                this.plUploadSms.Visible = false;
                                this.plUploadSmsAction.Visible = false;
                                this.plAgentSMS.Visible = true;
                                this.plUploadSmsAgent.Visible = false;
                                this.GetAgentSmsData();
                                break;
                        }
                    }
                    else if (Users.UserBulkAgentCheck(this.lbUser.Text))
                    {

                        switch (str)
                        {
                            case "1":
                                this.btnDetailSch.Text =Session["LanguageEn"] == "zh-HK" ? "詳情" : "Detail";// "詳情";
                                this.btnDetailSch.UpdateAfterCallBack = true;
                                this.GetdplUserData(this.dplUsers);
                                this.GetSmsHisData();
                                this.txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                this.txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                this.plDefineScheduleMsg.Visible = false;
                                this.plSendMsg.Visible = false;
                                this.plSendHist.Visible = false;
                                this.plCallHist.Visible = false;
                                this.plMsgData.Visible = true;
                                this.plSendLogion.Visible = false;
                                this.plUploadSms.Visible = false;
                                this.plUploadSmsAction.Visible = false;
                                this.plAgentSMS.Visible = false;
                                this.plUploadSmsAgent.Visible = false;
                                break;
                            case "0":
                                this.plSendLogion.Visible = false;
                                this.plSendMsg.Visible = false;
                                this.plMsgData.Visible = false;
                                this.plSendHist.Visible = false;
                                this.plCallHist.Visible = false;
                                this.plDefineScheduleMsg.Visible = false;
                                this.plUploadSms.Visible = false;
                                this.plUploadSmsAction.Visible = false;
                                this.plAgentSMS.Visible = false;
                                this.plUploadSmsAgent.Visible = true;
                                this.GetBulkAgentSmsData();
                                break;
                        }
                        if (str == "0")
                        {
                            if (this.Session["doSmsAgentLoad"] == null)
                            {
                                this.doSmsAgentLoad = new DoSmsAgentLoad();
                                this.Session["doSmsAgentLoad"] = this.doSmsAgentLoad;
                            }
                            else
                            {
                                this.doSmsAgentLoad = (DoSmsAgentLoad)this.Session["doSmsAgentLoad"];
                            }
                        }
                    }
                    else
                    {
                        switch (str)
                        {
                            case "1":
                                this.btnDetailSch.Text =Session["LanguageEn"] == "zh-HK" ? "詳情" : "Detail";
                                this.btnDetailSch.UpdateAfterCallBack = true;
                                this.GetdplUserData(this.dplUsers);
                                this.GetSmsHisData();
                                this.txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                this.txtStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                this.plDefineScheduleMsg.Visible = false;
                                this.plSendMsg.Visible = false;
                                this.plSendHist.Visible = false;
                                this.plCallHist.Visible = false;
                                this.plMsgData.Visible = true;
                                this.plSendLogion.Visible = false;
                                this.plUploadSms.Visible = false;
                                this.plUploadSmsAction.Visible = false;
                                this.plAgentSMS.Visible = false;
                                this.plUploadSmsAgent.Visible = false;
                                break;

                            case "2":
                                {
                                    this.txtEndDate2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                    this.txtStartDate2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                    this.GetdplUserData(this.dplUser2);
                                    this.GetSmsScheduleData();
                                    this.GetSmsSchedule2Data();
                                    this.plDefineScheduleMsg.Visible = false;
                                    this.plSendHist.Visible = true;
                                    this.plCallHist.Visible = false;
                                    this.plSendMsg.Visible = false;
                                    this.plMsgData.Visible = false;
                                    this.plSendLogion.Visible = false;
                                    this.plUploadSms.Visible = false;
                                    this.plUploadSmsAction.Visible = false;
                                    this.plAgentSMS.Visible = false;
                                    if (Users.UserExtraGroup(this.lbUser.Text))
                                    {
                                        this.dplUser2.Enabled = false;
                                    }
                                    string str3 = (string)this.Session["datagrid"];
                                    if ((str3 == "dgSchedule2") && (str3 != null))
                                    {
                                        this.dgSchedule.Visible = false;
                                        this.dgSchedule2.Visible = true;
                                    }
                                    else
                                    {
                                        this.dgSchedule2.Visible = false;
                                        this.dgSchedule.Visible = true;
                                    }
                                    break;
                                }
                            case "3":
                                this.btnDetailSch.Text = Session["LanguageEn"] == "zh-HK" ? "詳情" : "Detail";
                                this.btnDetailSch.UpdateAfterCallBack = true;
                                this.txtEndDateCall.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                this.txtStartDateCall.Text = DateTime.Now.ToString("yyyy-MM-dd");
                                this.GetdplUserData(this.dplUsersCall);
                                this.GetSmsCallData();
                                this.plDefineScheduleMsg.Visible = false;
                                this.plSendHist.Visible = false;
                                this.plCallHist.Visible = true;
                                this.plSendMsg.Visible = false;
                                this.plMsgData.Visible = false;
                                this.plSendLogion.Visible = false;
                                this.plUploadSms.Visible = false;
                                this.plUploadSmsAction.Visible = false;
                                this.plAgentSMS.Visible = false;
                                this.plUploadSmsAgent.Visible = false;
                                if (Users.UserExtraGroup(this.lbUser.Text))
                                {
                                    this.dplUsersCall.Enabled = false;
                                }
                                break;
                            case "4":
                                this.plSendLogion.Visible = false;
                                this.plSendMsg.Visible = false;
                                this.plMsgData.Visible = false;
                                this.plSendHist.Visible = false;
                                this.plCallHist.Visible = false;
                                this.plDefineScheduleMsg.Visible = false;
                                this.plUploadSms.Visible = true;
                                this.plUploadSmsAction.Visible = false;
                                this.plAgentSMS.Visible = false;
                                this.plUploadSmsAgent.Visible = false;
                                //if (this.Session["doSmsLoad"] == null)
                                //{
                                //    this.doSmsLoad = new DoSmsLoad();
                                //    this.Session["doSmsLoad"] = this.doSmsLoad;
                                //}
                                //else
                                //{
                                //    this.doSmsLoad = (DoSmsLoad)this.Session["doSmsLoad"];
                                //}
                                break;
                            case "5":
                                this.plSendLogion.Visible = false;
                                this.plSendMsg.Visible = false;
                                this.plMsgData.Visible = false;
                                this.plSendHist.Visible = false;
                                this.plCallHist.Visible = false;
                                this.plDefineScheduleMsg.Visible = false;
                                this.plUploadSms.Visible = false;
                                this.plUploadSmsAction.Visible = true;
                                this.plAgentSMS.Visible = false;
                                this.plUploadSmsAgent.Visible = false;
                                //if (this.Session["doSmsLoad"] == null)
                                //{
                                //    this.doSmsLoad = new DoSmsLoad();
                                //    this.Session["doSmsLoad"] = this.doSmsLoad;
                                //}
                                //else
                                //{
                                //    this.doSmsLoad = (DoSmsLoad)this.Session["doSmsLoad"];
                                //}
                                break;
                            case "6":
                                this.plSendLogion.Visible = false;
                                this.plSendMsg.Visible = false;
                                this.plMsgData.Visible = false;
                                this.plSendHist.Visible = false;
                                this.plCallHist.Visible = false;
                                this.plDefineScheduleMsg.Visible = false;
                                this.plUploadSms.Visible = false;
                                this.plUploadSmsAction.Visible = false;
                                this.plAgentSMS.Visible = true;
                                this.plUploadSmsAgent.Visible = false;
                                this.GetAgentSmsData();
                                //if (this.Session["doSmsLoad"] == null)
                                //{
                                //    this.doSmsLoad = new DoSmsLoad();
                                //    this.Session["doSmsLoad"] = this.doSmsLoad;
                                //}
                                //else
                                //{
                                //    this.doSmsLoad = (DoSmsLoad)this.Session["doSmsLoad"];
                                //}
                                break;
                            case "7":
                                this.plSendLogion.Visible = false;
                                this.plSendMsg.Visible = false;
                                this.plMsgData.Visible = false;
                                this.plSendHist.Visible = false;
                                this.plCallHist.Visible = false;
                                this.plDefineScheduleMsg.Visible = false;
                                this.plUploadSms.Visible = false;
                                this.plUploadSmsAction.Visible = false;
                                this.plAgentSMS.Visible = false;
                                this.plUploadSmsAgent.Visible = true;
                                this.GetBulkAgentSmsData();
                                //if (this.Session["doSmsLoad"] == null)
                                //{
                                //    this.doSmsLoad = new DoSmsLoad();
                                //    this.Session["doSmsLoad"] = this.doSmsLoad;
                                //}
                                //else
                                //{
                                //    this.doSmsLoad = (DoSmsLoad)this.Session["doSmsLoad"];
                                //}
                                break;
                            case "8":
                                if (AppFlag.DefineMessage)
                                {
                                    this.plSendLogion.Visible = false;
                                    this.plSendMsg.Visible = false;
                                    this.plMsgData.Visible = false;
                                    this.plSendHist.Visible = false;
                                    this.plCallHist.Visible = false;
                                    this.plDefineScheduleMsg.Visible = true;
                                    this.plUploadSms.Visible = false;
                                    this.plUploadSmsAction.Visible = false;
                                    this.plAgentSMS.Visible = false;
                                    this.plUploadSmsAgent.Visible = false;
                                    this.GetSmsSchData();
                                }
                                else
                                {
                                    //this.plSendLogion.Visible = false;
                                    //this.plSendMsg.Visible = false;
                                    //this.plMsgData.Visible = false;
                                    //this.plSendHist.Visible = false;
                                    //this.plCallHist.Visible = false;
                                    //this.plDefineScheduleMsg.Visible = false;
                                    //this.plUploadSms.Visible = true;

                                    //if (this.Session["doSmsLoad"] == null)
                                    //{
                                    //    this.doSmsLoad  = new DoSmsLoad();
                                    //    this.Session["doSmsLoad"] = this.doSmsLoad;
                                    //}
                                    //else
                                    //{
                                    //    this.doSmsLoad = (DoSmsLoad)this.Session["doSmsLoad"];
                                    //}
                                }
                                break;

                            case "0":
                                {
                                    this.btnDetailSch.Text = Session["LanguageEn"] == "zh-HK" ? "詳情" : "Detail";
                                    this.btnDetailSch.UpdateAfterCallBack = true;
                                    this.plDefineScheduleMsg.Visible = false;
                                    this.plSendMsg.Visible = true;
                                    this.plMsgData.Visible = false;
                                    this.plSendHist.Visible = false;
                                    this.plCallHist.Visible = false;
                                    this.plUploadSms.Visible = false;
                                    this.plUploadSmsAction.Visible = false;
                                    this.plAgentSMS.Visible = false;
                                    this.plUploadSmsAgent.Visible = false;

                                    ///add group/groupmember for send msg 2018/0301
                                   // ListItem item = new ListItem("▼私人組別", "P");
                                    ListItem item = new ListItem("▼" + (Session["LanguageEn"] == "zh-HK" ? "私人組別" : "Private"), "P"); 

                                    this.lstGroup.Items.Add(item);
                                    this.lstGroupMember.Items.Add(item);
                                    //item = new ListItem("▼共享組別", "S");
                                    item = new ListItem("▼" + (Session["LanguageEn"] == "zh-HK" ? "共享組別" : "Share"), "S");

                                    this.lstGroup.Items.Add(item);
                                    this.lstGroupMember.Items.Add(item);
                                    //this.lstGroupMember.SelectedIndex = 0;
                                    this.lstGroup.UpdateAfterCallBack = true; 
                                    this.lstGroupMember.UpdateAfterCallBack = true; 

                                    if (Users.UserExtraGroup(this.Context.User.Identity.Name))
                                    {
                                        if (this.Session["Operator"] == null)
                                        {
                                            this.plSendLogion.Visible = true;
                                            this.plSendMsg.Visible = false;
                                        }
                                        else
                                        {
                                            this.plSendLogion.Visible = false;
                                            this.plSendMsg.Visible = true;
                                            this.lbMsgLogin.Text = "登入用戶：" + ((string)this.Session["Operator"]);
                                        }
                                        this.tbNum.ReadOnly = true;
                                        this.rbSendbyTime.Enabled = false;
                                        this.rbSendontime.Enabled = false;
                                    }
                                    else
                                    {
                                        this.plSendLogion.Visible = false;
                                        this.plSendMsg.Visible = true;
                                    }
                                    break;
                                }
                        }

                        //                if (str == "0")
                        //                {
                        //                    if (this.Session["sendload"] == null)
                        //                    {
                        //                        this.doload = new Sendload();
                        //                        this.Session["sendload"] = this.doload;
                        //                    }
                        //                    else
                        //                    {
                        //                        this.doload = (Sendload)this.Session["sendload"];
                        //                    }
                        //                    switch (this.doload.State)
                        //                    {
                        //                        case 1:
                        //                            this.txtSmsContent.Text = this.doload.txtSmsContent;
                        //                            this.tbNum.Text = "";
                        //                            this.lbGroupIDContent.Text = "";
                        //                            this.lbLen.Text = this.doload.lbLen;
                        //                            this.lbNum.Text = this.doload.lbNum;
                        //                            this.btnSend.Enabled = true;
                        //                            break;
                        //
                        //                        case 3:
                        //                            this.tbNum.Text = "";
                        //                            this.lbGroupIDContent.Text = "";
                        //                            this.lbMsg.Text = this.doload.lbMsg;
                        //                            if (this.doload.lbMsg.IndexOf("SMS exceeds 10.") > 1)
                        //                            {
                        //                                this.lbLen.Text = this.doload.txtSmsContent.Length.ToString();
                        //                            }
                        //                            this.Session["sendload"] = null;
                        //                            break;
                        //                    }
                        //                }
                        //                if (str == "4")
                        //                // if ((str == "4" && !AppFlag.DefineMessage) || str == "5")
                        //                {
                        //                    if (this.Session["doSmsLoad"] == null)
                        //                    {
                        //                        this.doSmsLoad = new DoSmsLoad();
                        //                        this.Session["doSmsLoad"] = this.doSmsLoad;
                        //                    }
                        //                    else
                        //                    {
                        //                        this.doSmsLoad = (DoSmsLoad)this.Session["doSmsLoad"];
                        //                    }
                        //                }
                        //                if (str == "5")
                        //                {
                        //                    if (this.Session["doSmsActionLoad"] == null)
                        //                    {
                        //                        this.doSmsActionLoad = new DoSmsActionLoad();
                        //                        this.Session["doSmsActionLoad"] = this.doSmsActionLoad;
                        //                    }
                        //                    else
                        //                    {
                        //                        this.doSmsActionLoad = (DoSmsActionLoad)this.Session["doSmsActionLoad"];
                        //                    }
                        //                }
                        //                 if (str == "7")
                        //                {
                        //                    if (this.Session["doSmsAgentLoad"] == null)
                        //                    {
                        //                        this.doSmsAgentLoad = new DoSmsAgentLoad();
                        //                        this.Session["doSmsAgentLoad"] = this.doSmsAgentLoad;
                        //                    }
                        //                    else
                        //                    {
                        //                        this.doSmsAgentLoad = (DoSmsAgentLoad)this.Session["doSmsAgentLoad"];
                        //                    }
                        //                }
                    }
                    if (batchid != "")
                    {
                        if (batchid.IndexOf("B") > -1)
                        {
                            SmsMsgHistData smsDatabyBatchid = new SmsMsgHists().GetSmsDatabyBatchid(batchid);
                            this.txtSmsContent.Text = GetText(smsDatabyBatchid.Tables[0].Rows[0]["CSMSMSG"]);
                            this.lbLen.Text = smsDatabyBatchid.Tables[0].Rows[0]["IMSGLEN"].ToString();
                            this.lbNum.Text = smsDatabyBatchid.Tables[0].Rows[0]["ISMSMSGNO"].ToString();
                        }
                        else
                        {
                            SmsMsgSchData schSmsDatabyBatchid = new SmsMsgSchs().GetSchSmsDatabyBatchid(batchid);
                            this.txtSmsContent.Text = GetText(schSmsDatabyBatchid.Tables[0].Rows[0]["CSMSMSG"]);
                            this.lbLen.Text = schSmsDatabyBatchid.Tables[0].Rows[0]["IMSGLEN"].ToString();
                            this.lbNum.Text = schSmsDatabyBatchid.Tables[0].Rows[0]["ISMSMSGNO"].ToString();
                        }
                    }
                }
                //if (!Users.UserBulkAgentCheck(this.lbUser.Text))
                if (Users.UserAdminCheck(this.lbUser.Text))
                {
                    if (str == "0")
                    {
                        if (this.Session["sendload"] == null)
                        {
                            this.doload = new Sendload();
                            this.Session["sendload"] = this.doload;
                        }
                        else
                        {
                            this.doload = (Sendload)this.Session["sendload"];
                        }
                        switch (this.doload.State)
                        {
                            case 1:
                                this.txtSmsContent.Text = this.doload.txtSmsContent;
                                this.tbNum.Text = "";
                                this.lbGroupIDContent.Text = "";
                                this.lbLen.Text = this.doload.lbLen;
                                this.lbNum.Text = this.doload.lbNum;
                                this.btnSend.Enabled = true;
                                break;

                            case 3:
                                this.tbNum.Text = "";
                                this.lbGroupIDContent.Text = "";
                                this.lbMsg.Text = this.doload.lbMsg;
                                if (this.doload.lbMsg.IndexOf("SMS exceeds 10.") > 1)
                                {
                                    this.lbLen.Text = this.doload.txtSmsContent.Length.ToString();
                                }
                                this.Session["sendload"] = null;
                                break;
                        }
                    }
                    if (str == "4")
                    // if ((str == "4" && !AppFlag.DefineMessage) || str == "5")
                    {
                        if (this.Session["doSmsLoad"] == null)
                        {
                            this.doSmsLoad = new DoSmsLoad();
                            this.Session["doSmsLoad"] = this.doSmsLoad; 
                        }
                        else
                        {
                            this.doSmsLoad = (DoSmsLoad)this.Session["doSmsLoad"];
                            if (this.doSmsLoad.State !=0)
                            {
                                this.chkAction.Checked = this.doSmsLoad.DoAction;
                            }
                          } 
                    }
                    if (str == "5")
                    {
                        if (this.Session["doSmsActionLoad"] == null)
                        {
                            this.doSmsActionLoad = new DoSmsActionLoad();
                            this.Session["doSmsActionLoad"] = this.doSmsActionLoad;
                        }
                        else
                        {
                            this.doSmsActionLoad = (DoSmsActionLoad)this.Session["doSmsActionLoad"];
                        }
                    }
                    if (str == "7")
                    {
                        if (this.Session["doSmsAgentLoad"] == null)
                        {
                            this.doSmsAgentLoad = new DoSmsAgentLoad();
                            this.Session["doSmsAgentLoad"] = this.doSmsAgentLoad;
                        }
                        else
                        {
                            this.doSmsAgentLoad = (DoSmsAgentLoad)this.Session["doSmsAgentLoad"];
                            if (this.txtUploadAgentSmsContent.Text.Trim() == "" && this.doSmsAgentLoad.State != 4)
                            {
                                this.txtUploadAgentSmsContent.Text = this.doSmsAgentLoad.doSmsContent;
                               // this.subUploadAgentSms.Disabled = true;
                            }
                            //if (this.doSmsAgentLoad != null)
                            //{
                            //    this.txtUploadAgentSmsContent.Text = this.doSmsAgentLoad.doSmsContent;
                            //}
                        }
                    }
                }
                else if (Users.UserBulkAgentCheck(this.lbUser.Text))
                {
                    if (str == "0")
                    {
                        if (this.Session["doSmsAgentLoad"] == null)
                        {
                            this.doSmsAgentLoad = new DoSmsAgentLoad();
                            this.Session["doSmsAgentLoad"] = this.doSmsAgentLoad;
                        }
                        else
                        {
                            this.doSmsAgentLoad = (DoSmsAgentLoad) this.Session["doSmsAgentLoad"];
                            if (this.txtUploadAgentSmsContent.Text.Trim() == "" && this.doSmsAgentLoad.State != 4)
                            {
                                this.txtUploadAgentSmsContent.Text = this.doSmsAgentLoad.doSmsContent;
                            }
                            //if (this.doSmsAgentLoad != null)
                            //{
                            //    this.txtUploadAgentSmsContent.Text = this.doSmsAgentLoad.doSmsContent;
                            //}
                        }
                    }
                }
                else
                {
                    if (str == "0")
                    {
                        if (this.Session["sendload"] == null)
                        {
                            this.doload = new Sendload();
                            this.Session["sendload"] = this.doload;
                        }
                        else
                        {
                            this.doload = (Sendload)this.Session["sendload"];
                        }
                        switch (this.doload.State)
                        {
                            case 1:
                                this.txtSmsContent.Text = this.doload.txtSmsContent;
                                this.tbNum.Text = "";
                                this.lbGroupIDContent.Text = "";
                                this.lbLen.Text = this.doload.lbLen;
                                this.lbNum.Text = this.doload.lbNum;
                                this.btnSend.Enabled = true;
                                break;

                            case 3:
                                this.tbNum.Text = "";
                                this.lbGroupIDContent.Text = "";
                                this.lbMsg.Text = this.doload.lbMsg;
                                if (this.doload.lbMsg.IndexOf("SMS exceeds 10.") > 1)
                                {
                                    this.lbLen.Text = this.doload.txtSmsContent.Length.ToString();
                                }
                                this.Session["sendload"] = null;
                                break;
                        }
                    }
                    if (str == "4")
                    // if ((str == "4" && !AppFlag.DefineMessage) || str == "5")
                    {
                        if (this.Session["doSmsLoad"] == null)
                        {
                            this.doSmsLoad = new DoSmsLoad();
                            this.Session["doSmsLoad"] = this.doSmsLoad;
                        }
                        else
                        {
                            this.doSmsLoad = (DoSmsLoad)this.Session["doSmsLoad"];
                            if (this.doSmsLoad.State != 0)
                            {
                                this.chkAction.Checked = this.doSmsLoad.DoAction;
                            }
                        }
                    }
                }

                

            }
        }

        private void GetBulkAgentSmsData()
        {
            SmsSchContentData data = new SmsSchContents().LoadAllSchData();
            this.dplUploadAgentSmsNum.DataSource = data.Tables["SMS_MSGSCH_CONTENT"].DefaultView;
            this.dplUploadAgentSmsNum.DataTextField = "CTITLE";
            this.dplUploadAgentSmsNum.DataValueField = "ID";
            this.dplUploadAgentSmsNum.DataBind();
            //this.dplAgentSmsNum.SelectedIndex = (this.dplAgentSmsNum.Items.Count == 0) ? -1 : 0;
            ////  this.dplAgentSmsNum.SelectedValue   = "Normal";
            // this.dplAgentSmsNum.SelectedIndex = -1;
            this.dplUploadAgentSmsNum.Items.Insert(0, new ListItem("---請選擇SMS---"));
            this.dplUploadAgentSmsNum.UpdateAfterCallBack = true;
            //if(this.doSmsAgentLoad !=null)
            //{
            //    this.txtUploadAgentSmsContent.Text = this.doSmsAgentLoad.doSmsContent;
            //}
            // this.txtAgentSmsContent.Text = (data.Tables[0] == null || data.Tables[0].Rows.Count == 0) ? "" : data.Tables["SMS_MSGSCH_CONTENT"].Select("ID='" + this.dplAgentSmsNum.SelectedValue + "'")[0]["CSMSMSG"].ToString();
            //  this.txtAgentSmsContent.UpdateAfterCallBack = true;
        }

        private void GetAgentSmsData()
        {
            SmsSchContentData data = new SmsSchContents().LoadAllSchData();
            this.dplAgentSmsNum.DataSource = data.Tables["SMS_MSGSCH_CONTENT"].DefaultView;
            this.dplAgentSmsNum.DataTextField = "CTITLE";
            this.dplAgentSmsNum.DataValueField = "ID";
            this.dplAgentSmsNum.DataBind();
            //this.dplAgentSmsNum.SelectedIndex = (this.dplAgentSmsNum.Items.Count == 0) ? -1 : 0;
            ////  this.dplAgentSmsNum.SelectedValue   = "Normal";
            // this.dplAgentSmsNum.SelectedIndex = -1;
            this.dplAgentSmsNum.Items.Insert(0, new ListItem("---請選擇SMS---"));
            this.dplAgentSmsNum.UpdateAfterCallBack = true;

            // this.txtAgentSmsContent.Text = (data.Tables[0] == null || data.Tables[0].Rows.Count == 0) ? "" : data.Tables["SMS_MSGSCH_CONTENT"].Select("ID='" + this.dplAgentSmsNum.SelectedValue + "'")[0]["CSMSMSG"].ToString();
            //  this.txtAgentSmsContent.UpdateAfterCallBack = true;
        }

        private void dplUploadAgentSmsNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dplUploadAgentSmsNum.SelectedIndex != 0)
            {
                SmsSchContents contents = new SmsSchContents();
                SmsSchContentData data = contents.LoadSmsSchContentByID(this.dplUploadAgentSmsNum.SelectedValue);
                string str = data.Tables["SMS_MSGSCH_CONTENT"].Rows[0]["CSMSMSG"].ToString();

                //                if (txtSmsPhone.Text.Trim() != "")
                //                {
                //                    str = str.Replace("MRT", txtAgentPhone.Text.Trim());
                //                    str = str.Replace("CSDL", txtSaleName.Text.Trim());
                //                    str = str.Replace("CSN", txtSalePhone.Text.Trim());
                //                }
                this.txtUploadAgentSmsContent.Text = str;
                this.lbrfvUpload3.Visible = false; 
            }
            else
            {
                this.lbrfvUpload3.Visible = true;
                this.txtUploadAgentSmsContent.Text = "";
            }
            this.txtUploadAgentSmsContent.UpdateAfterCallBack = true;
            this.lbrfvUpload3.UpdateAfterCallBack = true;
        }

        private void dpldplAgentSmsNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dplAgentSmsNum.SelectedIndex != 0)
            {
                SmsSchContents contents = new SmsSchContents();
                SmsSchContentData data = contents.LoadSmsSchContentByID(this.dplAgentSmsNum.SelectedValue);
                string str = data.Tables["SMS_MSGSCH_CONTENT"].Rows[0]["CSMSMSG"].ToString();

                if (txtSmsPhone.Text.Trim() != "")
                {
                    str = str.Replace("MRT", txtAgentPhone.Text.Trim());
                    str = str.Replace("CSDL", txtSaleName.Text.Trim());
                    str = str.Replace("CSN", txtSalePhone.Text.Trim());
                }
                this.txtAgentSmsContent.Text = str;
            }
            else
            {
                this.txtAgentSmsContent.Text = "";
            }
            this.txtAgentSmsContent.UpdateAfterCallBack = true;
        }

        private void rbSendbyTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbSendbyTime.Checked)
            {
                this.rbSendontime.Checked = false;
                this.rbSendontime.UpdateAfterCallBack = true;
                ((Anthem.Button)this.FindControl("btnSend")).Attributes.Remove("onclick");
                this.btnSend.UpdateAfterCallBack = true;
                this.lbMsg.Text = "";
                this.lbMsg.UpdateAfterCallBack = true;
                if (AppFlag.DefineMessage)
                {
                    SmsSchContentData data = new SmsSchContents().LoadSchDataByStatusAndSender(this.Context.User.Identity.Name);
                    if (data.Tables[0].Rows.Count > 0)
                    {
                        int num = 0;
                        int ilen = 0;
                        int maxlen = 0;
                        string strTemp = "";
                        try
                        {
                            DataRow row = data.Tables[0].Rows[0];
                            strTemp = row["CSMSMSG"].ToString();
                            num = ConfigManager.CheckSmsData(strTemp, out ilen, out maxlen);
                            if (num == -1)
                            {
                                throw new Exception("SMS exceeds 10.");
                            }
                            this.txtSmsContent.Text = strTemp;
                            this.lbLen.Text = ilen.ToString();
                            this.lbNum.Text = num.ToString();
                            this.lbMsg.Text = "";
                            this.lbMsg.UpdateAfterCallBack = true;
                            this.lbLen.UpdateAfterCallBack = true;
                            this.lbNum.UpdateAfterCallBack = true;
                        }
                        catch (Exception)
                        {
                            this.lbMsg.Text =(Session["LanguageEn"] == "en-US") ? "More than the maximum " : "超過最大字符數 " + maxlen.ToString() + "!";
                            this.lbMsg.UpdateAfterCallBack = true;
                        }
                    }
                    else
                    {
                        this.txtSmsContent.Text = "";
                    }
                    this.txtSmsContent.UpdateAfterCallBack = true;
                }
            }
        }

        private void rbSendontime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbSendontime.Checked)
            {
                this.rbSendbyTime.Checked = false;
                this.rbSendbyTime.UpdateAfterCallBack = true;
                ((Anthem.Button)this.FindControl("btnSend")).Attributes.Add("onclick", "return confirm('Are you sure?');");
                this.btnSend.UpdateAfterCallBack = true;
                this.lbMsg.Text = "";
                this.lbMsg.UpdateAfterCallBack = true;
            }
        }

        private void SaveLogin_Click(object sender, EventArgs e)
        {
            string str = this.txtUserLogion.Text.ToUpper();
            if (new Users().GetUserByUSER_ID(str, this.txtUserPWLogion.Text.Trim()) != null)
            {
                this.plSendLogion.Visible = false;
                this.plSendMsg.Visible = true;
                this.lbMsgLogin.Text = (Session["LanguageEn"] == "en-US") ? "Login User：" : "登入用戶：" + str;
                this.lbMsgLogin.UpdateAfterCallBack = true;
                this.btnLoginOut.Visible = true;
                this.btnLoginOut.UpdateAfterCallBack = true;
                this.plSendLogion.UpdateAfterCallBack = true;
                this.plSendMsg.UpdateAfterCallBack = true;
                this.Session["Operator"] = str;
                Manager.AddScriptForClientSideEval("Focus( 'txtSmsContent');");
                this.lbMsgError.Text = "";
                Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.Context.User.Identity.Name + "  登入用戶：" + str + ")");
            }
            else
            {
                this.lbMsgError.Text = (Session["LanguageEn"] == "en-US") ? "UserName&Password Error！" : "用戶名或密碼錯誤！";// "用戶名或密碼錯誤！";
                Manager.AddScriptForClientSideEval("Focus( 'txtUserLogion');");
            }
            this.lbMsgError.UpdateAfterCallBack = true;
        }

        public string StringStatus(object status)
        {
            if (status.ToString() == "C")
            {
                status = (Session["LanguageEn"] == "en-US") ? "Sent" : "已發送"; //"已發送";
            }
            else if (status.ToString() == "N")
            {
                status = (Session["LanguageEn"] == "en-US") ? "Waitting" : "等待發送"; // "等待發送";
            }
            else if (status.ToString() == "D")
            {
                status = (Session["LanguageEn"] == "en-US") ? "Deleted" : "已刪除"; //"已刪除";
            }
            return status.ToString();
        }

        protected string GetText(object str)
        {
            return base.Server.UrlDecode(str.ToString());
        }

        public string CountData(object id, object no, object len, object iUnSend)
        {
            //int iUnSend= SmsMsgs.GetUnSendSms(id.ToString());
            // int iUnSend = new SmsMsgs().GetUnSendSmsCount(id.ToString());
            if (Convert.ToInt32(iUnSend) != -1)
            {
                return ((Convert.ToInt32(iUnSend) * Convert.ToInt32(len)).ToString() + "/" + (Convert.ToInt32(no) - Convert.ToInt32(iUnSend)) * Convert.ToInt32(len)).ToString();
            }
            else
            {
                return ((Convert.ToInt32(no)) * Convert.ToInt32(len)).ToString() + "/0";
            }
        }

        public string CountData2(object id, object no, object len, object iUnSend)
        {
            //int iUnSend= SmsMsgs.GetUnSendSms(id.ToString());
            // int iUnSend = new SmsMsgs().GetUnSendSmsCount(id.ToString());
            if (Convert.ToInt32(iUnSend) == -1)
            {
                return ((Convert.ToInt32(no)) * Convert.ToInt32(len)).ToString() + "/0";
            }
            else
            {
                return (Convert.ToInt32(iUnSend) * Convert.ToInt32(len)).ToString() + "/" + ((Convert.ToInt32(no) * Convert.ToInt32(len)) - (Convert.ToInt32(iUnSend) * Convert.ToInt32(len))).ToString();

            }
        }
    }
}

