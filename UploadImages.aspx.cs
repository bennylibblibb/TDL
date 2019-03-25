using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSLMMMS
{
    public partial class UploadImages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Request.IsAuthenticated && !this.Page.IsPostBack)
            {
                string strUrl = (base.Request.QueryString["Url"] == null) ? "" : base.Request.QueryString["Url"].ToString().Trim();
                string strBatchid = strUrl.Substring(0, strUrl.IndexOf("\\"));
                string strName = strUrl.Substring(strUrl.IndexOf("\\") + 1, strUrl.Length - strUrl.IndexOf("\\") - 1);
                lbID.Text = "BatchID:" + strBatchid + "    " + strName;
                this.Page.Title = strBatchid + "'s Attached";
                igUpload.AlternateText = strName;
                igUpload.ImageUrl = "MmsUploadFolder\\" + strUrl;
            }
        }
    }
}