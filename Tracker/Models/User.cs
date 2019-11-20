
namespace Tracker.Models
{
    public class UserDetails : User
    {
        public string Pwd { get; set; }
        public string Salt { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
