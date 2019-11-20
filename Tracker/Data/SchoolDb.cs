using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace Tracker.Data
{
    public class SchooldDb: Database
    {
        public SchooldDb(string _server, string _database) : base(_server, _database)
        {

        }
        public async Task<DataTable> UserSelect(string Email)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("Email", Email));
            return await Select("sp_User_Select", pars.ToArray());
        }
        public async Task<DataTable> YearGroups()
        {
            return await Select("sp_YearGroup_Select");
        }
        public async Task<DataTable> Subjects(int yearGroupId)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("year_group_id", yearGroupId));
            return await Select("sp_Subject_Select", pars.ToArray());
        }
        public async Task<int> ClassId(int yearGroupId, int subjectId)
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
        public async Task<DataTable> TrackerPupils(string yearGroupCode, int classId)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("year_group_code", yearGroupCode));
            pars.Add(new SqlParameter("class_id", classId));
            return await Select("sp_TrackerPupil_Select", pars.ToArray());
        }
        public async Task<DataTable> Objectives()
        {
            return await Select("sp_Objectives_Select");
        }
    }
}