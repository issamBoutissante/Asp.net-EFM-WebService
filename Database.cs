using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ServiceWeb
{
    internal class Database
    {
        internal static string conString = ConfigurationManager.ConnectionStrings["GestionStagiaire"].ConnectionString;
        //internal static SqlConnection Connection = new SqlConnection(conString);
        internal static void Execute(Action<SqlConnection> instrunctions,Action Success=null,Action<string> Error=null)
        {
            SqlConnection Connection = new SqlConnection(conString);
            Connection.Open();
            try
            {
                instrunctions(Connection);
                Success?.Invoke();
            }catch(Exception e)
            {
                Error?.Invoke(e.Message);
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}