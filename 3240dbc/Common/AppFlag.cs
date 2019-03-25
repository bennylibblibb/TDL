namespace CENTASMS
{
    using System;
    using System.Configuration;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Size=1)]
    internal struct AppFlag
    {
        internal static readonly string WEBSITELABEL;
        internal static readonly string CENTASMSMAININTEConn;
        internal static readonly string CENTASMSINTEConn;
        internal static readonly string SMS_MSG_RECEIVER_TABLE;
        internal static readonly string SMS_MSG_TABLE;
        internal static readonly int iPageSize;
        internal static readonly string WinMsgID;
        internal static readonly string ServiceURL;
        internal static string CentaSmsError;
        internal static string CentaSmsErrorFolder;
        internal static string CentaSmsEventFolder;
        internal static string CentaSmsLog;
        internal static string CentaSmsUploadFolder;
        internal static string CentaSmsAdmin;
        internal static string CentaSmsExtra;
        internal static readonly int CentaSmsSendTime;
        internal static readonly int UploadRefresh;
        internal static readonly int SendRefresh;
        internal static readonly string RefreshMode;
        internal static readonly string ValidPrefixes;
        internal static readonly string DeteleGroupMode;
        internal static readonly bool DefineMessage;
        internal static readonly string MobileSign;
        internal static readonly string MobileType;
        static AppFlag()
        {
            WEBSITELABEL = ConfigurationSettings.AppSettings["WEBSITELABEL"];
            CENTASMSMAININTEConn = ConfigurationSettings.AppSettings["CENTASMSMAININTEConn"];
            CENTASMSINTEConn = ConfigurationSettings.AppSettings["CENTASMSINTEConn"];
            SMS_MSG_RECEIVER_TABLE = ConfigurationSettings.AppSettings["SMS_MSG_RECEIVER_TABLE"];
            SMS_MSG_TABLE = ConfigurationSettings.AppSettings["SMS_MSG_TABLE"];
            iPageSize = Convert.ToInt32(ConfigurationSettings.AppSettings["PageSize"]);
            WinMsgID = ConfigurationSettings.AppSettings["WinMsgID"];
            ServiceURL = ConfigurationSettings.AppSettings["ServiceURL"];
            CentaSmsError = ConfigurationSettings.AppSettings["CentaSmsError"];
            CentaSmsErrorFolder = ConfigurationSettings.AppSettings["CentaSmsErrorFolder"];
            CentaSmsEventFolder = ConfigurationSettings.AppSettings["CentaSmsEventFolder"];
            CentaSmsLog = ConfigurationSettings.AppSettings["CentaSmsLog"];
            CentaSmsUploadFolder = ConfigurationSettings.AppSettings["CentaSmsUploadFolder"];
            CentaSmsAdmin = ConfigurationSettings.AppSettings["CentaSmsAdmin"];
            CentaSmsExtra = ConfigurationSettings.AppSettings["CentaSmsExtra"];
            CentaSmsSendTime = Convert.ToInt32(ConfigurationSettings.AppSettings["CentaSmsSendTime"]);
            UploadRefresh = Convert.ToInt32(ConfigurationSettings.AppSettings["UploadRefresh"]) * 0x3e8;
            SendRefresh = Convert.ToInt32(ConfigurationSettings.AppSettings["SendRefresh"]) * 0x3e8;
            RefreshMode = ConfigurationSettings.AppSettings["RefreshMode"];
            ValidPrefixes = ConfigurationSettings.AppSettings["ValidPrefixes"].Trim();
            DeteleGroupMode = ConfigurationSettings.AppSettings["DeteleGroupMode"].ToUpper().Trim();
            DefineMessage = ConfigurationSettings.AppSettings["DefineMessage"].ToUpper().Trim() == "TRUE";
            MobileSign = ConfigurationSettings.AppSettings["MobileSign"].Trim();
            MobileType = ConfigurationSettings.AppSettings["MobileType"].Trim();
        }
    }
}

