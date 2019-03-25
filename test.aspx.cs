using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CENTASMS
{
	/// <summary>
	/// WebForm1 的摘要描述。
	/// </summary>
	public class WebForm1 : Page
	{
		protected DataGrid DataGrid2;
		protected TextBox txtStartDate;
		protected RequiredFieldValidator rfv;
		protected TextBox txtEndDate;
		protected DataGrid DataGrid1;

		private void Page_Load(object sender, EventArgs e)
		{
			// 在這裡放置使用者程式碼以初始化網頁
		}

		#region Web Form 設計工具產生的程式碼

		protected override void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 此為 ASP.NET Web Form 設計工具所需的呼叫。
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// 此為設計工具支援所必須的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new EventHandler(this.Page_Load);

		}

		#endregion

		private void Button1_Click(object sender, EventArgs e)
		{
//			bool retVal =false;
//			string m_batchid="";
//			 SmsMsgData smsmsgdata=new SmsMsgData() ;
////DataSet  smsmsgdata=new DataSet() ;
//			 retVal = (new SmsMsgs()).CreateSmsMsg(TextBox1 .Text .Trim(),TextBox2 .Text .Trim() ,"b",0,DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),-1,TextBox3 .Text .Trim(), out m_batchid,out smsmsgdata);
//			if ( retVal && ( smsmsgdata != null ) )
//			{
//				DataGrid1 .DataSource =smsmsgdata .Tables [0].DefaultView ;
//				DataGrid1 .DataBind() ;
//				DataGrid2 .DataSource =smsmsgdata .Tables [1].DefaultView ;
//				DataGrid2 .DataBind() ; 
//			}
//			    DataRow[]   yesterDayCollection;   
//			    DataRow[]   toDayCollection;   
//			    DataRow[]   tomorrowCollection;   
//			DataSet   ds   =   new   DataSet();   
//			//yesterday------*-------------------------------------------------------------   
//			//today----------------------todayStart------*-------todayEnd------------------   
//			//tomorrow--------------------------------------------------------------*------   
//			string   todayStart=DateTime.Today.ToShortDateString()+"   00:00:00";   
//			string   todayEnd=DateTime.Today.ToShortDateString()+"   23:59:59";   
//			//yesterday:todayStart>end   time   
//			yesterDayCollection=ds.Tables[0].Select("'"+todayStart+"'>EndOn","EndOn");   
//			//today:not   (todayStart>end   time   or   todayEnd<start   time)   
//			toDayCollection=ds.Tables[0].Select("not('"+todayStart+"'>EndOn   or   '"+todayEnd+"'<StartOn)","EndOn");   
//			//tomorrow:todayEnd<start   time   
//			tomorrowCollection=ds.Tables[0].Select("'"+todayEnd+"'<StartOn","EndOn");
		}
	}
}