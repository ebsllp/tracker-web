using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace Tracker.Data
{
    public class Database
    {
        public static string Error;
        private static string GetConnectionString()
        {
            return "Server=LAPTOP-JH4982VT\\EBSLLP;Database=Tracker;Trusted_Connection=true;";
        }

        public static async Task<DataTable> Select(string StoredProcedure, SqlParameter[] Parameters = null)
        {
            DataTable dt = new DataTable();
            Error = null;
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
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
        public async static Task<DataTable> YearGroups()
        {
            return await Select("sp_YearGroup_Select");
        }
        public async static Task<DataTable> Subjects(int yearGroupId)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("year_group_id", yearGroupId));
            return await Select("sp_Subject_Select", pars.ToArray());
        }
    }
}