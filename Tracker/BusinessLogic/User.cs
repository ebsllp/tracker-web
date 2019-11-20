using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.BusinessLogic
{
    public class BLL_User
    {
        public string HashPassword(string Pwd, string Salt)
        {
            var hash = KeyDerivation.Pbkdf2(
                                     password: Pwd,
                                     salt: Encoding.UTF8.GetBytes(Salt),
                                     prf: KeyDerivationPrf.HMACSHA512,
                                     iterationCount: 10000,
                                     numBytesRequested: 256 / 8);
 
            return Convert.ToBase64String(hash);
        }
        public string GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }
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
                user.Email = r["Email"].ToString();
            }
            return user;
        }
    }
}