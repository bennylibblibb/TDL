namespace CENTASMS
{
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Collections;
    using System.Data;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Text;

    public class Sendload
    {
        public string DateTimenow = "";
        public DateTime ErrorTime;
        public DateTime FinishTime;
        public int ilen = 0;
        public int ipart = 0;
        public int ipriority = 0;
        public string itemp = "▼私人組別";
        public string items = "▼共享組別";
        public string lbGroupIDContent = "";
        public string lbLen = "";
        public string lbMsg = "";
        public string lbNum = "";
        public bool lbrfvContentVisable = false;
        public bool lbrfvNumVisable = false;
        public string lbUser = "";
        public int maxlen = 0;
        public string Operator = "";
        public int Percent = 0;
        public bool retVal = false;
        public bool SendState = false;
        public DateTime StartTime;
        public int State = 0;
        public string strBatchid = "";
        public string strmembers = "";
        public string stropr = "";
        public string tbNum = "";
        public string txtSmsContent = "";
        public string type = "A";

        //private void InsertSendData()
        //{
        //    try
        //    {
        //        Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser + ")  開始發送訊息！");
        //        Thread.Sleep(0x3e8);
        //        string[] strArray = Regex.Split(this.tbNum, "\r\n", RegexOptions.IgnoreCase);
        //        ArrayList list = new ArrayList();
        //        ArrayList list2 = new ArrayList();
        //        for (int i = 0; i < strArray.Length; i++)
        //        {
        //            if (strArray[i].ToString().IndexOf("組別") <= -1)
        //            {
        //                if (!list.Contains(i))
        //                {
        //                    list.Add(i);
        //                }
        //                list2.Add(strArray[i].ToString());
        //            }
        //        }
        //        string[] strArray2 = Regex.Split(this.lbGroupIDContent, ",", RegexOptions.IgnoreCase);
        //        int num2 = 0;
        //        int num3 = 0;
        //        for (int j = 0; j < (((strArray2.Length - 1) / 2) + list.Count); j++)
        //        {
        //            if (list.Contains(j) && (num2 < list.Count))
        //            {
        //                this.strmembers = this.strmembers + list2[num2] + "\r\n";
        //                num2++;
        //                for (int m = num2; num2 < list2.Count; m++)
        //                {
        //                    if (Convert.ToInt32(list[m]) != (Convert.ToInt32(list[m - 1]) + 1))
        //                    {
        //                        break;
        //                    }
        //                    this.strmembers = this.strmembers + list2[num2] + "\r\n";
        //                    num2++;
        //                    j++;
        //                }
        //            }
        //            else if (num3 < ((strArray2.Length - 1) / 2))
        //            {
        //                DataRow[] rowArray = new GroupMembers().GetMemberDataByGroupID(strArray2[2 * num3].ToString()).Tables[0].Select();
        //                if (rowArray.Length > 0)
        //                {
        //                    foreach (DataRow row in rowArray)
        //                    {
        //                        this.strmembers = this.strmembers + row["CMOBILENO"].ToString().Trim() + "[" + strArray2[(2 * num3) + 1].ToString() + "]\r\n";
        //                    }
        //                }
        //                num3++;
        //            }
        //        }
        //        string[] strArray3 = Regex.Split(this.strmembers, "\r\n", RegexOptions.IgnoreCase);
        //        ArrayList cmoblieno = new ArrayList();
        //        for (int k = 0; k < strArray3.Length; k++)
        //        {
        //            if (!cmoblieno.Contains(strArray3[k].ToString()) && (strArray3[k].ToString() != ""))
        //            {
        //                cmoblieno.Add(strArray3[k].ToString());
        //            }
        //        }
        //        if (cmoblieno.Count == 0)
        //        {
        //            this.lbMsg = "組別中不存在號碼！";
        //        }
        //        else
        //        {
        //            this.retVal = new SmsMsgs().CreateSmsMsg(this.txtSmsContent,"","", this.type, this.ipriority, this.DateTimenow, cmoblieno, this.lbUser, this.Operator, this.ilen, this.ipart, cmoblieno.Count, out this.strBatchid);
        //            if (this.retVal && (this.strBatchid != ""))
        //            {
        //                this.SendState = ConfigManager.SendWinMsg(AppFlag.WinMsgID);
        //                if (this.SendState)
        //                {
        //                    Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser + this.stropr + ")  設置即時發送成功! （RemoteService）ID:" + this.strBatchid + "  \r\n 短訊內容：\r\n " + this.txtSmsContent + "\r\n 發送號碼： ");
        //                    Files.CicsWriteLog(this.strmembers.Replace("\r\n", ",   "));
        //                    this.lbMsg = "發送成功!";
        //                    this.lbLen = "0";
        //                    this.lbNum = "0";
        //                    this.txtSmsContent = "";
        //                    this.tbNum = "";
        //                    this.lbGroupIDContent = "";
        //                    this.itemp = "▼私人組別";
        //                    this.items = "▼共享組別";
        //                }
        //                else
        //                {
        //                    Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser + this.stropr + ")  設置即時發送成功! （No RemoteService）ID:" + this.strBatchid + "  \r\n 短訊內容：\r\n " + this.txtSmsContent + "\r\n 發送號碼：\r\n " + this.strmembers.Replace("\r\n", ",   ") + "");
        //                    this.lbMsg = "RemoteService失敗!";
        //                }
        //                this.lbrfvNumVisable = false;
        //                this.lbrfvContentVisable = false;
        //                Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser + ")  結束即時發送訊息！\r\n");
        //            }
        //            else
        //            {
        //                this.lbMsg = "發送失敗,請重發!";
        //                this.lbrfvNumVisable = true;
        //                this.lbrfvContentVisable = true;
        //                Files.CicsWriteLog(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  ( " + this.lbUser + ")  即時發送失敗,請重發！\r\n");
        //            }
        //        }
        //        this.State = 2;
        //    }
        //    catch (Exception exception)
        //    {
        //        if (exception.ToString().IndexOf("SMS exceeds 10.") > 1)
        //        {
        //            this.lbMsg = "超過最大字符數" + this.maxlen.ToString() + "！";
        //            this.lbLen = this.txtSmsContent.Length.ToString();
        //        }
        //        else
        //        {
        //            this.lbMsg = "請稍后再試！";
        //            Files.CicsWriteError(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "  設置即時發送失敗!   " + exception.ToString());
        //        }
        //        this.ErrorTime = DateTime.Now;
        //        this.State = 3;
        //    }
        //    finally
        //    {
        //        this.FinishTime = DateTime.Now;
        //    }
        //}

        private void InsertSendData()
        {
            try
            {
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + ")  開始發送訊息！");
                Thread.Sleep(0x3e8);
                string[] strArray = Regex.Split(this.tbNum, "\r\n", RegexOptions.IgnoreCase);
                ArrayList list = new ArrayList();
                ArrayList list2 = new ArrayList();
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].ToString().IndexOf("組別") <= -1)
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
                        this.strmembers = this.strmembers + list2[num2] + "\r\n";
                        num2++;
                        for (int m = num2; num2 < list2.Count; m++)
                        {
                            if (Convert.ToInt32(list[m]) != (Convert.ToInt32(list[m - 1]) + 1))
                            {
                                break;
                            }
                            this.strmembers = this.strmembers + list2[num2] + "\r\n";
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
                                this.strmembers = this.strmembers + row["CMOBILENO"].ToString().Trim() + "[" + strArray2[(2 * num3) + 1].ToString() + "]\r\n";
                            }
                        }
                        num3++;
                    }
                }
                string[] strArray3 = Regex.Split(this.strmembers, "\r\n", RegexOptions.IgnoreCase);
                ArrayList cmoblieno = new ArrayList();
                for (int k = 0; k < strArray3.Length; k++)
                {
                    if (AppFlag.DuplicateSending)
                    {
                        if ( (strArray3[k].ToString() != ""))
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
                }
                if (cmoblieno.Count == 0)
                {
                    this.lbMsg = "組別中不存在號碼！";
                }
                else
                {
                    this.retVal = new SmsMsgs().CreateSmsMsg(this.txtSmsContent, this.type, this.ipriority, this.DateTimenow, cmoblieno, this.lbUser, this.Operator, this.ilen, this.ipart, cmoblieno.Count, out this.strBatchid);
                    if (this.retVal && (this.strBatchid != ""))
                    {
                        this.SendState = ConfigManager.SendWinMsg(AppFlag.WinMsgID);
                        if (this.SendState)
                        {
                            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + this.stropr + ")  設置即時發送成功! （RemoteService）ID:" + this.strBatchid + "  \r\n 短訊內容：\r\n " + this.txtSmsContent + "\r\n Unicode Msg: " + BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(this.txtSmsContent)).Replace("-", "") + "\r\n 發送號碼： ");
                            Files.CicsWriteLog(this.strmembers.Replace("\r\n", ",   "));
                            this.lbMsg = "發送成功!";
                            this.lbLen = "0";
                            this.lbNum = "0";
                            this.txtSmsContent = "";
                            this.tbNum = "";
                            this.lbGroupIDContent = "";
                            this.itemp = "▼私人組別";
                            this.items = "▼共享組別";
                        }
                        else
                        {
                            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + this.stropr + ")  設置即時發送成功! （No RemoteService）ID:" + this.strBatchid + "  \r\n 短訊內容：\r\n " + this.txtSmsContent + "\r\n Unicode Msg: " + BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(this.txtSmsContent)).Replace("-", "") + "\r\n 發送號碼：\r\n " + this.strmembers.Replace("\r\n", ",   ") + "");
                            this.lbMsg = "RemoteService失敗!";
                        }
                        this.lbrfvNumVisable = false;
                        this.lbrfvContentVisable = false;
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + ")  結束即時發送訊息！\r\n");
                    }
                    else
                    {
                        this.lbMsg = "發送失敗,請重發!";
                        this.lbrfvNumVisable = true;
                        this.lbrfvContentVisable = true;
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  ( " + this.lbUser + ")  即時發送失敗,請重發！\r\n");
                    }
                }
                this.State = 2;
            }
            catch (Exception exception)
            {
                if (exception.ToString().IndexOf("SMS exceeds 10.") > 1)
                {
                    this.lbMsg = "超過最大字符數" + this.maxlen.ToString() + "！";
                    this.lbLen = this.txtSmsContent.Length.ToString();
                }
                else
                {
                    this.lbMsg = "請稍后再試！";
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  設置即時發送失敗!   " + exception.ToString());
                }
                this.ErrorTime = DateTime.Now;
                this.State = 3;
            }
            finally
            {
                this.FinishTime = DateTime.Now;
            }
        }

        public void runload()
        {
            lock (this)
            {
                if (this.State != 1)
                {
                    this.State = 1;
                    this.StartTime = DateTime.Now;
                    new Thread(new ThreadStart(this.InsertSendData)).Start();
                }
            }
        }
    }
}

