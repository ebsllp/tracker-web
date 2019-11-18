
namespace Tracker.Models
{
    public class UserDetails : User
    {
        public string Pwd { get; set; }
        public string Salt { get; set; }
        //public string PwdWithoutSalt
        //{
        //    get => Pwd.Substring(0, Pwd.IndexOf("|") - 1);
        //}
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
    }
}
