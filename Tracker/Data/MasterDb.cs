using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Extensions.Options;

namespace Tracker.Data
{
    public class MasterDb: Database 
    {
        public MasterDb(string _server, string _database): base(_server, _database)
        {

        }
        public async Task<DataTable> UserSelect(string Email, string Pwd)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter("Email", Email));
            pars.Add(new SqlParameter("Pwd", Pwd));
            return await Select("sp_User_Select", pars.ToArray());
        }
    }
}