namespace CENTASMS.DAL
{
    using CENTASMS;
    using RemoteService.Win32;
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Runtime.InteropServices;
    using System.Text; 
    using System.IO;
    using System.Collections;

    public class ConfigManager : MarshalByRefObject
    {
        private static string applicationPath;
        private static string dalConnectionString;

        public static int CheckSmsData(string strTemp, out int ilen, out int maxlen)
        {
            ilen = 0;
            maxlen = 0;
            int num = 0;
            int nLen = 0;
            if (strTemp.Length != Encoding.Default.GetByteCount(strTemp))
            {
                if (Encoding.Default.GetByteCount(strTemp) > 0x53c)
                {
                    num = -1;
                    maxlen = 670;
                    return num;
                }
                num = CountSmsBig5(strTemp.Length, out maxlen);
                ilen = strTemp.Length;
                return num;
            }
            nLen = Encoding.Default.GetByteCount(strTemp);
            if (nLen > 0x5fa)
            {
                num = -1;
                maxlen = 0x5fa;
                return num;
            }
            num = CountSmsNoBig5(nLen, out maxlen);
            ilen = nLen;
            return num;
        }

        private static int CountSmsBig5(int nLen, out int maxlen1)
        {
            maxlen1 = 0;
            if (nLen == 0)
            {
                return 0;
            }
            if (nLen <= 70)
            {
                return 1;
            }
            if (nLen <= 0x86)
            {
                return 2;
            }
            if (nLen <= 0xc9)
            {
                return 3;
            }
            if (nLen <= 0x10c)
            {
                return 4;
            }
            if (nLen <= 0x14f)
            {
                return 5;
            }
            if (nLen <= 0x192)
            {
                return 6;
            }
            if (nLen <= 0x1d5)
            {
                return 7;
            }
            if (nLen <= 0x218)
            {
                return 8;
            }
            if (nLen <= 0x25b)
            {
                return 9;
            }
            if (nLen <= 670)
            {
                return 10;
            }
            maxlen1 = 670;
            return -1;
        }

        private static int CountSmsNoBig5(int nLen, out int maxlen)
        {
            maxlen = 0;
            if (nLen == 0)
            {
                return 0;
            }
            if (nLen <= 160)
            {
                return 1;
            }
            if (nLen <= 0x132)
            {
                return 2;
            }
            if (nLen <= 0x1cb)
            {
                return 3;
            }
            if (nLen <= 0x264)
            {
                return 4;
            }
            if (nLen <= 0x2fd)
            {
                return 5;
            }
            if (nLen <= 0x396)
            {
                return 6;
            }
            if (nLen <= 0x42f)
            {
                return 7;
            }
            if (nLen <= 0x4c8)
            {
                return 8;
            }
            if (nLen <= 0x561)
            {
                return 9;
            }
            if (nLen <= 0x5fa)
            {
                return 10;
            }
            maxlen = 0x5fa;
            return -1;
        }

        public static void InitializeApplication(NameValueCollection settings)
        {
            dalConnectionString = settings["CENTASMSINTEConn"];
        }

        public static void OnApplicationStart(string path)
        {
            applicationPath = path;
            InitializeApplication(ConfigurationSettings.AppSettings);
        }

        public static bool SendWinMsg(string Batchid)
        {
            bool flag = false;
            try
            {
                Win32Message message = (Win32Message) Activator.GetObject(typeof(Win32Message), AppFlag.ServiceURL);
                if (message == null)
                {
                    return false;
                }
                message.Broadcast(Batchid);
                flag = true;
            }
            catch (Exception exception)
            {
                new Exception(exception.ToString());
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SendWinMsg  " + exception.ToString());
            }
            return flag;
        }

        public static bool SendWinMsgAction(string Batchid)
        {
            bool flag = false;
            try
            {
                Win32Message message = (Win32Message)Activator.GetObject(typeof(Win32Message), AppFlag.ServiceActionURL);
                if (message == null)
                {
                    return false;
                }
                message.Broadcast(Batchid);
                flag = true;
            }
            catch (Exception exception)
            {
                new Exception(exception.ToString());
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SendWinMsgAction  " + exception.ToString());
            }
            return flag;
        }
        public static bool SendWinMsgAction(ArrayList Batchids)
        {
            bool flag = false;
            try
            {
                Win32Message message = (Win32Message)Activator.GetObject(typeof(Win32Message), AppFlag.ServiceActionURL);
                if (message == null)
                {
                    return false;
                }
                for (int i = 0; i < Batchids.Count; i++)
                {
                    message.Broadcast(Batchids[i].ToString ());
                }
                flag = true;
            }
            catch (Exception exception)
            {
                new Exception(exception.ToString());
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   SendWinMsgAction  " + exception.ToString());
            }
            return flag;
        }
        public static bool UplaodAttach(string user,string batchid, Anthem.FileUpload uploadControl)
        {
            bool flag = false;
            string strMmsUploadFolder = AppFlag.MmsUploadFolder;
            string strFileName = Path.GetFileName(uploadControl.PostedFile.FileName).ToUpper();
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + strMmsUploadFolder + "\\" + batchid;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (File.Exists(path + "\\" + strFileName))
                {
                   	File .Delete (path + "\\" + strFileName);
                   //path = path + strFileName.Substring(0, strFileName.LastIndexOf(".JPG")) + "_" + DateTime.Now.ToString("MMddHHmm") + ".JPG";
                } 

                uploadControl.PostedFile.SaveAs(path +"\\"+ strFileName);
                flag = true;
            }
            catch (Exception exception)
            {
                flag = false;
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + user  + ") UplaodAttach error:" + exception .ToString ());
            }

            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + user  + ")  上載 " + batchid +"\\" + strFileName + ".");

            return flag;
        }

        public static string DALConnectionString
        {
            get
            {
                return dalConnectionString;
            }
        }
    }
}

