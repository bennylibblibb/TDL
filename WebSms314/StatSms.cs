namespace CENTASMS
{
    using Anthem;
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Web.UI;
    using System .Globalization ;
    using System.Web.UI.WebControls;

    public class StatSms : Page
    {
        protected Anthem.Button btnSearchSch;
        private IFormatProvider culture = new CultureInfo("en-GB", true);
        protected Anthem.DataGrid dgData;
        protected Anthem.DropDownList dplUsers;
        protected Anthem.Label lbMsgSch;
        protected System.Web.UI.WebControls.Label lbUser;
        protected Anthem.Panel plSendMsg;
        protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvMsg;
        protected System.Web.UI.WebControls.RequiredFieldValidator rfvNum;
        protected System.Web.UI.WebControls.TextBox txtEndDate2;
        protected System.Web.UI.WebControls.TextBox txtStartDate2;

        private void btnSearchSch_Click(object sender, EventArgs e)
        {
            this.GetSmsStatist(this.dplUsers.SelectedItem.Text.Trim(), this.txtStartDate2.Text, this.txtEndDate2.Text);
            this.dgData.UpdateAfterCallBack = true;
        }

        private void dgData_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.dgData.CurrentPageIndex = e.NewPageIndex;
            this.dgData.DataSource = (DataTable) this.Session["smsstatdata"];
            this.dgData.PageSize = AppFlag.iPageSize;
            this.dgData.DataBind();
            this.dgData.UpdateAfterCallBack = true;
        }

        private void dplUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.GetSmsStatist(this.dplUsers.SelectedItem.Text.Trim(), "", "");
            this.dgData.UpdateAfterCallBack = true;
        }

        private string GetSmsCount(string name, string startdate, string enddate)
        {
            int length = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            string strCondition = "";
            if (startdate == "")
            {
                strCondition = "CSENDER='" + name + "' and CBATCHID  like 'B%' ";
            }
            else
            {
                strCondition = "CSENDER='" + name + "' AND '" + startdate + " 00:00:01'<= create_date AND  create_date<='" + enddate + " 23:59:59'and CBATCHID  like 'B%' ";
            }
            SmsMsgHistData data = new SmsMsgHistData();
            SmsMsgHists hists = new SmsMsgHists();
            DataRow[] rowArray = hists.LoadSmsHisDataBy(strCondition).Tables[0].Select();
            length = rowArray.Length;
            foreach (DataRow row in rowArray)
            {
                num2 += Convert.ToInt32(row["ISMSMSGNO"]);
                num3 += Convert.ToInt32(row["IMOBILETOTAL"]);
                num4 += Convert.ToInt32(row["ISMSMSGNO"]) * Convert.ToInt32(row["IMOBILETOTAL"]);
            }
            int num5 = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = 0;
            if (startdate == "")
            {
                strCondition = "CSENDER='" + name + "' and CBATCHID  like 'S%' ";
            }
            else
            {
                strCondition = "CSENDER='" + name + "' AND '" + startdate + " 00:00:01'<= create_date AND  create_date<='" + enddate + " 23:59:59'and CBATCHID  like 'S%' ";
            }
            rowArray = hists.LoadSmsHisDataBy(strCondition).Tables[0].Select();
            num5 = rowArray.Length;
            foreach (DataRow row2 in rowArray)
            {
                num6 += Convert.ToInt32(row2["ISMSMSGNO"]);
                num7 += Convert.ToInt32(row2["IMOBILETOTAL"]);
                num8 += Convert.ToInt32(row2["ISMSMSGNO"]) * Convert.ToInt32(row2["IMOBILETOTAL"]);
            }
            int num9 = 0;
            int num10 = 0;
            int num11 = 0;
            int num12 = 0;
            if (startdate == "")
            {
                strCondition = "CALLER='" + name + "' and CBATCHID  like 'B%' ";
            }
            else
            {
                strCondition = "CALLER='" + name + "' AND '" + startdate + " 00:00:01'<= create_date AND  create_date<='" + enddate + " 23:59:59'and CBATCHID  like 'B%' ";
            }
            rowArray = hists.LoadSmsHisDataBy(strCondition).Tables[0].Select();
            num9 = rowArray.Length;
            foreach (DataRow row3 in rowArray)
            {
                num10 += Convert.ToInt32(row3["ISMSMSGNO"]);
                num11 += Convert.ToInt32(row3["IMOBILETOTAL"]);
                num12 += Convert.ToInt32(row3["ISMSMSGNO"]) * Convert.ToInt32(row3["IMOBILETOTAL"]);
            }
            string str4 = Convert.ToString((int) ((length + num5) + num9)) + "(" + length.ToString() + "/" + num5.ToString() + "/" + num9.ToString() + ")";
            string str5 = str4 + "," + Convert.ToString((int) ((num2 + num6) + num10)) + "(" + num2.ToString() + "/" + num6.ToString() + "/" + num10.ToString() + ")";
            string str6 = str5 + "," + Convert.ToString((int) ((num3 + num7) + num11)) + "(" + num3.ToString() + "/" + num7.ToString() + "/" + num11.ToString() + ")";
            return (str6 + "," + Convert.ToString((int) ((num4 + num8) + num12)) + "(" + num4.ToString() + "/" + num8.ToString() + "/" + num12.ToString() + ")");
        }

        private void GetSmsStatist(string name, string startdate, string enddate)
        {
            DataRow row;
            this.dgData.CurrentPageIndex = 0;
            DataTable table = new DataTable("SMS_STAT");
            DataColumnCollection columns = table.Columns;
            columns.Add("NAME", typeof(string));
            columns.Add("SMS_COUNT", typeof(string));
            columns.Add("SMS_PART", typeof(string));
            columns.Add("SMS_NUM", typeof(string));
            columns.Add("SMS_ALLCOUNT", typeof(string));
            columns.Add("SMS_REMARK", typeof(string));
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            if (name == "All")
            {
                foreach (DataRow row2 in new Users().GetUserDataBy(" WHERE USER_RIGHT<>'" + AppFlag.CentaSmsExtra + "'").Tables[0].Select())
                {
                    name = row2["USER_ID"].ToString();
                    string[] strArray = Regex.Split(this.GetSmsCount(name, startdate, enddate), ",", RegexOptions.IgnoreCase);
                    row = table.NewRow();
                    row[0] = name;
                    row[1] = strArray[0];
                    num += Convert.ToInt32(strArray[0].Substring(0, strArray[0].IndexOf("(")));
                    row[2] = strArray[1];
                    num2 += Convert.ToInt32(strArray[1].Substring(0, strArray[1].IndexOf("(")));
                    row[3] = strArray[2];
                    num3 += Convert.ToInt32(strArray[2].Substring(0, strArray[2].IndexOf("(")));
                    row[4] = strArray[3];
                    num4 += Convert.ToInt32(strArray[3].Substring(0, strArray[3].IndexOf("(")));
                    row[5] = "";
                    table.Rows.Add(row);
                }
            }
            else
            {
                string[] strArray2 = Regex.Split(this.GetSmsCount(name, startdate, enddate), ",", RegexOptions.IgnoreCase);
                row = table.NewRow();
                row[0] = name;
                row[1] = strArray2[0];
                row[2] = strArray2[1];
                row[3] = strArray2[2];
                row[4] = strArray2[3];
                row[5] = "";
                table.Rows.Add(row);
                num = Convert.ToInt32(strArray2[0].Substring(0, strArray2[0].IndexOf("(")));
                num2 = Convert.ToInt32(strArray2[1].Substring(0, strArray2[1].IndexOf("(")));
                num3 = Convert.ToInt32(strArray2[2].Substring(0, strArray2[2].IndexOf("(")));
                num4 = Convert.ToInt32(strArray2[3].Substring(0, strArray2[3].IndexOf("(")));
            }
            row = table.NewRow();
            row[0] = "統計:";
            row[1] = num.ToString();
            row[2] = num2.ToString();
            row[3] = num3.ToString();
            row[4] = num4.ToString();
            row[5] = Convert.ToString(table.Rows.Count) + " 行";
            table.Rows.Add(row);
            this.dgData.DataSource = table;
            this.dgData.PageSize = AppFlag.iPageSize;
            this.dgData.DataBind();
            this.Session["smsstatdata"] = table;
        }

        private void InitializeComponent()
        {
            this.dplUsers.SelectedIndexChanged += new EventHandler(this.dplUsers_SelectedIndexChanged);
            this.btnSearchSch.Click += new EventHandler(this.btnSearchSch_Click);
            this.dgData.PageIndexChanged += new DataGridPageChangedEventHandler(this.dgData_PageIndexChanged);
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
                if (!this.Page.IsPostBack)
                {
                    this.lbUser.Text = this.Context.User.Identity.Name;
                    this.txtEndDate2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    this.txtStartDate2.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    UserData userDataBy = new Users().GetUserDataBy("");
                    this.dplUsers.DataSource = userDataBy.Tables[0].DefaultView;
                    this.dplUsers.DataTextField = "USER_ID";
                    this.dplUsers.DataBind();
                    this.dplUsers.Items.Insert(0, "All");
                    ListItem item = this.dplUsers.Items.FindByText(this.Context.User.Identity.Name);
                    this.dplUsers.ClearSelection();
                    item.Selected = true;
                    if (!Users.UserAdminCheck(this.Context.User.Identity.Name))
                    {
                        this.dplUsers.Enabled = false;
                    }
                    else
                    {
                        this.dplUsers.Enabled = true;
                    }
                    this.GetSmsStatist(this.dplUsers.SelectedItem.Text.Trim(), "", "");
                }
            }
            else
            {
                base.Response.Redirect("Default.aspx", false);
            }
        }
    }
}

