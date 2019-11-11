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
        public async Task<JsonResult> OnGetClassId(int yearGroupId, int subjectId)
        {
            return new JsonResult(await Data.Database.ClassId(yearGroupId, subjectId));
        }
        public async Task<JsonResult> OnGetTrackerPupils(string yearGroupCode, int classId)
        {
            return new JsonResult(await Data.Database.TrackerPupils(yearGroupCode, classId));
        }
    }
}
