#pragma checksum "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5b2d18b2854d7cf9366a5a61bb949cd087e6a62a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Attendances_Index), @"mvc.1.0.view", @"/Views/Attendances/Index.cshtml")]
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
#line 1 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\_ViewImports.cshtml"
using HumanResource;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\_ViewImports.cshtml"
using HumanResource.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b2d18b2854d7cf9366a5a61bb949cd087e6a62a", @"/Views/Attendances/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a9df7cfaae1220a4cbc4882db53be7339154fa8", @"/Views/_ViewImports.cshtml")]
    public class Views_Attendances_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HumanResource.Models.Attendance>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Attendances", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mr-1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteAttendance", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-lg-12"">
        <div class=""card"">
            <div class=""card-header"">
                <div class=""card-title-wrap bar-success"">
                    <h4 class=""card-title"">Attendance and departure request</h4>
                </div>
            </div>
            <div class=""card-body collapse show"">
                <div class=""card-block card-dashboard"">
                    <p class=""card-text"">
                        DataTables has most features enabled by default,
                        so all you need to do to use it with your own ables is to call the construction
                    </p>

                    <div class=""row"">
");
            WriteLiteral("                        <div class=\"col-lg-3\">\r\n                            <button id=\"addRow\" class=\"btn btn-primary mb-2\">\r\n                                <i class=\"ft-plus\"></i>&nbsp;\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b2d18b2854d7cf9366a5a61bb949cd087e6a62a6575", async() => {
                WriteLiteral("  Add new Employee");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </button>
                        </div>
                    </div>
                    <hr />
                    <table class=""table table-striped table-bordered zero-configuration mt-40"" id=""datatablesSimple"">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Id</th>
                                <th>Date </th>
                                <th>Attendance date</th>
                                <th>check-out date</th>

                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 70 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
                             foreach(var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 73 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
                               Write(item.Employee.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 74 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
                               Write(item.EmployeeSSN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                <td>");
#nullable restore
#line 76 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
                               Write(item.Date.ToString("d"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                <td>");
#nullable restore
#line 78 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
                               Write(item.StartTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 79 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
                               Write(item.EndTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b2d18b2854d7cf9366a5a61bb949cd087e6a62a10522", async() => {
                WriteLiteral("\r\n                                        <i class=\"icon-note\"></i> Edit\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 81 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
                                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5b2d18b2854d7cf9366a5a61bb949cd087e6a62a13244", async() => {
                WriteLiteral("\r\n                                        <span");
                BeginWriteAttribute("id", " id=\"", 4324, "\"", 4355, 2);
                WriteAttributeValue("", 4329, "ConfirmDeleteSpan_", 4329, 18, true);
#nullable restore
#line 87 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
WriteAttributeValue("", 4347, item.Id, 4347, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" style=""display:none"">
                                            <span>Are You sure You want to Delete</span>
                                            <button type=""submit"" class=""btn btn-danger mb-2"">Yes</button>
                                            <a href=""#"" class=""btn btn-primary mb-2""");
                BeginWriteAttribute("onclick", " onclick=\"", 4662, "\"", 4703, 3);
                WriteAttributeValue("", 4672, "ConfirmDelete(\'", 4672, 15, true);
#nullable restore
#line 90 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
WriteAttributeValue("", 4687, item.Id, 4687, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4695, "\',false)", 4695, 8, true);
                EndWriteAttribute();
                WriteLiteral(">No</a>\r\n                                        </span>\r\n                                        <span");
                BeginWriteAttribute("id", " id=\"", 4807, "\"", 4831, 2);
                WriteAttributeValue("", 4812, "DeleteSpan_", 4812, 11, true);
#nullable restore
#line 92 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
WriteAttributeValue("", 4823, item.Id, 4823, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                            <a href=\"#\" class=\"btn btn-danger\"");
                BeginWriteAttribute("onclick", " onclick=\"", 4913, "\"", 4953, 3);
                WriteAttributeValue("", 4923, "ConfirmDelete(\'", 4923, 15, true);
#nullable restore
#line 93 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
WriteAttributeValue("", 4938, item.Id, 4938, 8, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4946, "\',true)", 4946, 7, true);
                EndWriteAttribute();
                WriteLiteral(">Delete</a>\r\n                                        </span>\r\n\r\n\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 86 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
                                                                                                                     WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 101 "D:\Track\Sql Server\Project\HumanResource\HumanResource\Views\Attendances\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            \r\n                            \r\n                           \r\n                            \r\n                        </tbody>\r\n\r\n                    </table>\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HumanResource.Models.Attendance>> Html { get; private set; }
    }
}
#pragma warning restore 1591
