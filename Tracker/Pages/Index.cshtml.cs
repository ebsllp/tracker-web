using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tracker.Pages
{
    public class IndexModel : PageModel
    {
        public async Task<JsonResult> OnGetYearGroups()
        {
           return new JsonResult(await Data.Database.YearGroups());
        }
        public async Task<JsonResult> OnGetSubjects(int yearGroupId)
        {
            return new JsonResult(await Data.Database.Subjects(yearGroupId));
        }
    }
}
