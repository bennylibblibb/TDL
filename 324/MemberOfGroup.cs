namespace CENTASMS
{
    using System;
    using System.IO;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class MemberOfGroup : Page
    {
        protected DataGrid dgMembers;
        protected Label lbGroupNameP;
        protected Label lbGroupNamePE;
        protected TextBox txtGroupPE;

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
            try
            {
                string fileName = @"C:\Inetpub\wwwroot\CENTASMS\temp\dfsdfdsf.csv";
                string s = "dfsdfdsf.csv";
                FileInfo info = new FileInfo(fileName);
                base.Response.Clear();
                base.Response.AddHeader("Content-Disposition", "attachment; filename=" + base.Server.UrlEncode(s));
                base.Response.AddHeader("Content-Length", info.Length.ToString());
                base.Response.ContentType = "application/ms-excel";
                base.Response.WriteFile(info.FullName);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            catch (Exception exception)
            {
                base.Response.Write(@"<script>alert('error:\n" + exception.Message + @"!\n call.')</script>");
            }
        }
    }
}

