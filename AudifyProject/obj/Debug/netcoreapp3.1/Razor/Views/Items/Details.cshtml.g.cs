#pragma checksum "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee08053081ada9b0214f0ab91cef9608259865f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Items_Details), @"mvc.1.0.view", @"/Views/Items/Details.cshtml")]
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
#line 1 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\_ViewImports.cshtml"
using AudifyProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\_ViewImports.cshtml"
using AudifyProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee08053081ada9b0214f0ab91cef9608259865f9", @"/Views/Items/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc4a255485f6eab35232c4f28d193148a0e17171", @"/Views/_ViewImports.cshtml")]
    public class Views_Items_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AudifyProject.ViewModels.ItemViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formUploadChapter"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Chapters/UploadChapter"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""content-header"">
    <h2> Audio/Essay/Novel</h2>
</section>
<section class=""content"">
    <div class=""box box-default"">
        <div class=""box-header with-border"">
            <h3 class=""box-title""> Audio/Essay/Novel</h3>
        </div>
        <input type=""hidden"" id=""itemId""");
            BeginWriteAttribute("value", " value=\"", 441, "\"", 458, 1);
#nullable restore
#line 15 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
WriteAttributeValue("", 449, Model.Id, 449, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
        <div class=""box-body"">
            <div class=""row"">
                <div class=""col-5"">
                    <div class=""row"">
                        <table class=""table table-responsive table-bordered"">
                            <tr>
                                <td> ");
#nullable restore
#line 22 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <th> ");
#nullable restore
#line 23 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>");
#nullable restore
#line 26 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                               Write(Html.DisplayNameFor(model => model.CoverFileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td><img");
            BeginWriteAttribute("src", " src=\"", 1084, "\"", 1110, 1);
#nullable restore
#line 27 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
WriteAttributeValue("", 1090, Model.CoverFileName, 1090, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"80\" height=\"80\" class=\"img-thumbnail\" /></td>\r\n                            </tr>\r\n\r\n                            <tr>\r\n                                <td> ");
#nullable restore
#line 31 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                Write(Html.DisplayNameFor(model => model.TotalReview));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td> ");
#nullable restore
#line 32 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                Write(Html.DisplayFor(model => model.TotalReview));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td> ");
#nullable restore
#line 35 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                Write(Html.DisplayNameFor(model => model.TotalPage));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 36 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                               Write(Html.DisplayFor(model => model.TotalPage));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td> ");
#nullable restore
#line 39 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                Write(Html.DisplayNameFor(model => model.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                <td>");
#nullable restore
#line 40 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                               Write(Html.DisplayFor(model => model.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td> ");
#nullable restore
#line 43 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                Write(Html.DisplayNameFor(model => model.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td> ");
#nullable restore
#line 44 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                Write(Html.DisplayFor(model => model.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td> ");
#nullable restore
#line 47 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                Write(Html.DisplayNameFor(model => model.AuthorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 48 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                               Write(Html.DisplayFor(model => model.AuthorName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>Summary</td>\r\n                                <th>  ");
#nullable restore
#line 52 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                 Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                            </tr>

                        </table>


                    </div>
                </div>
                <div class=""col-1""></div>
                <div class=""col-6"">
                    <div class=""row"">
                        <h3");
            BeginWriteAttribute("class", " class=\"", 2882, "\"", 2890, 0);
            EndWriteAttribute();
            WriteLiteral(@">Audio Files</h3>
                        
                        <button type=""button"" class=""btn btn-primary pull-right"" data-toggle=""modal"" data-target=""#modal-primary"">
                            Add New Audio
                        </button>
                    </div>

                    <div class=""row"">
                        <table class=""table table-bordered"">
                            <thead>
                                <tr>
                                    <th>No</th>
                                    <th>Name</th>
                                    <th>File</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 80 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                   
                                    int i = 1;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                 foreach(var chapter in Model.Chapters)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 86 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 87 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                       Write(chapter.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 88 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                       Write(chapter.FileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 90 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                    i++;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class=""modal modal-info fade audio-modal"" id=""modal-primary"" style=""display: none;"" aria-hidden=""true"">
                <div class=""modal-dialog"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee08053081ada9b0214f0ab91cef9608259865f915808", async() => {
                WriteLiteral(@"
                        <div class=""modal-content"">
                            <div class=""modal-header"">
                                <h4 class=""modal-title"">New Audio file</h4>
                                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                    <span aria-hidden=""true"">×</span>
                                </button>
                            </div>
                            <div class=""modal-body"">

                                <div class=""section"">
                                    <div class=""row"">
                                        <input type=""hidden"" name=""ItemId"" id=""itemIdForDetail""");
                BeginWriteAttribute("value", " value=\"", 5337, "\"", 5354, 1);
#nullable restore
#line 111 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
WriteAttributeValue("", 5345, Model.Id, 5345, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                                        <div class=""col-10"">
                                            <div class=""form-group"">
                                                <label for=""chapterName"">Name</label>
                                                <input type=""text"" name=""Name"" class=""form-control"" id=""chapterName"" />
                                            </div>
                                            <div class=""form-group"">
                                                <label for=""audioFile"">Audio file</label>
                                                <input type=""file"" name=""File"" class=""form-control"" id=""audioFile"" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class=""modal-footer"">
                                <button type=""button"" class=""btn btn-");
                WriteLiteral(@"outline"" data-dismiss=""modal"">Close</button>
                                <button type=""submit"" id=""btnUploadAudio"" class=""btn btn-outline float-right"">Save changes</button>
                            </div>
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <!-- /.modal-content -->\r\n                </div>\r\n                <!-- /.modal-dialog -->\r\n            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee08053081ada9b0214f0ab91cef9608259865f920202", async() => {
                WriteLiteral("Edit");
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
#line 139 "D:\Trustcore Projects\C#\C# Projects\AudifyProject\AudifyProject\Views\Items\Details.cshtml"
                                       WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee08053081ada9b0214f0ab91cef9608259865f922382", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        </div>\r\n</section>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@" 
    <script>
        $(document).ready(function () {
          
           /*  $(""#btnUploadAudio"").click(function () {
                $(""#btnUploadAudio"").attr(""disabled"", true);
               var name = $(""#chapterName"").val();
                var fdata = new FormData();
                var fileUpload = $(""#audioFile"").get(0);
                var files = fileUpload.files;
                fdata.append(files[0].name, files[0]);
                fdata.append('Name', name);
                fdata.append('ItemId', $(""#itemId"").val());

                $.ajax({
                    type: ""POST"",
                    url: ""/Chapters/UploadChapter"",
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader(""XSRF-TOKEN"",
                            $('input:hidden[name=""__RequestVerificationToken""]').val());
                    },
                    data: fdata,
                    contentType: false,
                    processData: false,
               ");
                WriteLiteral(@"     async: true,
                    success: function (response) {
                        if (response.length == 0) {
                            alert('Something is wrong, Error Occur and Try Again');
                            $('.audio-modal').modal('hide');
                        }

                        else {

                            if (response != null && response.length > 0) {
                                alert(response);
                            }
                            $('.bs-salary-modal-lg').modal('hide');
                        }
                    },
                    error: function (e) {
                        $('#divPrint').html(e.responseText);
                    }
                });
                
            });
            */
        });
        
    </script>
");
            }
            );
            WriteLiteral("        \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AudifyProject.ViewModels.ItemViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591