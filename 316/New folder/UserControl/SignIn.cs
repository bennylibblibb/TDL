namespace CENTASMS.UserControl
{
    using CENTASMS;
    using CENTASMS.BLL;
    using CENTASMS.Common;
    using CENTASMS.DAL;
    using System;
    using System.Collections;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class SignIn : UserControl
    {
        protected Button BtnSignin;
        protected Label Message;
        private string msg = "";
        protected TextBox Password;
        protected CheckBox RememberCheckbox;
        protected RequiredFieldValidator RequiredFieldValidator1;
        protected RequiredFieldValidator RequiredFieldValidator2;
        protected RequiredFieldValidator RequiredFieldValidator3;
        protected ResourceHelper res;
        protected TextBox txtValidate;
        protected TextBox UserID;
        protected Anthem.CheckBox rcLanguage;
        protected Label lbUserInfo;
        protected Label lbUserInfoID;
        protected Label lbUserInfoPwd;
        protected  Label lbValidateCode;
        protected System.Web.UI.HtmlControls.HtmlInputButton btnCCannel;

        private void Btnsignin_Click(object sender, EventArgs e)
        {
            if (base.Request.Cookies["CheckCode"] == null)
            {
                this.Message.Text = "<br>Cookie Is Block！<br>";
                this.Message.Visible = true;
            }
            else if (string.Compare(base.Request.Cookies["CheckCode"].Value, this.txtValidate.Text, true) != 0)
            {
                this.Message.Text = "<br>驗證碼錯誤！<br>";
                this.Message.Visible = true;
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.UserID.Text.ToUpper() + ")" + "  驗證碼錯誤！");

            }
            else
            {
                try
                {
                    string str = "";
                    UserData data = new Users().GetUserByUSER_ID(this.UserID.Text.ToUpper(), this.Password.Text.Trim());
                    if (data != null)
                    {
                        str = data.Tables[0].Rows[0]["USER_ID"].ToString().ToUpper();
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  " + str + " login success.");
                        FormsAuthentication.SetAuthCookie(str.ToUpper(), this.RememberCheckbox.Checked);
                        FormsAuthentication.RedirectFromLoginPage(str.ToUpper(), false);
                        Hashtable hashtable = (Hashtable)base.Application["Online"];
                        if (hashtable != null)
                        {
                            for (int i = 0; i < hashtable.Count; i++)
                            {
                                IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
                                string str2 = "";
                                while (enumerator.MoveNext())
                                {
                                    if ((enumerator.Value != null) && enumerator.Value.ToString().Equals(str.ToUpper()))
                                    {
                                        str2 = enumerator.Key.ToString();
                                        hashtable[str2] = "XXXXXX";
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            hashtable = new Hashtable();
                        }
                        hashtable[base.Session.SessionID] = str.ToUpper();
                        base.Application.Lock();
                        base.Application["Online"] = hashtable;
                        base.Application.UnLock();
                    }
                    else
                    {
                        this.Message.Text = "<br>Login Failure！<br>";
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.UserID.Text.ToUpper() + ")" + "  Invalid UserName or Password,Login Failure！");

                    }
                }
                catch
                {
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.UserID.Text.ToUpper() + ")" + "  Database error,Login Failure！");

                }
            }
        }

        private void InitializeComponent()
        {
            this.BtnSignin.Click += new EventHandler(this.Btnsignin_Click); 
             this.rcLanguage.CheckedChanged  += new EventHandler(this.Check_Clicked); 
              base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.res = new ResourceHelper(this.Page);
            base.Response.Cookies["userroles"].Value = "";
            base.Response.Cookies["userroles"].Path = "/";
            base.Response.Cookies["userroles"].Expires = new DateTime(0x76c, 10, 12);
            this.Context.User = null;
            this.Message.Text = this.Msg;
        }

        void Check_Clicked(Object sender, EventArgs e)
        {
            if (rcLanguage.Checked)
            {
                Session["LanguageEn"] = "en-US";
                this.lbUserInfo.Text = "Login Information";
                this.lbUserInfoID.Text = "User Name:";
                this.lbUserInfoPwd.Text = "Password:";
                this.lbValidateCode.Text = "Security Code";
                this.RememberCheckbox.Text = "Remember the login data";
                this.BtnSignin.Text = "Login";
                this.btnCCannel.Value = "Reset";
                this.rcLanguage.Text = "  English";
            }
            else
            {
                Session["LanguageEn"] = "zh-HK";
                this.lbUserInfo.Text = "用戶登錄";
                this.lbUserInfoID.Text = "用戶 ID:";
                this.lbUserInfoPwd.Text = "密碼:";
                this.lbValidateCode.Text = "驗證碼 :";
                this.RememberCheckbox.Text = "在這部電腦上記住";
                this.BtnSignin.Text = "登入";
                this.btnCCannel.Value = "重置";
                this.rcLanguage.Text = "  中文";
            }
        }

        public string Msg
        {
            get
            {
                return this.msg;
            }
            set
            {
                this.msg = value;
            }
        }
    }
}

