namespace CENTASMS
{
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Collections;
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Threading; 
    using Anthem; 
    using System.Net;
    using System.Text;
    using System.IO;


    public class SchSendload
    {
        public DateTime ErrorTime;
        public DateTime FinishTime;
        public int ilen = 0;
        public int ipart = 0;
        public string lbGroupIDContent = "";
        public string lbMsg = "";
        public string lbUser = "";
        public int Percent = 0;
        public DateTime StartTime;
        public int State = 0;
        public string strScheduleDatetime = "";
        public string tbNum = "";
        public string txtSmsContent = ""; 
        
        public bool retVal = false;
        public string txtMmsSubject = "";
        public string txtMmsAttach = "";
        public Anthem.FileUpload attachUploadSch = null; 
        public string lang = "";

//        private void InsertSchSendData()
//        {
//            try
//            {
//                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + ")  開始發送訊息！");
//                Thread.Sleep(0x3e8);
//                string input = "";
//                string strBatchid = "";
//                string[] strArray = Regex.Split(this.tbNum, "\r\n", RegexOptions.IgnoreCase);
//                ArrayList list = new ArrayList();
//                ArrayList list2 = new ArrayList();
//                for (int i = 0; i < strArray.Length; i++)
//                {
//                    if (strArray[i].ToString().IndexOf("組別") <= -1)
//                    {
//                        if (!list.Contains(i))
//                        {
//                            list.Add(i);
//                        }
//                        list2.Add(strArray[i].ToString());
//                    }
//                }
//                string[] strArray2 = Regex.Split(this.lbGroupIDContent, ",", RegexOptions.IgnoreCase);
//                int num2 = 0;
//                int num3 = 0;
//                for (int j = 0; j < (((strArray2.Length - 1) / 2) + list.Count); j++)
//                {
//                    if (list.Contains(j) && (num2 < list.Count))
//                    {
//                        input = input + list2[num2] + "\r\n";
//                        num2++;
//                        for (int m = num2; num2 < list2.Count; m++)
//                        {
//                            if (Convert.ToInt32(list[m]) != (Convert.ToInt32(list[m - 1]) + 1))
//                            {
//                                break;
//                            }
//                            input = input + list2[num2] + "\r\n";
//                            num2++;
//                            j++;
//                        }
//                    }
//                    else if (num3 < ((strArray2.Length - 1) / 2))
//                    {
//                        DataRow[] rowArray = new GroupMembers().GetMemberDataByGroupID(strArray2[2 * num3].ToString()).Tables[0].Select();
//                        if (rowArray.Length > 0)
//                        {
//                            foreach (DataRow row in rowArray)
//                            {
//                                input = input + row["CMOBILENO"].ToString().Trim() + "[" + strArray2[(2 * num3) + 1].ToString() + "]\r\n";
//                            }
//                        }
//                        num3++;
//                    }
//                }
//                string[] strArray3 = Regex.Split(input, "\r\n", RegexOptions.IgnoreCase);
//                ArrayList cmoblieno = new ArrayList();
//                for (int k = 0; k < strArray3.Length; k++)
//                {
//                    //if (!cmoblieno.Contains(strArray3[k].ToString()) && (strArray3[k].ToString() != ""))
//                    //{
//                    //    cmoblieno.Add(strArray3[k].ToString());
//                    //} 
//                    string phoneNum = strArray3[k].Trim();
//                    if (!cmoblieno.Contains(phoneNum) && (phoneNum != ""))
//                    {
//                        string sign = "";
//                        string status = CheckDNC(phoneNum);
//                        if (status == "NON-DNC")
//                        {
//                            sign = "0";
//                        }
//                        else if (status == "DNC1" || status == "DNC2")
//                        {
//                            sign = "-1"; 
//                        }
//                        else if (status == "")
//                        { 
//                            sign = "-3";
//                        }
//                        else
//                        {
//                            sign = "-2";
//                        } 
//                        cmoblieno.Add(phoneNum + "," + sign);
//                        //string sign = (CheckDNC(phoneNum) == true) ? "-1" : "0";
//                        //cmoblieno.Add(phoneNum + "," + sign);
//                    }
//                }
                
//                    this.retVal = new SmsSchedules().CreateSmsScheduleMsg(this.lbUser, this.strScheduleDatetime, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "N", this.txtSmsContent,this.txtMmsSubject ,this.txtMmsAttach , "A", 0, cmoblieno, this.ilen, this.ipart, cmoblieno.Count, out strBatchid);
//                    if (this.retVal && (strBatchid != ""))
//                    { 
//                         bool bUpload = ConfigManager.UplaodAttach(this.lbUser,strBatchid, this.attachUploadSch);
//                         if(bUpload)
//                         {  
//                            this.lbMsg = "預設成功！";
//                           Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + ")  設置預設發送成功!  ID:" + strBatchid + "  預設發送時間：" + this.strScheduleDatetime + "\r\n 短訊內容：\r\n " + this.txtSmsContent + "\r\n 發送號碼： ");
//                           Files.CicsWriteLog(input.Replace("\r\n", ",   "));
//                           Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + ")  結束預設發送訊息！\r\n");
//                          }
//                         else
//                         { 
//                            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.lbUser + ")  設置即時發送失敗! （No attachment）,Call back(DELETE) ID:"+ strBatchid) ;
//                             new SmsMsgSchs().DeletelSmsSchData (strBatchid );
//                             this.lbMsg = "Upload attachment失敗!";
//                         }
//                    }
//                    else
//                    {
//                     this.lbMsg = "預設失敗！";
//                     Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + ")  設置預設發送失敗!  \r\n 短訊內容：\r\n " + this.txtSmsContent + "\r\n 發送號碼：\r\n " + input.Replace("\r\n", ",   ") + "");
//                    }
////                if (new SmsSchedules().CreateSmsScheduleMsg(this.lbUser, this.strScheduleDatetime, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "N", this.txtSmsContent, "A", 0, cmoblieno, this.ilen, this.ipart, cmoblieno.Count, out str2) && (str2 != ""))
////                {
////                    this.lbMsg = "預設成功！";
////                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + ")  設置預設發送成功!  ID:" + str2 + "  預設發送時間：" + this.strScheduleDatetime + "\r\n 短訊內容：\r\n " + this.txtSmsContent + "\r\n 發送號碼： ");
////                    Files.CicsWriteLog(input.Replace("\r\n", ",   "));
////                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + ")  結束預設發送訊息！\r\n");
////                }
////                else
////                {
////                    this.lbMsg = "預設失敗！";
////                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + ")  設置預設發送失敗!  \r\n 短訊內容：\r\n " + this.txtSmsContent + "\r\n 發送號碼：\r\n " + input.Replace("\r\n", ",   ") + "");
////                }
//                this.State = 2;
//            }
//            catch (Exception exception)
//            {
//                this.lbMsg = "請稍后再試！";
//                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  設置即時發送失敗!   " + exception.ToString());
//                this.ErrorTime = DateTime.Now;
//                this.State = 3;
//            }
//            finally
//            {
//                this.FinishTime = DateTime.Now;
//            }
//        }
        private void InsertSchSendData()
        {
            try
            {
                Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser + ")  開始發送訊息！");
                Thread.Sleep(0x3e8);
                string input = "";
                string str2 = "";
               // string[] strArray = Regex.Split(this.tbNum, "\r\n", RegexOptions.IgnoreCase);
                string[] strArray = null;
                if (this.tbNum.IndexOf("\r\n") > -1)
                {
                    strArray = Regex.Split(this.tbNum, "\r\n", RegexOptions.IgnoreCase);
                }
                else
                {
                    strArray = Regex.Split(this.tbNum, "\n", RegexOptions.IgnoreCase);
                }
                ArrayList list = new ArrayList();
                ArrayList list2 = new ArrayList();
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].ToString().IndexOf("組別") <= -1 && strArray[i].ToString().IndexOf("(Private)") <= -1 && strArray[i].ToString().IndexOf("(Share)") <= -1)
                    {
                        if (!list.Contains(i))
                        {
                            list.Add(i);
                        }
                        list2.Add(strArray[i].ToString());
                    }
                }
                string[] strArray2 = Regex.Split(this.lbGroupIDContent, ",", RegexOptions.IgnoreCase);
                int num2 = 0;
                int num3 = 0;
                for (int j = 0; j < (((strArray2.Length - 1) / 2) + list.Count); j++)
                {
                    if (list.Contains(j) && (num2 < list.Count))
                    {
                        input = input + list2[num2] + "\r\n";
                        num2++;
                        for (int m = num2; num2 < list2.Count; m++)
                        {
                            if (Convert.ToInt32(list[m]) != (Convert.ToInt32(list[m - 1]) + 1))
                            {
                                break;
                            }
                            input = input + list2[num2] + "\r\n";
                            num2++;
                            j++;
                        }
                    }
                    else if (num3 < ((strArray2.Length - 1) / 2))
                    {
                        DataRow[] rowArray = new GroupMembers().GetMemberDataByGroupID(strArray2[2 * num3].ToString()).Tables[0].Select();
                        if (rowArray.Length > 0)
                        {
                            foreach (DataRow row in rowArray)
                            {
                                input = input + row["CMOBILENO"].ToString().Trim() + "[" + strArray2[(2 * num3) + 1].ToString() + "]\r\n";
                            }
                        }
                        num3++;
                    }
                }
                string[] strArray3 = Regex.Split(input, "\r\n", RegexOptions.IgnoreCase);
                ArrayList cmoblieno = new ArrayList();
                for (int k = 0; k < strArray3.Length; k++)
                {
                    if (AppFlag.DuplicateSending)
                    {
                        if ((strArray3[k].ToString() != ""))
                        {
                            cmoblieno.Add(strArray3[k].ToString());
                        }
                    }
                    else
                    {
                        if (!cmoblieno.Contains(strArray3[k].ToString()) && (strArray3[k].ToString() != ""))
                        {
                            cmoblieno.Add(strArray3[k].ToString());
                        }
                    }
                    //if (!cmoblieno.Contains(strArray3[k].ToString()) && (strArray3[k].ToString() != ""))
                    //{
                    //    cmoblieno.Add(strArray3[k].ToString());
                    //}
                }
                if (new SmsSchedules().CreateSmsScheduleMsg(this.lbUser, this.strScheduleDatetime, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "N", this.txtSmsContent, "A", 0, cmoblieno, this.ilen, this.ipart, cmoblieno.Count, out str2) && (str2 != ""))
                {
                    this.lbMsg = (lang == "en-US") ? "Add success！" : "預設成功!"; //"預設成功！";
                    Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser + ")  設置預設發送成功!  ID:" + str2 + "  預設發送時間：" + this.strScheduleDatetime + "\r\n 短訊內容：\r\n " + this.txtSmsContent + "\r\n Unicode Msg: " + BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(this.txtSmsContent)).Replace("-", "") + "\r\n 發送號碼： ");
                    Files.CicsWriteLog(input.Replace("\r\n", ",   "));
                    Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser + ")  結束預設發送訊息！\r\n");
                }
                else
                {
                    this.lbMsg = (lang == "en-US") ? "Add failed！" : "預設失敗!"; // "預設失敗！";
                    Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser + ")  設置預設發送失敗!  \r\n 短訊內容：\r\n " + this.txtSmsContent + "\r\n Unicode Msg: " + BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(this.txtSmsContent)).Replace("-", "") + "\r\n 發送號碼：\r\n " + input.Replace("\r\n", ",   ") + "");
                }
                this.State = 2;
            }
            catch (Exception exception)
            {
                this.lbMsg = (lang == "en-US") ? "Add failed,try a later！" : "請稍后再試!"; //"請稍后再試！";
                Files.CicsWriteError(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  設置即時發送失敗!   " + exception.ToString());
                this.ErrorTime = DateTime.Now;
                this.State = 3;
            }
            finally
            {
                this.FinishTime = DateTime.Now;
            }
        }
        private static string CheckDNC(String phoneNum)
        {
            string Num = (phoneNum.IndexOf("[") > -1) ? phoneNum.Substring(0, phoneNum.IndexOf("[")) : phoneNum;
            try
            {
                string dataSend = AppFlag.CheckDNCUrl + Num;
                WebRequest req = WebRequest.Create(dataSend);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";

                req.ContentLength = dataSend.Length;
                byte[] buff = Encoding.UTF8.GetBytes(dataSend);

                Stream reqStream = req.GetRequestStream();
                reqStream.Write(buff, 0, buff.Length);
                reqStream.Close();

                Stream ReceiveStream = req.GetResponse().GetResponseStream();
                Encoding enc = Encoding.GetEncoding("utf-8");
                StreamReader sr = new StreamReader(ReceiveStream, enc);
                string str = sr.ReadToEnd().ToUpper();
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  " + Num + " " + str);
                return str;
            }
            catch (Exception exp)
            {
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  CheckDNC(),phoneNum=" + Num + "," + exp.ToString());
                return "";
            }
        }

        //private static bool CheckDNC(String phoneNum)
        //{
        //    string Num = (phoneNum.IndexOf("[") > -1) ? phoneNum.Substring(0, phoneNum.IndexOf("[")) : phoneNum;
        //    bool isDNC = false;
        //    try
        //    {
        //        string dataSend = AppFlag.CheckDNCUrl + Num;
        //        WebRequest req = WebRequest.Create(dataSend);
        //        req.Method = "POST";
        //        req.ContentType = "application/x-www-form-urlencoded";

        //        req.ContentLength = dataSend.Length;
        //        byte[] buff = Encoding.UTF8.GetBytes(dataSend);

        //        Stream reqStream = req.GetRequestStream();
        //        reqStream.Write(buff, 0, buff.Length);
        //        reqStream.Close();

        //        Stream ReceiveStream = req.GetResponse().GetResponseStream();
        //        Encoding enc = Encoding.GetEncoding("utf-8");
        //        StreamReader sr = new StreamReader(ReceiveStream, enc);
        //        string str = sr.ReadToEnd().ToUpper();
        //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  CheckDNC-Num:" + Num + " " + str);

        //        isDNC = (str == "NON-DNC") ? false : true;
        //    }
        //    catch (Exception exp)
        //    {
        //        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  CheckDNC(),phoneNum=" + Num + "," + exp.ToString());
        //        return false;
        //    }
        //    return isDNC;
        //}

        public void runload()
        {
            lock (this)
            {
                if (this.State != 1)
                {
                    this.State = 1;
                    this.StartTime = DateTime.Now;
                    new Thread(new ThreadStart(this.InsertSchSendData)).Start();
                }
            }
        }
    }
}

