namespace CENTASMS.BLL
{
    using CENTASMS;
    using CENTASMS.DAL;
    using System;
    using System.Data;
    using FirebirdSql.Data.FirebirdClient;
    using System.Threading;

    public class Groups : IDisposable
    {
        public const string CGROUP_ID_PARM = "@CGROUP_ID";
        public const string CGROUP_NAME_PARM = "@CGROUP_NAME";
        public const string CGROUP_OWNER_PARM = "@CGROUP_OWNER";
        public const string CGROUP_PWD_PARM = "@CGROUP_PWD_PARM";
        public const string CGROUP_TYPE_PARM = "@CGROUP_TYPE";
        public const string CREATE_DATE_PARM = "@CREATE_DATE";
        private FbCommand deleteCommand;
        private FbDataAdapter dsCommand = new FbDataAdapter();
        private FbCommand insertCommand;
        private FbCommand loadCommand;
        private FbCommand updateCommand;

        public Groups()
        {
            this.dsCommand.SelectCommand = new FbCommand();
            this.dsCommand.SelectCommand.Connection = new FbConnection(AppFlag.CENTASMSINTEConn);
            this.dsCommand.TableMappings.Add("Table", "GROUP_INFO");
        }

        public bool BoolExistShareGroupName(string groupname)
        {
            bool flag = false;
            if (new Groups().LoadGroupByName(groupname).Tables[0].Rows.Count == 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool DeleteGroup(GroupData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.DeleteCommand = this.GetDeleteCommand();
                this.dsCommand.Update(data, "GROUP_INFO");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   GroupData  " + exception.ToString());
            }
            if (data.HasErrors)
            {
                data.Tables["GROUP_INFO"].GetErrors()[0].ClearErrors();
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

        public static bool ExtraGroupPwd(string pwd)
        {
            bool flag = false;
            if (new Groups().LoadGroupByPWD(pwd).Tables[0].Rows.Count == 0)
            {
                flag = true;
            }
            return flag;
        }

        private FbCommand GetDeleteCommand()
        {
            if (this.deleteCommand == null)
            {
                string cmdText = "DELETE FROM  GROUP_INFO   where CGROUP_ID=? ";
                this.deleteCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.deleteCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.deleteCommand.Parameters;
                parameters.Add(new FbParameter("@CGROUP_ID", FbDbType.VarChar, 11));
                parameters["@CGROUP_ID"].SourceColumn = "CGROUP_ID";
                parameters["@CGROUP_ID"].SourceVersion = DataRowVersion.Original;
            }
            return this.deleteCommand;
        }

        public GroupData GetGroupDataBy(string strCondition)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupData dataSet = new GroupData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO   " + strCondition + "  order by create_date desc ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupData GetGroupDatabyAdminatMemberPage(string owner, string type)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupData dataSet = new GroupData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            if (type == "S")
            {
                this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO where CGROUP_OWNER='" + owner + "' or CGROUP_TYPE='" + type + "'  order by  cgroup_id asc  ";
            }
            else
            {
                this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO where CGROUP_OWNER='" + owner + "' and  CGROUP_TYPE='" + type + "'  order by  cgroup_id asc ";
            }
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupData GetGroupDataByOwner(string owner)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupData dataSet = new GroupData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO where CGROUP_OWNER='" + owner + "'  order by create_date desc ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupData GetGroupDatabyOwnerAndType(string owner, string type)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupData dataSet = new GroupData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            if (type == "S")
            {
                this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO where CGROUP_TYPE='" + type + "'  order by cgroup_id asc ";
            }
            else
            {
                this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO where CGROUP_OWNER='" + owner + "' and  CGROUP_TYPE='" + type + "'  order by cgroup_id asc ";
            }
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupData GetGroupDataByType(string type)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupData dataSet = new GroupData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO where CGROUP_TYPE='" + type + "'  order by cgroup_id asc ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public static string GetGroupNamebyGroupID(string id)
        {
            return new Groups().LoadGroupByID(id).Tables[0].Rows[0]["CGROUP_NAME"].ToString();
        }

        private static string GetIDNO(string strno)
        {
            while (strno.Length < 10)
            {
                strno = "0" + strno;
            }
            return strno;
        }

        private FbCommand GetInsertCommand()
        {
            if (this.insertCommand == null)
            {
                string cmdText = "INSERT INTO  GROUP_INFO  (CGROUP_ID, CGROUP_NAME , CGROUP_OWNER,CGROUP_TYPE,CGROUP_PWD, CREATE_DATE  ) VALUES (?,?,?,?,?,?)";
                this.insertCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.insertCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.insertCommand.Parameters;
                parameters.Add(new FbParameter("@CGROUP_ID", FbDbType.VarChar, 11));
                parameters.Add(new FbParameter("@CGROUP_NAME", FbDbType.VarChar, 30));
                parameters.Add(new FbParameter("@CGROUP_OWNER", FbDbType.VarChar, 0x15));
                parameters.Add(new FbParameter("@CGROUP_TYPE", FbDbType.VarChar, 1));
                parameters.Add(new FbParameter("@CGROUP_PWD_PARM", FbDbType.VarChar, 11));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters["@CGROUP_ID"].SourceColumn = "CGROUP_ID";
                parameters["@CGROUP_NAME"].SourceColumn = "CGROUP_NAME";
                parameters["@CGROUP_OWNER"].SourceColumn = "CGROUP_OWNER";
                parameters["@CGROUP_TYPE"].SourceColumn = "CGROUP_TYPE";
                parameters["@CGROUP_PWD_PARM"].SourceColumn = "CGROUP_PWD";
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

        public string GetNewGroupid(string groupname, string username)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            DataSet dataSet = new DataSet();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "select  max(CGROUP_ID) CGROUP_ID from GROUP_INFO order by CGROUP_ID desc";
            try
            {
                this.dsCommand.Fill(dataSet);
                if (dataSet.Tables["GROUP_INFO"].Rows[0][0] == DBNull.Value)
                {
                    return "G0000000001";
                }
                int num = Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString().Trim().Substring(1, 10)) + 1;
                return (dataSet.Tables[0].Rows[0][0].ToString().Trim().Substring(0, 1) + GetIDNO(num.ToString()));
            }
            catch (Exception exception)
            {
                string str2 = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   Groups.GetNewGroupid  " + exception.ToString());
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Catch exception, GetNewGroupid,CGROUP_NAME: " + groupname.Trim() + ",CGROUP_OWNER: " + username.Trim());
                //Thread.Sleep(0xea60);
            }
            finally
            {
                if (this.dsCommand.SelectCommand.Connection.State == ConnectionState.Open)
                {
                    this.dsCommand.SelectCommand.Connection.Close();
                }
            }
            return "";
        }

        public static string GetOwnerbyGroupID(string id)
        {
            return new Groups().LoadGroupByID(id).Tables[0].Rows[0]["CGROUP_OWNER"].ToString();
        }

        public static string GetOwnerbyGroupname(string name)
        {
            return new Groups().LoadGroupByName(name).Tables[0].Rows[0]["CGROUP_OWNER"].ToString();
        }

        private FbCommand GetUpdateCommand()
        {
            if (this.updateCommand == null)
            {
                string cmdText = "UPDATE   GROUP_INFO SET   CGROUP_NAME=?  , CGROUP_OWNER=?, CGROUP_TYPE=?, CGROUP_PWD=?, CREATE_DATE=? where CGROUP_ID=?";
                this.updateCommand = new FbCommand(cmdText, new FbConnection(AppFlag.CENTASMSINTEConn));
                this.updateCommand.CommandType = CommandType.Text;
                FbParameterCollection parameters = this.updateCommand.Parameters;
                parameters.Add(new FbParameter("@CGROUP_NAME", FbDbType.VarChar, 30));
                parameters.Add(new FbParameter("@CGROUP_OWNER", FbDbType.VarChar, 0x15));
                parameters.Add(new FbParameter("@CGROUP_TYPE", FbDbType.VarChar, 1));
                parameters.Add(new FbParameter("@CGROUP_PWD_PARM", FbDbType.VarChar, 11));
                parameters.Add(new FbParameter("@CREATE_DATE", FbDbType.Date));
                parameters.Add(new FbParameter("@OLDCGROUP_ID_PARM", FbDbType.VarChar, 11));
                parameters["@CGROUP_NAME"].SourceColumn = "CGROUP_NAME";
                parameters["@CGROUP_OWNER"].SourceColumn = "CGROUP_OWNER";
                parameters["@CGROUP_TYPE"].SourceColumn = "CGROUP_TYPE";
                parameters["@CGROUP_PWD_PARM"].SourceColumn = "CGROUP_PWD";
                parameters["@CREATE_DATE"].SourceColumn = "CREATE_DATE";
                parameters["@OLDCGROUP_ID_PARM"].SourceColumn = "CGROUP_ID";
                parameters["@OLDCGROUP_ID_PARM"].SourceVersion = DataRowVersion.Original;
            }
            return this.updateCommand;
        }

        public bool InsertGroup(GroupData data)
        {
            GroupData data2;
            using (Groups groups = new Groups())
            {
                data2 = groups.LoadGroupByID(data.Tables[0].Rows[0][0].ToString());
            }
            if (data2.Tables["GROUP_INFO"].Rows.Count == 1)
            {
                return false;
            }
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.InsertCommand = this.GetInsertCommand();
                this.dsCommand.Update(data, "GROUP_INFO");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + " Insert GroupData  " + exception.ToString());
            }
            if (data.HasErrors)
            {
                data.Tables["GROUP_INFO"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
            return true;
        }

        public GroupData LoadGroupByGroupNameandOwner(string groupname, string username)
        {
            GroupData dataSet = new GroupData();
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.SelectCommand = this.GetLoadCommand();
                this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO    WHERE CGROUP_NAME= '" + groupname + "' and CGROUP_OWNER='" + username + "'  order by create_date desc ";
                this.dsCommand.Fill(dataSet);
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + "   GroupData.LoadGroupByGroupNameandOwner  " + exception.ToString());
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Catch exception, CGROUP_NAME: " + groupname.Trim() + ",CGROUP_OWNER: " + username.Trim());
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

        public GroupData LoadGroupByID(string id)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupData dataSet = new GroupData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO    WHERE CGROUP_ID= '" + id + "'  order by create_date desc ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupData LoadGroupByName(string name)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupData dataSet = new GroupData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO    WHERE CGROUP_NAME= '" + name + "'  order by create_date desc ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public GroupData LoadGroupByPWD(string pwd)
        {
            if (this.dsCommand == null)
            {
                throw new ObjectDisposedException(base.GetType().FullName);
            }
            GroupData dataSet = new GroupData();
            this.dsCommand.SelectCommand = this.GetLoadCommand();
            this.dsCommand.SelectCommand.CommandText = "SELECT * from GROUP_INFO    WHERE CGROUP_PWD= '" + pwd + "'  order by create_date desc ";
            this.dsCommand.Fill(dataSet);
            return dataSet;
        }

        public bool UpdateGroup(GroupData data)
        {
            try
            {
                if (this.dsCommand == null)
                {
                    throw new ObjectDisposedException(base.GetType().FullName);
                }
                this.dsCommand.UpdateCommand = this.GetUpdateCommand();
                this.dsCommand.Update(data, "GROUP_INFO");
            }
            catch (Exception exception)
            {
                string str = exception.ToString();
                Files.CicsWriteError(DateTime.Now.ToString("HH:mm:ss") + " Update GroupData  " + exception.ToString());
                Files.CicsWriteLog(DateTime.Now.ToString("HH:mm:ss") + " Catch exception, Update GroupData");
            }
            if (data.HasErrors)
            {
                data.Tables["GROUP_INFO"].GetErrors()[0].ClearErrors();
                return false;
            }
            data.AcceptChanges();
            return true;
        }
    }
}

