using MVC_User.Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_User.DAL
{
    public class User_DAL
    {
        private string _ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["UserConnectionString"].ConnectionString; }
        }
        private OracleConnection conn;
        private OracleCommand cmd;
        public List<User> Show_all_users()
        {
            DataTable dataTable = new DataTable();
            List<User> list_of_users = new List<User>();
            using (conn = new OracleConnection(_ConnectionString))
            {
                conn.Open();
                try
                {
                    cmd = new OracleCommand("SELECT_ALL_USERS", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    OracleParameter p1 =
                      cmd.Parameters.Add("R_USER", OracleDbType.RefCursor);
                    p1.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();
                    // Construct an OracleDataReader from the REF CURSOR
                    OracleDataReader reader1 = ((OracleRefCursor)p1.Value).GetDataReader();
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    da.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
                foreach(DataRow dr in dataTable.Rows)
                {
                    list_of_users.Add(new User
                    {
                        U_ID = Convert.ToInt32(dr["U_ID"]),// or (int)dr["U_ID"]
                        U_NAME = dr["U_NAME"].ToString(),
                        U_ROLL = dr["U_ROLL"].ToString()
                    });
                }
            } 
            return list_of_users;
        }

        public void Save_User(User oUser)
        {
            using (conn = new OracleConnection(_ConnectionString))
            {
                conn.Open();
                try
                {
                    cmd = new OracleCommand("SP_USER", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@P_NAME", oUser.U_NAME);
                    cmd.Parameters.Add("@P_ROLL", oUser.U_ROLL);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
                Console.Read();
            }
        }
    }
}