namespace CENTASMS
{
    using CENTASMS.BLL;
    using CENTASMS.DAL;
    using System;
    using System.Data;
   // using FirebirdSql.Data.FirebirdClient;
    using System.Data.OleDb;
    using System.Text.RegularExpressions;
    using System.Threading; 
    using System.Collections; 
    using System.IO;

    public class Doload
    {
        public string dobtnUploadMode = "";
        public string dolbUploadResult = "";
        public string dolbUser = "";
        public bool dorbGroupP = false;
        public bool dorbTypeAdd = false;
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

        //private void InsertUploadData()
        //{
        //    Thread.Sleep(0x3e8);
        //    bool flag = true;
        //    bool flag2 = false;
        //    DataSet dataSet = new DataSet();
        //    string fileName = this.FileName;
        //    OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.dobtnUploadMode + ";Extended Properties='Excel 8.0;IMEX=1';");
        //    try
        //    {
        //        connection.Open();
        //        OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
        //        OleDbDataAdapter adapter = new OleDbDataAdapter();
        //        adapter.SelectCommand = command;
        //        adapter.Fill(dataSet);
        //        this.Total = dataSet.Tables[0].Rows.Count;
        //    }
        //    catch (Exception exception)
        //    {
        //        this.ErrorTime = DateTime.Now;
        //        this.Percent = 0;
        //        this.State = 3;
        //        flag = false;
        //        this.dolbUploadResult = "請上傳正確格式文件!";
        //        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + " Upload: " + fileName + "  Error: " + exception.ToString());
        //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  停止上載 " + fileName + " 組別！");
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    try
        //    {
        //        if (flag)
        //        {
                     
        //            DataRow[]  rowArray = dataSet.Tables[0].Select(dataSet.Tables[0].Columns[0].ColumnName + "<>''");
                   

        //            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Start");

        //            string strGuid = System.Guid.NewGuid().ToString("N");
        //            DataSet dataset = new DataSet();

        //            DataTable table = new DataTable("GROUP_MEMBER_INFO");
        //            DataColumnCollection columns = table.Columns;

        //            columns.Add("GUID", typeof(string));
        //            columns.Add("IITEM_NO", typeof(int));
        //            columns.Add("CMEMBER_NAME", typeof(string));
        //            columns.Add("CMOBILENO", typeof(string));
        //            dataset.Tables.Add(table);
        //            DataRow dr;
        //            int no = 1;
        //            foreach (DataRow memberRow in rowArray)
        //            {
        //                dr = dataset.Tables[0].NewRow();
        //                dr[0] = strGuid;
        //                dr[1] = no;
        //                dr[2] = memberRow[1].ToString().Trim();
        //                dr[3] = memberRow[2].ToString().Trim();
        //                dataset.Tables[0].Rows.Add(dr);
        //                no++;
        //                Percent++; State = 1; 
        //            }
        //            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Start insert");
        //            int count = new GroupMembers().InsertMemberInfo(dataset);
        //            State = 2;
        //            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Insert " + count);

        //        }
        //    }
        //    catch (Exception exception2)
        //    {
        //        flag2 = false;
        //        ErrorTime = DateTime.Now;
        //        Percent = 0;
        //        State = 3;
        //        dolbUploadResult = "上傳" + FileName + ",請稍后再試！";
        //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + dolbUploadResult.Replace("<br>", "|"));
        //        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + fileName + "  Error: " + exception2.ToString());
        //    }
        //    finally
        //    {
        //        string ACTION_REMARKS = dolbUploadResult.Replace("<br>", "|");
        //        if (ACTION_REMARKS.Length > 1000)
        //        {
        //            ACTION_REMARKS = ACTION_REMARKS.Substring(0, 999);
        //        }
        //        else
        //        {
        //            ACTION_REMARKS = ACTION_REMARKS;
        //        }
        //        if (flag2 == true)
        //        {
        //            try
        //            {
        //                SmsActions smsaction = new SmsActions();
        //                SmsActionData actiondata = smsaction.LoadActionByCondition(strcondtion);
        //                string endtime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
        //                DataRow actiondr = actiondata.Tables[SmsActionData.SMS_ACTIONS].Rows[0];
        //                actiondr[SmsActionData.CSMS_ACTION_STATUS] = "完成";
        //                actiondr[SmsActionData.ACTION_ENDTIME] = endtime;
        //                actiondr[SmsActionData.ACTION_REMARKS] = "備註：" + ACTION_REMARKS;
        //                smsaction.UpdateAction(actiondata);
        //                strcondtionirecno = Convert.ToInt32(actiondr[SmsActionData.ISMS_IREC_NO]);
        //            }
        //            catch (Exception exp)
        //            {
        //                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + fileName + " Action,  Error: " + exp.ToString());
        //            }
        //        }
        //        else
        //        {
        //            try
        //            {
        //                SmsActions smsaction = new SmsActions();
        //                SmsActionData actiondata = smsaction.LoadActionByCondition(strcondtion);
        //                string endtime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
        //                DataRow actiondr = actiondata.Tables[SmsActionData.SMS_ACTIONS].Rows[0];
        //                actiondr[SmsActionData.CSMS_ACTION_STATUS] = "N/A";
        //                actiondr[SmsActionData.ACTION_ENDTIME] = endtime;
        //                actiondr[SmsActionData.ACTION_REMARKS] = "備註：" + ACTION_REMARKS;
        //                smsaction.UpdateAction(actiondata);
        //                strcondtionirecno = Convert.ToInt32(actiondr[SmsActionData.ISMS_IREC_NO]);
        //            }
        //            catch (Exception exp)
        //            {
        //                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + fileName + " Action,  Error: " + exp.ToString());
        //            }
        //        }
        //        dataSet = null;
        //        FinishTime = DateTime.Now;
        //    }
        //}

        private void InsertUploadData()
        {
            Thread.Sleep(0x3e8);
            bool flag = true;
            bool flag2 = false;
            DataSet dataSet = new DataSet();
            string fileName = this.FileName.ToUpper ();
            if (fileName.LastIndexOf("XLS") == fileName.Length - 3 || fileName.LastIndexOf("XLSX") == fileName.Length - 4)
            {
                string str = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.dobtnUploadMode + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                OleDbConnection connection = new OleDbConnection(str);
              
              //  OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.dobtnUploadMode + ";Extended Properties='Excel 8.0;IMEX=1';");
                try
                {
                    connection.Open();
                  DataTable table=  connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,null);
                    //OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
                    string sheetName=table.Rows [0][2].ToString ();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM [" + sheetName + "]", connection);
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dataSet);
                    this.Total = dataSet.Tables[0].Rows.Count;
                }
                catch (Exception exception)
                {
                    this.ErrorTime = DateTime.Now;
                    this.Percent = 0;
                    this.State = 3;
                    flag = false;
                    this.dolbUploadResult = "請上傳正確格式文件!";
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + " Upload: " + fileName + "  Error: " + exception.ToString());
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  停止上載 " + fileName + ", 請上傳正確格式文件!");
                }
                finally
                {
                    connection.Close();
                }
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  Start parser excel.");
            }
            else if (fileName.LastIndexOf("CSV") == fileName.Length - 3)
            {
                try
                {
                    string[] arr = File.ReadAllLines(this.dobtnUploadMode);


                    DataTable table = new DataTable("tempTable");
                    DataColumnCollection columns = table.Columns; 
                    columns.Add("GROUP_NAME", typeof(string));
                    columns.Add("MEMBER_NAME", typeof(string));
                    columns.Add("MOBILENO", typeof(string));
                    dataSet.Tables.Add(table);
                    DataRow dr; 

                    for (int i = 0; i < arr.Length; i++)
                    {
                        string[] strArray = Regex.Split(arr[i], ",", RegexOptions.IgnoreCase);
                        if (strArray==null || strArray.Length < 3) continue;
                        dr = dataSet.Tables[0].NewRow();
                        dr[0] = strArray[0]; 
                        dr[1] = strArray[1]; 
                        dr[2] = strArray[2]; 
                        dataSet.Tables[0].Rows.Add(dr); 
                    }
                    this.Total = dataSet.Tables[0].Rows.Count;
                }
                catch (Exception exp)
                {
                    this.ErrorTime = DateTime.Now;
                    this.Percent = 0;
                    this.State = 3;
                    flag = false;
                    this.dolbUploadResult = "請上傳正確格式文件!";
                    Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + " Upload: " + fileName + "  Error: " + exp.ToString());
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  停止上載 " + fileName + ", 請上傳正確格式文件!");
                }
            }
            else
            {
                this.ErrorTime = DateTime.Now;
                this.Percent = 0;
                this.State = 3;
                flag = false;
                this.dolbUploadResult = "請上傳正確格式文件!";
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  停止上載 " + fileName + ", 請上傳正確格式文件!");
            }

            string strGuid = "";
            GroupMembers members = new GroupMembers(); 
            //GroupMembers groupMembers = new GroupMembers();
            try
            {
                if (flag)
                {
                    string dolbUser = this.dolbUser;
                    string str4 = "";
                    string str5 = "";
                    DataRow[] rowArrays = dataSet.Tables[0].Select(dataSet.Tables[0].Columns[0].ColumnName + "<>''");
                   
                    if (this.dorbGroupP)
                    {
                        str4 = "P";
                    }
                    else
                    {
                        str4 = "S";
                    }
                    if (this.dorbTypeAdd)
                    {
                        str5 = "A";
                    }
                    else
                    {
                        str5 = "C";
                    }
                    if (str5 == "C")
                    {
                        foreach (DataRow row in rowArrays)
                        {
                            string str6 = row[0].ToString();
                            GroupMemberData memberDataByGroupNameandOwner = new GroupMemberData();
                           // GroupMembers members = new GroupMembers();
                            memberDataByGroupNameandOwner = members.GetMemberDataByGroupNameandOwner(str6, dolbUser);
                            if (memberDataByGroupNameandOwner.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow row2 in memberDataByGroupNameandOwner.Tables[0].Select())
                                {
                                    row2.Delete();
                                }
                                members.DeleteMember(memberDataByGroupNameandOwner);

                                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (上傳覆蓋組別的號碼)Delete.");
                            }
                        }
                    }
                    this.Percent = 0;
                   // GroupMembers groupMembers = new GroupMembers();
                   // string strGuid = "";
                    if (AppFlag.UploadFilter)
                    { 
                         strGuid = System.Guid.NewGuid().ToString("N");
                        DataSet dataset = new DataSet();

                        DataTable table = new DataTable("GROUP_MEMBER_INFO");
                        DataColumnCollection columns = table.Columns;

                        columns.Add("GUID", typeof(string));
                        columns.Add("IITEM_NO", typeof(int));
                        columns.Add("CGROUP_NAME", typeof(string));
                        columns.Add("CMEMBER_NAME", typeof(string));
                        columns.Add("CMOBILENO", typeof(string));
                        dataset.Tables.Add(table);
                        DataRow dr;
                        int no = 1;
                        foreach (DataRow memberRow in rowArrays)
                        {
                            dr = dataset.Tables[0].NewRow();
                            dr[0] = strGuid;
                            dr[1] = no;
                            dr[2] = memberRow[0].ToString().Trim();
                            dr[3] = memberRow[1].ToString().Trim();
                            dr[4] = memberRow[2].ToString().Trim();
                            dataset.Tables[0].Rows.Add(dr);
                            no++;
                        } 
                        members.InsertMemberInfo(dataset);
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  Inserted data to GROUP_MEMBER_INFO." + dataset.Tables[0].Rows.Count .ToString());
                    }
                    this.dolbUploadResult = "Filtering...";
                    this.Percent = 0;
                    string strGroupID = "";
                    string strGroupName = "";
                    string strMemberName = "";
                    string strMobile = "";
                    string strGroupType = "";
                    string strCreateDate = "";

                    //GroupMembers groupMembers = new GroupMembers();
                    //int item_No = 0;// groupMembers.GetNewItem_NO();
                    int item_No = members.GetNewItem_NO();
                    GroupMemberData memberData = new GroupMemberData();
                    bool existGroupID = false;
                    int iexistconut = 0;
                    string strErrorMobile = "";
                    string strExistMobile = "";
                    int count = 0; 
                    DataSet da1 =   members.GroupMemberRepeatInfo(strGuid);
                    
                    //Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "start delete rowRepeatArray");
                    //foreach (DataRow row1 in da1.Tables[0].Select())
                    //{
                    //    row1.Delete();
                    //}
                    //members.DeleteGroupMemberRepeatInfo(da1);
                    //Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " delete rowRepeatArray");

                    DataRow[] rowRepeatArray = da1.Tables[0].Select();

                   // Percent = 20;
                   
                    ArrayList arr = new ArrayList();
                    ArrayList arrNO = new ArrayList(); 
                    foreach (DataRow rowRepeat in rowRepeatArray)
                    {
                        if (!arrNO.Contains(rowRepeat["CMOBILENO"].ToString().Trim()))
                        {

                            arrNO.Add(rowRepeat["CMOBILENO"].ToString().Trim());
                        }
                        else
                        {
                            arr.Add(rowRepeat["IITEM_NO"].ToString().Trim());
                            members.DeleteGroupMemberRepeatInfobyNO(strGuid, rowRepeat["IITEM_NO"].ToString().Trim());
                         }
                        strExistMobile += rowRepeat[2].ToString().Trim() + " " + rowRepeat[3].ToString().Trim() + " " + rowRepeat[4].ToString().Trim() + "<br>";
                    }
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  Got repeat data." + arrNO.Count .ToString());

                    //members.DeleteGroupMemberRepeatInfobyNOs(strGuid,string.Join("','", (string[])arr.ToArray(typeof(string))));
                    //Percent = 30;
                    DataRow[] rowArray = members.GroupMemberInfo(strGuid).Tables[0].Select();
                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  Got valid data." + rowArray.Length .ToString()); 

                    foreach (DataRow memberRow in rowArray)
                    {
                        strGroupName = memberRow[2].ToString();
                        strMemberName = memberRow[3].ToString();
                        strMobile = memberRow[4].ToString().Trim();
                        strGroupType = str4;
                        strCreateDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ");
                        bool existMobile = false;
                        // if (strGroupID == "" && strGroupName.Trim() != "")
                        if (strGroupName.Trim() != "")
                        {
                            Groups groups = new Groups();
                            GroupData data = groups.LoadGroupByGroupNameandOwner(strGroupName, dolbUser);

                            // GroupID  not exist in by GroupName and CGROUP_OWNER
                            if (data.Tables[0].Rows.Count == 0)
                            {
                                strGroupID = groups.GetNewGroupid(strGroupName, dolbUser);
                                DataRow row4 = data.Tables["GROUP_INFO"].NewRow();
                                row4["CGROUP_ID"] = strGroupID;
                                row4["CGROUP_NAME"] = strGroupName;
                                row4["CGROUP_OWNER"] = dolbUser;
                                row4["CGROUP_TYPE"] = str4;
                                row4["CGROUP_PWD"] = "";
                                row4["CREATE_DATE"] = strCreateDate;
                                data.Tables["GROUP_INFO"].Rows.Add(row4);
                                groups.InsertGroup(data);
                                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  Insert GROUP_INFO, CGROUP_ID: " + strGroupID + ",CGROUP_NAME: " + strGroupName.Trim());
                                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  Filer  existent member by CGROUP_ID: " + strGroupID + ",CGROUP_NAME: " + strGroupName.Trim() + " and Ready to Insert GROUP_MEMBER");
                                //     item_No = 1;
                            }
                            else
                            {
                                //GroupID  exist in 
                                strGroupID = data.Tables[0].Rows[0]["CGROUP_ID"].ToString();
                                existGroupID = true;
                                //  item_No = groupMembers.GetNewItem_NO();
                            }
                        }
                        if (existGroupID)
                        {
                            //Mobile not exist in Group  by GroupID
                            if (members.LoadMembesByGroupNameIDandMobileNum(strGroupID, strMobile).Tables[0].Rows.Count != 0)
                            {
                                existMobile = true;
                            }
                        }
                        if (existMobile)
                        {
                            // log exist mobile
                            iexistconut++;
                            if (iexistconut < 20)
                            {
                                strExistMobile += strGroupName.Trim() + " " + strMemberName.Trim() + " " + strMobile + "<br>";
                            }
                            else if (iexistconut == 20)
                            {
                                strExistMobile = strExistMobile + "......etc";
                            }
                        }
                        else
                        {
                            // insert mobile
                            bool flag5 = false;
                            if (strMobile.IndexOf("00852") == 0)
                            {
                                string input = strMobile.Substring(5);
                                if (input.Length != 8)
                                {
                                    strErrorMobile = "(電話號碼位數不正確)";
                                }
                                else if (Regex.Match(input, "[" + AppFlag.ValidPrefixes + "]{1}[0-9]{7}$").Success)
                                {
                                    flag5 = true;
                                }
                                else
                                {
                                    strErrorMobile = "(請輸入正確號碼)";
                                }
                            }
                            else if (strMobile.IndexOf("00") == 0)
                            {
                                if (strMobile.Length < 3)
                                {
                                    strErrorMobile = "(電話號碼位數不正確)";
                                }
                                else
                                {
                                    flag5 = true;
                                }
                            }
                            else if (strMobile.Length != 8)
                            {
                                strErrorMobile = "(電話號碼位數不正確)";
                            }
                            else if (Regex.Match(strMobile, "[" + AppFlag.ValidPrefixes + "]{1}[0-9]{7}$").Success)
                            {
                                flag5 = true;
                            }
                            else
                            {
                                strErrorMobile = "(請輸入正確號碼)";
                            }
                            if (flag5)
                            {
                                DataRow row5 = memberData.Tables["GROUP_MEMBER"].NewRow();
                                row5["IITEM_NO"] = item_No;// this.Percent + 2;
                                row5["CGROUP_ID"] = strGroupID;
                                row5["CMEMBER_NAME"] = strMemberName ;
                                row5["CMOBILENO"] = strMobile;
                                row5["CREATE_DATE"] = strCreateDate;
                                //if (AppFlag.UploadFilter)
                                //{
                                   //// string filterExpression = "CMOBILENO='" + strMobile + "' and CGROUP_ID='" + strGroupID + "'";
                                   // bool exist = groupMembers.MobileExistIn(strGroupName, strMobile, strGuid);
                                   // if (exist)
                                   // {
                                   //     iexistconut++;
                                   //     if (iexistconut < 20)
                                   //     {
                                   //         strExistMobile += strGroupName.Trim() + " " + strMemberName.Trim() + " " + strMobile + "<br>";
                                   //     }
                                   //     else if (iexistconut == 20)
                                   //     {
                                   //         strExistMobile = strExistMobile + "......etc";
                                   //     }
                                   // }
                                   // else
                                   // {
                                        // row5["IITEM_NO"] = 1;
                                        //memberData.Tables["GROUP_MEMBER"].Rows.Add(row5);
                                        //item_No++;
                                    //}


                                //}
                                //else
                                //{
                                    //row5["IITEM_NO"] = 1;
                                    memberData.Tables["GROUP_MEMBER"].Rows.Add(row5);
                                    item_No++;
                                //}
                            }
                            else if (strGroupName.Trim() != "")
                            {
                                strErrorMobile += strGroupName.Trim() + " " + strMemberName.Trim() + " " + strMobile + "<br>";
                            }
                        }

                        State = 1;
                        Percent++;
                        strMobile = "";
                        strGroupName = "";
                        strMemberName = "";
                    }//foreach

                    /*
                    bool flag3 = false;
                    bool flag4 = false;
                    string str7 = "";
                    string str8 = "";
                    int count = 0;
                    int num2 = 0;
                    this.Percent = 0;
                    GroupMemberData data2 = new GroupMemberData();
                    GroupMembers members2 = new GroupMembers();
                    int num3 = members2.GetNewItem_NO();
                    string groupname = "";
                    string str10 = "";
                    string mobilenum = "";
                    string groupid = "";
                    foreach (DataRow row3 in rowArray)
                    {
                        string str13 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ");
                        groupname = row3[0].ToString() + "                              ";
                        str10 = row3[1].ToString() + "                              ";
                        mobilenum = row3[2].ToString().Trim();
                        groupid = "";
                        if (groupname.Trim() != "")
                        {
                            Groups groups = new Groups();
                            GroupData data = groups.LoadGroupByGroupNameandOwner(groupname, dolbUser);
                            if (data.Tables[0].Rows.Count == 0)
                            {
                                groupid = groups.GetNewGroupid(groupname, dolbUser);
                                DataRow row4 = data.Tables["GROUP_INFO"].NewRow();
                                row4["CGROUP_ID"] = groupid;
                                row4["CGROUP_NAME"] = groupname;
                                row4["CGROUP_OWNER"] = dolbUser;
                                row4["CGROUP_TYPE"] = str4;
                                row4["CGROUP_PWD"] = "";
                                row4["CREATE_DATE"] = str13;
                                data.Tables["GROUP_INFO"].Rows.Add(row4);
                                groups.InsertGroup(data);
                                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  Insert GROUP_INFO, CGROUP_ID: " + groupid + ",CGROUP_NAME: " + groupname.Trim());
                                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + this.dolbUser + ")  Filer  existent member by CGROUP_ID: " + groupid + ",CGROUP_NAME: " + groupname.Trim() + " and Ready to Insert GROUP_MEMBER");
                                flag3 = false;
                            }
                            else
                            {
                                groupid = data.Tables[0].Rows[0]["CGROUP_ID"].ToString();
                                if (members2.GetMemberDataByGroupID(groupid).Tables[0].Rows.Count > 0)
                                {
                                    flag3 = true;
                                }
                            }
                            if (flag3)
                            {
                                GroupMemberData data4 = new GroupMemberData();
                                flag4 = members2.LoadMembesByGroupNameIDandMobileNum(groupid, mobilenum).Tables[0].Rows.Count == 0;
                            }
                            else
                            {
                                flag4 = true;
                            }
                            string str14 = "";
                            if (flag4)
                            {
                                bool flag5 = false;
                                if (mobilenum.IndexOf("00852") == 0)
                                {
                                    string input = mobilenum.Substring(5);
                                    if (input.Length != 8)
                                    {
                                        str14 = "(電話號碼位數不正確)";
                                    }
                                    else if (Regex.Match(input, "[" + AppFlag.ValidPrefixes + "]{1}[0-9]{7}$").Success)
                                    {
                                        flag5 = true;
                                    }
                                    else
                                    {
                                        str14 = "(請輸入正確號碼)";
                                    }
                                }
                                else if (mobilenum.IndexOf("00") == 0)
                                {
                                    if (mobilenum.Length < 3)
                                    {
                                        str14 = "(電話號碼位數不正確)";
                                    }
                                    else
                                    {
                                        flag5 = true;
                                    }
                                }
                                else if (mobilenum.Length != 8)
                                {
                                    str14 = "(電話號碼位數不正確)";
                                }
                                else if (Regex.Match(mobilenum, "[" + AppFlag.ValidPrefixes + "]{1}[0-9]{7}$").Success)
                                {
                                    flag5 = true;
                                }
                                else
                                {
                                    str14 = "(請輸入正確號碼)";
                                }
                                if (flag5)
                                {
                                    DataRow row5 = data2.Tables["GROUP_MEMBER"].NewRow();
                                    row5["IITEM_NO"] = this.Percent + 2;
                                    row5["CGROUP_ID"] = groupid;
                                    row5["CMEMBER_NAME"] = str10;
                                    row5["CMOBILENO"] = mobilenum + "                         ";
                                    row5["CREATE_DATE"] = str13;
                                    string filterExpression = "CMOBILENO='" + mobilenum + "' and CGROUP_ID='" + groupid + "'";
                                    if (data2.Tables["GROUP_MEMBER"].Select(filterExpression).Length > 0)
                                    {
                                        num2++;
                                        if (num2 < 20)
                                        {
                                            string str20 = str8;
                                            string[] strArray6 = new string[] { str20, " ", (this.Percent + 2).ToString(), " ", groupname.Trim(), " ", str10.Trim(), " ", mobilenum, "<br>" };
                                            str8 = string.Concat(strArray6);
                                        }
                                        else if (num2 == 20)
                                        {
                                            str8 = str8 + "......etc";
                                        }
                                    }
                                    else
                                    {
                                        data2.Tables["GROUP_MEMBER"].Rows.Add(row5);
                                        num3++;
                                    }
                                }
                                else if (groupname.Trim() != "")
                                {
                                    string str21 = str7;
                                    string[] strArray7 = new string[] { str21, " ", (this.Percent + 2).ToString(), " ", groupname.Trim(), " ", str10.Trim(), " ", mobilenum, str14, "<br>" };
                                    str7 = string.Concat(strArray7);
                                }
                            }
                            else
                            {
                                num2++;
                                string str22 = str8;
                                string[] strArray8 = new string[] { str22, " ", (this.Percent + 2).ToString(), " ", groupname.Trim(), " ", str10.Trim(), " ", mobilenum, "<br>" };
                                str8 = string.Concat(strArray8);
                            }
                        }
                        this.State = 1;
                        this.Percent++;
                        groupname = "";
                        str10 = "";
                        mobilenum = "";
                    }//foreach
                     */
                    if (memberData.Tables[0].Rows.Count == 0)
                    {
                        flag2 = true;
                        count = 0;
                    }
                    else
                    {
                        Files.CicsWriteLog(string.Concat(new object[] { DateTime.Now.ToString("HH:mm:ss"), "  (", this.dolbUser, ")  Start Insert GROUP_MEMBER, Total: ", memberData.Tables[0].Rows.Count }));
                        if (members.InsertMember(memberData))
                        {
                            count = memberData.Tables[0].Rows.Count;
                            flag2 = true;
                            Files.CicsWriteLog(string.Concat(new object[] { DateTime.Now.ToString("HH:mm:ss"), "  (", this.dolbUser, ")  Finished Insert GROUP_MEMBER, Total: ", memberData.Tables[0].Rows.Count }));
                        }
                        else
                        {
                            Files.CicsWriteLog(string.Concat(new object[] { DateTime.Now.ToString("HH:mm:ss"), "  (", this.dolbUser, ")  Insert GROUP_MEMBER Break down, Total: ", memberData.Tables[0].Rows.Count }));
                            flag2 = false;
                        }
                    }
                    if (flag2)
                    {
                        if (strErrorMobile.Trim() == "" && strExistMobile.Trim() == "")
                        {
                            dolbUploadResult = FileName + "上傳成功,共上傳 " + count.ToString() + " 個!";
                        }
                        else if (strErrorMobile.Trim() != "" && strExistMobile.Trim() != "")
                        {
                            dolbUploadResult = FileName + "上傳成功,共上傳 " + count.ToString() + " 個,其中號碼：<br>" + strErrorMobile + " 錯誤！<br>" + strExistMobile + " 已存在！";
                        }
                        else if (strExistMobile.Trim() != "")
                        {
                            dolbUploadResult = FileName + "上傳成功,共上傳 " + count.ToString() + " 個,其中號碼：<br>" + strExistMobile + " 已存在！";
                        }
                        else
                        {
                            dolbUploadResult = FileName + "上傳成功,共上傳 " + count.ToString() + " 個,其中號碼：<br>" + strErrorMobile + " 錯誤！";
                        }
                        State = 2;
                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + dolbUploadResult.Replace("<br>", "|"));
                    }
                    else
                    {
                        ErrorTime = DateTime.Now;
                        Percent = 0;
                        State = 3;
                        dolbUploadResult = "上傳" + FileName + ",請稍后再試！";
                    }
                }
            }
            catch (Exception exception2)
            {
                flag2 = false;
                ErrorTime = DateTime.Now;
                Percent = 0;
                State = 3;
                dolbUploadResult = "上傳" + FileName + ",請稍后再試！";
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + dolbUploadResult.Replace("<br>", "|"));
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + fileName + "  Error: " + exception2.ToString());
            }
            finally
            { 
                string ACTION_REMARKS = dolbUploadResult.Replace("<br>", "|");
                if (ACTION_REMARKS.Length > 1000)
                {
                    ACTION_REMARKS = ACTION_REMARKS.Substring(0, 999);
                }
                else
                {
                    ACTION_REMARKS = ACTION_REMARKS;
                }
                if (flag2 == true)
                {
                    try
                    {
                        members.DeleteGroupMemberInfo(strGuid);
                        SmsActions smsaction = new SmsActions();
                        SmsActionData actiondata = smsaction.LoadActionByCondition(strcondtion, "UPLOAD");
                        string endtime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
                        DataRow actiondr = actiondata.Tables[SmsActionData.SMS_ACTIONS].Rows[0];
                        actiondr[SmsActionData.CSMS_ACTION_STATUS] = "完成";
                        actiondr[SmsActionData.ACTION_ENDTIME] = endtime;
                        actiondr[SmsActionData.ACTION_REMARKS] = "備註：" + ACTION_REMARKS;
                        smsaction.UpdateAction(actiondata);
                        strcondtionirecno = Convert.ToInt32(actiondr[SmsActionData.ISMS_IREC_NO]);
                    }
                    catch (Exception exp)
                    {
                        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + fileName + " Action,  Error: " + exp.ToString());
                    }
                }
                else
                {
                    try
                    {
                        members.DeleteGroupMemberInfo(strGuid);
                        SmsActions smsaction = new SmsActions();
                        SmsActionData actiondata = smsaction.LoadActionByCondition(strcondtion, "UPLOAD");
                        string endtime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
                        DataRow actiondr = actiondata.Tables[SmsActionData.SMS_ACTIONS].Rows[0];
                        actiondr[SmsActionData.CSMS_ACTION_STATUS] = "N/A";
                        actiondr[SmsActionData.ACTION_ENDTIME] = endtime;
                        actiondr[SmsActionData.ACTION_REMARKS] = "備註：" + ACTION_REMARKS;
                        smsaction.UpdateAction(actiondata);
                        strcondtionirecno = Convert.ToInt32(actiondr[SmsActionData.ISMS_IREC_NO]);
                    }
                    catch (Exception exp)
                    {
                        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + fileName + " Action,  Error: " + exp.ToString());
                    }
                }
                dataSet = null;
                FinishTime = DateTime.Now;
            }
        }

        //private void InsertUploadData()
        //{
        //    Thread.Sleep(1000);
        //    bool breadexcel = true;
        //    bool bResult = false;
        //    DataSet data = new DataSet();
        //    //string strUploadFolder = AppFlag.CentaSmsUploadFolder;
        //    string stsFileName = FileName;
        //    //string lstrFileNamePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + strUploadFolder + stsFileName;
        //    string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dobtnUploadMode + ";Extended Properties='Excel 8.0;IMEX=1';";
        //    OleDbConnection oledbConn = new OleDbConnection(connString);
        //    try
        //    {
        //        oledbConn.Open();
        //        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);
        //        OleDbDataAdapter oleda = new OleDbDataAdapter();
        //        oleda.SelectCommand = cmd;
        //        oleda.Fill(data);
        //        //					doload.FileName=stsFileName;
        //        //					doload .Total = data.Tables[0].Rows .Count;
        //        //FileName = stsFileName;
        //        Total = data.Tables[0].Rows.Count;
        //    }
        //    catch (Exception exp)
        //    {
        //        ErrorTime = DateTime.Now;
        //        Percent = 0;
        //        State = 3;
        //        breadexcel = false;
        //        dolbUploadResult = "請上傳正確格式文件!";
        //        //				this.lbUploadResult.Text = "上載失敗！";
        //        //				this.lbUploadResult.UpdateAfterCallBack = true;
        //        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + " Upload: " + stsFileName + "  Error: " + exp.ToString());
        //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  停止上載 " + stsFileName + " 組別！");
        //    }
        //    finally
        //    {
        //        oledbConn.Close();
        //    }
        //    try
        //    {
        //        if (breadexcel == true)
        //        {
        //            //string username = this.lbUser.Text.Trim();
        //            string username = dolbUser;
        //            string grouptype = "";
        //            string mode = "";
        //            //string create_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ");
        //            DataRow[] rows = data.Tables[0].Select();

        //            //if (rbGroupP.Checked)
        //            //grouptype=(dorbGroupP) ? "P" : "S";
        //            if (dorbGroupP)
        //            {
        //                grouptype = "P";
        //            }
        //            else
        //            {
        //                grouptype = "S";
        //            }
        //            //if (rbTypeAdd.Checked)
        //            //mode=(dorbTypeAdd) ? "A" : "C";
        //            if (dorbTypeAdd)
        //            {
        //                mode = "A";
        //            }
        //            else
        //            {
        //                mode = "C";
        //            }
        //            if (mode == "C")
        //            {
        //                foreach (DataRow dr in rows)
        //                {
        //                    string groupname = dr[0].ToString();
        //                    GroupMemberData mebmerdata = new GroupMemberData();
        //                    GroupMembers action1 = new GroupMembers();
        //                    mebmerdata = action1.GetMemberDataByGroupNameandOwner(groupname, username);
        //                    if (mebmerdata.Tables[0].Rows.Count > 0)
        //                    {
        //                        DataRow[] rows1 = mebmerdata.Tables[0].Select();
        //                        foreach (DataRow dr1 in rows1)
        //                        {
        //                            dr1.Delete();
        //                            //	action1.DeleteMember(mebmerdata);
        //                        }
        //                        action1.DeleteMember(mebmerdata);
        //                    }
        //                }
        //            }
        //            bool bcheckmember = false;
        //            bool noexistedmember = false;
        //            string strErrorMobile = "";
        //            string strExistMobile = "";
        //            int count = 0;
        //            int iexistconut = 0;
        //            Percent = 0; //other upload in the page 
        //            GroupMemberData member = new GroupMemberData();
        //            GroupMembers memberaction = new GroupMembers();
        //            int item_no = memberaction.GetNewItem_NO();
        //            foreach (DataRow dr in rows)
        //            {
        //                string create_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ");
        //                string groupname = dr[0].ToString() + "            " + "            " + "      ";
        //                string membername = dr[1].ToString() + "            " + "            " + "      ";
        //                string membermobile = dr[2].ToString();
        //                string groupid = "";
        //                if (groupname.Trim() != "")
        //                {
        //                    Groups action = new Groups();
        //                    GroupData groupdata = action.LoadGroupByGroupNameandOwner(groupname, username);
        //                    if (groupdata.Tables[0].Rows.Count == 0)
        //                    {
        //                        //insert group if have no groupname in groupinfo table 
        //                        groupid = action.GetNewGroupid(groupname, username);
        //                        DataRow groupdr = groupdata.Tables[GroupData.GROUP_INFO].NewRow();
        //                        groupdr[GroupData.CGROUP_ID] = groupid;
        //                        groupdr[GroupData.CGROUP_NAME] = groupname;
        //                        groupdr[GroupData.CGROUP_OWNER] = username;
        //                        groupdr[GroupData.CGROUP_TYPE] = grouptype;
        //                        groupdr[GroupData.CGROUP_PWD] = "";
        //                        groupdr[GroupData.CREATE_DATE] = create_date;
        //                        groupdata.Tables[GroupData.GROUP_INFO].Rows.Add(groupdr);
        //                        action.InsertGroup(groupdata);
        //                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + "Insert GROUP_INFO, CGROUP_ID: " + groupid + ",CGROUP_NAME: " + groupname.Trim());
        //                        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + "Filer  existent member by CGROUP_ID: " + groupid + ",CGROUP_NAME: " + groupname.Trim() + " and Ready to Insert GROUP_MEMBER");
        //                        bcheckmember = false;
        //                    }
        //                    else
        //                    {
        //                        groupid = groupdata.Tables[0].Rows[0][GroupData.CGROUP_ID].ToString();
        //                        if (memberaction.GetMemberDataByGroupID(groupid).Tables[0].Rows.Count > 0)
        //                        {
        //                            bcheckmember = true;
        //                        }
        //                    }
        //                    //if no groupname in groupinfo table no need to check member
        //                    if (bcheckmember)
        //                    {
        //                        //insert  Members
        //                        //GroupMembers memberaction = new GroupMembers();
        //                        GroupMemberData data1 = new GroupMemberData();
        //                        data1 = memberaction.LoadMembesByGroupNameIDandMobileNum(groupid, membermobile);
        //                        noexistedmember = data1.Tables[0].Rows.Count == 0;
        //                    }
        //                    else
        //                    {
        //                        noexistedmember = true;
        //                    }

        //                    if (noexistedmember)
        //                    {
        //                        Match m = Regex.Match(membermobile, "[" + AppFlag.ValidPrefixes + "]{1}[0-9]{7}$");
        //                        if (m.Success)
        //                        {
        //                            //GroupMemberData member = new GroupMemberData();
        //                            DataRow memberdr = member.Tables[GroupMemberData.GROUP_MEMBER].NewRow();
        //                            //memberdr[GroupMemberData.IITEM_NO] = memberaction.GetNewItem_NO();
        //                            memberdr[GroupMemberData.IITEM_NO] = item_no;
        //                            memberdr[GroupMemberData.CGROUP_ID] = groupid;
        //                            memberdr[GroupMemberData.CMEMBER_NAME] = membername;
        //                            memberdr[GroupMemberData.CMOBILENO] = membermobile;
        //                            memberdr[GroupMemberData.CREATE_DATE] = create_date;

        //                            string strSelect = "CMOBILENO='" + membermobile + "' and CGROUP_ID='" + groupid + "'";
        //                            if ((member.Tables[GroupMemberData.GROUP_MEMBER].Select(strSelect)).Length > 0)
        //                            {
        //                                iexistconut++;
        //                                if (iexistconut < 20)
        //                                {
        //                                    strExistMobile += groupname.Trim() + " " + membername.Trim() + " " + membermobile + "<br>";
        //                                }
        //                                else if (iexistconut == 20)
        //                                {
        //                                    strExistMobile = strExistMobile + "......etc";
        //                                }
        //                            }
        //                            else
        //                            {
        //                                member.Tables[GroupMemberData.GROUP_MEMBER].Rows.Add(memberdr);
        //                                item_no++;
        //                            }
        //                            //									if (memberaction.InsertMember(member))
        //                            //									{
        //                            //										count++;
        //                            //									}
        //                            //									else
        //                            //									{
        //                            //										bResult = false;
        //                            //									}
        //                        }
        //                        else
        //                        {
        //                            if (groupname.Trim() != "")
        //                            {
        //                                strErrorMobile += groupname.Trim() + " " + membername.Trim() + " " + membermobile + "<br>";
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        iexistconut++;
        //                        if (iexistconut < 20)
        //                        {
        //                            strExistMobile += groupname.Trim() + " " + membername.Trim() + " " + membermobile + "<br>";
        //                        }
        //                        else if (iexistconut == 20)
        //                        {
        //                            strExistMobile = strExistMobile + "......etc";
        //                        }
        //                    }
        //                }

        //                State = 1;
        //                Percent++;
        //                groupname = "";
        //                membername = "";
        //                membermobile = "";
        //            }

        //            // member =  SelectDistinct(member);
        //            if (member.Tables[0].Rows.Count == 0)
        //            {
        //                bResult = true;
        //                count = 0;
        //            }
        //            else
        //            {
        //                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + "Start Insert GROUP_MEMBER, Total: " + member.Tables[0].Rows.Count);
        //                if (memberaction.InsertMember(member))
        //                {
        //                    count = member.Tables[0].Rows.Count;
        //                    bResult = true;
        //                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + "Finished Insert GROUP_MEMBER, Total: " + member.Tables[0].Rows.Count);
        //                }
        //                else
        //                {
        //                    Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + "Insert GROUP_MEMBER Break down, Total: " + member.Tables[0].Rows.Count);
        //                    bResult = false;
        //                }
        //            }
        //            if (bResult == true)
        //            {
        //                if (strErrorMobile.Trim() == "" && strExistMobile.Trim() == "")
        //                {
        //                    dolbUploadResult = FileName + "上傳成功,共上傳 " + count.ToString() + " 個!";
        //                }
        //                else if (strErrorMobile.Trim() != "" && strExistMobile.Trim() != "")
        //                {
        //                    dolbUploadResult = FileName + "上傳成功,共上傳 " + count.ToString() + " 個,其中號碼：<br>" + strErrorMobile + " 錯誤！<br>" + strExistMobile + " 已存在！";
        //                }
        //                else if (strExistMobile.Trim() != "")
        //                {
        //                    dolbUploadResult = FileName + "上傳成功,共上傳 " + count.ToString() + " 個,其中號碼：<br>" + strExistMobile + " 已存在！";
        //                }
        //                else
        //                {
        //                    dolbUploadResult = FileName + "上傳成功,共上傳 " + count.ToString() + " 個,其中號碼：<br>" + strErrorMobile + " 錯誤！";
        //                }
        //                State = 2;
        //                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + dolbUploadResult.Replace("<br>", "|"));
        //            }
        //            else
        //            {
        //                ErrorTime = DateTime.Now;
        //                Percent = 0;
        //                State = 3;
        //                dolbUploadResult = "上傳" + FileName + ",請稍后再試！";
        //            }
        //            //Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + Context.User.Identity.Name + ")  " + lbUploadResult.Text);
        //            //lbUploadResult.UpdateAfterCallBack = true;
        //        }
        //    }
        //    catch (Exception exp)
        //    {
        //        bResult = false;
        //        ErrorTime = DateTime.Now;
        //        Percent = 0;
        //        State = 3;
        //        dolbUploadResult = "上傳" + FileName + ",請稍后再試！";
        //        //	lbUploadResult.UpdateAfterCallBack = true;
        //        Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + dolbUploadResult.Replace("<br>", "|"));
        //        Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + stsFileName + "  Error: " + exp.ToString());
        //    }
        //    finally
        //    {
        //        string ACTION_REMARKS = dolbUploadResult.Replace("<br>", "|");
        //        if (ACTION_REMARKS.Length > 1000)
        //        {
        //            ACTION_REMARKS = ACTION_REMARKS.Substring(0, 999);
        //        }
        //        else
        //        {
        //            ACTION_REMARKS = ACTION_REMARKS;
        //        }
        //        if (bResult == true)
        //        {
        //            try
        //            {
        //                SmsActions smsaction = new SmsActions();
        //                SmsActionData actiondata = smsaction.LoadActionByCondition(strcondtion);
        //                string endtime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
        //                DataRow actiondr = actiondata.Tables[SmsActionData.SMS_ACTIONS].Rows[0];
        //                actiondr[SmsActionData.CSMS_ACTION_STATUS] = "完成";
        //                actiondr[SmsActionData.ACTION_ENDTIME] = endtime;
        //                actiondr[SmsActionData.ACTION_REMARKS] = "備註：" + ACTION_REMARKS;
        //                smsaction.UpdateAction(actiondata);
        //                strcondtionirecno = Convert.ToInt32(actiondr[SmsActionData.ISMS_IREC_NO]);
        //            }
        //            catch (Exception exp)
        //            {
        //                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + stsFileName + " Action,  Error: " + exp.ToString());
        //            }
        //        }
        //        else
        //        {
        //            try
        //            {
        //                SmsActions smsaction = new SmsActions();
        //                SmsActionData actiondata = smsaction.LoadActionByCondition(strcondtion);
        //                string endtime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff");
        //                DataRow actiondr = actiondata.Tables[SmsActionData.SMS_ACTIONS].Rows[0];
        //                actiondr[SmsActionData.CSMS_ACTION_STATUS] = "N/A";
        //                actiondr[SmsActionData.ACTION_ENDTIME] = endtime;
        //                actiondr[SmsActionData.ACTION_REMARKS] = "備註：" + ACTION_REMARKS;
        //                smsaction.UpdateAction(actiondata);
        //                strcondtionirecno = Convert.ToInt32(actiondr[SmsActionData.ISMS_IREC_NO]);
        //            }
        //            catch (Exception exp)
        //            {
        //                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "  (" + dolbUser + ")  " + " Upload: " + stsFileName + " Action,  Error: " + exp.ToString());
        //            }
        //        }
        //        data = null;
        //        //data.Dispose();
        //        FinishTime = DateTime.Now;
        //        //	doload .Percent=0;  
        //    }
        //}

        public void runload()
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

