namespace CENTASMS.BLL
{
    using CENTASMS;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using System.Drawing;
    using FirebirdSql.Data.FirebirdClient;
    using System.Threading;

    public class GroupMembers : IDisposable
    {
        public const string CGROUP_ID_PARM = "@CGROUP_ID";
        public const string CMEMBER_NAME_PARM = "@CMEMBER_NAME";
        public const string CMOBILENO_PARM = "@CMOBILENO";
        public const string CREATE_DATE_PARM = "@CREATE_DATE";
        private FbCommand deleteCommand;
        private FbDataAdapter dsCommand = new FbDataAdapter();
        public const string IITEM_NO_PARM = "@IITEM_NO";
        private FbCommand insertCommand;
        private FbCommand loadCommand;
        private FbCommand updateCommand;

        public GroupMembers()
        {
            this.dsCommand.SelectCommand = new FbCommand();
            this.dsCommand.SelectCommand.Connection = new FbConnection(AppFlag.CENTASMSINTEConn);
            this.dsCommand.TableMappings.Add("Table", "GROUP_MEMBER");
        }

        public bool DeleteMember(GroupMemberData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.DeleteCommand = this.GetDeleteCommand();
                this.dsCommand.Update(data, "GROUP_MEMBER");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   GroupMemberData  " + exception.ToString());
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Catch exception, Delete GroupMemberData");
            }
            if (data.HasErrors)
            {
                data.Tables["GROUP_MEMBER"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
            return true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && (this.dsCommand != null))
            {
                if (this.dsCommand.SelectCommand != null)
                {
                    if (this.dsCommand.SelectCommand.Connection != null)
                    {
                        this.dsCommand.SelectCommand.Connection.Dispose();
                    }
                    this.dsCommand.SelectCommand.Dispose();
                }
                this.dsCommand.Dispose();
                this.dsCommand = null;
            }
        }

        private FbCommand GetDeleteCommand()
        {
            if (this.deleteCommand == null)
            {
                string cmdText = "DELETE FROM  GROUP_MEMBER   where  CGROUP_ID=? and CMOBILENO=? ";
                this.deleteCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.deleteCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.deleteCommand.Parameters;
                parameters.Add(new FbParameter("@CGROUP_ID", FbDbType.VarChar, 11));
                parameters.Add(new FbParameter("@CMOBILENO", FbDbType.VarChar, 15));
                parameters["@CGROUP_ID"].SourceColumn = "CGROUP_ID";
                parameters["@CGROUP_ID"].SourceVersion = DataRowVersion.Original;
                parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
                parameters["@CMOBILENO"].SourceVersion = DataRowVersion.Original;
            }
            return this.deleteCommand;
        }

        private FbCommand GetInsertCommand()
        {
            if (this.insertCommand == null)
            {
                string cmdText = "INSERT INTO  GROUP_MEMBER  ( IITEM_NO,CGROUP_ID ,  CMEMBER_NAME ,  CMOBILENO , CREATE_DATE ) VALUES (?,?,?,?,?)";
                this.insertCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new FbParameter("@IITEM_NO", FbDbType.Integer));
                parameters.Add(new FbParameter("@CGROUP_ID", FbDbType.VarChar, 11));
                parameters.Add(new FbParameter("@CMEMBER_NAME", FbDbType.VarChar, 30));
                parameters.Add(new FbParameter("@CMOBILENO", FbDbType.VarChar, 15));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters["@IITEM_NO"].SourceColumn = "IITEM_NO";
                parameters["@CGROUP_ID"].SourceColumn = "CGROUP_ID";
                parameters["@CMEMBER_NAME"].SourceColumn = "CMEMBER_NAME";
                parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
                parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
            }
            return this.insertCommand;
        }

        private FbCommand GetLoadCommand()
        {
            if (this.loadCommand == null)
            {
                this.loadCommand = new FbCommand();
                this.loadCommand.Connection = new FbConnection(AppFlag.CENTASMSINTEConn);
                this.loadCommand.CommandType = CommandType.Text;
            }
            return this.loadCommand;
        }

        public GroupMemberData GetMemberDatabyAdminatMemberPage(string username, string type)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            if (type == "P")
            {
                this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER    WHERE CGROUP_ID IN (SELECT CGROUP_ID FROM GROUP_INFO WHERE CGROUP_OWNER= '" + username + "' and CGROUP_TYPE='" + type + "' )  order by IITEM_NO asc";
            }
            else
            {
                this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER    WHERE CGROUP_ID IN (SELECT CGROUP_ID FROM GROUP_INFO WHERE CGROUP_OWNER= '" + username + "' OR  CGROUP_TYPE='" + type + "')  order by IITEM_NO asc";
            }
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupMemberData GetMemberDatabyAllGroupAndOwner(string username, string type)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            if (type == "S")
            {
                this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER    WHERE CGROUP_ID IN (SELECT CGROUP_ID FROM GROUP_INFO WHERE  CGROUP_TYPE='" + type + "')  order by IITEM_NO asc";
            }
            else
            {
                this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER    WHERE CGROUP_ID IN (SELECT CGROUP_ID FROM GROUP_INFO WHERE CGROUP_OWNER= '" + username + "' AND CGROUP_TYPE='" + type + "')  order by IITEM_NO asc";
            }
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public string GetFirstByGroupID(string groupid)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER    WHERE CGROUP_ID= '" + groupid + "' order by IITEM_NO asc";
            try
            {
                this.dsCommand.Fill(dataSet);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   GroupMemberData.GetFirstByGroupID  " + exception.ToString());
            }
            finally
            {
                if (this.dsCommand.SelectCommand.Connection.State == ConnectionState.Open)
                {
                    this.dsCommand.SelectCommand.Connection.Close();
                }
            }
            return (dataSet.Tables[0].Rows.Count > 0) ? dataSet.Tables[0].Rows[0]["CMOBILENO"].ToString() : "";
        }

        public GroupMemberData GetMemberDataByGroupID(string groupid)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER    WHERE CGROUP_ID= '" + groupid + "' order by IITEM_NO asc";
            try
            {
                this.dsCommand.Fill(dataSet);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   GroupMemberData.GetMemberDataByGroupID  " + exception.ToString());
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Catch exception GetMemberDataByGroupID CGROUP_ID: " + groupid.Trim());
                //Thread.Sleep(0xea60);
            }
            finally
            {
                if (this.dsCommand.SelectCommand.Connection.State == ConnectionState.Open)
                {
                    this.dsCommand.SelectCommand.Connection.Close();
                }
            }
            return dataSet;
        }

        public GroupMemberData GetMemberDataByGroupName(string groupname)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER    WHERE CGROUP_Name= '" + groupname + "' order by IITEM_NO asc";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupMemberData GetMemberDataByGroupNameandOwner(string groupname, string username)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = " SELECT * from GROUP_MEMBER a inner join GROUP_INFO b ON a.CGROUP_ID=b.CGROUP_ID WHERE CGROUP_NAME='" + groupname + "' and CGROUP_OWNER ='" + username + "'  order by IITEM_NO asc";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupMemberData GetMembersDataBy(string strCondition)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER   " + strCondition + " order by IITEM_NO asc ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public int GetNewItem_NO()
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            SmsMsgHistData dataSet = new SmsMsgHistData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "select  max(IITEM_NO) ITEM_NO from GROUP_MEMBER ";
            this.dsCommand.Fill(dataSet);
            if (dataSet.Tables["GROUP_MEMBER"].Rows[0][0] == DBNull.Value)
            {
                return 1;
            }
            return (Convert.ToInt32(dataSet.Tables["GROUP_MEMBER"].Rows[0][0]) + 1);
        }

        private FbCommand GetUpdateCommand()
        {
            if (this.updateCommand == null)
            {
                string cmdText = "UPDATE   GROUP_MEMBER SET   CGROUP_ID=? ,  CMEMBER_NAME=? ,  CMOBILENO=?  ,CREATE_DATE=? where CGROUP_ID=? and CMOBILENO=? ";
                this.updateCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.updateCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.updateCommand.Parameters;
                parameters.Add(new FbParameter("@CGROUP_ID", FbDbType.VarChar, 11));
                parameters.Add(new FbParameter("@CMEMBER_NAME", FbDbType.VarChar, 30));
                parameters.Add(new FbParameter("@CMOBILENO", FbDbType.VarChar, 15));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters.Add(new FbParameter("@OLDCGROUP_ID_PARM", FbDbType.VarChar, 11));
                parameters.Add(new FbParameter("@OLDCMEMBER_NO_PARM", FbDbType.VarChar, 15));
                parameters["@CGROUP_ID"].SourceColumn = "CGROUP_ID";
                parameters["@CMEMBER_NAME"].SourceColumn = "CMEMBER_NAME";
                parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
                parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
                parameters["@OLDCGROUP_ID_PARM"].SourceColumn = "CGROUP_ID";
                parameters["@OLDCGROUP_ID_PARM"].SourceVersion = DataRowVersion.Original;
                parameters["@OLDCMEMBER_NO_PARM"].SourceColumn = "CMOBILENO";
                parameters["@OLDCMEMBER_NO_PARM"].SourceVersion = DataRowVersion.Original;
            }
            return this.updateCommand;
        }

        public bool InsertMember(GroupMemberData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.InsertCommand = this.GetInsertCommand();
                this.dsCommand.Update(data, "GROUP_MEMBER");
            }
            catch (Exception exception)
            {
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   GroupMemberData  " + exception.ToString());
                //Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Catch exception, Insert GroupMemberData");
            }
            if (data.HasErrors)
            {
                data.Tables["GROUP_MEMBER"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
            return true;
        }

        public GroupMemberData LoadMembersByGroupType(string type)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER    WHERE CGROUP_TYPE= '" + type + "' order by IITEM_NO asc ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupMemberData LoadMembesByGroupIDAndMemberNo(string groupid, string memberno)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER    WHERE CGROUP_ID= '" + groupid + "' and CMOBILENO='" + memberno + "' ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupMemberData LoadMembesByGroupNameandOwnerandMemberName(string groupname, string owner, string membername)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = " SELECT * from GROUP_MEMBER a inner join GROUP_INFO b ON a.CGROUP_ID=b.CGROUP_ID WHERE CGROUP_NAME='" + groupname + "' and CGROUP_OWNER ='" + owner + "' and CMEMBER_NAME='" + membername + "'";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupMemberData LoadMembesByGroupNameIDandMobileNum(string groupid, string mobilenum)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = " SELECT * from GROUP_MEMBER WHERE CGROUP_ID='" + groupid + "' and CMOBILENO ='" + mobilenum + "'";
            try
            {
                this.dsCommand.Fill(dataSet);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   GroupMemberData.LoadMembesByGroupNameIDandMobileNum  " + exception.ToString());
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Catch exception, CGROUP_ID: " + groupid.Trim() + ",CMOBILENO: " + mobilenum.Trim());
                //Thread.Sleep(0xea60);
            }
            finally
            {
                if (this.dsCommand.SelectCommand.Connection.State == ConnectionState.Open)
                {
                    this.dsCommand.SelectCommand.Connection.Close();
                }
            }
            return dataSet;
        }

        public GroupMemberData LoadMembesByMemberbyAll(string groupid, string membername, string no)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupMemberData dataSet = new GroupMemberData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_MEMBER    WHERE   CMEMBER_NAME='" + membername + "' and  CMOBILENO='" + no + "' and CGROUP_ID='" + groupid + "'";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public bool UpdateMember(GroupMemberData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.UpdateCommand = this.GetUpdateCommand();
                this.dsCommand.Update(data, "GROUP_MEMBER");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   GroupMemberData  " + exception.ToString());
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Catch exception, Update GroupMemberData");
            }
            if (data.HasErrors)
            {
                data.Tables["GROUP_MEMBER"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
            return true;
        }


        public int InsertMemberInfo(DataSet data)
        {
            // bool result = false;
            string insertString = "INSERT INTO GROUP_MEMBER_INFO (GUID, IITEM_NO, CGROUP_NAME,CMEMBER_NAME, CMOBILENO) VALUES (@GUID, @IITEM_NO,@CGROUP_NAME, @CMEMBER_NAME,@CMOBILENO)";
            using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
            {
                FbDataAdapter adapter = new FbDataAdapter();
                adapter.InsertCommand = new FbCommand(insertString, connection);
                adapter.InsertCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = adapter.InsertCommand.Parameters;
                parameters.Add(new FbParameter("@GUID", FbDbType.VarChar, 32));
                parameters.Add(new FbParameter("@IITEM_NO", FbDbType.Integer));
                parameters.Add(new FbParameter("@CGROUP_NAME", FbDbType.VarChar, 30));
                parameters.Add(new FbParameter("@CMEMBER_NAME", FbDbType.VarChar, 30));
                parameters.Add(new FbParameter("@CMOBILENO", FbDbType.VarChar, 15));
                parameters["@GUID"].SourceColumn = "GUID";
                parameters["@IITEM_NO"].SourceColumn = "IITEM_NO";
                parameters["@CGROUP_NAME"].SourceColumn = "CGROUP_NAME";
                parameters["@CMEMBER_NAME"].SourceColumn = "CMEMBER_NAME";
                parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
                connection.Open();

                int count = adapter.Update(data, "GROUP_MEMBER_INFO");
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss ") + " Execute sql:" + insertString); 
                return count;

                //this.insertCommand = new FbCommand(insertString, new FbConnection(AppFlag.CENTASMSINTEConn));
                //this.insertCommand.CommandType = CommandType.Text;
                //FbParameterCollection parameters = this.insertCommand.Parameters;
                //parameters.Add(new FbParameter("@IITEM_NO", FbDbType.Integer));
                //parameters.Add(new FbParameter("@CGROUP_ID", FbDbType.VarChar, 11));
                //parameters.Add(new FbParameter("@CMEMBER_NAME", FbDbType.VarChar, 30));
                //parameters.Add(new FbParameter("@CMOBILENO", FbDbType.VarChar, 15));
                //parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                //parameters["@IITEM_NO"].SourceColumn = "IITEM_NO";
                //parameters["@CGROUP_ID"].SourceColumn = "CGROUP_ID";
                //parameters["@CMEMBER_NAME"].SourceColumn = "CMEMBER_NAME";
                //parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
                //parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";



                //string sql = "INSERT INTO [User] (UserId, UserName, Password, Sex, Age) VALUES (@UserId, @UserName, @Password, @Sex, @Age)";
                //SqlCommand cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.Add("@UserId", SqlDbType.Int, 8, "UserId");
                //cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 20, "UserName");
                //cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "Password");
                //cmd.Parameters.Add("@Sex", SqlDbType.Bit, 8, "Sex");
                //cmd.Parameters.Add("@Age", SqlDbType.Int, 8, "Age");
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //adapter.InsertCommand = cmd;
                //adapter.Update(dt);  

            }


            //return result;
        }

        public bool MobileExistIn(String groupName, string mobileNo, string guid)
        {
            bool bResult = false;
            string selectString = "select count(*) from  GROUP_MEMBER_INFO where  CGROUP_NAME='" + groupName + "' and CMOBILENO='" + mobileNo + "' and GUID='" + guid + "'";
            using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
            {
                FbCommand cmd = new FbCommand(selectString, connection);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 1)
                {
                    bResult = true;
                }
            }
            return bResult;
        }

        public DataSet GroupMemberInfo(string guid)
        {
            DataSet dataSet = new DataSet();
            //string selectString = "select * from   GROUP_MEMBER_INFO WHERE CMEMBER_NAME in (select MAX(CMEMBER_NAME) from GROUP_MEMBER_INFO group by CMOBILENO)  AND GUID='" + guid + "'";
            string selectString = "select * from   GROUP_MEMBER_INFO WHERE GUID='" + guid + "'";
             
            using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
            {
                FbDataAdapter adapter = new FbDataAdapter();
                adapter.SelectCommand = new FbCommand(selectString, connection);
                adapter.SelectCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = adapter.SelectCommand.Parameters;
                parameters.Add(new FbParameter("@GUID", FbDbType.VarChar, 32));
                parameters["@GUID"].SourceColumn = "GUID";
                connection.Open();
                adapter.Fill(dataSet, "GROUP_MEMBER_INFO");
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss ") + " Execute sql:" + selectString); 
                return dataSet;

            }
        }
        public DataSet GroupMemberRepeatInfo(string guid)
        {
            DataSet dataSet = new DataSet();
            // string selectString = "select * from GROUP_MEMBER_INFO where CMOBILENO in (select   CMOBILENO from   GROUP_MEMBER_INFO where GUID='"+guid +"' group by   CMOBILENO having count(CMOBILENO) > 1 ) and  GUID='"+guid +"'";
            string selectString = "SELECT * FROM GROUP_MEMBER_INFO a WHERE ((SELECT COUNT(*) FROM GROUP_MEMBER_INFO WHERE CMOBILENO = a.CMOBILENO and   GUID='" + guid + "') > 1 )  and  GUID='" + guid + "' ORDER BY CMOBILENO DESC";
             
            using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
            {
                FbDataAdapter adapter = new FbDataAdapter();
                adapter.SelectCommand = new FbCommand(selectString, connection);
                adapter.SelectCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = adapter.SelectCommand.Parameters;
                parameters.Add(new FbParameter("@GUID", FbDbType.VarChar, 32));
                parameters["@GUID"].SourceColumn = "GUID";
                connection.Open();
                adapter.Fill(dataSet, "GROUP_MEMBER_INFO");
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss ") + " Execute sql:" + selectString); 
                return dataSet;

            }
        }

        public bool DeleteGroupMemberInfo(string guid)
        {
            bool bResult = false;
            string deleteString = "delete from  GROUP_MEMBER_INFO where  GUID='" + guid + "'";
            using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
            {
                FbCommand cmd = new FbCommand(deleteString, connection);
                connection.Open();
                int count = (int)cmd.ExecuteNonQuery();
                if (count > -1)
                {
                    bResult = true;
                }
            }
            Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss ") + " Execute sql:" + deleteString + "\r\n");
            return bResult;
        }
        public int DeleteGroupMemberRepeatInfobyNO(string no, string id)
        {
            int count = 0;
            FbCommand command = new FbCommand();
            FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn);

            try
            {
                command.Connection = connection;
                connection.Open();
                string str = "DELETE FROM GROUP_MEMBER_INFO WHERE GUID='" + no + "' and IITEM_NO ='" + id + "'";
                command.CommandText = str;
                count = command.ExecuteNonQuery();
                connection.Close();
            }
            catch (FbException exception)
            {

            }

            return count;
        }


        public int DeleteGroupMemberRepeatInfobyNOs(string no,string ids)
        {
            int count = 0;
            FbCommand command = new FbCommand();
            FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn);
           
            try
            {
                command.Connection = connection;
                connection.Open();
                string str = "DELETE FROM GROUP_MEMBER_INFO WHERE GUID='" + no + "' and IITEM_NO in ('" + ids + "')" ;
                command.CommandText = str;
               count=  command.ExecuteNonQuery();
                connection.Close();  
             }
            catch (FbException exception)
            {

             }

            return count;
        }

        public int DeleteGroupMemberRepeatInfo(DataSet data)
        { 
            string cmdText = "DELETE FROM  GROUP_MEMBER_INFO   where GUID=? and CGROUP_NAME=? and CMOBILENO=? ";
            using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
            {
                FbDataAdapter adapter = new FbDataAdapter();
                adapter.DeleteCommand = new FbCommand(cmdText, connection);
                adapter.DeleteCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = adapter.DeleteCommand.Parameters;
                parameters.Add(new FbParameter("@GUID", FbDbType.VarChar, 32));
                parameters.Add(new FbParameter("@CGROUP_NAME", FbDbType.VarChar, 30));
                parameters.Add(new FbParameter("@CMOBILENO", FbDbType.VarChar, 25));
                parameters["@GUID"].SourceColumn = "GUID";
                parameters["@GUID"].SourceVersion = DataRowVersion.Original;
                parameters["@CGROUP_NAME"].SourceColumn = "CGROUP_NAME";
                parameters["@CGROUP_NAME"].SourceVersion = DataRowVersion.Original;
                parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
                parameters["@CMOBILENO"].SourceVersion = DataRowVersion.Original;
                int count = adapter.Update(data, "GROUP_MEMBER_INFO");
                data.AcceptChanges();
                return 0;
            }

            //string insertString = "delete from GROUP_MEMBER_INFO where (GUID=@GUID and CGROUP_NAME=@CGROUP_NAME and CMOBILENO=@CMOBILENO)";
            //using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
            //{
            //    FbDataAdapter adapter = new FbDataAdapter();
            //    adapter.DeleteCommand = new FbCommand(insertString, connection);
            //    adapter.DeleteCommand.CommandType = CommandType.Text;
            //    FbParameterCollection parameters = adapter.DeleteCommand.Parameters;
            //    parameters.Add(new FbParameter("@GUID", FbDbType.VarChar, 32)); 
            //    parameters.Add(new FbParameter("@CGROUP_NAME", FbDbType.VarChar, 30)); 
            //    parameters.Add(new FbParameter("@CMOBILENO", FbDbType.VarChar, 15));
            //    parameters["@GUID"].SourceColumn = "GUID"; 
            //    parameters["@CGROUP_NAME"].SourceColumn = "CGROUP_NAME"; 
            //    parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
            //    connection.Open();

            //    int count = adapter.Update(data, "GROUP_MEMBER_INFO");
            //    table.Select(null, null, DataViewRowState.Deleted)); 
            //    int count = adapter.Update(data.Tables [0].Select(null, null, DataViewRowState.Deleted));
            //    data.AcceptChanges();
            //    return count;

            //string deleteString = "DELETE FROM  GROUP_MEMBER_INFO   where   GUID=? and CGROUP_NAME=? and CMOBILENO=?";
            //using (FbConnection connection = new FbConnection(AppFlag.CENTASMSINTEConn))
            //{
            //    FbDataAdapter adapter = new FbDataAdapter();
            //    FbCommand cmd=new FbCommand(deleteString, connection);
            //   // adapter.DeleteCommand = new FbCommand(deleteString, connection);
            //    cmd.CommandType = CommandType.Text;
            //    FbParameterCollection parameters = cmd.Parameters;
            //    parameters.Add(new FbParameter("@GUID", FbDbType.VarChar, 32));
            //    parameters.Add(new FbParameter("@CGROUP_NAME", FbDbType.VarChar, 30));
            //    parameters.Add(new FbParameter("@CMOBILENO", FbDbType.VarChar, 25));
            //    parameters["@GUID"].SourceColumn = "GUID";
            //    parameters["@GUID"].SourceVersion = DataRowVersion.Original;
            //    parameters["@CGROUP_NAME"].SourceColumn = "CGROUP_NAME";
            //    parameters["@CGROUP_NAME"].SourceVersion = DataRowVersion.Original;
            //    parameters["@CMOBILENO"].SourceColumn = "CMOBILENO";
            //    parameters["@CMOBILENO"].SourceVersion = DataRowVersion.Original;
            //    adapter.DeleteCommand = cmd;
            //    connection.Open();

            //     int count=adapter.Update(data, "GROUP_MEMBER_INFO");
            //    data.AcceptChanges();
            //    return 0;

            //}
        }

    }
}

