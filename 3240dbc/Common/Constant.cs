using System;
using System.Configuration;
using System.Runtime.InteropServices;

namespace CENTASMS
{
	internal struct AppFlag
	{
		//Application config
		internal static readonly string WEBSITELABEL = ConfigurationSettings.AppSettings["WEBSITELABEL"];
        internal static readonly string CENTASMSMAININTEConn = ConfigurationSettings.AppSettings["IBODBCConnectionStrings"];
		internal static readonly string CENTASMSINTEConn = ConfigurationSettings.AppSettings["CENTASMSINTEConn"];
        internal static readonly string IBODBCConnectionStrings = ConfigurationSettings.AppSettings["IBODBCConnectionStrings"];
        
		internal static readonly string SMS_MSG_RECEIVER_TABLE = ConfigurationSettings.AppSettings["SMS_MSG_RECEIVER_TABLE"];
		internal static readonly string SMS_MSG_TABLE = ConfigurationSettings.AppSettings["SMS_MSG_TABLE"];

		internal static readonly int iPageSize = Convert.ToInt32(ConfigurationSettings.AppSettings["PageSize"]);
		internal static readonly string WinMsgID = ConfigurationSettings.AppSettings["WinMsgID"];
		internal static readonly string ServiceURL = ConfigurationSettings.AppSettings["ServiceURL"];

		internal static string CentaSmsError = ConfigurationSettings.AppSettings["CentaSmsError"];
		internal static string CentaSmsErrorFolder = ConfigurationSettings.AppSettings["CentaSmsErrorFolder"];
		internal static string CentaSmsEventFolder = ConfigurationSettings.AppSettings["CentaSmsEventFolder"];
		internal static string CentaSmsLog = ConfigurationSettings.AppSettings["CentaSmsLog"];
		internal static string CentaSmsUploadFolder = ConfigurationSettings.AppSettings["CentaSmsUploadFolder"];
		internal static string CentaSmsAdmin = ConfigurationSettings.AppSettings["CentaSmsAdmin"];
		internal static string CentaSmsExtra = ConfigurationSettings.AppSettings["CentaSmsExtra"];
		internal static readonly int CentaSmsSendTime = Convert.ToInt32(ConfigurationSettings.AppSettings["CentaSmsSendTime"]);
		internal static readonly int UploadRefresh = Convert.ToInt32(ConfigurationSettings.AppSettings["UploadRefresh"])*1000;
		internal static readonly int SendRefresh = Convert.ToInt32(ConfigurationSettings.AppSettings["SendRefresh"])*1000;
		internal static readonly string RefreshMode = ConfigurationSettings.AppSettings["RefreshMode"];
		internal static readonly string ValidPrefixes = ConfigurationSettings.AppSettings["ValidPrefixes"].Trim();
		internal static readonly string DeteleGroupMode = ConfigurationSettings.AppSettings["DeteleGroupMode"].ToUpper().Trim();
		internal static readonly bool DefineMessage = (ConfigurationSettings.AppSettings["DefineMessage"].ToUpper().Trim() == "TRUE") ? true : false;
        internal static readonly string MmsUploadFolder ="";// ConfigurationSettings.AppSettings["MmsUploadFolder"];
        internal static readonly string CheckDNCUrl ="";// ConfigurationSettings.AppSettings["CheckDNCUrl"];
         internal static readonly int ImageMaximumSize=0;// = Convert.ToInt32(ConfigurationSettings.AppSettings["ImageMaximumSize"]);
         internal static readonly bool UploadFilter = (ConfigurationSettings.AppSettings["UploadFilter"].ToUpper().Trim() == "TRUE") ? true : false;
         internal static string CentaSmsBatchUploadFolder = ConfigurationSettings.AppSettings["CentaSmsBatchUploadFolder"];
         internal static readonly bool DuplicateSending = (ConfigurationSettings.AppSettings["DuplicateSending"].ToUpper().Trim() == "TRUE") ? true : false;
         internal static readonly bool MobileIDD = (ConfigurationSettings.AppSettings["MobileIDD"].ToUpper().Trim() == "TRUE") ? true : false;
         internal static string MobileSign = ConfigurationSettings.AppSettings["MobileSign"];
         internal static readonly string AccountActionUrl = ConfigurationSettings.AppSettings["AccountActionUrl"];
         internal static readonly int MaxCountSec = Convert.ToInt32(ConfigurationSettings.AppSettings["MaxCountSec"]);
         internal static string CentaSmsAgent = ConfigurationSettings.AppSettings["CentaSmsAgent"];
         internal static string CentaSmsBulkAgent = ConfigurationSettings.AppSettings["CentaSmsBulkAgent"];
         internal static readonly bool CentaEditAgentSms = (ConfigurationSettings.AppSettings["CentaEditAgentSms"].ToUpper().Trim() == "YES") ? true : false;
         internal static readonly string ServiceActionURL = ConfigurationSettings.AppSettings["ServiceActionURL"];
         internal static readonly int MaximunBatch = Convert.ToInt32(ConfigurationSettings.AppSettings["MaximunBatch"]);
         internal static readonly bool AgentFunction = (ConfigurationSettings.AppSettings["AgentFunction"].ToUpper().Trim() == "YES") ? true : false;
         internal static readonly bool BulkFunction = (ConfigurationSettings.AppSettings["BulkFunction"].ToUpper().Trim() == "YES") ? true : false;
    
    }
}