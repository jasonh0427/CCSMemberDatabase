#pragma checksum "D:\Cambridge\CCS\MemberDatabase\Views\Home\AddMembers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73b09bdf903d9c9bf7ecfc086ec3c4d0d3a28795"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AddMembers), @"mvc.1.0.view", @"/Views/Home/AddMembers.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/AddMembers.cshtml", typeof(AspNetCore.Views_Home_AddMembers))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73b09bdf903d9c9bf7ecfc086ec3c4d0d3a28795", @"/Views/Home/AddMembers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7ccda0b74fbaea60719f91a12a0985b178ef052", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AddMembers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\Cambridge\CCS\MemberDatabase\Views\Home\AddMembers.cshtml"
  
    ViewData["Title"] = "Add Members";

#line default
#line hidden
            BeginContext(47, 909, true);
            WriteLiteral(@"<br>
<div>
<button type = 'button' onclick = 'getNotMarriedUser()' class = 'btn btn-primary btn-sm'>Show all not married users of your year</button>
<button type = 'button' onclick = 'getNoParentsUser()' class = 'btn btn-primary btn-sm'>Show all users without parents in lower years</button>
</div>


<h3>
    Or, please enter the member's crsID in the search bar below: 
</h3>



<p>
    <input id=""patterns"" class=""form-control"" type=""text"" name=""SearchString"" onchange=""getUser()"">
</p>

<div>
    <h3 id=""Name""></h3>
    <h3 id=""Privilege""></h3>
    <h3 id=""College""></h3>
    <h3 id=""Subject""></h3>
    <h3 id=""Year of admission""></h3>
    <h3 id=""Spouse""></h3>
</div>


<table class=""table"">
    <thead>
        <th>User Name</th>
        <th>Married</th>
        <th>Has Parents</th>
        <th>Actions</th>
    </thead>
    <tbody id=""results""></tbody>
</table>

");
            EndContext();
            BeginContext(1250, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1270, 740, true);
                WriteLiteral(@"
    <script>
        function getUser()
        {
            var input = document.getElementById('patterns');
            //patterns 取到了这个 input 控件，类型是HTMLElement（好像是吧。。。反正是什么什么element2333
            //要获取到input里面填的东西，需要取出value（这个可以赋值也可以取值，如果赋值的话，对应那个input里面的内容也就变了）
            var patterns = input.value;
            //js可以用alert弹出提示框，这样方便你懒得debug的时候看变量内容
            //你应该把这个AddMembers单独做成一个页面，然后关于搜索用户的API单独拿出来，不做成页面，只返回json结果
            //前端我们使用了jQuery框架，里面有一个ajax命令可以用来和后端在不刷新页面的情况下交互
            $.ajax({
                method: ""POST"", //指定使用post协议
                data: {
                    patterns: patterns //data就是指要给后端的api传的parameters，然后大括号里面写内容，多个参数用逗号分开，参数名: 内容
                },
                url: '");
                EndContext();
                BeginContext(2011, 33, false);
#line 65 "D:\Cambridge\CCS\MemberDatabase\Views\Home\AddMembers.cshtml"
                 Write(Url.Action("SearchUsers", "Home"));

#line default
#line hidden
                EndContext();
                BeginContext(2044, 3272, true);
                WriteLiteral(@"',//这里写请求地址，我们的api是SearchUsers，那么就直接用C#提供的一个命令直接获取到对应的url，Url.Action(action, controller)
                success: function(ret) {
                    if (ret == null || ret.length == 0){
                        alert(""not found!"");
                        return;
                    }
                    var container = document.getElementById('results');
                    //放东西前先把已经有的清空
                    container.innerHTML = """"; //innerHTML accesses content
                    for (var i=0; i<ret.length;i++){ //毕竟后端en返回回来的是个collection
                        var row = document.createElement('tr');
                        var userNameCol = document.createElement('td');
                        userNameCol.innerHTML = ret[i].userName;
                        row.appendChild(userNameCol);

                        var marriedCol = document.createElement('td');
                        if(ret[i].spouse != null)
                        {
                            marriedCol.innerHTML = ""Yes""");
                WriteLiteral(@";
                        }
                        else
                        {
                            marriedCol.innerHTML = ""No"";
                        }
                        row.appendChild(marriedCol);

                        var hasParentsCol = document.createElement('td');
                        if(ret[i].parent1 != null) {
                            hasParentsCol.innerHTML = ""Yes"";
                        }
                        else{
                            hasParentsCol.innerHTML = ""No"";
                        }
                        row.appendChild(hasParentsCol);

                        var actionCol = document.createElement('td');
                        actionCol.innerHTML = 
                            ""<button type='button' onclick='select(\"""" + ret[i].id + ""\"",1""
                            + "")' class='btn btn-primary btn-sm'>Ask this user to marry you</button>""
                            + ""<span>&nbsp;&nbsp;</span>""
                          ");
                WriteLiteral(@"  + ""<button type='button' onclick='select(\"""" + ret[i].id + ""\"",2""
                            + "")' class='btn btn-primary btn-sm'>Ask this user to be your child</button>""
                            + ""<span>&nbsp;&nbsp;</span>""
                            + ""<button type='button' onclick='profile(\"""" + ret[i].id +""\""""
                            + "")' class='btn btn-primary btn-sm'>Basic Information</button>""                            
                        row.appendChild(actionCol);
                       

                        container.appendChild(row);
                                        
                    }                   


          
                }, //这个是指，如果这个请求成功了，那么就执行这个函数，参数有一个ret，名字你可以换成别的，这个就是后端的Action返回回来的东西
//等等 你刚说的这个就是个命名规范吗还是后面自动处理了了，无论你后端返回回来的名字是怎么样的，成员变量名首字母到ok了前端都成了小写
                error: function() { //如果出现错误的话就会调用这个函数
                    alert(""some error occurred"");
                    
                }
            });
        }

       ");
                WriteLiteral(" function getNotMarriedUser()\r\n        {\r\n\r\n            $.ajax({\r\n                method: \"POST\", //指定使用post协议\r\n                data: {\r\n                   \r\n                },\r\n                url: \'");
                EndContext();
                BeginContext(5317, 35, false);
#line 136 "D:\Cambridge\CCS\MemberDatabase\Views\Home\AddMembers.cshtml"
                 Write(Url.Action("GetNotMarried", "Home"));

#line default
#line hidden
                EndContext();
                BeginContext(5352, 3271, true);
                WriteLiteral(@"',//这里写请求地址，我们的api是SearchUsers，那么就直接用C#提供的一个命令直接获取到对应的url，Url.Action(action, controller)
                success: function(ret) {
                    if (ret == null || ret.length == 0){
                        alert(""not found!"");
                        return;
                    }
                    var container = document.getElementById('results');
                    //放东西前先把已经有的清空
                    container.innerHTML = """"; //innerHTML accesses content
                    for (var i=0; i<ret.length;i++){ //毕竟后端en返回回来的是个collection
                        var row = document.createElement('tr');
                        var userNameCol = document.createElement('td');
                        userNameCol.innerHTML = ret[i].userName;
                        row.appendChild(userNameCol);

                        var marriedCol = document.createElement('td');
                        if(ret[i].spouse != null)
                        {
                            marriedCol.innerHTML = ""Yes""");
                WriteLiteral(@";
                        }
                        else
                        {
                            marriedCol.innerHTML = ""No"";
                        }
                        row.appendChild(marriedCol);

                        var hasParentsCol = document.createElement('td');
                        if(ret[i].parent1 != null) {
                            hasParentsCol.innerHTML = ""Yes"";
                        }
                        else{
                            hasParentsCol.innerHTML = ""No"";
                        }
                        row.appendChild(hasParentsCol);

                        var actionCol = document.createElement('td');
                        actionCol.innerHTML = 
                            ""<button type='button' onclick='select(\"""" + ret[i].id + ""\"",1""
                            + "")' class='btn btn-primary btn-sm'>Ask this user to marry you</button>""
                            + ""<span>&nbsp;&nbsp;</span>""
                          ");
                WriteLiteral(@"  + ""<button type='button' onclick='select(\"""" + ret[i].id + ""\"",2""
                            + "")' class='btn btn-primary btn-sm'>Ask this user to be your child</button>""
                            + ""<span>&nbsp;&nbsp;</span>""
                            + ""<button type='button' onclick='profile(\"""" + ret[i].id +""\""""
                            + "")' class='btn btn-primary btn-sm'>Basic Information</button>""                            
                        row.appendChild(actionCol);
                       

                        container.appendChild(row);
                                        
                    }                   


          
                }, //这个是指，如果这个请求成功了，那么就执行这个函数，参数有一个ret，名字你可以换成别的，这个就是后端的Action返回回来的东西
//等等 你刚说的这个就是个命名规范吗还是后面自动处理了了，无论你后端返回回来的名字是怎么样的，成员变量名首字母到ok了前端都成了小写
                error: function() { //如果出现错误的话就会调用这个函数
                    alert(""some error occurred"");
                    
                }
            });
        }

       ");
                WriteLiteral(" function getNoParentsUser()\r\n        {\r\n\r\n            $.ajax({\r\n                method: \"POST\", //指定使用post协议\r\n                data: {\r\n                   \r\n                },\r\n                url: \'");
                EndContext();
                BeginContext(8624, 34, false);
#line 207 "D:\Cambridge\CCS\MemberDatabase\Views\Home\AddMembers.cshtml"
                 Write(Url.Action("GetNoParents", "Home"));

#line default
#line hidden
                EndContext();
                BeginContext(8658, 3147, true);
                WriteLiteral(@"',//这里写请求地址，我们的api是SearchUsers，那么就直接用C#提供的一个命令直接获取到对应的url，Url.Action(action, controller)
                success: function(ret) {
                    if (ret == null || ret.length == 0){
                        alert(""not found!"");
                        return;
                    }
                    var container = document.getElementById('results');
                    //放东西前先把已经有的清空
                    container.innerHTML = """"; //innerHTML accesses content
                    for (var i=0; i<ret.length;i++){ //毕竟后端en返回回来的是个collection
                        var row = document.createElement('tr');
                        var userNameCol = document.createElement('td');
                        userNameCol.innerHTML = ret[i].userName;
                        row.appendChild(userNameCol);

                        var marriedCol = document.createElement('td');
                        if(ret[i].spouse != null)
                        {
                            marriedCol.innerHTML = ""Yes""");
                WriteLiteral(@";
                        }
                        else
                        {
                            marriedCol.innerHTML = ""No"";
                        }
                        row.appendChild(marriedCol);

                        var hasParentsCol = document.createElement('td');
                        if(ret[i].parent1 != null) {
                            hasParentsCol.innerHTML = ""Yes"";
                        }
                        else{
                            hasParentsCol.innerHTML = ""No"";
                        }
                        row.appendChild(hasParentsCol);

                        var actionCol = document.createElement('td');
                        actionCol.innerHTML = 
                            ""<button type='button' onclick='select(\"""" + ret[i].id + ""\"",1""
                            + "")' class='btn btn-primary btn-sm'>Ask this user to marry you</button>""
                            + ""<span>&nbsp;&nbsp;</span>""
                          ");
                WriteLiteral(@"  + ""<button type='button' onclick='select(\"""" + ret[i].id + ""\"",2""
                            + "")' class='btn btn-primary btn-sm'>Ask this user to be your child</button>""
                            + ""<span>&nbsp;&nbsp;</span>""
                            + ""<button type='button' onclick='profile(\"""" + ret[i].id +""\""""
                            + "")' class='btn btn-primary btn-sm'>Basic Information</button>""                            
                        row.appendChild(actionCol);
                       

                        container.appendChild(row);
                                        
                    }                   


          
                }, //这个是指，如果这个请求成功了，那么就执行这个函数，参数有一个ret，名字你可以换成别的，这个就是后端的Action返回回来的东西
//等等 你刚说的这个就是个命名规范吗还是后面自动处理了了，无论你后端返回回来的名字是怎么样的，成员变量名首字母到ok了前端都成了小写
                error: function() { //如果出现错误的话就会调用这个函数
                    alert(""some error occurred"");
                    
                }
            });
        }

       ");
                WriteLiteral(" function select(user, type){\r\n            $.ajax({\r\n                url: \'");
                EndContext();
                BeginContext(11806, 36, false);
#line 272 "D:\Cambridge\CCS\MemberDatabase\Views\Home\AddMembers.cshtml"
                 Write(Url.Action("ProcessRequest", "Home"));

#line default
#line hidden
                EndContext();
                BeginContext(11842, 283, true);
                WriteLiteral(@"', //我在后端还没定义这个函数，等会再实现
                data: {
                    userId: user,
                    type: type
                },
                method: ""POST"",
                success: function(ret){
                    alert(ret);
                    window.location = '");
                EndContext();
                BeginContext(12126, 28, false);
#line 280 "D:\Cambridge\CCS\MemberDatabase\Views\Home\AddMembers.cshtml"
                                  Write(Url.Action("Family", "Home"));

#line default
#line hidden
                EndContext();
                BeginContext(12154, 299, true);
                WriteLiteral(@"'; //js跳转页面用这个，直接给location赋个地址就跳过去了 ok
                },
                error: function(){
                    alert(""Some error occurred, please try again later."");
                }
            })
        }

        function profile(user){
            $.ajax({

                url: '");
                EndContext();
                BeginContext(12454, 33, false);
#line 291 "D:\Cambridge\CCS\MemberDatabase\Views\Home\AddMembers.cshtml"
                 Write(Url.Action("GetUserInfo", "Home"));

#line default
#line hidden
                EndContext();
                BeginContext(12487, 3328, true);
                WriteLiteral(@"',
                data: {
                    id: user,
                },
                method: ""POST"",
                success: function(ret){
                    document.getElementById('Name').innerHTML = ret.name;
                    document.getElementById('Privilege').innerHTML = ret.privilege;
                    document.getElementById('Subject').innerHTML = ret.subject;
                    document.getElementById('College').innerHTML = ret.college;
                    document.getElementById('Year of admission').innerHTML = ret.yoa;
                    document.getElementById('Spouse').innerHTML = ""Married to "" + ret.spouse;
                },
                error: function(){
                    alert(""Some error occurred, please try again later."");
                }
            })
        }
                                        //稍微梳理一下吧。创建了一个element，设置了innerHTML位userName，然后用setAttribute把名字为onclick的attribute设置成select(""userName"")，这样一点他就会执行select哈桑农户，并且把userName传进去。
        ");
                WriteLiteral(@"                                //然后把这个element append到那个div里面，就ok了

                                        //你这一大波操作
                                        //我明天一整天就在这了23333333你可以去了解一下dom操作，专门就是说这块的
                                        //有链接吗
                        
                                        
                                        //奥对，不能直接这么弄，事件的话得要通过setAttribute来设置，setAttribute是纯文本的，你给的啥它里面就会写啥，所以你也可以不把this传进去，直接换成userName也行
                                        //这样就已经出来了，如果你想让他点击会出现什么的话，那就直接把这个element的onclick绑定到某个函数上去 牛逼，html绑定的函数都是js的函数，跟后端、controller什么的没关系
                                        //还有就是，为什么要把脚本放到这个Scripts的section里面
                                        //其实你不放进去也可以的，但是网页是按顺序加载的，也就是说在前面的东西会先加载，在后面的东西会后加载
                                        //这样的话你用的js库也是这样
                                        //如果先加载js库的话，那么网页就会有更多时间的空白，等js加载完了才会加载网页内容
                                        //这样用户看起来就会觉得你网站加载慢
                                        //所以我们在_L");
                WriteLiteral(@"ayout.cshtml里面定义了一个地方加载名字为Scripts的section，这个section放在页面最下面加载，在加载这个section的上面把相关的js库加载一下就行了
                                        //这样js、js库就都放到最后才加载了，网页的显示内容就会优先加载出来，显得比较快
                                        //等下啊 我好像有点明白js的目的了  是不是因为html本身不能用来编程 所以dynamic的这些东西必须用js来弄嗯 牛逼
                                        //现在既然拿到了结果，你总不能把结果弹个提示框给用户就结束了，肯定要弄成类似于下拉列表那种样子让用户来选择
                                        //这个就很麻烦了233
                                        //没事 我明天 先把你刚才的操作搞懂
                                        //然后学一学js基础的东西，因为我刚看得还是有点懵逼
                                        //然后弄懂了以后再试试看能不能弄出来那个玩意
                                        //我看之前它asp.net core的教程里
                                        //会直接有这样子的东西，好像ef core都给他整好了的样子
                                        //这两不是一个东西，一个是通过访问页面的方式执行后台的action，处理数据然后把数据传到前端来，在渲染页面的时候就把这些数据全部都放到网页里
                                        //咱们现在做的事不通过访问网页的方式，直接手动用js来调整页面的布局、添加和删除页面里面的元素
                                        //我先给你做一个添加元素的例");
                WriteLiteral(@"子，不然只有提示框看也不行
                                        //整个html类似一个tree，这你能看出来吧，<xxx></xxx>相互嵌套，里面的就是child，外面的就是parent，一层一层的 嗯
                                        //那我们给你要放东西的地方搞一个div（这个就类似于html里面啥都不显示的一个容器一样的东西，本身是没有任何可视的东西的）
    </script>




");
                EndContext();
            }
            );
            BeginContext(15818, 8, true);
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
