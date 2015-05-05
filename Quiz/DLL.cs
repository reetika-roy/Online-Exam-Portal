using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Quiz
{
    public class DLL
    {
        string constring = System.Configuration.ConfigurationManager.ConnectionStrings["databasecon"].ConnectionString;

        public DataSet Getdataset(string query)
        {

            SqlConnection con = new SqlConnection(constring);
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                con.Open();
                dataAdapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public int InsertData(string query)
        {
            SqlConnection con = new SqlConnection(constring);
            try
            {
                SqlCommand cmd = null;
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
    }

}