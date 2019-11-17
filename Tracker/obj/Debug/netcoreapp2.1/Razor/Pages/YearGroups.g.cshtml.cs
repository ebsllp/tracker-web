#pragma checksum "C:\apps\Tracker\Tracker\Tracker\Pages\YearGroups.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95067b39076955551e2588a3708d7021a9ae51d7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Tracker.Pages.Pages_YearGroups), @"mvc.1.0.razor-page", @"/Pages/YearGroups.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/YearGroups.cshtml", typeof(Tracker.Pages.Pages_YearGroups), null)]
namespace Tracker.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\apps\Tracker\Tracker\Tracker\Pages\_ViewImports.cshtml"
using Tracker;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95067b39076955551e2588a3708d7021a9ae51d7", @"/Pages/YearGroups.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa3b49f3f8cb69681207b48a82c7c5a511939a27", @"/Pages/_ViewImports.cshtml")]
    public class Pages_YearGroups : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/YearGroups.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\apps\Tracker\Tracker\Tracker\Pages\YearGroups.cshtml"
  
    ViewData["Title"] = "Year Groups";

#line default
#line hidden
            BeginContext(79, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(98, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(104, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "465c7eb2db334a1390aba4ee3413d08e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(146, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(151, 1764, true);
            WriteLiteral(@"<style>
    .objectives {
        width: 150px;
    }
</style>
<div class=""container col-lg-12"" style=""        text-align: center"">
    <div id=""yearGroupContainer"" style=""        display: none"" class=""container"">
        <h2>Select Year Group</h2>
        <br />
        <div id=""yearGroups"" class=""row"">
            <table class=""table yearGroupTable"">
                <tbody></tbody>
            </table>
        </div>
    </div>
    <div id=""subjectContainer"" style=""        display: none"" class=""container"">
        <h2>Select Subject</h2>
        <br />
        <div id=""subjects"" class=""row"">
            <table class=""table subjectTable"">
                <tbody></tbody>
            </table>
        </div>
    </div>
    <div id=""pupilsContainer"" style=""        display: none"" class=""container"">
        <h2 id=""pupil-title"">Pupils</h2>
        <br />
        <div id=""pupils"" class=""row"">
            <table class=""table pupilTable"">
                <thead>
                    <tr>
            WriteLiteral(@"
                        <th data-sortable=""true"" data-field=""pupilName"">Pupil</th>
                        <th data-sortable=""true"" data-field=""formTeacher"">Teacher</th>
                        <th data-sortable=""true"" data-field=""monthsOld"">Months Old</th>
                        <th data-sortable=""true"" data-field=""endOfLastYearStatus"">End of Last Year</th>
                        <th data-sortable=""true"" data-field=""autumnStatus"">Summer</th>
                        <th data-sortable=""true"" data-field=""springStatus"">Spring</th>
                        <th data-sortable=""true"" data-field=""summerStatus"">Summer</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
</div>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<YearGroupsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YearGroupsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<YearGroupsModel>)PageContext?.ViewData;
        public YearGroupsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591