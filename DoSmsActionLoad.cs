namespace CENTASMS
{
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using FirebirdSql.Data.FirebirdClient;
    using System.Data.OleDb;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Collections;
    using System.IO;
    using System.Text; 
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography; 
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls; 
    using System.Security; 
    using System.Collections.Generic;
    using System.Net.Security;
    using System.IO.Compression; 

    public class DoSmsActionLoad
    {
        public string dobtnUploadMode = "";
        public string dolbUploadResult = "";
        public string dolbUser = "";
        public DateTime ErrorTime;
        public string FileName = "";
        public DateTime FinishTime;
        public int Percent = 0;
        public DateTime StartTime;
        public int State = 0;
        public string strcondtion = "";
        public int strcondtionirecno = -1;
        public int Total = 0;


        private bool ColumnEqual(object A, object B)
        {
            if ((A == DBNull.Value) && (B == DBNull.Value))
            {
                return true;
            }
            if ((A == DBNull.Value) || (B == DBNull.Value))
            {
                return false;
            }
            return A.Equals(B);
        }

        private void InsertUploadData()
        {
            bool bReadExcel = true;
            bool bResult = false;
            string fileName = this.FileName.ToUpper();
            if (fileName.LastIndexOf("XLSX") == fileName.Length - 4 || fileName.LastIndexOf("XLS") == fileName.Length - 3)
            {
                //OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.dobtnUploadMode + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';");
                string str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.dobtnUploadMode + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1;'";
                OleDbConnection connection = new OleDbConnection(str);
                try
                { 
                    connection.Open();
                    DataTable table = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                   // SmsMsgs smsMsgs = new SmsMsgs();
                    DataSet dataSet;

                    this.Total = table.Rows.Count;
                    this.Percent = 0;
                    bool error = false;
                    foreach (DataRow name in table.Rows)
                    {
                        try
                        {
                            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + fileName+"-" + name[2].ToString() + ")");
                            this.dolbUploadResult = name[2].ToString();
                            this.Percent++;

                            dataSet = new DataSet();
                            OleDbCommand command = new OleDbCommand("SELECT * FROM [" + name[2] + "]", connection);
                            OleDbDataAdapter adapter = new OleDbDataAdapter();
                            adapter.SelectCommand = command;
                            adapter.Fill(dataSet);
                            ArrayList cmoblieno = new ArrayList();
                            string strInvildMobile = "";
                            if (dataSet.Tables[0].Columns.Count < 4)
                            {
                                error = true;
                                throw (new Exception("請上傳正確格式文件"));
                               // break;
                            }
                            foreach (DataRow dr in dataSet.Tables[0].Rows)
                            {
                              //  string strMobile = dr[1].ToString().Trim();
                                string strMobile = dr[1].ToString().Trim();
                                string strAction = dr[3].ToString().Trim();
                                 if (strMobile != "")
                                {  
                                    if (!AppFlag.MobileIDD)
                                    {
                                        if (strMobile.IndexOf("00") == 0 && strMobile.Length == 10)
                                        {
                                            cmoblieno.Add(strMobile.Substring(2, 8));
                                        }
                                        else if (strMobile.IndexOf("00852") == 0 && strMobile.Length == 13)
                                        {
                                            cmoblieno.Add(strMobile.Substring(5, 8));
                                        }
                                        else if (strMobile.IndexOf("00") != 0 && strMobile.Length == 8)
                                        {
                                            cmoblieno.Add(strMobile);
                                        }
                                        else
                                        {
                                            strInvildMobile += strMobile + ",";
                                        } 
                                    }
                                    else
                                    {
                                        bool done = false;
                                        if (strMobile.IndexOf("00") != 0 && strMobile.Length == 8)
                                        {
                                            cmoblieno.Add(strMobile);
                                            done = true;
                                        }
                                        else if (strMobile.IndexOf("00") == 0 && strMobile.Length == 10)
                                        {
                                            cmoblieno.Add(strMobile.Substring(2, 8));
                                            done = true;
                                        }
                                        else
                                        {
                                            string[] strArray2 = Regex.Split(AppFlag.MobileSign.Replace("+", ","), ",", RegexOptions.IgnoreCase);
                                            for (int i = 0; i < strArray2.Length / 2; i++)
                                            {
                                                string strRex = Regex.Replace((strArray2[2 * i]), @"[\s\S](?!$)", "$0][");
                                                if (Regex.Match(strMobile, "^[" + strRex + "][0-9]{" + (strArray2[2 * i + 1]) + "}$").Success)
                                                {
                                                    cmoblieno.Add(strMobile);
                                                    done = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (!done)
                                        {
                                            strInvildMobile += strMobile + ",";
                                            done = false;
                                        }
                                    }

                                }
                                 if (cmoblieno.Count > 0)
                                 {
                                     string m = cmoblieno[0].ToString (); 
                                     string n = strAction;
                                     string strURL = AppFlag.AccountActionUrl + "/" + m + "/content/" + n;
                                      Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss fff") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") " + " URL:"+strURL);
                                   
                                    // Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") " + " 發送成功!   短訊內容：  " + n + " 發送號碼： " + string.Join(",", (string[])cmoblieno.ToArray(typeof(string))) + "\r\n");
                                     Send(strURL);
                                     Thread.Sleep(1000 / ((AppFlag.MaxCountSec - 1 < 1) ? 2 : AppFlag.MaxCountSec + 1));
                                 }
                                 cmoblieno.Clear();
                            }
                            //int ilen = 0;
                            //int maxlen = 0;
                            //string msg = dataSet.Tables[0].Rows[0][2].ToString().Trim().Replace("SMS:", "");
                            //string dateNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                            //int ipart = ConfigManager.CheckSmsData(msg, out ilen, out maxlen);
                            //string strBatchid = "";
                            //this.State = 1;
                            //smsMsgs.CreateSmsMsg(msg, "B", 0, dateNow, cmoblieno, this.dolbUser, "", ilen, ipart, cmoblieno.Count, out strBatchid);
                            //Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") " + strBatchid + " 發送成功!  \r\n 短訊內容：\r\n " + msg + "\r\n Unicode Msg: " + BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(msg)).Replace("-", "") + "\r\n 發送號碼： ");
                            //Files.CicsWriteLog(string.Join(",", (string[])cmoblieno.ToArray(typeof(string))));
                            //Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") 完成." + ((strInvildMobile == "") ? "" : " Invalid 號碼: " + strInvildMobile.Trim(",".ToCharArray())) + "\r\n");

                            dataSet = null;
                            bResult = true;

                        }
                        catch
                        {
                            if (error == false)
                            {
                                continue;
                            }
                            else
                            {
                                throw (new Exception("請上傳正確格式文件"));
                            }
                        }
                    }

                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ") 上載ACTION " + fileName + "成功!");
                        
                    //if (bResult)
                    //{
                    //    if (ConfigManager.SendWinMsg(AppFlag.WinMsgID))
                    //    {
                    //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ") 上載 " + fileName + "成功! （RemoteService）");
                    //    }
                    //    else
                    //    {
                    //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ") 上載 " + fileName + "成功! （No RemoteService）");
                    //    }

                        this.State = 2;
                    //} 

                    //connection.Open();
                    //DataTable table = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //SmsMsgs smsMsgs = new SmsMsgs();
                    //DataSet dataSet;

                    //this.Total = table.Rows.Count;
                    //this.Percent = 0;
                    //foreach (DataRow name in table.Rows)
                    //{
                    //    try
                    //    {
                    //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ")");
                    //        this.dolbUploadResult = name[2].ToString();
                    //        this.Percent++;

                    //        dataSet = new DataSet();
                    //        OleDbCommand command = new OleDbCommand("SELECT * FROM [" + name[2] + "]", connection);
                    //        OleDbDataAdapter adapter = new OleDbDataAdapter();
                    //        adapter.SelectCommand = command;
                    //        adapter.Fill(dataSet);
                    //        ArrayList cmoblieno = new ArrayList();
                    //        string strInvildMobile = "";

                    //        foreach (DataRow dr in dataSet.Tables[0].Rows)
                    //        {
                    //            string strMobile = dr[1].ToString().Trim();
                    //            //if (!cmoblieno.Contains(dr[1].ToString().Trim()) && (dr[1].ToString().Trim() != ""))
                    //            if (strMobile != "")
                    //            {
                    //                //if (dr[1].ToString().Trim().IndexOf("00") == 0 && dr[1].ToString().Trim().Length == 10)
                    //                //{
                    //                //    // cmoblieno.Add(dr[1].ToString().Replace("00", ""));
                    //                //    cmoblieno.Add(dr[1].ToString().Trim().Substring(2, 8));
                    //                //}

                    //                //string strMobile = dr[1].ToString().Trim();
                    //                //if (strMobile.IndexOf("00") == 0 && strMobile.Length == 10)
                    //                //{ 
                    //                //    cmoblieno.Add(strMobile.Substring(2, 8));
                    //                //}
                    //                //else if (strMobile.IndexOf("00852") == 0 && strMobile.Length == 13)
                    //                //{
                    //                //    cmoblieno.Add(strMobile.Substring(5, 8));
                    //                //}

                    //                if (!AppFlag.MobileIDD)
                    //                {
                    //                    if (strMobile.IndexOf("00") == 0 && strMobile.Length == 10)
                    //                    {
                    //                        cmoblieno.Add(strMobile.Substring(2, 8));
                    //                    }
                    //                    else if (strMobile.IndexOf("00852") == 0 && strMobile.Length == 13)
                    //                    {
                    //                        cmoblieno.Add(strMobile.Substring(5, 8));
                    //                    }
                    //                    else if (strMobile.IndexOf("00") != 0 && strMobile.Length == 8)
                    //                    {
                    //                        cmoblieno.Add(strMobile);
                    //                    }
                    //                    else
                    //                    {
                    //                        strInvildMobile += strMobile + ",";
                    //                    }

                    //                }
                    //                else
                    //                {
                    //                    bool done = false;
                    //                    if (strMobile.IndexOf("00") != 0 && strMobile.Length == 8)
                    //                    {
                    //                        cmoblieno.Add(strMobile);
                    //                        done = true;
                    //                    }
                    //                    else if (strMobile.IndexOf("00") == 0 && strMobile.Length == 10)
                    //                    {
                    //                        cmoblieno.Add(strMobile.Substring(2, 8));
                    //                        done = true;
                    //                    }
                    //                    else
                    //                    {
                    //                        string[] strArray2 = Regex.Split(AppFlag.MobileSign.Replace("+", ","), ",", RegexOptions.IgnoreCase);
                    //                        for (int i = 0; i < strArray2.Length / 2; i++)
                    //                        {
                    //                            string strRex = Regex.Replace((strArray2[2 * i]), @"[\s\S](?!$)", "$0][");
                    //                            if (Regex.Match(strMobile, "^[" + strRex + "][0-9]{" + (strArray2[2 * i + 1]) + "}$").Success)
                    //                            {
                    //                                cmoblieno.Add(strMobile);
                    //                                done = true;
                    //                                break;
                    //                            }
                    //                        }
                    //                    }
                    //                    if (!done)
                    //                    {
                    //                        strInvildMobile += strMobile + ",";
                    //                        done = false;
                    //                    }
                    //                }

                    //            }
                    //        }
                    //        int ilen = 0;
                    //        int maxlen = 0;
                    //        string msg = dataSet.Tables[0].Rows[0][2].ToString().Trim().Replace("SMS:", "");
                    //        string dateNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    //        int ipart = ConfigManager.CheckSmsData(msg, out ilen, out maxlen);
                    //        string strBatchid = "";
                    //        this.State = 1;
                    //        smsMsgs.CreateSmsMsg(msg, "B", 0, dateNow, cmoblieno, this.dolbUser, "", ilen, ipart, cmoblieno.Count, out strBatchid);
                    //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") " + strBatchid + " 發送成功!  \r\n 短訊內容：\r\n " + msg + "\r\n Unicode Msg: " + BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(msg)).Replace("-", "") + "\r\n 發送號碼： ");
                    //        Files.CicsWriteLog(string.Join(",", (string[])cmoblieno.ToArray(typeof(string))));
                    //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") 完成." + ((strInvildMobile == "") ? "" : " Invalid 號碼: " + strInvildMobile.Trim(",".ToCharArray())) + "\r\n");

                    //        dataSet = null;
                    //        bResult = true;

                    //    }
                    //    catch
                    //    {
                    //        continue;
                    //    }
                    //}
                    //if (bResult)
                    //{
                    //    if (ConfigManager.SendWinMsg(AppFlag.WinMsgID))
                    //    {
                    //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ") 上載 " + fileName + "成功! （RemoteService）");
                    //    }
                    //    else
                    //    {
                    //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ") 上載 " + fileName + "成功! （No RemoteService）");
                    //    }

                    //    this.State = 2;
                    //} 
                }
                catch (Exception exp)
                {
                    this.ErrorTime = DateTime.Now;
                    this.Percent = 0;
                    this.State = 3;
                    bReadExcel = false;
                    this.dolbUploadResult = "請上傳正確格式文件(" + fileName + ")!";
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + " Upload ACTION: " + fileName + "  Error: " + exp.ToString());
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  停止上載 ACTION " + fileName + " !");
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                this.ErrorTime = DateTime.Now;
                this.Percent = 0;
                this.State = 3;
                bReadExcel = false;
                this.dolbUploadResult = "請上傳正確格式文件(" + fileName + ")!";
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  停止上載 ACTION" + fileName + ", 請上傳正確格式文件!");
            }
            try
            {
                if (bReadExcel)
                {
                }
            }
            catch (Exception exp)
            {
                bResult = false;
                ErrorTime = DateTime.Now;
                Percent = 0;
                State = 3;
                dolbUploadResult = "上傳 ACTION" + FileName + ",請稍后再試！";
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + dolbUploadResult.Replace("<br>", "|"));
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + fileName + "  Error: " + exp.ToString());
            }
            finally
            {
                string strACTION_REMARKS = dolbUploadResult.Replace("<br>", "|");
                if (strACTION_REMARKS.Length > 1000)
                {
                    strACTION_REMARKS = strACTION_REMARKS.Substring(0, 999);
                }

                try
                {

                    SmsActions smsaction = new SmsActions();
                    SmsActionData actiondata = smsaction.LoadActionByCondition(strcondtion, "ACTION");
                    string endtime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
                    DataRow actiondr = actiondata.Tables[SmsActionData.SMS_ACTIONS].Rows[0];
                    if (bResult == true)
                    {
                        actiondr[SmsActionData.CSMS_ACTION_STATUS] = "完成";
                    }
                    else
                    {
                        actiondr[SmsActionData.CSMS_ACTION_STATUS] = "N/A";
                    }
                    actiondr[SmsActionData.ACTION_ENDTIME] = endtime;
                    actiondr[SmsActionData.ACTION_REMARKS] = "備註：" + strACTION_REMARKS;
                    smsaction.UpdateAction(actiondata);
                    strcondtionirecno = Convert.ToInt32(actiondr[SmsActionData.ISMS_IREC_NO]);
                }
                catch (Exception exp)
                {
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + fileName + " Action,  Error: " + exp.ToString());
                }
                //  dataSet = null;
                FinishTime = DateTime.Now;
            }
        }

        public void Send(string url)
        {
            //POST
            //WebRequest req = WebRequest.Create(url);
            //req.Method = "POST";
            //req.ContentType = "application/x-www-form-urlencoded";

            //req.ContentLength = url.Length;
            //byte[] buff = Encoding.UTF8.GetBytes(url);

            //Stream reqStream = req.GetRequestStream();
            //reqStream.Write(buff, 0, buff.Length);
            //reqStream.Close();

            //Stream ReceiveStream = req.GetResponse().GetResponseStream();
            //Encoding enc = Encoding.GetEncoding("utf-8");
            //StreamReader sr = new StreamReader(ReceiveStream, enc);
            //string str = sr.ReadToEnd().ToUpper();
            try
            {
                string ReturnVal = "";
                WebRequest hr = HttpWebRequest.Create(url); 
                byte[] buf = System.Text.Encoding.GetEncoding("utf-8").GetBytes(url);
                hr.Method = "GET";
                hr.Timeout = 1000;
                System.Net.WebResponse response = hr.GetResponse();
                if (response != null)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        ReturnVal = reader.ReadToEnd();
                    }
                    // reader.Close();
                    response.Close();
                }
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Received:" + ReturnVal);
            }
            catch (Exception exp)
            {
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Received error." );
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + " Received error:" + exp.ToString());
            }
        }

        public void Runload()
        {
            lock (this)
            {
                if (this.State != 1)
                {
                    this.State = 1;
                    this.StartTime = DateTime.Now;
                    new Thread(new ThreadStart(this.InsertUploadData)).Start();
                }
            }
        }
    }
}

