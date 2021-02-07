#pragma checksum "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3b5afca8b526f814780908fc940c7b8153d1d81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TeamLeader_ShowTeamLeaders), @"mvc.1.0.view", @"/Views/TeamLeader/ShowTeamLeaders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3b5afca8b526f814780908fc940c7b8153d1d81", @"/Views/TeamLeader/ShowTeamLeaders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1cd403b176af46e85ea812cbc8b3a7a1a86d4d8", @"/Views/_ViewImports.cshtml")]
    public class Views_TeamLeader_ShowTeamLeaders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<h1>Team Leaders</h1>

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
#line 24 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
             foreach (var teamLeader in (List<TeamLeader>)ViewBag.TeamLeaders)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 27 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
               Write(teamLeader.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
               Write(teamLeader.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
               Write(teamLeader.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
               Write(teamLeader.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 31 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
               Write(teamLeader.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 32 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
                 if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>\r\n                        <a class=\"btn btn-info\"");
            BeginWriteAttribute("href", " href=\"", 1072, "\"", 1137, 2);
            WriteAttributeValue("", 1079, "/TeamLeader/ShowEditTeamLeader?teamLeaderId=", 1079, 44, true);
#nullable restore
#line 36 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
WriteAttributeValue("", 1123, teamLeader.Id, 1123, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\r\n                        <a class=\"btn btn-danger\" onclick=\"return confirm(\'Are you sure?\');\"");
            BeginWriteAttribute("href", " href=\"", 1241, "\"", 1294, 2);
            WriteAttributeValue("", 1248, "/TeamLeader/DeleteTeamLeader?Id=", 1248, 32, true);
#nullable restore
#line 37 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
WriteAttributeValue("", 1280, teamLeader.Id, 1280, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n                    </td>\r\n");
#nullable restore
#line 39 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tr>\r\n");
#nullable restore
#line 41 "C:\Users\User\Desktop\HTU training\ASP.net\FinalProject\FinalProject\Views\TeamLeader\ShowTeamLeaders.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    <div>\r\n        <a class=\"btn btn-primary\" href=\"/TeamLeader/Create\">New Team Leader</a>\r\n    </div>\r\n</div>");
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
