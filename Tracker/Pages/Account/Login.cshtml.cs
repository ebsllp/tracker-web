using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;
using Tracker.BusinessLogic;

namespace Tracker.Pages
{
    public class LoginModel : PageModel
    {
        public string Email { get; set; }
        public async Task<JsonResult> OnGetLogin(string Email, string Pwd)
        {
            var result = new JsonResult(false);
            var s = new BLL_School();
            var u = new BLL_User();
            var school = await s.LoadSchool(Email);

            if (school.SchoolName != null && school.SchoolName.Length > 0)
            {
                Globals.ConfigureSchoolDatabase(school.ServerName, school.DatabaseName);

                string encryptedEmail = Security.Encrypt(Email);
                var user = await u.LoadUser(encryptedEmail);

                if (user.UserId > 0)
                {
                    var auth = Security.HashWithSalt(Pwd, user.Salt);

                    if (auth == user.Pwd)
                    {
                        var identity = new ClaimsIdentity(new[] {
                                new Claim(ClaimTypes.Name, Email)
                            }, CookieAuthenticationDefaults.AuthenticationScheme);

                        var principal = new ClaimsPrincipal(identity);

                        var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        result = new JsonResult(true);
                    }
                }
            }
            return result;
        }
    }
}