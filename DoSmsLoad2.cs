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
    using System.Collections.Generic;

    public class DoSmsLoad2
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
        public bool DoAction = false;  


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

        public class SheetName
        {
            public string sheetName { get; set; }
            public string sheetType { get; set; }
            public string sheetCatalog { get; set; }
            public string sheetSchema { get; set; }
        }

        public List<SheetName> GetSheetNames(OleDbConnection conn)
        {
            List<SheetName> sheetNames = new List<SheetName>();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            DataTable excelSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            foreach (DataRow row in excelSchema.Rows)
            {
                if (!row["TABLE_NAME"].ToString().Contains("FilterDatabase"))
                {
                    sheetNames.Add(new SheetName() { sheetName = row["TABLE_NAME"].ToString(), sheetType = row["TABLE_TYPE"].ToString(), sheetCatalog = row["TABLE_CATALOG"].ToString(), sheetSchema = row["TABLE_SCHEMA"].ToString() });
                }
            }
            conn.Close();
            return sheetNames;
        }


        private void InsertUploadData()
        { 
            bool bReadExcel = true;
            bool bResult = false; 
            string fileName = this.FileName.ToUpper();
            if (fileName.LastIndexOf("XLS") == fileName.Length - 3 || fileName.LastIndexOf("XLSX") == fileName.Length - 4)
            {
                string str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.dobtnUploadMode + ";Extended Properties='Excel 12.0;HDR=No;IMEX=1;'";
                OleDbConnection connection = new OleDbConnection(str);
            //if (fileName.LastIndexOf("XLS") == fileName.Length - 3)
            //{
            //    OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.dobtnUploadMode + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';");
                try
                {
                    connection.Open();
                   // DataTable table = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                     SmsMsgs smsMsgs = new SmsMsgs();
                     DataSet dataSet;

                    // this.Total =   table.Rows.Count;
                     this.Percent =0;
                    // DateTime dtCreate = DateTime.Now;
                     DateTime dtCreate ;//= DateTime.Now;
                   /// string strCID = dtCreate.ToString("MMddHHmmss");
                     string strCID = DateTime.Now.ToString("MMddHHmmss");
                     int iSign = 0;
                     bool error = false;
                     ArrayList batchids = new ArrayList();

                     List<SheetName> sheetNames = GetSheetNames(connection);
                     this.Total = sheetNames.Count ;
                    // foreach (DataRow name in table.Rows)
                     foreach (SheetName sheet in sheetNames)
                    {
                        try
                        {
                            ///  string dateNow = dtCreate.AddSeconds(iSign).ToString("yyyy/MM/dd HH:mm:ss");
                            iSign++;
                            //Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ")");
                            //this.dolbUploadResult = name[2].ToString();
                            //this.Percent++;

                            //dataSet = new DataSet();
                            //OleDbCommand command = new OleDbCommand("SELECT * FROM [" + name[2] + "]", connection);
                            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + sheet.sheetName.ToString() + ")");
                            this.dolbUploadResult = sheet.sheetName;
                            this.Percent++;

                            dataSet = new DataSet();
                            OleDbCommand command = new OleDbCommand("SELECT * FROM [" + sheet.sheetName + "]", connection);
                            OleDbDataAdapter adapter = new OleDbDataAdapter();
                            adapter.SelectCommand = command;
                            adapter.Fill(dataSet);
                            ArrayList cmoblieno = new ArrayList();
                            string strInvildMobile = "";
                            ArrayList cmoblieAction = new ArrayList();
                            string strMobileAction = "";
                            string strMobile = "";
                            //if (dataSet.Tables[0].Rows.Count < 2)
                            //{
                            //    continue;
                            //}
                            if (dataSet.Tables[0].Columns.Count < 4 && DoAction == true)
                            {
                                if (dataSet.Tables[0].Rows.Count < 1)
                                {
                                    continue;
                                }
                                else
                                {
                                    error = true;
                                    throw (new Exception("請上傳正確格式文件"));
                                }
                                // break;
                            }

                            foreach (DataRow dr in dataSet.Tables[0].Rows)
                            {
                                if (DoAction == true)
                                {
                                    strMobileAction = dr[3].ToString().Trim();
                                }
                                strMobile = dr[1].ToString().Trim();
                                //if (!cmoblieno.Contains(dr[1].ToString().Trim()) && (dr[1].ToString().Trim() != ""))
                                if (strMobile != "")
                                {
                                    //if (dr[1].ToString().Trim().IndexOf("00") == 0 && dr[1].ToString().Trim().Length == 10)
                                    //{
                                    //    // cmoblieno.Add(dr[1].ToString().Replace("00", ""));
                                    //    cmoblieno.Add(dr[1].ToString().Trim().Substring(2, 8));
                                    //}

                                    //string strMobile = dr[1].ToString().Trim();
                                    //if (strMobile.IndexOf("00") == 0 && strMobile.Length == 10)
                                    //{ 
                                    //    cmoblieno.Add(strMobile.Substring(2, 8));
                                    //}
                                    //else if (strMobile.IndexOf("00852") == 0 && strMobile.Length == 13)
                                    //{
                                    //    cmoblieno.Add(strMobile.Substring(5, 8));
                                    //}

                                    if (!AppFlag.MobileIDD)
                                    {
                                        if (strMobile.IndexOf("00") == 0 && strMobile.Length == 10)
                                        {
                                            cmoblieAction.Add(strMobileAction);
                                            cmoblieno.Add(strMobile.Substring(2, 8));
                                        }
                                        else if (strMobile.IndexOf("00852") == 0 && strMobile.Length == 13)
                                        {
                                            cmoblieAction.Add(strMobileAction);
                                            cmoblieno.Add(strMobile.Substring(5, 8));
                                        }
                                        else if (strMobile.IndexOf("00") != 0 && strMobile.Length == 8)
                                        {
                                            cmoblieAction.Add(strMobileAction);
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
                                            cmoblieAction.Add(strMobileAction);
                                            cmoblieno.Add(strMobile);
                                            done = true;
                                        }
                                        else if (strMobile.IndexOf("00") == 0 && strMobile.Length == 10)
                                        {
                                            cmoblieAction.Add(strMobileAction);
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
                                                    cmoblieAction.Add(strMobileAction);
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
                                /// }
                                int ilen = 0;
                                int maxlen = 0;
                                //string msg = dataSet.Tables[0].Rows[0][2].ToString().Trim().Replace("SMS2:", "");
                                string msg =dr[2].ToString().Trim().Replace("SMS2:", "");
                                // string dateNow = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                                int ipart = ConfigManager.CheckSmsData(msg, out ilen, out maxlen);
                                string strBatchid = "";
                                this.State = 1;

                                //smsMsgs.CreateSmsMsg(msg, "B", 0, dateNow, cmoblieno, this.dolbUser, "", ilen, ipart, cmoblieno.Count, out strBatchid);
                                //Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") " + strBatchid + " 發送成功!  \r\n 短訊內容：\r\n " + msg + "\r\n Unicode Msg: " + BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(msg)).Replace("-", "") + "\r\n 發送號碼： ");
                                //Files.CicsWriteLog(string.Join(",", (string[])cmoblieno.ToArray(typeof(string))));
                                //Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") 完成." + ((strInvildMobile == "") ? "" : " Invalid 號碼: " + strInvildMobile.Trim(",".ToCharArray())) + "\r\n");
                                //if (DoAction == true)
                                //{
                                //    new SmsMsgsAction().CreateSmsMsgAction(strCID, cmoblieno, cmoblieAction);
                                //    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") " + " Action!  ");
                                //} 

                                ArrayList batchMobiles = new ArrayList();
                                ArrayList batchMobilesAction = new ArrayList();
                                for (int x = 0; x < cmoblieno.Count; x++)
                                {
                                    if (batchMobiles.Count < AppFlag.MaximunBatch)
                                    {
                                        batchMobilesAction.Add(cmoblieAction[x]);
                                        batchMobiles.Add(cmoblieno[x]);
                                    }
                                    if (batchMobiles.Count == AppFlag.MaximunBatch || x == cmoblieno.Count - 1)
                                    {
                                        dtCreate = DateTime.Now;
                                        string dateNow = dtCreate.AddSeconds(iSign).ToString("yyyy/MM/dd HH:mm:ss");
                                        //string strCID = dtCreate.ToString("MMddHHmmss");
                                        smsMsgs.CreateSmsMsg(msg, "B", 0, dateNow, batchMobiles, this.dolbUser, "", ilen, ipart, batchMobiles.Count, out strBatchid);
                                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + sheet.sheetName.ToString() + ") " + strBatchid + " 發送成功!  \r\n 短訊內容：\r\n " + msg + "\r\n Unicode Msg: " + BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(msg)).Replace("-", "") + "\r\n 發送號碼： ");
                                        Files.CicsWriteLog(string.Join(",", (string[])batchMobiles.ToArray(typeof(string))));
                                        //  Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") 完成." + ((strInvildMobile == "") ? "" : " Invalid 號碼: " + strInvildMobile.Trim(",".ToCharArray())) + "\r\n");
                                        if (DoAction == true)
                                        {
                                            new SmsMsgsAction().CreateSmsMsgAction(strBatchid, batchMobiles, batchMobilesAction);
                                            //   Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") " + " Action!  ");
                                            //   Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + name[2].ToString() + ") " + strBatchid + " Action!  ");
                                            batchids.Add(strBatchid);
                                        }
                                        //batchMobiles.Clear();
                                        //batchMobilesAction.Clear();
                                    }
                                }
                                batchMobiles.Clear();
                                batchMobilesAction.Clear();
                                cmoblieno.Clear();
                                cmoblieAction.Clear();
                                //Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + sheet.sheetName.ToString() + ") 完成." + ((strInvildMobile == "") ? "" : " Invalid 號碼: " + strInvildMobile.Trim(",".ToCharArray())));
                                //if (DoAction == true)
                                //{
                                //    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + sheet.sheetName.ToString() + ") " + " Action 完成. \r\n ");
                                //}
                                //dataSet = null;
                                //bResult = true;
                            } 
                           
                            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + sheet.sheetName.ToString() + ") 完成.");// + ((strInvildMobile == "") ? "" : " Invalid 號碼: " + strInvildMobile.Trim(",".ToCharArray())));
                            if (DoAction == true)
                            {
                                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  上載 (" + sheet.sheetName.ToString() + ") " + " Action 完成. \r\n ");
                            }
                            dataSet = null;
                            bResult = true;
                        }
                        catch
                        {
                            // continue; 
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
                    if (bResult)
                    {
                        if (ConfigManager.SendWinMsg(AppFlag.WinMsgID))
                        {
                            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ") 上載SMS2 " + fileName +"成功! （RemoteService）");
                         }
                        else
                        {
                            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ") 上載SMS2 " + fileName + "成功! （No RemoteService）");
                        }
                        if (DoAction == true)
                        {
                            if (ConfigManager.SendWinMsgAction(batchids))
                            {
                                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ") 上載ACTION " + string.Join(",", (string[])batchids.ToArray(typeof(string))) + "," + fileName + " ! （RemoteService）");
                            }
                            else
                            {
                                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ") 上載ACTON " + fileName + " ! （No RemoteService）");
                            }
                        }
                      this.State = 2; 
                    }
                    //OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
                    //string sheetName = table.Rows[0][2].ToString();
                    //OleDbCommand command = new OleDbCommand("SELECT * FROM [" + sheetName + "]", connection);
                    //OleDbDataAdapter adapter = new OleDbDataAdapter();
                    //adapter.SelectCommand = command;
                    //adapter.Fill(dataSet);
                    //this.Total = dataSet.Tables[0].Rows.Count;
                }
                catch (Exception exp)
                {
                    this.ErrorTime = DateTime.Now;
                    this.Percent = 0;
                    this.State = 3;
                    bReadExcel = false;
                    this.dolbUploadResult = "請上傳正確格式文件(" + fileName + ")!";
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + " Upload: " + fileName + "  Error: " + exp.ToString());
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  停止上載 " + fileName +" !");
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
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  停止上載 " + fileName + ", 請上傳正確格式文件!");
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
                dolbUploadResult = "上傳" + FileName + ",請稍后再試！";
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
                    SmsActionData actiondata = smsaction.LoadActionByCondition(strcondtion,"SMS2");
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

