#pragma checksum "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "44870d3f77e6dd0aac7ed3879ba8c6bc5a4298e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Project_ShowTeamLeaderProjects), @"mvc.1.0.view", @"/Views/Project/ShowTeamLeaderProjects.cshtml")]
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
#line 6 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
using System.Reflection;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44870d3f77e6dd0aac7ed3879ba8c6bc5a4298e0", @"/Views/Project/ShowTeamLeaderProjects.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1cd403b176af46e85ea812cbc8b3a7a1a86d4d8", @"/Views/_ViewImports.cshtml")]
    public class Views_Project_ShowTeamLeaderProjects : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Project>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<h1>Your Projects</h1>

<div class=""container"">
    <table class=""table table-hover table-dark"">
        <thead>
            <tr>
                <th scope=""col"">Title</th>
                <th scope=""col"">Description</th>
                <th scope=""col"">Project Manager</th>
                <th scope=""col"">Developers</th>
                <th scope=""col"">Status</th>


            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 26 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
             foreach (var project in (List<Project>)ViewBag.projects)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
               Write(project.ProjectTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
               Write(project.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                Write(project.projectManager.FirstName+" "+project.projectManager.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n");
#nullable restore
#line 33 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                     foreach (var developer in project.ProjectsDevelopers)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>");
#nullable restore
#line 35 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                          Write(developer.Developer.FirstName + " " + developer.Developer.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br />\r\n");
#nullable restore
#line 36 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n");
#nullable restore
#line 38 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                 if (project.Status == HelperClass.Status.PendingApproval)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 42 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                    Write(project.Status.GetType().GetMember(project.Status.ToString()).First().GetCustomAttribute<DisplayAttribute>().GetName());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 44 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        ");
#nullable restore
#line 48 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                   Write(project.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n");
#nullable restore
#line 50 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                     if (User.Identity.IsAuthenticated && User.IsInRole("TeamLeader"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <td>\r\n                            <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1898, "\"", 1953, 2);
            WriteAttributeValue("", 1905, "/Sprint/ShowProjectSprints?projectId=", 1905, 37, true);
#nullable restore
#line 54 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
WriteAttributeValue("", 1942, project.ID, 1942, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sprints</a>\r\n                        </td>\r\n");
#nullable restore
#line 56 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 58 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\Project\ShowTeamLeaderProjects.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n</div>\r\n\r\n\r\n");
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
