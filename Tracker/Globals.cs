
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
        public static void ConfigureSchoolDatabase(string _ServerName, string _DatabaseName)
        {
            if (_ServerName.Length == 0) _ServerName = ServerName;
            SchoolDatabase = new Data.SchooldDb(_ServerName, _DatabaseName);
        }
    }
}
