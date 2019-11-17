
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Tracker
{
    public static class Globals
    {
        public static IConfiguration Config;
        private static IConfigurationSection AppSettings
        {
            get => Config.GetSection("AppSettings");
        }
        public static string ServerName
        {
            get => AppSettings.GetValue<string>("ServerName");
        }
        public static string MasterDatabaseName
        {
            get => AppSettings.GetValue<string>("MasterDatabase");
        }
        public static Data.MasterDb MasterDatabase { get; internal set; }
        public static Data.SchooldDb SchoolDatabase { get; internal set; }
        public static void ConfigureMasterDatabase()
        {
            MasterDatabase = new Data.MasterDb(ServerName, MasterDatabaseName);           
        }
        public async static Task<bool> ConfigureSchoolDatabase(string Email, string Pwd)
        {
            bool Success = false;

            var dt = await MasterDatabase.UserSelect(Email, Pwd);
            if (dt.Rows.Count > 0)
            {
                string SchoolServerName = dt.Rows[0]["ServerName"].ToString();
                string SchoolDatabaseName = dt.Rows[0]["DatabaseName"].ToString();
                if (SchoolServerName.Length == 0) SchoolServerName = ServerName;

                SchoolDatabase = new Data.SchooldDb(SchoolServerName, SchoolDatabaseName);
                Success = true;
            }
            return Success;
        }
    }
}
