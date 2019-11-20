using System;
using System.Threading.Tasks;

namespace Tracker.BusinessLogic
{
    public class BLL_User
    {
      
        public async Task<Models.UserDetails> LoadUser(string Email)
        {
            Models.UserDetails user = new Models.UserDetails();
            var dt = await Globals.SchoolDatabase.UserSelect(Email);
            if (dt.Rows.Count > 0)
            {
                var r = dt.Rows[0];
                user.UserId = Convert.ToInt32(r["UserId"]);
                user.Pwd = r["Pwd"].ToString();
                user.Salt = r["Salt"].ToString();
                user.Email = Security.Decrypt(r["Email"].ToString());
            }
            return user;
        }
    }
}