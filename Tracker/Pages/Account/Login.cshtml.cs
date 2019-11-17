using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tracker.Pages
{
    public class LoginModel : PageModel
    {
        public string Email { get; set; }
        public async Task<JsonResult> OnGetLogin(string Email, string Pwd)
        {
            if (await Globals.ConfigureSchoolDatabase(Email, Pwd))
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, Email)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return new JsonResult(true);
            }
            else
            {
                return new JsonResult(false);
            }
        }
    }

}
