#pragma checksum "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5d7f5d6c3ef4e64d02bfc497293714db395e655"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_List), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/List.cshtml")]
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
#line 1 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\_ViewImports.cshtml"
using EvaraStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\_ViewImports.cshtml"
using EvaraStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5d7f5d6c3ef4e64d02bfc497293714db395e655", @"/Areas/Admin/Views/Users/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"669e997ab35ddd7e892713270ca160634508776a", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Users_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserOrderModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <style>\r\n        .alert {\r\n            position: fixed;\r\n            top: 0;\r\n            left: 0;\r\n            z-index: 9999;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral("\r\n");
#nullable restore
#line 14 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
 if (TempData["Success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible fade show\" role=\"alert\">\r\n        <div class=\"container\">\r\n            <strong>");
#nullable restore
#line 18 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
               Write(TempData["Success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n            <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n                <span aria-hidden=\"true\">&times;</span>\r\n            </button>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 24 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Users</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5d7f5d6c3ef4e64d02bfc497293714db395e6556805", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                    <li class=""breadcrumb-item active"">Users</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>

<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">

                <div class=""card"">
                    <div class=""card-body"">
                        <div id=""example1_wrapper"" class=""dataTables_wrapper dt-bootstrap4"">
                            <div class=""row"">
                                <div class=""col-sm-12"">
                                    <table id=""example1"" class=""table table-bordered table-striped dataTable dtr-inline"" role=""grid"" aria-describedby=""example1_info"">
                                        <thead>
                                            <tr role=""row"">
                                                <th class=""sorting sorting_asc"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-sort=""asce");
            WriteLiteral(@"nding"" aria-label=""Rendering engine: activate to sort column descending"">
                                                    UserName
                                                </th>
                                                <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""CSS grade: activate to sort column ascending"">
                                                    Email
                                                </th>
                                                <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""Engine version: activate to sort column ascending"">
                                                    Orders
                                                </th>
                                                <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""Engine version: activate to sort column ascending"">
                       ");
            WriteLiteral(@"                             Block User
                                                </th>
                                                <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""Engine version: activate to sort column ascending"">
                                                    Creation Date
                                                </th>
                                                <th class=""sorting"" tabindex=""0"" aria-controls=""example1"" rowspan=""1"" colspan=""1"" aria-label=""CSS grade: activate to sort column ascending"">
                                                    Actions
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
");
#nullable restore
#line 76 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                             foreach (var user in Model.lstUsers)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr class=\"odd\">\r\n                                                    <td class=\"dtr-control sorting_1\" tabindex=\"0\">");
#nullable restore
#line 79 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                                                                              Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 80 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                                   Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 81 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                                   Write(Model.lstOrder.Where(a => a.Billing.UserName == user.UserName).Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 82 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                                     if (user.LockoutEnd != null)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td>");
#nullable restore
#line 84 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                                       Write(user.LockoutEnd.Value.DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 85 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <td></td>\r\n");
#nullable restore
#line 89 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td>");
#nullable restore
#line 90 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                                   Write(user.CreationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5d7f5d6c3ef4e64d02bfc497293714db395e65514662", async() => {
                WriteLiteral("Block");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 92 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                                                               WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5d7f5d6c3ef4e64d02bfc497293714db395e65516998", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                                                                 WriteLiteral(user.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 96 "C:\Users\Blu-Ray\source\repos\EvaraStore\EvaraStore\Areas\Admin\Views\Users\List.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserOrderModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
