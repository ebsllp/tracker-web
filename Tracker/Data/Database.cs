using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public async static Task<int> ClassId(int yearGroupId, int subjectId)
        {
            int Id = 0;
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("year_group_id", yearGroupId));
            pars.Add(new SqlParameter("subject_id", subjectId));
            using (var dt = await Select("sp_Class_Select", pars.ToArray()))
            {
                if (dt.Rows.Count > 0) Id = Convert.ToInt32(dt.Rows[0]["oid"]);
            }
            return Id;
        }
        public async static Task<DataTable> TrackerPupils(string yearGroupCode, int classId)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("year_group_code", yearGroupCode));
            pars.Add(new SqlParameter("class_id", classId));
            return await Select("sp_TrackerPupil_Select", pars.ToArray());
        }
        public async static Task<DataTable> Objectives()
        {
            return await Select("sp_Objectives_Select");
        }
    }
}