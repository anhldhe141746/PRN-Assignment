#pragma checksum "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bcb63f26a18d6b2b28d073000309239ee70e48a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Addcategory), @"mvc.1.0.view", @"/Views/Home/Addcategory.cshtml")]
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
#line 1 "C:\Users\leduc\source\repos\Assignment\Views\_ViewImports.cshtml"
using Assignment;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\leduc\source\repos\Assignment\Views\_ViewImports.cshtml"
using Assignment.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0bcb63f26a18d6b2b28d073000309239ee70e48a", @"/Views/Home/Addcategory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12290ae8b54fdba546f13d1190a2a2d1619f6758", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Addcategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Assignment.Models.TblCategroy>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
  
    ViewBag.Title = "Addcategory";
    Layout = "~/Views/Shared/Layout2.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1 style=\"text-align:center;background-color:#808080;color:white\">Add category</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <hr />\r\n        ");
#nullable restore
#line 14 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 16 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
       Write(Html.LabelFor(model => model.CatName, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
#nullable restore
#line 18 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
           Write(Html.EditorFor(model => model.CatName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 19 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
           Write(Html.ValidationMessageFor(model => model.CatName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
        </div>


        <div class=""form-group"">
            <div class=""col-md-offset-2 col-md-10"">
                <input type=""submit"" value=""Create"" class=""btn btn-default"" />
            </div>
        </div>
    </div>
");
#nullable restore
#line 30 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<hr />

<div style=""overflow:scroll"">

    <table class=""table table-responsive"">
        <thead>
            <tr>
                <th>ID</th>
                <th>NAME</th>
                <th>Room Name</th>
            </tr>

        </thead>

        <tbody>
");
#nullable restore
#line 46 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
             foreach (var item in ViewData["list"] as List<Assignment.Models.TblCategroy>)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\r\n                    <td>");
#nullable restore
#line 50 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
                   Write(item.CatId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    <td>");
#nullable restore
#line 52 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
                   Write(item.CatName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 53 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
                   Write(item.CatEncyptedstring);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 56 "C:\Users\leduc\source\repos\Assignment\Views\Home\Addcategory.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n        </tbody>\r\n\r\n\r\n\r\n    </table>\r\n\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Assignment.Models.TblCategroy> Html { get; private set; }
    }
}
#pragma warning restore 1591
