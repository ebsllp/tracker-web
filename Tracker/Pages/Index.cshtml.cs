using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tracker.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
       public void OnGet()
        {

        }
    }
}
