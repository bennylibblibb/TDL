namespace CENTASMS
{
    using CENTASMS.UserControl;
    using System;
    using System.Web.Security;
    using System.Web.UI;
    using System.Resources;
    using System.Reflection;
    using System.Collections;

    public class _Default : Page
    {
        protected System.Web.UI.WebControls.Literal lDefaultTxt1;
        protected System.Web.UI.WebControls.Literal lDefaultTxt2;
        protected System.Web.UI.WebControls.Literal lDefaultTxt3;
        protected System.Web.UI.WebControls.Literal lDefaultTxt4;

        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        //protected override void InitializeCulture()
        //{
        //    var languageCookie = Session["LanguageEn"];

        //    if (languageCookie != null)
        //    {
        //        Page.UICulture = languageCookie.ToString();
        //    }
        //    else
        //    {
        //        Session["LanguageEn"] = "zh-HK";
        //        Page.UICulture = "zh-HK";
        //    }

        //    base.InitializeCulture();
        //}

        public static string GetResxValue(string resxFileName, string sKey)
        {
            string valueResult = "";

            if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + resxFileName))    //For Example:string filePaht=Server.MapPath("App_LocalResources/Default.aspx.resx")
            {
                ResXResourceReader aa = new ResXResourceReader(AppDomain.CurrentDomain.BaseDirectory.ToString() + resxFileName);
                foreach (DictionaryEntry d in aa)
                {
                    if (d.Key.ToString() == sKey)
                    {
                        valueResult = d.Value.ToString();
                        return valueResult;
                    }
                }
            }

            return valueResult;
        }

        private void Page_Load(object sender, EventArgs e)
        {
            //if (Session["LanguageEn"] == null)
            //{
                SignIn controlSignIn1 = this.FindControl("SignIn1") as SignIn;
                //if (((Anthem.CheckBox)controlSignIn1.FindControl("rcLanguage")).Checked)
                if (((Anthem.RadioButtonList)controlSignIn1.FindControl("rbLanguages")).SelectedValue == "en")
                {
                    this.lDefaultTxt4.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt4");
                    this.lDefaultTxt3.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt3");
                    this.lDefaultTxt2.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt2");
                    this.lDefaultTxt1.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt1");
                }
                else
                {
                    this.lDefaultTxt4.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt4");
                    this.lDefaultTxt3.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt3");
                    this.lDefaultTxt2.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt2");
                    this.lDefaultTxt1.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt1");
                }
            //}else
            //{
            //    if (Session["LanguageEn"].ToString() == "en-US")
            //    {
            //        this.lDefaultTxt3.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt3");
            //        this.lDefaultTxt2.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt2");
            //        this.lDefaultTxt1.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt1");
            //    }
            //    else
            //    {
            //        this.lDefaultTxt3.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt3");
            //        this.lDefaultTxt2.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt2");
            //        this.lDefaultTxt1.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt1");
            //    }
            //}

                if (!this.Page.IsPostBack && Session["LanguageEn"]!=null )
                {
                    if (Session["LanguageEn"].ToString() == "en-US")
                    {
                        this.lDefaultTxt4.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt4");
                        this.lDefaultTxt3.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt3");
                        this.lDefaultTxt2.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt2");
                        this.lDefaultTxt1.Text = GetResxValue("App_LocalResources/Default.aspx.en-US.resx", "DefaultTxt1");
                    }
                    else
                    {
                        this.lDefaultTxt4.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt4");
                        this.lDefaultTxt3.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt3");
                        this.lDefaultTxt2.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt2");
                        this.lDefaultTxt1.Text = GetResxValue("App_LocalResources/Default.aspx.resx", "DefaultTxt1");
                    }
                }


            if ((base.Request["redtype"] != "unonly") && (base.Request["redtype"] != "again"))
            {
                if (base.Request.IsAuthenticated)
                {
                    base.Response.Redirect("SendByGroup.aspx");
                }
            }
            else
            {
                SignIn controlSignIn = this.FindControl("SignIn1") as SignIn;
                if (base.Request["redtype"] == "again")
                {
                    controlSignIn.Msg = "<br>" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  Time out ,please re-login.<br>";
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.Context.User.Identity.Name + ")   Time out ,please re-login.");
                }
                else
                {
                    controlSignIn.Msg = "<br>" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  This login name is already in use by a different user,please re-login.<br>";
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.Context.User.Identity.Name + ")   This login name is already in use by a different user,please re-login.");
                }
                FormsAuthentication.SignOut();
                base.Response.Cookies["userroles"].Value = "";
                base.Response.Cookies["userroles"].Path = "/";
                base.Response.Cookies["userroles"].Expires = new DateTime(0x76c, 10, 12);
                this.Session.Clear();
                this.Context.User = null;
            }
        }
    }
}
