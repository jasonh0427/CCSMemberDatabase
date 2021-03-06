#pragma checksum "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e389094863defe4b4102dd1bebd79f9df0eea6c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Family), @"mvc.1.0.view", @"/Views/Home/Family.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Family.cshtml", typeof(AspNetCore.Views_Home_Family))]
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
#line 1 "D:\Cambridge\CCS\MemberDatabase\Views\_ViewImports.cshtml"
using MemberDatabase;

#line default
#line hidden
#line 2 "D:\Cambridge\CCS\MemberDatabase\Views\_ViewImports.cshtml"
using MemberDatabase.Models;

#line default
#line hidden
#line 1 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
using MemberDatabase.Data;

#line default
#line hidden
#line 2 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e389094863defe4b4102dd1bebd79f9df0eea6c2", @"/Views/Home/Family.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7ccda0b74fbaea60719f91a12a0985b178ef052", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Family : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddMembers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(66, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(170, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
  
    ViewData["Title"] = "My Family";

#line default
#line hidden
            BeginContext(217, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(222, 17, false);
#line 10 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(239, 15, true);
            WriteLiteral("</h2>\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(272, 227, true);
                WriteLiteral("\r\n    <script>\r\n        function withdrawRequest(reqId, index)\r\n        {\r\n            $.ajax({\r\n                method: \"POST\",\r\n                data: {\r\n                    i: reqId\r\n                },\r\n                url: \'");
                EndContext();
                BeginContext(500, 40, false);
#line 24 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                 Write(Url.Action("RemoveRelationship", "Home"));

#line default
#line hidden
                EndContext();
                BeginContext(540, 561, true);
                WriteLiteral(@"',
                success: function (ret){
                    var element = document.getElementById('req_' + index);
                    element.remove();
                    alert(ret);
                },
                error: function (){
                    alert(""Some error occurred"");
                }
            });
        }

        function confirmRequest(reqId, index)
        {
            $.ajax({
                method: ""POST"",
                data: {
                    i: reqId
                },
                url: '");
                EndContext();
                BeginContext(1102, 40, false);
#line 43 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                 Write(Url.Action("ConfirmRelationship","Home"));

#line default
#line hidden
                EndContext();
                BeginContext(1142, 752, true);
                WriteLiteral(@"',
                success: function (ret){
                    var element = document.getElementById('req_' + index);
                    element.remove();
                    if(ret.type == 1) {
                        document.getElementById('spouse').innerText = ret.source;
                    }
                    else{
                        document.getElementById('parents').innerText += ret.source;
                        document.getElementById('parents').innerText += ret.otherParent;
                    }
                    alert(""Successful."");
                },
                error: function (){
                    alert(""Some error occurred"");
                }
            });
        }

    </script>


");
                EndContext();
            }
            );
            BeginContext(1897, 10, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
            EndContext();
#line 71 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
  
    var self = await UserManager.GetUserAsync(User);


#line default
#line hidden
            BeginContext(1967, 69, true);
            WriteLiteral("    <div>\r\n        <h3>My parents are:</h3>\r\n        <p id=\"parents\">");
            EndContext();
            BeginContext(2037, 15, false);
#line 76 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                   Write(ViewBag.Parent1);

#line default
#line hidden
            EndContext();
            BeginContext(2052, 8, true);
            WriteLiteral(" &nbsp; ");
            EndContext();
            BeginContext(2061, 15, false);
#line 76 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                                           Write(ViewBag.Parent2);

#line default
#line hidden
            EndContext();
            BeginContext(2076, 18, true);
            WriteLiteral("</p>\r\n    </div>\r\n");
            EndContext();
            BeginContext(2096, 66, true);
            WriteLiteral("    <div>\r\n        <h3>My spouse is:</h3>\r\n        <p id=\"spouse\">");
            EndContext();
            BeginContext(2163, 14, false);
#line 81 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                  Write(ViewBag.Spouse);

#line default
#line hidden
            EndContext();
            BeginContext(2177, 18, true);
            WriteLiteral("</p>\r\n    </div>\r\n");
            EndContext();
            BeginContext(2197, 71, true);
            WriteLiteral("    <div>\r\n        <h3>My children are:</h3>\r\n        <p id=\"children\">");
            EndContext();
            BeginContext(2269, 14, false);
#line 86 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                    Write(ViewBag.Child1);

#line default
#line hidden
            EndContext();
            BeginContext(2283, 8, true);
            WriteLiteral(" &nbsp; ");
            EndContext();
            BeginContext(2292, 14, false);
#line 86 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                                           Write(ViewBag.Child2);

#line default
#line hidden
            EndContext();
            BeginContext(2306, 19, true);
            WriteLiteral(" </p>\r\n    </div>\r\n");
            EndContext();
#line 88 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"




    if (ViewBag.relation != null && ViewBag.relation.Count != 0)
    {
        var counter = 0;
        foreach (var i in ViewBag.relation)
        {
            counter++;
            if (i.Relationship == 2) //pending adoption request
                {
                    if(i.SourceUser == self.Id)
                    {

#line default
#line hidden
            BeginContext(2668, 26, true);
            WriteLiteral("                        <p");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2694, "\"", 2711, 2);
            WriteAttributeValue("", 2699, "req_", 2699, 4, true);
#line 102 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 2703, counter, 2703, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2712, 46, true);
            WriteLiteral(">\r\n                            You have asked ");
            EndContext();
            BeginContext(2759, 55, false);
#line 103 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                                      Write(UserManager.FindByIdAsync(i.TargetUser).Result.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(2814, 221, true);
            WriteLiteral(" to become your child. If you no longer see this meesage and the other user does not appear above, it means your request has been rejected.\r\n                            <a class=\"btn btn-primary\" href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3035, "\"", 3081, 6);
            WriteAttributeValue("", 3045, "withdrawRequest(\'", 3045, 17, true);
#line 104 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 3062, i.Id, 3062, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 3067, "\',", 3067, 2, true);
            WriteAttributeValue(" ", 3069, "\'", 3070, 2, true);
#line 104 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 3071, counter, 3071, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 3079, "\')", 3079, 2, true);
            EndWriteAttribute();
            BeginContext(3082, 45, true);
            WriteLiteral(">Withdraw</a>\r\n                        </p>\r\n");
            EndContext();
#line 106 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(3199, 26, true);
            WriteLiteral("                        <p");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3225, "\"", 3242, 2);
            WriteAttributeValue("", 3230, "req_", 3230, 4, true);
#line 109 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 3234, counter, 3234, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3243, 32, true);
            WriteLiteral("> \r\n                            ");
            EndContext();
            BeginContext(3276, 55, false);
#line 110 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                       Write(UserManager.FindByIdAsync(i.SourceUser).Result.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(3331, 122, true);
            WriteLiteral(" has asked you to become his/her child. \r\n                            <a class=\"btn btn-primary\" href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3453, "\"", 3498, 6);
            WriteAttributeValue("", 3463, "confirmRequest(\'", 3463, 16, true);
#line 111 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 3479, i.Id, 3479, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 3484, "\',", 3484, 2, true);
            WriteAttributeValue(" ", 3486, "\'", 3487, 2, true);
#line 111 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 3488, counter, 3488, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 3496, "\')", 3496, 2, true);
            EndWriteAttribute();
            BeginContext(3499, 94, true);
            WriteLiteral(">Confirm</a>\r\n                            <a class=\"btn btn-primary\" href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3593, "\"", 3639, 6);
            WriteAttributeValue("", 3603, "withdrawRequest(\'", 3603, 17, true);
#line 112 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 3620, i.Id, 3620, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 3625, "\',", 3625, 2, true);
            WriteAttributeValue(" ", 3627, "\'", 3628, 2, true);
#line 112 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 3629, counter, 3629, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 3637, "\')", 3637, 2, true);
            EndWriteAttribute();
            BeginContext(3640, 43, true);
            WriteLiteral(">Reject</a>\r\n                        </p>\r\n");
            EndContext();
#line 114 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                    }
                }
            else //pending marriage request
            {
                    if(i.SourceUser == self.Id)
                    {

#line default
#line hidden
            BeginContext(3857, 26, true);
            WriteLiteral("                        <p");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 3883, "\"", 3900, 2);
            WriteAttributeValue("", 3888, "req_", 3888, 4, true);
#line 120 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 3892, counter, 3892, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3901, 46, true);
            WriteLiteral(">\r\n                            You have asked ");
            EndContext();
            BeginContext(3948, 55, false);
#line 121 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                                      Write(UserManager.FindByIdAsync(i.TargetUser).Result.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(4003, 222, true);
            WriteLiteral(" to become your spouse. If you no longer see this meesage and the other user does not appear above, it means your request has been rejected.\r\n                            <a class=\"btn btn-primary\" href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4225, "\"", 4271, 6);
            WriteAttributeValue("", 4235, "withdrawRequest(\'", 4235, 17, true);
#line 122 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 4252, i.Id, 4252, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 4257, "\',", 4257, 2, true);
            WriteAttributeValue(" ", 4259, "\'", 4260, 2, true);
#line 122 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 4261, counter, 4261, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 4269, "\')", 4269, 2, true);
            EndWriteAttribute();
            BeginContext(4272, 45, true);
            WriteLiteral(">Withdraw</a>\r\n                        </p>\r\n");
            EndContext();
#line 124 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(4389, 26, true);
            WriteLiteral("                        <p");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4415, "\"", 4432, 2);
            WriteAttributeValue("", 4420, "req_", 4420, 4, true);
#line 127 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 4424, counter, 4424, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4433, 32, true);
            WriteLiteral("> \r\n                            ");
            EndContext();
            BeginContext(4466, 55, false);
#line 128 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                       Write(UserManager.FindByIdAsync(i.SourceUser).Result.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(4521, 123, true);
            WriteLiteral(" has asked you to become his/her spouse. \r\n                            <a class=\"btn btn-primary\" href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4644, "\"", 4689, 6);
            WriteAttributeValue("", 4654, "confirmRequest(\'", 4654, 16, true);
#line 129 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 4670, i.Id, 4670, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 4675, "\',", 4675, 2, true);
            WriteAttributeValue(" ", 4677, "\'", 4678, 2, true);
#line 129 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 4679, counter, 4679, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 4687, "\')", 4687, 2, true);
            EndWriteAttribute();
            BeginContext(4690, 94, true);
            WriteLiteral(">Confirm</a>\r\n                            <a class=\"btn btn-primary\" href=\"javascript:void(0)\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4784, "\"", 4830, 6);
            WriteAttributeValue("", 4794, "withdrawRequest(\'", 4794, 17, true);
#line 130 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 4811, i.Id, 4811, 5, false);

#line default
#line hidden
            WriteAttributeValue("", 4816, "\',", 4816, 2, true);
            WriteAttributeValue(" ", 4818, "\'", 4819, 2, true);
#line 130 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
WriteAttributeValue("", 4820, counter, 4820, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 4828, "\')", 4828, 2, true);
            EndWriteAttribute();
            BeginContext(4831, 43, true);
            WriteLiteral(">Reject</a>\r\n                        </p>\r\n");
            EndContext();
#line 132 "D:\Cambridge\CCS\MemberDatabase\Views\Home\Family.cshtml"
                    }
            }
        
        }
    }
    else 
    {
       // <p>You have no family members yet. :(</p>
    }

#line default
#line hidden
            BeginContext(5021, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(5023, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d7e76003e8b6451998444a347746f4bb", async() => {
                BeginContext(5072, 18, true);
                WriteLiteral("Add family members");
                EndContext();
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
            EndContext();
            BeginContext(5094, 18, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<MemberUserInfo> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<MemberUserInfo> SignInManager { get; private set; }
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
