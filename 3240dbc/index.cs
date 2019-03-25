namespace CENTASMS
{
    using System;
    using System.Web.UI.WebControls;

    public class index : CommonPage
    {
        protected Label lbUser;

        private void BtnSignin_Click(object sender, EventArgs e)
        {
        }

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
            if (base.Request.IsAuthenticated)
            {
                this.lbUser.Text = this.Context.User.Identity.Name;
            }
            else
            {
                base.Response.Redirect("SendByGroup.aspx", false);
            }
        }
    }
}

