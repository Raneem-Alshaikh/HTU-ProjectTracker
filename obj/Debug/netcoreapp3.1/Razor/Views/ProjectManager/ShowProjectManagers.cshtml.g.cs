#pragma checksum "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14a8fdb5e2084510df48d7ee7c1551a7b07803e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProjectManager_ShowProjectManagers), @"mvc.1.0.view", @"/Views/ProjectManager/ShowProjectManagers.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14a8fdb5e2084510df48d7ee7c1551a7b07803e2", @"/Views/ProjectManager/ShowProjectManagers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1cd403b176af46e85ea812cbc8b3a7a1a86d4d8", @"/Views/_ViewImports.cshtml")]
    public class Views_ProjectManager_ShowProjectManagers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h1>Project Managers</h1>

<div class=""container"">
    <table class=""table table-hover table-dark"">
        <thead>
            <tr>
                <th scope=""col"">First Name</th>
                <th scope=""col"">Last Name</th>
                <th scope=""col"">Email</th>
                <th scope=""col"">User Name</th>
                <th scope=""col"">Age</th>


            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 24 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"
             foreach (var projectManager in (List<ProjectManager>)ViewBag.ProjectManagers)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("             <tr>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"
               Write(projectManager.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"
               Write(projectManager.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"
               Write(projectManager.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"
               Write(projectManager.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"
               Write(projectManager.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 33 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"
                 if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1109, "\"", 1190, 2);
            WriteAttributeValue("", 1116, "/ProjectManager/ShowEditProjectManager?projectManagerId=", 1116, 56, true);
#nullable restore
#line 36 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"
WriteAttributeValue("", 1172, projectManager.Id, 1172, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\r\n                        <a class=\"btn btn-danger\" onclick=\"return confirm(\'Are you sure?\');\"");
            BeginWriteAttribute("href", " href=\"", 1294, "\"", 1359, 2);
            WriteAttributeValue("", 1301, "/ProjectManager/DeleteProjectManager?Id=", 1301, 40, true);
#nullable restore
#line 37 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"
WriteAttributeValue("", 1341, projectManager.Id, 1341, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n                    </td>\r\n");
#nullable restore
#line 39 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("             </tr>\r\n");
#nullable restore
#line 41 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\ProjectManager\ShowProjectManagers.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <div>\r\n        <a class=\"btn btn-primary\" href=\"/ProjectManager/Create\">New Project Manager</a>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
