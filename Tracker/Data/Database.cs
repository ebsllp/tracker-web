using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Tracker.Data
{
    public class Database
    {
        public string Error { get; set; }
        private string ConnectionString { get; set; }
        public Database(string _server, string _database)
        {
            ConnectionString = "Server=" + _server + "; Database=" + _database + ";Trusted_Connection=true;";
        }

        public async Task<DataTable> Select(string StoredProcedure, SqlParameter[] Parameters = null)
        {
            DataTable dt = new DataTable();
            Error = null;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedure, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        await con.OpenAsync();

                        if (Parameters != null)
                        {
                            cmd.Parameters.AddRange(Parameters);
                        }
                        using (SqlDataAdapter a = new SqlDataAdapter(cmd))
                        {
                            a.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }

            return dt;
        }
    }
}