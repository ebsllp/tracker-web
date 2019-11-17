using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Tracker.Pages
{
    [Authorize]
    public class YearGroupsModel : PageModel
    {
        public async Task<JsonResult> OnGetYearGroupsList()
        {
           return new JsonResult(await Globals.SchoolDatabase.YearGroups());
        }
        public async Task<JsonResult> OnGetSubjectsList(int yearGroupId)
        {
            return new JsonResult(await Globals.SchoolDatabase.Subjects(yearGroupId));
        }
        public async Task<JsonResult> OnGetClassId(int yearGroupId, int subjectId)
        {
            return new JsonResult(await Globals.SchoolDatabase.ClassId(yearGroupId, subjectId));
        }
        public async Task<JsonResult> OnGetTrackerPupils(string yearGroupCode, int classId)
        {
            return new JsonResult(await Globals.SchoolDatabase.TrackerPupils(yearGroupCode, classId));
        }
        public async Task<JsonResult> OnGetObjectivesList()
        {
            return new JsonResult(await Globals.SchoolDatabase.Objectives());
        }
    }
}
