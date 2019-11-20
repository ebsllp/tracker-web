using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.BusinessLogic
{
    public class BLL_School
    {
        public async Task<Models.School> LoadSchool(string Email)
        {
            Models.School school = new Models.School();
            var dt = await Globals.MasterDatabase.SchoolSelect(Email);
            if (dt.Rows.Count > 0)
            {
                var r = dt.Rows[0];
                school.SchoolName = r["SchoolName"].ToString();
                school.DatabaseName = r["DatabaseName"].ToString();
                school.ServerName = r["ServerName"].ToString();
            }
            return school;
        }
    }
}
