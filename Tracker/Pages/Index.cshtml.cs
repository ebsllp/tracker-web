using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Tracker.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
       public async Task<JsonResult> OnGetLogOut()
        {
            await HttpContext.SignOutAsync();
            return new JsonResult(true);
        }
    }
}
