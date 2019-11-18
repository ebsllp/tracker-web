
namespace Tracker.Models
{
    public class Authentication
    {
        public string Pwd { get; set; }
        public string Salt { get; set; }
        public string FullPassword
        {
            get => Salt + "|" + Pwd;
        }
    }
}
