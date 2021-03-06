#pragma checksum "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1e0cc99e9468d4fc80d93511f3cf2e1cf28f08e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_ShowDeveloperProjects), @"mvc.1.0.view", @"/Views/Project/ShowDeveloperProjects.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\_ViewImports.cshtml"
using FinalProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\_ViewImports.cshtml"
using FinalProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
using System.Reflection;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1e0cc99e9468d4fc80d93511f3cf2e1cf28f08e", @"/Views/Project/ShowDeveloperProjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1cd403b176af46e85ea812cbc8b3a7a1a86d4d8", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_ShowDeveloperProjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Project>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Your Projects</h1>\r\n\r\n<div class=\"container\">\r\n    <div class=\"table-responsive\">\r\n        <table class=\"table table-bordered table-hover table-dark\" id=\"dataTable\" width=\"100%\" cellspacing=\"0\">\r\n\r\n");
            WriteLiteral(@"                <thead>
                    <tr>
                        <th scope=""col"">Title</th>
                        <th scope=""col"">Description</th>
                        <th scope=""col"">Team Leader</th>
                        <th scope=""col"">Status</th>


                    </tr>
                </thead>
                <tbody>

");
#nullable restore
#line 28 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                     foreach (var project in (List<Project>)ViewBag.projects)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 31 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                           Write(project.ProjectTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 32 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                           Write(project.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 33 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                            Write(project.TeamLeader.FirstName+" "+project.TeamLeader.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 34 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                             if (project.Status == HelperClass.Status.PendingApproval)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    ");
#nullable restore
#line 37 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                                Write(project.Status.GetType().GetMember(project.Status.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n");
#nullable restore
#line 39 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>");
#nullable restore
#line 42 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                               Write(project.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 43 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 45 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                             if (User.Identity.IsAuthenticated && User.IsInRole("Developer"))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td>\r\n                                    <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1958, "\"", 2009, 2);
            WriteAttributeValue("", 1965, "/Task/ShowProjectTasks?projectId=", 1965, 33, true);
#nullable restore
#line 48 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
WriteAttributeValue("", 1998, project.ID, 1998, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sprints</a>\r\n                                </td>\r\n");
#nullable restore
#line 50 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 52 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowDeveloperProjects.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'#dataTable\').DataTable();\r\n    });\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Project> Html { get; private set; }
    }
}
#pragma warning restore 1591
