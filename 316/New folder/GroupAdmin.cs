namespace CENTASMS
{
    using Anthem;
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using FirebirdSql.Data.FirebirdClient;
    using System.Drawing;
    using System.IO;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class GroupAdmin : CommonPage
    {
        protected System.Web.UI.WebControls.Button btnAdd;
        protected Anthem.Button btnAddGroupP;
        protected Anthem.Button btnAddGroupS;
        protected Anthem.Button btnDeleteMember;
        protected Anthem.Button btnDeleteP;
        protected Anthem.Button btnDeleteS;
        protected Anthem.Button btnSaveRight;
        protected Anthem.Button btnSearch;
        protected Anthem.Button btnSearch11;
        protected Anthem.Button btnSearch4;
        protected Anthem.Button btnUpload;
        protected HtmlInputFile btnUploadMode;
        protected Anthem.Button Button1;
        protected Anthem.Button Button4;
        protected Anthem.CheckBox cbCheckAll;
        protected System.Web.UI.WebControls.CheckBoxList cblCheck;
        protected Anthem.DataGrid dgData;
        protected Anthem.DataGrid dgData2;
        protected Anthem.DataGrid dgdata4;
        protected Anthem.DataGrid dgMember;
        protected HtmlGenericControl div_load;
        protected HtmlGenericControl divStatus;
        protected Doload doload;
        protected Anthem.DropDownList dplAllGroup;
        protected Anthem.DropDownList dplGroups;
        protected Anthem.DropDownList dplGroupType;
        protected Anthem.DropDownList dplUsers;
        protected Anthem.DropDownList dplUsers11;
        protected Anthem.DropDownList Dropdownlist4;
        protected System.Web.UI.WebControls.Image imgLoad;
        protected System.Web.UI.WebControls.Label lab_state;
//        protected System.Web.UI.WebControls.Label Label1;
        protected System.Web.UI.WebControls.Label Label10;
        protected System.Web.UI.WebControls.Label Label11;
        protected System.Web.UI.WebControls.Label Label2;
        protected System.Web.UI.WebControls.Label Label3;
        protected System.Web.UI.WebControls.Label Label4;
        protected System.Web.UI.WebControls.Label Label5;
        protected System.Web.UI.WebControls.Label Label6;
        protected System.Web.UI.WebControls.Label Label7;
        protected System.Web.UI.WebControls.Label Label8;
        protected System.Web.UI.WebControls.Label Label9;
        protected System.Web.UI.WebControls.TextBox lbdgMemberName;
        protected System.Web.UI.WebControls.Label lbGroupPP;
        protected System.Web.UI.WebControls.Label lbGroupPPwd;
        protected System.Web.UI.WebControls.Label lbGroupS;
        protected System.Web.UI.WebControls.Label lbGroupSPwd;
        protected Anthem.Label lbMsg6;
        protected Anthem.Label  lbMsgP;
        protected Anthem.Label lbmsgRP;
        protected Anthem.Label lbmsgRS;
        protected Anthem.Label lbMsgS;
        protected Anthem.Label lbrfvmobile;
        protected Anthem.Label lbrfvname;
        protected Anthem.Label lbrfvUpload;
        protected Anthem.Label lbRightResult;
        protected System.Web.UI.WebControls.Label lbRightShow;
//        protected System.Web.UI.WebControls.LinkButton LbtnRefresh;
        protected Anthem.Label lbUploadResult;
        protected System.Web.UI.WebControls.Label lbUser;
        protected Anthem.Panel panel1;
        protected Anthem.Panel panel2;
        protected Anthem.Panel panel3;
        protected Anthem.Panel panel4;
        protected Anthem.Panel panel5;
        protected Anthem.Panel panel6;
        protected Anthem.RadioButton rbGroupP;
        protected Anthem.RadioButton rbGroupS;
        protected Anthem.RadioButton rbTypeAdd;
        protected Anthem.RadioButton rbTypeCover;
        protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
        protected System.Web.UI.WebControls.RequiredFieldValidator REQUIREDFIELDVALIDATOR1;
        protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator3;
        protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator5;
        protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator6;
        protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator7;
        protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator8;
        protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator9;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfv;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfv11;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvMsg;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvUplaod;
        protected HtmlInputButton Submit1;
        protected Anthem.TextBox tbGroupPPwd;
        protected Anthem.TextBox tbGroupSPwd;
//        protected TextBox TextBox1;
//        protected TextBox TextBox2;
//        protected TextBox TextBox3;
        protected System.Web.UI.WebControls.TextBox TextBox4;
        protected System.Web.UI.WebControls.TextBox Textbox7;
        protected System.Web.UI.WebControls.TextBox Textbox8;
        protected System.Web.UI.WebControls.TextBox  txtEndDate;
        protected System.Web.UI.WebControls.TextBox  txtEndDate11;
        protected Anthem.TextBox txtGroupP;
        protected Anthem.TextBox txtGroupS;
        protected Anthem.TextBox txtMobile;
        protected Anthem.TextBox txtMobile4;
        protected Anthem.TextBox txtName;
        protected Anthem.TextBox txtName4;
        protected System.Web.UI.WebControls.TextBox  txtStartDate;
        protected System.Web.UI.WebControls.TextBox  txtStartDate1;

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

        private void BindUserRight()
        {
            UserData userDataBy = new Users().GetUserDataBy("");
            this.cblCheck.DataSource = userDataBy.Tables["USER_PROFILE"].DefaultView;
            this.cblCheck.DataTextField = "USER_ID";
            this.cblCheck.DataValueField = "SHAREDGP_RIGHT";
            this.cblCheck.DataBind();
            for (int i = 0; i < this.cblCheck.Items.Count; i++)
            {
                if (this.cblCheck.Items[i].Value == "Y")
                {
                    this.cblCheck.Items[i].Selected = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.dgMember.Columns[7].HeaderText = "";
            this.dgMember.Columns[6].HeaderText = "";
            if ((this.txtMobile.Text.Trim() == "") && (this.txtName.Text.Trim() == ""))
            {
                this.lbrfvmobile.Visible = true;
                this.lbrfvmobile.UpdateAfterCallBack = true;
                this.lbrfvname.Visible = true;
                this.lbrfvname.UpdateAfterCallBack = true;
            }
            if ((this.txtMobile.Text.Trim() == "") && (this.txtName.Text.Trim() != ""))
            {
                this.txtMobile.Visible = true;
                this.txtMobile.UpdateAfterCallBack = true;
            }
            if ((this.txtMobile.Text.Trim() != "") && (this.txtName.Text.Trim() == ""))
            {
                this.txtName.Visible = true;
                this.txtName.UpdateAfterCallBack = true;
            }
            if ((this.txtName.Text.Trim() != "") && (this.txtMobile.Text.Trim() != ""))
            {
                if (this.dplGroups.SelectedItem.Text.Trim() != "All")
                {
                    GroupMemberData data = new GroupMemberData();
                    GroupMembers members = new GroupMembers();
                    DataRow row = data.Tables["GROUP_MEMBER"].NewRow();
                    row["IITEM_NO"] = members.GetNewItem_NO();
                    row["CGROUP_ID"] = this.dplGroups.SelectedItem.Value.Trim();
                    row["CMEMBER_NAME"] = this.txtName.Text.Trim();
                    row["CMOBILENO"] = this.txtMobile.Text.Trim();
                    row["CREATE_DATE"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ");
                    data.Tables["GROUP_MEMBER"].Rows.Add(row);
                    if (members.InsertMember(data))
                    {
                        this.lbMsg6.Text = "新增聯絡人成功!";
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  新增聯絡人 " + this.dplGroups.SelectedItem.Text.Trim() + " " + this.txtName.Text.Trim() + " " + this.txtMobile.Text.Trim() + " ！");
                        this.GetMemberByGroupID(this.lbUser.Text.Trim(), this.dplGroups.SelectedItem.Value.Trim());
                        Manager.AddScriptForClientSideEval("Focuss( 'txtName','All');");
                    }
                    else
                    {
                        this.lbMsg6.Text = "新增聯絡人失敗，號碼已存在!";
                    }
                }
                else
                {
                    this.lbMsg6.Text = "請選擇聯絡人組別!";
                }
            }
            this.lbrfvmobile.UpdateAfterCallBack = true;
            this.lbrfvname.UpdateAfterCallBack = true;
            this.lbMsg6.UpdateAfterCallBack = true;
            this.dgMember.CurrentPageIndex = 0;
            Manager.AddScriptForClientSideEval("Focuss( 'txtName','');");
        }

        private void btnAddGroupP_Click(object sender, EventArgs e)
        {
            if (this.txtGroupP.Text.Trim() == "")
            {
                this.lbmsgRP.Text = "*";
                this.lbmsgRP.UpdateAfterCallBack = true;
            }
            else
            {
                GroupData data = new GroupData();
                Groups groups = new Groups();
                DataRow row = data.Tables["GROUP_INFO"].NewRow();
                row["CGROUP_ID"] = groups.GetNewGroupid(this.txtGroupP.Text.Trim(), this.lbUser.Text.Trim());
                row["CGROUP_NAME"] = this.txtGroupP.Text.Trim();
                row["CGROUP_OWNER"] = this.lbUser.Text.Trim().ToUpper();
                row["CGROUP_TYPE"] = "P";
                row["CGROUP_PWD"] = this.tbGroupPPwd.Text.Trim();
                row["CREATE_DATE"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ");
                data.Tables["GROUP_INFO"].Rows.Add(row);
                if (new Groups().InsertGroup(data))
                {
                    this.lbMsgP.Text = "新增私人組別成功!";
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  新增私人組別 " + this.txtGroupP.Text.Trim() + " ！");
                    this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "P");
                    Manager.AddScriptForClientSideEval("Focuss( 'txtGroupP','All');");
                }
                else
                {
                    this.lbMsgP.Text = "新增組別失敗，私人組別名稱已存在!";
                }
                this.lbMsgP.UpdateAfterCallBack = true;
                Manager.AddScriptForClientSideEval("Focuss( 'txtGroupP','');");
                this.lbmsgRP.Text = "";
                this.lbmsgRP.UpdateAfterCallBack = true;
            }
        }

        private void btnAddGroupS_Click(object sender, EventArgs e)
        {
            if (this.txtGroupS.Text.Trim() == "")
            {
                this.lbmsgRS.Text = "*";
                this.lbmsgRS.UpdateAfterCallBack = true;
            }
            else
            {
                Groups groups = new Groups();
                GroupData data = new GroupData();
                if (groups.BoolExistShareGroupName(this.txtGroupS.Text.Trim()))
                {
                    DataRow row = data.Tables["GROUP_INFO"].NewRow();
                    row["CGROUP_ID"] = groups.GetNewGroupid(this.txtGroupS.Text.Trim(), this.lbUser.Text.Trim());
                    row["CGROUP_NAME"] = this.txtGroupS.Text.Trim();
                    row["CGROUP_OWNER"] = this.lbUser.Text.Trim().ToUpper();
                    row["CGROUP_TYPE"] = "S";
                    row["CGROUP_PWD"] = this.tbGroupSPwd.Text.Trim();
                    row["CREATE_DATE"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ");
                    data.Tables["GROUP_INFO"].Rows.Add(row);
                    if (groups.InsertGroup(data))
                    {
                        this.lbMsgS.Text = "新增共享組別成功!";
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  新增共享組別 " + this.txtGroupS.Text.Trim() + " ！");
                        Manager.AddScriptForClientSideEval("Focuss( 'txtGroupS','All');");
                        this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "S");
                    }
                    else
                    {
                        this.lbMsgS.Text = "新增組別失敗，共享組別名稱已存在!";
                    }
                }
                else
                {
                    this.lbMsgS.Text = "新增組別失敗，共享組別名稱已存在!";
                }
                Manager.AddScriptForClientSideEval("Focuss( 'txtGroupS','');");
                this.lbMsgS.UpdateAfterCallBack = true;
                this.lbmsgRS.Text = "";
                this.lbmsgRS.UpdateAfterCallBack = true;
            }
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            this.dgMember.Columns[7].HeaderText = "";
            this.dgMember.Columns[6].HeaderText = "";
            bool flag = false;
            GroupMemberData memberDatabyAdminatMemberPage = new GroupMemberData();
            GroupMembers members = new GroupMembers();
            string username = this.lbUser.Text.Trim();
            if (this.dplGroups.SelectedItem.Value.Trim() == "All")
            {
                if (Users.UserAdminCheck(username))
                {
                    memberDatabyAdminatMemberPage = members.GetMemberDatabyAdminatMemberPage(username, "S");
                }
                else
                {
                    memberDatabyAdminatMemberPage = members.GetMemberDatabyAdminatMemberPage(username, "P");
                }
            }
            else
            {
                memberDatabyAdminatMemberPage = members.GetMemberDataByGroupID(this.dplGroups.SelectedItem.Value.Trim());
            }
            if (memberDatabyAdminatMemberPage.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in memberDatabyAdminatMemberPage.Tables[0].Select())
                {
                    row.Delete();
                }
                if (members.DeleteMember(memberDatabyAdminatMemberPage))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
                if (flag)
                {
                    this.lbMsg6.Text = "刪除聯絡人成功！";
                    this.dgMember.CurrentPageIndex = 0;
                    this.dgMember.DataSource = null;
                    this.dgMember.DataBind();
                    this.dgMember.UpdateAfterCallBack = true;
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  刪除 " + this.dplGroups.SelectedItem.Text.Trim() + " 組別聯絡人！");
                }
                else
                {
                    this.lbMsg6.Text = "刪除聯絡人失敗！";
                }
            }
            else
            {
                this.lbMsg6.Text = "組別中不存在聯絡人！";
            }
            this.lbMsg6.UpdateAfterCallBack = true;
        }

        private void btnDeleteP_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgData.Items.Count > 0)
                {
                    using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        FbTransaction transaction = connection.BeginTransaction();
                        FbCommand command = new FbCommand(null, connection, transaction);
                        string str = "delete from GROUP_MEMBER where CGROUP_ID IN (SELECT CGROUP_ID FROM GROUP_INFO WHERE CGROUP_OWNER= '" + this.Context.User.Identity.Name.ToUpper() + "' and CGROUP_TYPE='P') ";
                        string str2 = "delete from GROUP_INFO WHERE    CGROUP_TYPE='P' AND CGROUP_OWNER= '" + this.Context.User.Identity.Name.ToUpper() + "'";
                        command.CommandText = str;
                        command.ExecuteNonQuery();
                        command.CommandText = str2;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        connection.Close();
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  delete all 私人組別&聯絡人  ！");
                        this.lbMsgP.Text = "刪除成功!";
                        this.GetGroupbyOwnerAndType(this.Context.User.Identity.Name, "P");
                    }
                }
                else
                {
                    this.lbMsgP.Text = "無私人組別&聯絡人!";
                }
            }
            catch (Exception exception)
            {
                this.lbMsgP.Text = "刪除不成功!";
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "btnDeleteP_Click(),Error" + exception.ToString());
            }
            this.lbMsgP.UpdateAfterCallBack = true;
        }

        private void btnDeleteS_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgData2.Items.Count > 0)
                {
                    using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
                    {
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        FbTransaction transaction = connection.BeginTransaction();
                        FbCommand command = new FbCommand(null, connection, transaction);
                        string str = "delete from GROUP_MEMBER where CGROUP_ID IN (SELECT CGROUP_ID FROM GROUP_INFO WHERE CGROUP_OWNER= '" + this.Context.User.Identity.Name.ToUpper() + "' and CGROUP_TYPE='S') ";
                        string str2 = "delete from GROUP_INFO WHERE    CGROUP_TYPE='S' AND CGROUP_OWNER= '" + this.Context.User.Identity.Name.ToUpper() + "'";
                        command.CommandText = str;
                        int num = command.ExecuteNonQuery();
                        command.CommandText = str2;
                        int num2 = command.ExecuteNonQuery();
                        transaction.Commit();
                        connection.Close();
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  delete all 共享組別&聯絡人  ！");
                        if ((num + num2) > 0)
                        {
                            this.lbMsgS.Text = "刪除成功!";
                            this.GetGroupbyOwnerAndType(this.Context.User.Identity.Name, "S");
                        }
                        else
                        {
                            this.lbMsgS.Text = "刪除不成功!";
                        }
                    }
                }
                else
                {
                    this.lbMsgS.Text = "無共享組別&聯絡人!";
                }
            }
            catch (Exception exception)
            {
                this.lbMsgS.Text = "刪除不成功!";
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "btnDeleteP_Click(),Error" + exception.ToString());
            }
            this.lbMsgS.UpdateAfterCallBack = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.BindUserRight();
        }

        private void btnSaveRight_Click(object sender, EventArgs e)
        {
            UserData userdata = new UserData();
            Users users = new Users();
            bool flag = false;
            string str = "";
            for (int i = 0; i < this.cblCheck.Items.Count; i++)
            {
                userdata = users.LoadUserByUSER_ID(this.cblCheck.Items[i].Text);
                if (this.cblCheck.Items[i].Selected)
                {
                    userdata.Tables[0].Rows[0]["SHAREDGP_RIGHT"] = "Y";
                    str = str + userdata.Tables[0].Rows[0]["USER_ID"] + " ";
                }
                else
                {
                    userdata.Tables[0].Rows[0]["SHAREDGP_RIGHT"] = "N";
                }
                if (users.UpdateUser(userdata))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                this.lbRightResult.Text = "設置成功!";
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  設置有共享組別權限：" + str + "！");
            }
            else
            {
                this.lbRightResult.Text = "設置失敗!";
            }
            this.lbRightResult.UpdateAfterCallBack = true;
        }

        private void btnSearch4_Click(object sender, EventArgs e)
        {
            GroupMemberData memberDatabyAllGroupAndOwner = (GroupMemberData) this.Session["memberdata"];
            GroupMembers members = new GroupMembers();
            string filterExpression = "";
            string str2 = this.txtName4.Text.Trim();
            string str3 = this.txtMobile4.Text.Trim();
            if (str2 != "")
            {
                filterExpression = filterExpression + "and  CMEMBER_NAME ='" + str2 + "' ";
            }
            if (str3 != "")
            {
                filterExpression = filterExpression + "and   CMOBILENO='" + str3 + "' ";
            }
            if (filterExpression == "")
            {
                if (this.dplAllGroup.SelectedItem.Text == "All")
                {
                    memberDatabyAllGroupAndOwner = members.GetMemberDatabyAllGroupAndOwner(this.lbUser.Text.Trim(), this.dplGroupType.SelectedItem.Value);
                }
                else
                {
                    memberDatabyAllGroupAndOwner = members.GetMemberDataByGroupID(this.dplAllGroup.SelectedItem.Value.Trim());
                }
                this.dgdata4.DataSource = memberDatabyAllGroupAndOwner.Tables["GROUP_MEMBER"].DefaultView;
                this.Session["memberdata"] = memberDatabyAllGroupAndOwner;
            }
            else
            {
                filterExpression = filterExpression.Substring(4, filterExpression.Length - 4);
                DataRow[] rowArray = memberDatabyAllGroupAndOwner.Tables["GROUP_MEMBER"].Select(filterExpression, "CREATE_DATE DESC");
                DataTable table = memberDatabyAllGroupAndOwner.Tables["GROUP_MEMBER"].Copy();
                table.Rows.Clear();
                GroupMemberData data2 = new GroupMemberData();
                foreach (DataRow row in rowArray)
                {
                    object[] itemArray = row.ItemArray;
                    table.Rows.Add(itemArray);
                    data2.Tables["GROUP_MEMBER"].Rows.Add(itemArray);
                }
                this.dgdata4.DataSource = table.DefaultView;
                this.Session["memberdata"] = data2;
            }
            this.dgdata4.CurrentPageIndex = 0;
            this.dgdata4.PageSize = AppFlag.iPageSize;
            this.dgdata4.DataBind();
            this.dgdata4.UpdateAfterCallBack = true;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            Anthem . DataList list = (Anthem. DataList) this.Page.FindControl("GroupTabs1").FindControl("tabs");
            list.Enabled = false;
            string centaSmsUploadFolder = AppFlag.CentaSmsUploadFolder;
            string strFileName = this.btnUploadMode.PostedFile.FileName.ToUpper();
            string str2 = Path.GetFileName(strFileName).ToUpper();
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + centaSmsUploadFolder + str2;
            bool flag = true;
            string str4 = "";
            if (str2 != "")
            {
                try
                {
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + centaSmsUploadFolder))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString() + centaSmsUploadFolder);
                    }
                    if (File.Exists(path))
                    {
                       // path = AppDomain.CurrentDomain.BaseDirectory.ToString() + centaSmsUploadFolder + str2.Substring(0, str2.LastIndexOf(".XLS")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".XLS";
                       
                        if (strFileName.LastIndexOf("XLS") == strFileName.Length - 3)
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + str2.Substring(0, str2.LastIndexOf(".XLS")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".XLS";
                        }
                        else if (strFileName.LastIndexOf("XLSX") == strFileName.Length - 4)
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + str2.Substring(0, str2.LastIndexOf(".XLSX")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".XLSX";
                        }
                        else
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + AppFlag.CentaSmsBatchUploadFolder + str2 + "_" + DateTime.Now.ToString("MMddHHmm");
                        } 
                    }
                    this.btnUploadMode.PostedFile.SaveAs(path);
                }
                catch (Exception exception)
                {
                    flag = false;
                    str4 = exception.ToString();
                }
                this.btnUploadMode.Dispose();
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  開始上載 " + str2 + " 組別！");
                if (flag)
                {
                    if (this.doload.State != 1)
                    {
                        SmsActions actions = new SmsActions();
                        SmsActionData data = new SmsActionData();
                        string str5 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
                        DataRow row = data.Tables["SMS_ACTIONS"].NewRow();
                        row["CSMS_ACTION_CONTENT"] = str2;
                        row["CSMS_ACTION_TYPE"] = "UPLOAD";
                        row["CSMS_ACTION_STATUS"] = "進行中";
                        row["CACTION_HANDLER"] = this.Context.User.Identity.Name;
                        row["ACTION_STARTTIME"] = str5;
                        row["ACTION_ENDTIME"] = "";
                        row["ACTION_REMARKS"] = "";
                        data.Tables["SMS_ACTIONS"].Rows.Add(row);
                        if (actions.InsertAction(data))
                        {
                            this.doload.strcondtion = str5;
                            this.doload.dolbUploadResult = "";
                            this.doload.dolbUser = this.Context.User.Identity.Name;
                            this.doload.FileName = str2;
                            this.doload.dobtnUploadMode = path;
                            if (this.rbGroupP.Checked)
                            {
                                this.doload.dorbGroupP = true;
                            }
                            if (this.rbTypeAdd.Checked)
                            {
                                this.doload.dorbTypeAdd = true;
                            }
                            this.div_load.Visible = true;
                            this.Page.RegisterStartupScript("", "<script>location.href=location.href;</script>");
                            this.doload.runload();
                        }
                    }
                }
                else
                {
                    this.doload.dolbUploadResult = "上載失敗 ！";
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   Upload error:  " + str4);
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

        private void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbCheckAll.Text == "全選")
            {
                this.cbCheckAll.Text = "全不選";
            }
            else
            {
                this.cbCheckAll.Text = "全選";
            }
            this.cbCheckAll.UpdateAfterCallBack = true;
        }

        private void dgData_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgData.EditItemIndex = -1;
            this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "P");
        }

        private void dgData_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string text = ((System.Web.UI.WebControls.Label) this.dgData.Items[e.Item.ItemIndex].FindControl("lbGroupIDP")).Text;
            string str2 = ((System.Web.UI.WebControls.Label) this.dgData.Items[e.Item.ItemIndex].FindControl("lbGroupIDNameP")).Text.Trim();
            if (AppFlag.DeteleGroupMode == "ALL")
            {
                using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand command = new FbCommand(null, connection, transaction);
                    string str3 = "delete from GROUP_MEMBER where CGROUP_ID= '" + text + "' ";
                    string str4 = "delete from GROUP_INFO WHERE    CGROUP_ID= '" + text + "' ";
                    command.CommandText = str3;
                    command.ExecuteNonQuery();
                    command.CommandText = str4;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  delete " + str2 + " 私人組別&聯絡人！");
                    this.lbMsgP.Text = "刪除 " + str2 + " 私人組別&聯絡人成功!";
                }
            }
            else if (new GroupMembers().GetMemberDataByGroupID(text).Tables[0].Rows.Count == 0)
            {
                Groups groups = new Groups();
                GroupData data = new GroupData();
                data = groups.LoadGroupByID(text);
                data.Tables[0].Rows[0].Delete();
                if (groups.DeleteGroup(data))
                {
                    this.lbMsgP.Text = "刪除私人組別成功！";
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  刪除私人組別 " + str2 + " ！");
                }
                else
                {
                    this.lbMsgP.Text = "刪除私人組別失敗！";
                }
            }
            else
            {
                this.lbMsgP.Text = "組別中已存在成員，刪除私人組別失敗！";
            }
            this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "P");
            this.lbMsgP.UpdateAfterCallBack = true;
        }

        private void dgData_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.lbMsgP.Text = "";
            string str = ((System.Web.UI.WebControls.Label) this.dgData.Items[e.Item.ItemIndex].FindControl("lbGroupIDNameP")).Text.Trim();
            this.txtGroupP.Text = str;
            this.dgData.EditItemIndex = e.Item.ItemIndex;
            this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "P");
            this.txtGroupP.UpdateAfterCallBack = true;
            this.lbMsgP.UpdateAfterCallBack = true;
        }

        private void dgData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgData.CurrentPageIndex = e.NewPageIndex;
            this.dgData.EditItemIndex = -1;
            this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "P");
        }

        private void dgData_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            string str = ((System.Web.UI.WebControls.TextBox) this.dgData.Items[e.Item.ItemIndex].FindControl("txtGroupPwdPE")).Text.Trim();
            this.dgData.EditItemIndex = -1;
            GroupData data = new GroupData();
            string text = ((System.Web.UI.WebControls.Label) this.dgData.Items[e.Item.ItemIndex].FindControl("lbGroupIDPE")).Text;
            string str3 = ((System.Web.UI.WebControls.Label) this.dgData.Items[e.Item.ItemIndex].FindControl("lboldGroupNamePE")).Text.Trim();
            string str4 = ((System.Web.UI.WebControls.TextBox) this.dgData.Items[e.Item.ItemIndex].FindControl("txtGroupPE")).Text;
            data = new Groups().LoadGroupByID(text);
            DataRow row = data.Tables[0].Rows[0];
            row["CGROUP_NAME"] = str4;
            row["CGROUP_OWNER"] = this.lbUser.Text.Trim().ToUpper();
            row["CGROUP_TYPE"] = "P";
            row["CGROUP_PWD"] = str;
            row["CREATE_DATE"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (new Groups().UpdateGroup(data))
            {
                this.lbMsgP.Text = "更新私人組別成功!";
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  更新私人組別名稱 " + str3 + " 至 " + str4 + "！");
            }
            else
            {
                this.lbMsgP.Text = "更新私人組別失敗!";
            }
            this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "P");
            this.lbMsgP.UpdateAfterCallBack = true;
        }

        private void dgData2_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgData2.EditItemIndex = -1;
            this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "S");
        }

        private void dgData2_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string text = ((System.Web.UI.WebControls.Label) this.dgData2.Items[e.Item.ItemIndex].FindControl("lbGroupIDS")).Text;
            string str2 = ((System.Web.UI.WebControls.Label) this.dgData2.Items[e.Item.ItemIndex].FindControl("lbGroupIDNameS")).Text.Trim();
            if (AppFlag.DeteleGroupMode == "ALL")
            {
                using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    FbTransaction transaction = connection.BeginTransaction();
                    FbCommand command = new FbCommand(null, connection, transaction);
                    string str3 = "delete from GROUP_MEMBER where CGROUP_ID IN (SELECT CGROUP_ID FROM GROUP_INFO WHERE CGROUP_OWNER= '" + this.Context.User.Identity.Name.ToUpper() + "' and CGROUP_ID='" + text + "') ";
                    string str4 = "delete from GROUP_INFO  WHERE CGROUP_OWNER= '" + this.Context.User.Identity.Name.ToUpper() + "' and CGROUP_ID='" + text + "' ";
                    command.CommandText = str3;
                    int num = command.ExecuteNonQuery();
                    command.CommandText = str4;
                    int num2 = command.ExecuteNonQuery();
                    transaction.Commit();
                    connection.Close();
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  delete " + str2 + " 共享組別&聯絡人！");
                    if ((num + num2) > 0)
                    {
                        this.lbMsgS.Text = "刪除 " + str2 + " 共享組別&聯絡人成功!";
                    }
                    else
                    {
                        this.lbMsgS.Text = "刪除 " + str2 + " 共享組別&聯絡人不成功!";
                    }
                }
            }
            else if (new GroupMembers().GetMemberDataByGroupID(text).Tables[0].Rows.Count == 0)
            {
                Groups groups = new Groups();
                GroupData data = new GroupData();
                data = groups.LoadGroupByID(text);
                data.Tables[0].Rows[0].Delete();
                if (groups.DeleteGroup(data))
                {
                    this.lbMsgS.Text = "刪除共享組別成功！";
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  刪除共享組別 " + str2 + " ！");
                }
                else
                {
                    this.lbMsgS.Text = "刪除共享組別失敗！";
                }
            }
            else
            {
                this.lbMsgS.Text = "組別中已存在成員，刪除共享組別失敗！";
            }
            this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "S");
            this.lbMsgS.UpdateAfterCallBack = true;
        }

        private void dgData2_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.lbMsgS.Text = "";
            string str = ((System.Web.UI.WebControls.Label) this.dgData2.Items[e.Item.ItemIndex].FindControl("lbGroupIDNameS")).Text.Trim();
            this.txtGroupS.Text = str;
            this.dgData2.EditItemIndex = e.Item.ItemIndex;
            this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "S");
            this.lbMsgS.UpdateAfterCallBack = true;
            this.txtGroupS.UpdateAfterCallBack = true;
        }

        private void dgData2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgData2.CurrentPageIndex = e.NewPageIndex;
            this.dgData2.EditItemIndex = -1;
            this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "S");
        }

        private void dgData2_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            string id = ((System.Web.UI.WebControls.Label) this.dgData2.Items[e.Item.ItemIndex].FindControl("lbGroupIDSE")).Text.Trim();
            string str2 = ((System.Web.UI.WebControls.Label) this.dgData2.Items[e.Item.ItemIndex].FindControl("lboldGroupNameSE")).Text.Trim();
            string groupname = ((System.Web.UI.WebControls.TextBox) this.dgData2.Items[e.Item.ItemIndex].FindControl("txtGroupSE")).Text.Trim();
            string str4 = ((System.Web.UI.WebControls.TextBox) this.dgData2.Items[e.Item.ItemIndex].FindControl("txtGroupPwdSE")).Text.Trim();
            Groups groups = new Groups();
            GroupData data = new GroupData();
            if ((groups.BoolExistShareGroupName(groupname) && (groupname != Groups.GetGroupNamebyGroupID(id))) || (groupname == Groups.GetGroupNamebyGroupID(id)))
            {
                this.dgData2.EditItemIndex = -1;
                data = groups.LoadGroupByID(id);
                DataRow row = data.Tables[0].Rows[0];
                row["CGROUP_NAME"] = groupname;
                row["CGROUP_OWNER"] = this.lbUser.Text.Trim().ToUpper();
                row["CGROUP_TYPE"] = "S";
                row["CGROUP_PWD"] = str4;
                row["CREATE_DATE"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                if (new Groups().UpdateGroup(data))
                {
                    this.lbMsgS.Text = "更新共享組別成功!";
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  更新共享組別名稱 " + str2 + " 至 " + groupname + "！");
                }
                else
                {
                    this.lbMsgS.Text = "更新共享組別失敗!";
                }
                this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), "S");
            }
            else
            {
                this.lbMsgS.Text = "更新組別失敗，共享組別名稱已存在!";
            }
            this.lbMsgS.UpdateAfterCallBack = true;
        }

        private void dgdata4_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgdata4.Columns[5].HeaderText = "";
            this.dgdata4.Columns[6].HeaderText = "";
            this.dgdata4.EditItemIndex = -1;
            GroupMemberData data = (GroupMemberData) this.Session["memberdata"];
            this.dgdata4.DataSource = data.Tables["GROUP_MEMBER"].DefaultView;
            this.dgdata4.DataBind();
            this.dgdata4.UpdateAfterCallBack = true;
        }

        private void dgdata4_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgdata4.EditItemIndex = -1;
            GroupMembers members = new GroupMembers();
            GroupMemberData data = new GroupMemberData();
            string groupid = ((System.Web.UI.WebControls.Label) this.dgdata4.Items[e.Item.ItemIndex].FindControl("lbdg4GroupID4")).Text.Trim();
            string str2 = ((System.Web.UI.WebControls.Label) this.dgdata4.Items[e.Item.ItemIndex].FindControl("lbdg4GroupName4")).Text.Trim();
            string str3 = ((System.Web.UI.WebControls.Label) this.dgdata4.Items[e.Item.ItemIndex].FindControl("lbdg4Name4")).Text.Trim();
            string memberno = ((System.Web.UI.WebControls.Label) this.dgdata4.Items[e.Item.ItemIndex].FindControl("lbdg4Mobile4")).Text.Trim();
            data = members.LoadMembesByGroupIDAndMemberNo(groupid, memberno);
            data.Tables[0].Rows[0].Delete();
            if (members.DeleteMember(data))
            {
                this.dgdata4.Columns[6].HeaderText = "刪除成功";
                this.dgdata4.Columns[6].HeaderStyle.ForeColor = Color.Red;
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  刪除聯絡人 " + str2 + " " + str3 + " " + memberno + " ！");
            }
            else
            {
                this.dgdata4.Columns[6].HeaderText = "刪除失敗";
                this.dgdata4.Columns[6].HeaderStyle.ForeColor = Color.Red;
            }
            this.dgdata4.Columns[5].HeaderText = "";
            this.GetMemberByGroupID(this.lbUser.Text.Trim(), this.dplAllGroup.SelectedItem.Value.Trim());
        }

        private void dgdata4_EditCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                this.dgdata4.Columns[5].HeaderText = "";
                this.dgdata4.Columns[6].HeaderText = "";
                this.txtMobile4.Text = ((System.Web.UI.WebControls.Label) this.dgdata4.Items[e.Item.ItemIndex].FindControl("lbdg4Mobile4")).Text.Trim();
                this.txtName4.Text = ((System.Web.UI.WebControls.Label) this.dgdata4.Items[e.Item.ItemIndex].FindControl("lbdg4Name4")).Text.Trim();
                this.txtMobile4.UpdateAfterCallBack = true;
                this.txtName4.UpdateAfterCallBack = true;
                this.dgdata4.EditItemIndex = e.Item.ItemIndex;
                GroupMemberData data = (GroupMemberData) this.Session["memberdata"];
                this.dgdata4.DataSource = data.Tables["GROUP_MEMBER"].DefaultView;
                this.dgdata4.DataBind();
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
            }
            this.dgdata4.UpdateAfterCallBack = true;
        }

        private void dgdata4_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                GroupData groupDatabyOwnerAndType = new GroupData();
                groupDatabyOwnerAndType = new Groups().GetGroupDatabyOwnerAndType(this.lbUser.Text.Trim(), this.dplGroupType.SelectedItem.Value);
                try
                {
                    ((System.Web.UI.WebControls.TextBox) e.Item.FindControl("txtdg4Mobile4")).Attributes.Add("onChange", "javascript:return CheckNumAll(this)");
                    ((System.Web.UI.WebControls.DropDownList) e.Item.FindControl("dpldg4Group4")).DataSource = groupDatabyOwnerAndType.Tables[0].DefaultView;
                    ((System.Web.UI.WebControls.DropDownList) e.Item.FindControl("dpldg4Group4")).DataTextField = groupDatabyOwnerAndType.Tables[0].Columns[1].ColumnName;
                    ((System.Web.UI.WebControls.DropDownList) e.Item.FindControl("dpldg4Group4")).DataValueField = groupDatabyOwnerAndType.Tables[0].Columns[0].ColumnName;
                    ((System.Web.UI.WebControls.DropDownList) e.Item.FindControl("dpldg4Group4")).DataBind();
                }
                catch (Exception exception)
                {
                    string str = exception.ToString();
                }
            }
        }

        private void dgdata4_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                string text = ((System.Web.UI.WebControls.Label) e.Item.FindControl("lbdg4GroupID4E")).Text;
                ListItem item = ((System.Web.UI.WebControls.DropDownList) e.Item.FindControl("dpldg4Group4")).Items.FindByValue(text);
                if (item != null)
                {
                    ((System.Web.UI.WebControls.DropDownList) e.Item.FindControl("dpldg4Group4")).ClearSelection();
                    item.Selected = true;
                }
            }
        }

        private void dgdata4_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgdata4.Columns[5].HeaderText = "";
            this.dgdata4.Columns[6].HeaderText = "";
            this.dgdata4.CurrentPageIndex = e.NewPageIndex;
            this.dgdata4.EditItemIndex = -1;
            GroupMemberData data = (GroupMemberData) this.Session["memberdata"];
            this.dgdata4.DataSource = data.Tables["GROUP_MEMBER"].DefaultView;
            this.dgdata4.DataBind();
            this.dgdata4.UpdateAfterCallBack = true;
        }

        private void dgdata4_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgdata4.EditItemIndex = -1;
            GroupMemberData data = new GroupMemberData();
            string groupid = ((System.Web.UI.WebControls.Label) this.dgdata4.Items[e.Item.ItemIndex].FindControl("lbdg4GroupID4E")).Text.Trim();
            string memberno = ((System.Web.UI.WebControls.Label) this.dgdata4.Items[e.Item.ItemIndex].FindControl("lbdg4Mobile4E")).Text.Trim();
            string str3 = ((System.Web.UI.WebControls.Label) this.dgdata4.Items[e.Item.ItemIndex].FindControl("lbdg4GroupName4E")).Text.Trim();
            string str4 = ((System.Web.UI.WebControls.Label) this.dgdata4.Items[e.Item.ItemIndex].FindControl("lbdg4Name4E")).Text.Trim();
            string str5 = ((System.Web.UI.WebControls.TextBox) this.dgdata4.Items[e.Item.ItemIndex].FindControl("txtdg4Name4")).Text.Trim();
            string str6 = ((System.Web.UI.WebControls.TextBox) this.dgdata4.Items[e.Item.ItemIndex].FindControl("txtdg4Mobile4")).Text.Trim();
            string str7 = ((System.Web.UI.WebControls.DropDownList) this.dgdata4.Items[e.Item.ItemIndex].FindControl("dpldg4Group4")).SelectedItem.Value.Trim();
            string str8 = ((System.Web.UI.WebControls.DropDownList) this.dgdata4.Items[e.Item.ItemIndex].FindControl("dpldg4Group4")).SelectedItem.Text.Trim();
            data = new GroupMembers().LoadMembesByGroupIDAndMemberNo(groupid, memberno);
            DataRow row = data.Tables[0].Rows[0];
            row["CGROUP_ID"] = str7;
            row["CMEMBER_NAME"] = str5;
            row["CMOBILENO"] = str6;
            row["CREATE_DATE"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (new GroupMembers().UpdateMember(data))
            {
                this.dgdata4.Columns[5].HeaderText = "更新成功";
                this.dgdata4.Columns[5].HeaderStyle.ForeColor = Color.Red;
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  更新聯絡人 " + str3 + " " + str4 + " " + memberno + " 至 " + str8 + " " + str5 + " " + str6 + "！");
            }
            else
            {
                this.dgdata4.Columns[5].HeaderText = "更新失敗";
                this.dgdata4.Columns[5].HeaderStyle.ForeColor = Color.Red;
            }
            this.dgdata4.Columns[6].HeaderText = "";
            this.GetMemberByGroupID(this.lbUser.Text.Trim(), this.dplAllGroup.SelectedItem.Value.Trim());
        }

        private void dgMember_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgMember.Columns[7].HeaderText = "";
            this.dgMember.Columns[6].HeaderText = "";
            this.dgMember.EditItemIndex = -1;
            GroupMemberData data = (GroupMemberData) this.Session["memberdata"];
            this.dgMember.DataSource = data.Tables["GROUP_MEMBER"].DefaultView;
            this.dgMember.DataBind();
            this.lbMsg6.Text = "";
            this.lbMsg6.UpdateAfterCallBack = true;
        }

        private void dgMember_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgMember.EditItemIndex = -1;
            GroupMembers members = new GroupMembers();
            GroupMemberData data = new GroupMemberData();
            string groupid = ((System.Web.UI.WebControls.Label) this.dgMember.Items[e.Item.ItemIndex].FindControl("lbdgMemberGroupID")).Text.Trim();
            string str2 = ((System.Web.UI.WebControls.Label) this.dgMember.Items[e.Item.ItemIndex].FindControl("lbdgMemberGroupName")).Text.Trim();
            string str3 = ((System.Web.UI.WebControls.Label) this.dgMember.Items[e.Item.ItemIndex].FindControl("lbUName")).Text.Trim();
            string memberno = ((System.Web.UI.WebControls.Label) this.dgMember.Items[e.Item.ItemIndex].FindControl("lbUMobile")).Text.Trim();
            data = members.LoadMembesByGroupIDAndMemberNo(groupid, memberno);
            data.Tables[0].Rows[0].Delete();
            if (members.DeleteMember(data))
            {
                this.dgMember.Columns[7].HeaderText = "刪除成功";
                this.dgMember.Columns[7].HeaderStyle.ForeColor = Color.Red;
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  刪除聯絡人 " + str2 + " " + str3 + " " + memberno + " ！");
            }
            else
            {
                this.dgMember.Columns[7].HeaderText = "刪除失敗";
                this.dgMember.Columns[7].HeaderStyle.ForeColor = Color.Red;
            }
            this.dgMember.Columns[6].HeaderText = "";
            this.lbMsg6.Text = "";
            this.lbMsg6.UpdateAfterCallBack = true;
            this.GetMemberByGroupID(this.lbUser.Text.Trim(), this.dplGroups.SelectedItem.Value.Trim());
        }

        private void dgMember_EditCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgMember.Columns[7].HeaderText = "";
            this.dgMember.Columns[6].HeaderText = "";
            this.lbMsg6.Text = "";
            this.lbMsg6.UpdateAfterCallBack = true;
            this.dgMember.EditItemIndex = e.Item.ItemIndex;
            this.txtMobile.Text = ((System.Web.UI.WebControls.Label) this.dgMember.Items[e.Item.ItemIndex].FindControl("lbUMobile")).Text.Trim();
            this.txtName.Text = ((System.Web.UI.WebControls.Label) this.dgMember.Items[e.Item.ItemIndex].FindControl("lbUName")).Text.Trim();
            this.txtMobile.UpdateAfterCallBack = true;
            this.txtName.UpdateAfterCallBack = true;
            GroupMemberData data = (GroupMemberData) this.Session["memberdata"];
            this.dgMember.DataSource = data.Tables["GROUP_MEMBER"].DefaultView;
            this.dgMember.DataBind();
        }

        private void dgMember_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.EditItem)
                {
                    ((System.Web.UI.WebControls.TextBox) e.Item.FindControl("txtdgMemberMobile")).Attributes.Add("onChange", "javascript:return CheckNumAll(this)");
                }
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
            }
        }

        private void dgMember_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgMember.Columns[7].HeaderText = "";
            this.dgMember.Columns[6].HeaderText = "";
            this.dgMember.CurrentPageIndex = e.NewPageIndex;
            this.dgMember.EditItemIndex = -1;
            GroupMemberData data = (GroupMemberData) this.Session["memberdata"];
            this.dgMember.DataSource = data.Tables["GROUP_MEMBER"].DefaultView;
            this.dgMember.DataBind();
            this.lbMsg6.Text = "";
            this.lbMsg6.UpdateAfterCallBack = true;
        }

        private void dgMember_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            this.dgMember.EditItemIndex = -1;
            GroupMemberData data = new GroupMemberData();
            string groupid = ((System.Web.UI.WebControls.Label) this.dgMember.Items[e.Item.ItemIndex].FindControl("lbdgMemberGroupID")).Text.Trim();
            string memberno = ((System.Web.UI.WebControls.Label) this.dgMember.Items[e.Item.ItemIndex].FindControl("lbdgMemberMobile")).Text.Trim();
            string str3 = ((System.Web.UI.WebControls.Label) this.dgMember.Items[e.Item.ItemIndex].FindControl("lbdgMemberGroupName")).Text.Trim();
            string str4 = ((System.Web.UI.WebControls.Label) this.dgMember.Items[e.Item.ItemIndex].FindControl("lbdgMemberName")).Text.Trim();
            string str5 = ((System.Web.UI.WebControls.TextBox) this.dgMember.Items[e.Item.ItemIndex].FindControl("txtdgMemberName")).Text.Trim();
            string str6 = ((System.Web.UI.WebControls.TextBox) this.dgMember.Items[e.Item.ItemIndex].FindControl("txtdgMemberMobile")).Text.Trim();
            data = new GroupMembers().LoadMembesByGroupIDAndMemberNo(groupid, memberno);
            DataRow row = data.Tables[0].Rows[0];
            row["CGROUP_ID"] = groupid;
            row["CMEMBER_NAME"] = str5;
            row["CMOBILENO"] = str6;
            row["CREATE_DATE"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (new GroupMembers().UpdateMember(data))
            {
                this.dgMember.Columns[6].HeaderText = "更新成功";
                this.dgMember.Columns[6].HeaderStyle.ForeColor = Color.Red;
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  更新聯絡人 " + str3 + " " + str4 + " " + memberno + " 至 " + str3 + " " + str5 + " " + str6 + "！");
            }
            else
            {
                this.dgMember.Columns[6].HeaderText = "更新失敗";
                this.dgMember.Columns[6].HeaderStyle.ForeColor = Color.Red;
            }
            this.dgMember.Columns[7].HeaderText = "";
            this.lbMsg6.Text = "";
            this.lbMsg6.UpdateAfterCallBack = true;
            this.GetMemberByGroupID(this.lbUser.Text.Trim(), this.dplGroups.SelectedItem.Value.Trim());
        }

        private void dplAllGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgdata4.Columns[5].HeaderText = "";
            this.dgdata4.Columns[6].HeaderText = "";
            this.dgdata4.CurrentPageIndex = 0;
            this.GetMemberByGroupID(this.lbUser.Text.Trim(), this.dplAllGroup.SelectedItem.Value.Trim());
        }

        private void dplGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgMember.Columns[7].HeaderText = "";
            this.dgMember.Columns[6].HeaderText = "";
            this.dgMember.CurrentPageIndex = 0;
            this.GetMemberByGroupID(this.lbUser.Text.Trim(), this.dplGroups.SelectedItem.Value.Trim());
            this.lbMsg6.Text = "";
            this.lbMsg6.UpdateAfterCallBack = true;
        }

        private void dplGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgdata4.Columns[5].HeaderText = "";
            this.dgdata4.Columns[6].HeaderText = "";
            this.dgdata4.CurrentPageIndex = 0;
            this.GetGroupbyOwnerAndType(this.lbUser.Text.Trim(), this.dplGroupType.SelectedItem.Value);
            this.GetMemberbyOwnerAndType(this.lbUser.Text.Trim(), this.dplGroupType.SelectedItem.Value);
            this.dplAllGroup.UpdateAfterCallBack = true;
            this.dgdata4.UpdateAfterCallBack = true;
        }

        private void GetGroupbyOwnerAndType(string username, string type)
        {
            GroupData groupDatabyOwnerAndType = new GroupData();
            groupDatabyOwnerAndType = new Groups().GetGroupDatabyOwnerAndType(username, type);
            if (this.panel1.Visible)
            {
                using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
                {
                    connection.Open();
                    foreach (DataRow dr in groupDatabyOwnerAndType.Tables[0].Rows)
                    {
                        string selectString = "select count(*) from GROUP_MEMBER where  CGROUP_ID='" + dr["CGROUP_ID"].ToString() + "'";
                        FbCommand cmd = new FbCommand(selectString, connection);
                        dr.BeginEdit();
                        dr["CREATE_COUNT"] = (int)cmd.ExecuteScalar();
                        dr.EndEdit();
                    }
                    connection.Close();
                }

                this.dgData.DataSource = groupDatabyOwnerAndType.Tables[0].DefaultView;
                this.dgData.DataBind();
                this.dgData.UpdateAfterCallBack = true;
            }
            else if (this.panel2.Visible)
            {
                using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
                {
                    connection.Open();
                    foreach (DataRow dr in groupDatabyOwnerAndType.Tables[0].Rows)
                    {
                        string selectString = "select count(*) from GROUP_MEMBER where  CGROUP_ID='" + dr["CGROUP_ID"].ToString() + "'";
                        FbCommand cmd = new FbCommand(selectString, connection);
                        dr.BeginEdit();
                        dr["CREATE_COUNT"] = (int)cmd.ExecuteScalar();
                        dr.EndEdit();
                    }
                    connection.Close();
                }

                this.dgData2.DataSource = groupDatabyOwnerAndType.Tables[0].DefaultView;
                this.dgData2.DataBind();
                if (!Users.UserAdminCheck(this.Context.User.Identity.Name))
                {
                    this.dgData2.Columns[6].Visible = false;
                    this.dgData2.Columns[7].Visible = false;
                }
                this.dgData2.UpdateAfterCallBack = true;
            }
            else if (!this.panel3.Visible)
            {
                if (this.panel4.Visible)
                {
                    this.Session["memberdata"] = groupDatabyOwnerAndType;
                    this.dplAllGroup.DataSource = groupDatabyOwnerAndType.Tables["GROUP_INFO"].DefaultView;
                    this.dplAllGroup.DataTextField = "CGROUP_NAME";
                    this.dplAllGroup.DataValueField = "CGROUP_ID";
                    this.dplAllGroup.DataBind();
                    int count = groupDatabyOwnerAndType.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        this.dplAllGroup.Items.Insert(count, "All");
                    }
                    this.dplAllGroup.UpdateAfterCallBack = true;
                }
                else if (!this.panel5.Visible && this.panel6.Visible)
                {
                    groupDatabyOwnerAndType = new Groups().GetGroupDatabyAdminatMemberPage(username, type);
                    this.dplGroups.DataSource = groupDatabyOwnerAndType.Tables["GROUP_INFO"].DefaultView;
                    this.dplGroups.DataTextField = "CGROUP_NAME";
                    this.dplGroups.DataValueField = "CGROUP_ID";
                    this.dplGroups.DataBind();
                    for (int i = 0; i < this.dplGroups.Items.Count; i++)
                    {
                        if (!Users.UserAdminCheck(this.Context.User.Identity.Name))
                        {
                            if (type == "S")
                            {
                                this.dplGroups.Items[i].Text = this.dplGroups.Items[i].Text + "(共享)";
                            }
                            else if (type == "P")
                            {
                                this.dplGroups.Items[i].Text = this.dplGroups.Items[i].Text + "(私人)";
                            }
                        }
                    }
                    int index = groupDatabyOwnerAndType.Tables[0].Rows.Count;
                    if (index > 0)
                    {
                        ListItem item = new ListItem("All", "All");
                        this.dplGroups.Items.Insert(index, item);
                    }
                }
            }
            this.dgData2.Columns[2].Visible = false;
            this.dgData.Columns[2].Visible = false;
        }

        public string GetGroupName(object id)
        {
            return Groups.GetGroupNamebyGroupID(id.ToString()).ToString();
        }

        private void GetMemberbyAdminatMemberPage(string username, string type)
        {
            GroupMemberData memberDatabyAdminatMemberPage = new GroupMemberData();
            if ((this.dplGroups.SelectedIndex == -1) || (this.dplGroups.SelectedItem.Text.Trim() == "All"))
            {
                memberDatabyAdminatMemberPage = new GroupMembers().GetMemberDatabyAdminatMemberPage(username, type);
            }
            else
            {
                memberDatabyAdminatMemberPage = new GroupMembers().GetMemberDataByGroupID(this.dplGroups.SelectedItem.Value.Trim());
            }
            this.Session["memberdata"] = memberDatabyAdminatMemberPage;
            this.dgMember.DataSource = memberDatabyAdminatMemberPage.Tables["GROUP_MEMBER"].DefaultView;
            this.dgMember.DataBind();
            this.dgMember.UpdateAfterCallBack = true;
        }

        private void GetMemberByGroupID(string username, string groupid)
        {
            GroupMemberData memberDatabyAllGroupAndOwner = new GroupMemberData();
            GroupMembers members = new GroupMembers();
            if (this.panel4.Visible)
            {
                if (this.dplAllGroup.SelectedItem.Text == "All")
                {
                    memberDatabyAllGroupAndOwner = members.GetMemberDatabyAllGroupAndOwner(username, this.dplGroupType.SelectedItem.Value);
                }
                else
                {
                    memberDatabyAllGroupAndOwner = members.GetMemberDataByGroupID(groupid);
                }
                this.Session["memberdata"] = memberDatabyAllGroupAndOwner;
                this.dgdata4.DataSource = memberDatabyAllGroupAndOwner.Tables["GROUP_MEMBER"].DefaultView;
                this.dgdata4.DataBind();
                if ((this.dplGroupType.SelectedItem.Value == "S") && !Users.UserAdminCheck(username))
                {
                    this.dgdata4.Columns[6].Visible = false;
                    this.dgdata4.Columns[5].Visible = false;
                }
                else
                {
                    this.dgdata4.Columns[6].Visible = true;
                    this.dgdata4.Columns[5].Visible = true;
                }
                this.dgdata4.UpdateAfterCallBack = true;
            }
            else if (this.panel6.Visible)
            {
                if (this.dplGroups.SelectedItem.Value == "All")
                {
                    if (Users.UserAdminCheck(this.Context.User.Identity.Name))
                    {
                        memberDatabyAllGroupAndOwner = members.GetMemberDatabyAdminatMemberPage(username, "S");
                    }
                    else
                    {
                        memberDatabyAllGroupAndOwner = members.GetMemberDatabyAdminatMemberPage(username, "P");
                    }
                }
                else
                {
                    memberDatabyAllGroupAndOwner = members.GetMemberDataByGroupID(groupid);
                }
                this.Session["memberdata"] = memberDatabyAllGroupAndOwner;
                this.dgMember.DataSource = memberDatabyAllGroupAndOwner.Tables["GROUP_MEMBER"].DefaultView;
                this.dgMember.DataBind();
                this.dgMember.UpdateAfterCallBack = true;
            }
        }

        private void GetMemberbyOwnerAndType(string username, string type)
        {
            try
            {
                GroupMemberData memberDatabyAllGroupAndOwner = new GroupMemberData();
                if ((this.dplAllGroup.SelectedIndex == -1) || (this.dplAllGroup.SelectedItem.Text.Trim() == "All"))
                {
                    memberDatabyAllGroupAndOwner = new GroupMembers().GetMemberDatabyAllGroupAndOwner(username, type);
                }
                else
                {
                    memberDatabyAllGroupAndOwner = new GroupMembers().GetMemberDataByGroupID(this.dplAllGroup.SelectedItem.Value.Trim());
                }
                this.Session["memberdata"] = memberDatabyAllGroupAndOwner;
                this.dgdata4.DataSource = memberDatabyAllGroupAndOwner.Tables[0].DefaultView;
                this.dgdata4.DataBind();
                if ((type == "S") && !Users.UserAdminCheck(username))
                {
                    this.dgdata4.Columns[6].Visible = false;
                    this.dgdata4.Columns[5].Visible = false;
                }
                else
                {
                    this.dgdata4.Columns[6].Visible = true;
                    this.dgdata4.Columns[5].Visible = true;
                }
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
            }
            this.dgdata4.UpdateAfterCallBack = true;
        }

        private void InitializeComponent()
        {
            this.btnAddGroupP.Click += new EventHandler(this.btnAddGroupP_Click);
            this.btnDeleteP.Click += new EventHandler(this.btnDeleteP_Click);
            this.dgData.DeleteCommand += new DataGridCommandEventHandler(this.dgData_DeleteCommand);
            this.dgData.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgData_PageIndexChanged);
            this.dgData.UpdateCommand += new DataGridCommandEventHandler(this.dgData_UpdateCommand);
            this.dgData.CancelCommand += new DataGridCommandEventHandler(this.dgData_CancelCommand);
            this.dgData.EditCommand += new DataGridCommandEventHandler(this.dgData_EditCommand);
            this.btnAddGroupS.Click += new EventHandler(this.btnAddGroupS_Click);
            this.btnDeleteS.Click += new EventHandler(this.btnDeleteS_Click);
            this.dgData2.DeleteCommand += new DataGridCommandEventHandler(this.dgData2_DeleteCommand);
            this.dgData2.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgData2_PageIndexChanged);
            this.dgData2.UpdateCommand += new DataGridCommandEventHandler(this.dgData2_UpdateCommand);
            this.dgData2.CancelCommand += new DataGridCommandEventHandler(this.dgData2_CancelCommand);
            this.dgData2.EditCommand += new DataGridCommandEventHandler(this.dgData2_EditCommand);
            this.dplGroupType.SelectedIndexChanged += new EventHandler(this.dplGroupType_SelectedIndexChanged);
            this.dplAllGroup.SelectedIndexChanged += new EventHandler(this.dplAllGroup_SelectedIndexChanged);
            this.btnSearch4.Click += new EventHandler(this.btnSearch4_Click);
            this.dgdata4.ItemCreated += new DataGridItemEventHandler(this.dgdata4_ItemCreated);
            this.dgdata4.DeleteCommand += new DataGridCommandEventHandler(this.dgdata4_DeleteCommand);
            this.dgdata4.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgdata4_PageIndexChanged);
            this.dgdata4.UpdateCommand += new DataGridCommandEventHandler(this.dgdata4_UpdateCommand);
            this.dgdata4.CancelCommand += new DataGridCommandEventHandler(this.dgdata4_CancelCommand);
            this.dgdata4.ItemDataBound += new DataGridItemEventHandler(this.dgdata4_ItemDataBound);
            this.dgdata4.EditCommand += new DataGridCommandEventHandler(this.dgdata4_EditCommand);
            this.cbCheckAll.CheckedChanged += new EventHandler(this.cbCheckAll_CheckedChanged);
            this.btnSaveRight.Click += new EventHandler(this.btnSaveRight_Click);
            this.rbGroupP.CheckedChanged += new EventHandler(this.rbGroupP_CheckedChanged);
            this.rbGroupS.CheckedChanged += new EventHandler(this.rbGroupS_CheckedChanged);
            this.rbTypeAdd.CheckedChanged += new EventHandler(this.rbTypeAdd_CheckedChanged);
            this.rbTypeCover.CheckedChanged += new EventHandler(this.rbTypeCover_CheckedChanged);
            this.btnUpload.Click += new EventHandler(this.btnUpload_Click);
            this.dplGroups.SelectedIndexChanged += new EventHandler(this.dplGroups_SelectedIndexChanged);
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            this.btnDeleteMember.Click += new EventHandler(this.btnDeleteMember_Click);
            this.dgMember.ItemCreated += new DataGridItemEventHandler(this.dgMember_ItemCreated);
            this.dgMember.DeleteCommand += new DataGridCommandEventHandler(this.dgMember_DeleteCommand);
            this.dgMember.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgMember_PageIndexChanged);
            this.dgMember.UpdateCommand += new DataGridCommandEventHandler(this.dgMember_UpdateCommand);
            this.dgMember.CancelCommand += new DataGridCommandEventHandler(this.dgMember_CancelCommand);
            this.dgMember.EditCommand += new DataGridCommandEventHandler(this.dgMember_EditCommand);
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
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
                if (Users.UserAdminCheck(this.Context.User.Identity.Name))
                {
                    string str = (base.Request["sIndex"] == null) ? "0" : base.Request["sIndex"];
                    if (!this.Page.IsPostBack)
                    {
                        Manager.Register(this.Page);
                        string username = this.Context.User.Identity.Name.Trim();
                        if (str == "0")
                        {
                            this.panel1.Visible = true;
                            this.Requiredfieldvalidator7.Enabled = false;
                            if (AppFlag.DeteleGroupMode == "ALL")
                            {
                                ((Anthem.Button)this.FindControl("btnDeleteP")).Attributes.Add("onclick", "return confirm('確定刪除所有私人組別&聯絡人？');");
                            }
                            else
                            {
                                this.btnDeleteP.Visible = false;
                            }
                            this.panel2.Visible = false;
                            this.panel3.Visible = false;
                            this.panel4.Visible = false;
                            this.panel5.Visible = false;
                            this.panel6.Visible = false;
                            this.GetGroupbyOwnerAndType(username, "P");
                        }
                        else
                        {
                            switch (str)
                            {
                                case "2":
                                    this.panel1.Visible = false;
                                    this.panel2.Visible = false;
                                    this.panel3.Visible = true;
                                    this.panel4.Visible = false;
                                    this.panel5.Visible = false;
                                    this.panel6.Visible = false;
                                    this.BindUserRight();
                                    break;

                                case "3":
                                    this.panel1.Visible = false;
                                    this.panel2.Visible = false;
                                    this.panel3.Visible = false;
                                    this.panel4.Visible = true;
                                    this.panel5.Visible = false;
                                    this.panel6.Visible = false;
                                    if (!Users.UserShareGroup(username) && !Users.UserAdminCheck(username))
                                    {
                                        this.dplGroupType.Enabled = false;
                                    }
                                    this.GetGroupbyOwnerAndType(username, "P");
                                    this.GetMemberbyOwnerAndType(username, "P");
                                    break;

                                case "4":
                                    this.panel1.Visible = false;
                                    this.panel2.Visible = false;
                                    this.panel3.Visible = false;
                                    this.panel4.Visible = false;
                                    this.panel5.Visible = true;
                                    this.panel6.Visible = false;
                                    if (!Users.UserAdminCheck(username))
                                    {
                                        this.rbGroupS.Enabled = false;
                                        this.rbGroupP.Enabled = false;
                                    }
                                    break;

                                case "5":
                                    ((Anthem.Button)this.FindControl("btnDeleteMember")).Attributes.Add("onclick", "return confirm('確定刪除聯絡人？');");
                                    this.panel1.Visible = false;
                                    this.panel2.Visible = false;
                                    this.panel3.Visible = false;
                                    this.panel4.Visible = false;
                                    this.panel5.Visible = false;
                                    this.panel6.Visible = true;
                                    if (Users.UserAdminCheck(username))
                                    {
                                        this.GetGroupbyOwnerAndType(username, "S");
                                        this.GetMemberbyAdminatMemberPage(username, "S");
                                    }
                                    else
                                    {
                                        this.GetGroupbyOwnerAndType(username, "P");
                                        this.GetMemberbyAdminatMemberPage(username, "P");
                                    }
                                    break;

                                case "1":
                                    if (AppFlag.DeteleGroupMode == "ALL")
                                    {
                                        ((Anthem.Button)this.FindControl("btnDeleteS")).Attributes.Add("onclick", "return confirm('確定刪除所有共享組別&聯絡人？');");
                                    }
                                    else
                                    {
                                        this.btnDeleteS.Visible = false;
                                    }
                                    this.panel1.Visible = false;
                                    this.panel2.Visible = true;
                                    this.Requiredfieldvalidator8.Enabled = false;
                                    this.panel3.Visible = false;
                                    this.panel4.Visible = false;
                                    this.panel5.Visible = false;
                                    this.panel6.Visible = false;
                                    if (!Users.UserAdminCheck(username))
                                    {
                                        this.btnAddGroupS.Visible = false;
                                        this.lbGroupS.Visible = false;
                                        this.txtGroupS.Visible = false;
                                        this.lbGroupSPwd.Visible = false;
                                        this.tbGroupSPwd.Visible = false;
                                        this.btnDeleteS.Visible = false;
                                    }
                                    this.GetGroupbyOwnerAndType(username, "S");
                                    break;
                            }
                        }
                    }
                    if (str == "4")
                    {
                        if (this.Session["doload"] == null)
                        {
                            this.doload = new Doload();
                            this.Session["doload"] = this.doload;
                        }
                        else
                        {
                            this.doload = (Doload)this.Session["doload"];
                        }
                    }
                }
                else
                {
                    this.Response.Write("<b><font color=red >Access Denied！</font></b>");
                } 
            }
        }

        private void rbGroupP_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbGroupP.Checked)
            {
                this.rbGroupS.Checked = false;
                this.rbGroupS.UpdateAfterCallBack = true;
                this.lbUploadResult.Text = "";
                this.lbUploadResult.UpdateAfterCallBack = true;
            }
        }

        private void rbGroupS_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbGroupS.Checked)
            {
                this.rbGroupP.Checked = false;
                this.rbGroupP.UpdateAfterCallBack = true;
                this.lbUploadResult.Text = "";
                this.lbUploadResult.UpdateAfterCallBack = true;
            }
        }

        private void rbTypeAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbTypeAdd.Checked)
            {
                this.rbTypeCover.Checked = false;
                this.rbTypeCover.UpdateAfterCallBack = true;
                this.lbUploadResult.Text = "";
                this.lbUploadResult.UpdateAfterCallBack = true;
            }
        }

        private void rbTypeCover_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbTypeCover.Checked)
            {
                this.rbTypeAdd.Checked = false;
                this.rbTypeAdd.UpdateAfterCallBack = true;
                this.lbUploadResult.Text = "";
                this.lbUploadResult.UpdateAfterCallBack = true;
            }
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            string centaSmsUploadFolder = AppFlag.CentaSmsUploadFolder;
            string strFileName = this.btnUploadMode.PostedFile.FileName.ToUpper();
            string str2 = Path.GetFileName(strFileName).ToUpper();
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + centaSmsUploadFolder + str2;
          
            bool flag = true;
            string str4 = "";
            if (str2 != "")
            {
                try
                {
                    if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + centaSmsUploadFolder))
                    {
                        Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString() + centaSmsUploadFolder);
                    }
                    if (File.Exists(path))
                    {

                        if (strFileName.LastIndexOf("XLS") == strFileName.Length - 3)
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + centaSmsUploadFolder + str2.Substring(0, str2.LastIndexOf(".XLS")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".XLS";
                        }
                        else if (strFileName.LastIndexOf("CSV") == strFileName.Length - 3)
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + centaSmsUploadFolder + str2.Substring(0, str2.LastIndexOf(".CSV")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".CSV";
                        }
                        else
                        {
                            path = AppDomain.CurrentDomain.BaseDirectory.ToString() + centaSmsUploadFolder + str2 + "_" + DateTime.Now.ToString("MMddHHmm");
                        }
                    }
                    this.btnUploadMode.PostedFile.SaveAs(path);
                }
                catch (Exception exception)
                {
                    flag = false;
                    str4 = str2 + " Error: " + exception.ToString();
                }
                Files.CicsWriteLog("\r\n"+DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  開始上載 " + str2 + "！");
                if (flag)
                {
                    try
                    {
                        if (this.doload.State != 1)
                        {
                            SmsActions actions = new SmsActions();
                            SmsActionData data = new SmsActionData();
                            string str5 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
                            DataRow row = data.Tables["SMS_ACTIONS"].NewRow();
                            row["CSMS_ACTION_CONTENT"] = str2;
                            row["CSMS_ACTION_TYPE"] = "UPLOAD";
                            row["CSMS_ACTION_STATUS"] = "進行中";
                            row["CACTION_HANDLER"] = this.Context.User.Identity.Name;
                            row["ACTION_STARTTIME"] = str5;
                            row["ACTION_ENDTIME"] = "";
                            row["ACTION_REMARKS"] = "";
                            data.Tables["SMS_ACTIONS"].Rows.Add(row);
                            if (actions.InsertAction(data))
                            {
                                this.doload.strcondtion = str5;
                                this.doload.dolbUploadResult = "";
                                this.doload.dolbUser = this.Context.User.Identity.Name;
                                this.doload.FileName = str2;
                                this.doload.dobtnUploadMode = path;
                                if (this.rbGroupP.Checked)
                                {
                                    this.doload.dorbGroupP = true;
                                }
                                if (this.rbTypeAdd.Checked)
                                {
                                    this.doload.dorbTypeAdd = true;
                                }
                                this.div_load.Visible = true;
                                this.Page.RegisterStartupScript("", "<script>location.href=location.href;</script>");
                                this.doload.runload();
                            }
                        }
                    }
                    catch (Exception exception2)
                    {
                        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  Uploaded " + str2 + " Error: " + exception2.ToString());
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  停止上載 " + str2 + " 組別！");
                    }
                }
                else
                {
                    this.doload.dolbUploadResult = "上載失敗 ！";
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  Upload " + str4);
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.Context.User.Identity.Name + ")  停止上載 " + str2 + "！");
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
    }
}

