using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemberDatabase.Models;
using Microsoft.AspNetCore.Identity;
using MemberDatabase.Data;
using Microsoft.Extensions.Configuration;

namespace MemberDatabase.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<MemberUserInfo> _userManager;
        private SignInManager<MemberUserInfo> _signInManager;
        private IConfiguration _configuration;
        public HomeController(
            UserManager<MemberUserInfo> userManager,
            SignInManager<MemberUserInfo> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            var x = new TestModel
            {
                abc = "nmsl"
            };
            return View(x);
        }

        [HttpPost]
        public IActionResult About(TestModel x)
        {
            ViewData["tt"] = x.abc;
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public async Task<bool> SendRequest(string targetUser, int result, int relationship)
        {
            if (!_signInManager.IsSignedIn(User))
                return false;


            var user = await _userManager.GetUserAsync(User);

            // using (var db = new ApplicationDbContext())
            // {
            //     db.MemberRelationship.Add(
            //         new MemberRelationship
            //         {
            //             SourceUser = user.Id,
            //             TargetUser = targetUser,
            //             Relationship = relationship,
            //             Result = result,
            //             ApplyingTime = DateTime.Now
            //         }
            //     );

            //     var x = db.MemberRelationship.FirstOrDefault(i => i.Id == 8);
            //     if (x != null) x.Result = 2;

            //     db.MemberRelationship.Remove(x);
            //     db.MemberRelationship.RemoveRange(db.MemberRelationship.Where(i => i.Result == 2));
            //     await db.SaveChangesAsync();
            // }
            return true;
        }

        public async Task<IActionResult> Manage()
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return Redirect("/Identity/Account/Login");
            }
            else
            {
                var selfUser = await _userManager.GetUserAsync(User);
                ViewBag.Privilege = selfUser.Privilege;
                return View();
            }

        }

        public async Task<IActionResult> Family()
        {
            if (!_signInManager.IsSignedIn(User))
                return Redirect("/Identity/Account/Login");

            var selfUser = await _userManager.GetUserAsync(User);

            using (var db = new ApplicationDbContext(_configuration.GetConnectionString("DefaultConnection")))
            {
                ViewBag.relation = db.MemberRelationship
                    .Where(i => (i.SourceUser == selfUser.Id || i.TargetUser == selfUser.Id) && i.Result == null)
                    .ToList();
            }
            ViewBag.Parent1 = (await _userManager.FindByIdAsync(selfUser.Parent1))?.UserName;
            ViewBag.Parent2 = (await _userManager.FindByIdAsync(selfUser.Parent2))?.UserName;
            ViewBag.Child1 = (await _userManager.FindByIdAsync(selfUser.Child1))?.UserName;
            ViewBag.Child2 = (await _userManager.FindByIdAsync(selfUser.Child2))?.UserName;
            ViewBag.Spouse = (await _userManager.FindByIdAsync(selfUser.Spouse))?.UserName;
            //这里有用到连接字符串吗
            //这个appsettings.json里面的配置会传进来，在HomeController的constructor里面我加了个parameter，传进来了一个IConfiguration的instance。这个东西里面就包含了appsettings.json里的配置信息
            //然后我这里用_configuration.GetConnectionString("xxx")可以直接获取到里面key为xxx的ConnectionString
            //也就是说你先修改了ApplicationDbContext里面的constructor对吧√ 我看一下啊

            return View();
        }

        public IActionResult GetAll() //gets all users
        {
            var tempUsers = _userManager.Users.ToList().OrderBy(i => i.UserName);
            return Json(tempUsers.Select(i => new { i.UserName, i.Id, i.Spouse, i.Parent1 }));
        }

        public async Task<IActionResult> GetNotMarried()  //gets not married users in the same year as the current user
        {
            var self = await _userManager.GetUserAsync(User);
            var tempUsers = _userManager.Users.Where(s => (s.Spouse == null && s.YearOfAdmission == self.YearOfAdmission)).ToList();
            return Json(tempUsers.Select(i => new { i.UserName, i.Id, i.Spouse, i.Parent1 }));
        }

        public async Task<IActionResult> GetNoParents() //gets  users without parents in the year below
        {
            var self = await _userManager.GetUserAsync(User);
            var tempUsers = _userManager.Users.Where(s => (s.Parent1 == null && s.YearOfAdmission > self.YearOfAdmission )).ToList();
            return Json(tempUsers.Select(i => new { i.UserName, i.Id, i.Spouse, i.Parent1 }));
        }


        //可以规定只能用POST协议访问，后端api一般来说需要提交参数的都用post比较好，因为浏览器直接访问这个页面是会用get协议，这样如果你的api是用post的话，浏览器直接访问不到，比较安全
        //并且，如果是get的话，参数值会直接嵌入到地址中，比如https://xxxx.com/Home/SearchUsers/tttt这种的，此时ttttt就是patterns
        //而post是通过另外一个渠道发送过来的，不在地址里面，也相对来说比较的安全一些 nb
        //既然是一个获取数据的API，不需要页面，那也就不return View了，用Json返回数据
        //我明白不返回view，但是这个json返回数据是个什么操作
        //json现在已经成了一种通用的前后端交流的数据格式
        //Json(xxxx)会把xxxx转换成json然后再返回，前端的js可以直接操作和读取json  ok
        [HttpPost]
        public IActionResult SearchUsers(string patterns)
        {
            if (String.IsNullOrEmpty(patterns)) return Json(null);
            var tempUsers = _userManager.Users.Where(s => s.UserName.ToLower().Contains(patterns.ToLower())).ToList();
            //应用查询得ToList()，查询操作会延时到直到你执行ToList的时候才会进行，否则他始终只是个查询表达式
            return Json(tempUsers.Select(i => new { i.UserName, i.Id, i.Spouse, i.Parent1 })); //additional info to display marriage/children status
            //这个select就是可以从已有的集合中的每一项中筛出你需要的字段然后生成一个新的集合
            //上面这个select完了之后，结果就只剩下了UserName和Id
        }   //等等啊
            //只剩下username和id是指结果出来到json里面只有这两项了吗对
            //然后刚才另外一个问题，关于你刚才说的这个操作延时，这里不需要用到你昨天说的await吗。这两个不是一个东西，这个不是异步操作 噢就是没有那个什么async对 ok

        public async Task<IActionResult> ManageUser(string userId, int type)
        {
            var targetUser = await _userManager.FindByIdAsync(userId);
            var spouse = await _userManager.FindByIdAsync(targetUser.Spouse);
            var child1 = await _userManager.FindByIdAsync(targetUser.Child1);
            var child2 = await _userManager.FindByIdAsync(targetUser.Child2);
            var child3 = await _userManager.FindByIdAsync(targetUser.Child3);
            var child4 = await _userManager.FindByIdAsync(targetUser.Child4);
            var parent1 = await _userManager.FindByIdAsync(targetUser.Parent1);
            var parent2 = await _userManager.FindByIdAsync(targetUser.Parent2);
            using (var db = new ApplicationDbContext(_configuration.GetConnectionString("DefaultConnection")))
            {
                if (type == 1)
                {
                    targetUser.Privilege = 1;
                    await db.SaveChangesAsync();
                    await _userManager.UpdateAsync(targetUser);
                    return Json("Successful.");
                }
                else
                {
                    if (type == 3)
                    {
                        db.MemberRelationship.RemoveRange(db.MemberRelationship.Where(i => (i.SourceUser == targetUser.Id || i.TargetUser == targetUser.Id))); //remove all entries containing this user
                        if (spouse != null)
                        {
                            targetUser.Spouse = null;
                            spouse.Spouse = null;
                            await _userManager.UpdateAsync(spouse);
                        }
                        if (child1 != null)
                        {
                            targetUser.Child1 = null;
                            child1.Parent1 = null;
                            child1.Parent2 = null;
                            await _userManager.UpdateAsync(child1);
                        }
                        if (child2 != null)
                        {
                            targetUser.Child2 = null;
                            child2.Parent1 = null;
                            child2.Parent2 = null;
                            await _userManager.UpdateAsync(child2);
                        }
                        if (child3 != null)
                        {
                            targetUser.Child3 = null;
                            child3.Parent1 = null;
                            child3.Parent2 = null;
                            await _userManager.UpdateAsync(child3);
                        }
                        if (child4 != null)
                        {
                            targetUser.Child4 = null;
                            child4.Parent1 = null;
                            child4.Parent2 = null;
                            await _userManager.UpdateAsync(child4);
                        }
                        if (parent1 != null)
                        {
                            targetUser.Parent1 = null;
                            targetUser.Parent2 = null;
                            if (parent1.Child1 == userId)
                            {
                                parent1.Child1 = null;
                                parent2.Child1 = null;
                            }
                            if (parent1.Child2 == userId)
                            {
                                parent1.Child2 = null;
                                parent2.Child2 = null;
                            }
                            if (parent1.Child3 == userId)
                            {
                                parent1.Child3 = null;
                                parent2.Child3 = null;
                            }
                            if (parent1.Child4 == userId)
                            {
                                parent1.Child4 = null;
                                parent2.Child4 = null;
                            }
                            await _userManager.UpdateAsync(parent1);
                            await _userManager.UpdateAsync(parent2);
                        }
                        await db.SaveChangesAsync();
                        await _userManager.UpdateAsync(targetUser);
                        return Json("All relationships cleared.");
                    }
                    else
                    { //confirm committee status
                        targetUser.Privilege = 2;
                        await db.SaveChangesAsync();
                        await _userManager.UpdateAsync(targetUser);
                        return Json("Successful.");
                    }
                }
            }
        }


        public async Task<IActionResult> ProcessRequest(string userId, int type)
        {
            //能稍微解释一下这个函数为啥和其他的长得不一样嘛，你是说async吗 把一个不是async的函数改造成async方法就是，价格async，然后把原来的return type讨一个Task 猴
            //说一下为啥要async，因为这个method显然牵扯到了数据库的相关操作，对数据库的操作一般来说比较耗时，所以用async函数，里面对耗时的步骤使用await xxxxAsync()这样的，可以避免阻塞提升并发能力 ok
            //先校验userId是否存在
            var selfUser = await _userManager.GetUserAsync(User); //这个是自己
            var targetUser = await _userManager.FindByIdAsync(userId); //这个是userId对应的User
            if (targetUser.Id == selfUser.Id) return Json("Cannot send request to yourself!");
            //然后查找数据库里面是否已经有了这两个人的相关记录

            using (var db = new ApplicationDbContext(_configuration.GetConnectionString("DefaultConnection")))
            {
                var myRelations = db.MemberRelationship.Where(i => (i.SourceUser == selfUser.Id || i.TargetUser == selfUser.Id));//both pending and existing relationships
                if (myRelations.Where(i => ((i.SourceUser == targetUser.Id) || (i.TargetUser == targetUser.Id)) && i.Result == 1).ToList().Count != 0)
                {
                    return Json("Request failed. You already have a relationship with the user you selected.");
                }
                else
                {
                    if (selfUser == targetUser)
                    {
                        return Json("You cannot send requests to yourself.");
                    } // this is a repetition but whatever.....
                    else
                    {
                        if (type == 1)
                        {
                            if (selfUser.Spouse != null || targetUser.Spouse != null)
                            {
                                return Json("Request failed. Either you or the user you selected is already married.");
                            }
                            else
                            {
                                //TODO: figure out how to efficiently check whether the user has any pending marriage requests.
                                var pending = myRelations.Where(i => i.Result == null && i.Relationship == 1).ToList(); //current user has pending marriage requests
                                if (pending.Count != 0)
                                {
                                    return Json("Request failed. Please process all your pending marriage requests in the My Family page before sending a new request.");
                                }
                                else
                                {
                                    var record = new MemberRelationship
                                    {
                                        SourceUser = selfUser.Id,
                                        TargetUser = targetUser.Id,
                                        Relationship = type,
                                        ApplyingTime = DateTime.Now
                                    };
                                    db.MemberRelationship.Add(record);
                                    await db.SaveChangesAsync();
                                    return Json("Successful.");
                                }
                            }
                        }
                        else
                        {
                            if (selfUser.Spouse == null)
                            {
                                return Json("Request failed. You are not yet married therefore cannot adopt any children.");
                            }
                            else
                            {
                                var spouse = await _userManager.FindByIdAsync(selfUser.Spouse);
                                if (selfUser.Privilege == 0 || spouse.Privilege == 0)
                                { //common use has privilege 0; member 1; committee 2
                                    return Json("Request failed. You and/or your spouse are not yet authorized as a CCS member therefore cannot adopt any children.");
                                }
                                else
                                {
                                    if (targetUser.Parent1 != null || targetUser.Parent2 != null)
                                    {
                                        return Json("Request failed. The user you selected already has parents.");
                                    }
                                    else
                                    {
                                        if (selfUser.Privilege == 1 && spouse.Privilege == 1)
                                        {
                                            if (selfUser.Child1 == null || selfUser.Child2 == null)
                                            {
                                                var record = new MemberRelationship
                                                {
                                                    SourceUser = selfUser.Id,
                                                    TargetUser = targetUser.Id,
                                                    Relationship = type,
                                                    ApplyingTime = DateTime.Now
                                                };
                                                db.MemberRelationship.Add(record);
                                                await db.SaveChangesAsync();
                                                return Json("Successful.");
                                            }
                                            else
                                            {
                                                return Json("Request failed, you already have the maximum number of children in your family.");
                                            }
                                        }
                                        else
                                        {
                                            if (selfUser.Privilege == 2 ^ spouse.Privilege == 2)
                                            { //exclusive or -- only one in the couple is a committee member
                                                if (selfUser.Child1 == null || selfUser.Child2 == null || selfUser.Child3 == null)
                                                {
                                                    var record = new MemberRelationship
                                                    {
                                                        SourceUser = selfUser.Id,
                                                        TargetUser = targetUser.Id,
                                                        Relationship = type,
                                                        ApplyingTime = DateTime.Now
                                                    };
                                                    db.MemberRelationship.Add(record);
                                                    await db.SaveChangesAsync();
                                                    return Json("Successful.");
                                                }
                                                else
                                                {
                                                    return Json("Request failed, you already have the maximum number of children in your family.");
                                                }
                                            }
                                            else
                                            { // the couple are both in the committee
                                                if (selfUser.Child1 == null || selfUser.Child2 == null || selfUser.Child3 == null || selfUser.Child4 == null)
                                                {
                                                    var record = new MemberRelationship
                                                    {
                                                        SourceUser = selfUser.Id,
                                                        TargetUser = targetUser.Id,
                                                        Relationship = type,
                                                        ApplyingTime = DateTime.Now
                                                    };
                                                    db.MemberRelationship.Add(record);
                                                    await db.SaveChangesAsync();
                                                    return Json("Successful.");
                                                }
                                                else
                                                {
                                                    return Json("Request failed, you already have the maximum number of children in your family.");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //你要不把刚才的代码撤销回来我好有个，刚那个有问题啊，只是保证了同样的两个人之间只有一个记录而已 型那我回头再想想 那个Any(i=>....)可以判断是否有满足条件的记录 

            //稍等下啊，两个问题
            //插数据的时候不需要给他赋Id的值吗，id是自动增长的字段，不赋值，它会自动便。并且在你SaveChanges执行之后，那个record的Id会被自动赋值成这个记录对应的Id ok
            //然后，目前这些提示信息都存在json数据里面，这个还没有被调用吧？是啊， 我现在就要写这块 okok我就确认一下 等等 我去上个厕所 马上回来 回来了神速 那可不
        }

        public async Task<IActionResult> GetFamilyInfo()
        {
            var selfUser = await _userManager.GetUserAsync(User);
            var Parent1 = (await _userManager.FindByIdAsync(selfUser.Parent1))?.UserName;
            var Parent2 = (await _userManager.FindByIdAsync(selfUser.Parent2))?.UserName;
            var Child1 = (await _userManager.FindByIdAsync(selfUser.Child1))?.UserName;
            var Child2 = (await _userManager.FindByIdAsync(selfUser.Child2))?.UserName;
            var Spouse = (await _userManager.FindByIdAsync(selfUser.Spouse))?.UserName;
            return Json(new { Parent1, Parent2, Child1, Child2 });
        }

        public async Task<IActionResult> GetUserInfo(string id) //for basic info in addmembers
        {
            var user = await _userManager.FindByIdAsync(id);
            var Name = user.Name;
            var Privilege = "";
            if(user.Privilege == 0){
                Privilege = "Unconfirmed user";
            }
            else{
                if(user.Privilege == 1){
                    Privilege = "CCS member";
                }
                else{
                    Privilege = "Committee member";
                }
            }
            var College = user.College;
            var Subject = user.Subject;
            var Yoa = user.YearOfAdmission.ToString();
            var Spouse = (user.Spouse != null) ? _userManager.FindByIdAsync(user.Spouse).Result.Name : null;
            return Json(new { Name, College, Subject, Yoa, Spouse, Privilege });
        }

        public async Task<IActionResult> RemoveRelationship(int i)
        {
            using (var db = new ApplicationDbContext(_configuration.GetConnectionString("DefaultConnection")))
            {
                db.MemberRelationship.Remove(db.MemberRelationship.Find(i));
                await db.SaveChangesAsync();
            }

            return Json("Completed.");
        }


        public async Task<IActionResult> ConfirmRelationship(int i)
        {
            string Source;
            string OtherParent;
            int Type;
            using (var db = new ApplicationDbContext(_configuration.GetConnectionString("DefaultConnection")))
            {
                var relation = await db.MemberRelationship.FindAsync(i);
                var sourceUser = await _userManager.FindByIdAsync(relation.SourceUser);
                var targetUser = await _userManager.FindByIdAsync(relation.TargetUser);
                var spouse = await _userManager.FindByIdAsync(sourceUser.Spouse);
                relation.Result = 1;
                if (relation.Relationship == 1)
                {
                    sourceUser.Spouse = relation.TargetUser;
                    targetUser.Spouse = relation.SourceUser;
                }
                else
                {
                    if (sourceUser.Child1 == null)
                    { //remember to add if statements when sending the request!!
                        sourceUser.Child1 = relation.TargetUser;
                        spouse.Child1 = relation.TargetUser;
                        targetUser.Parent1 = relation.SourceUser;
                        targetUser.Parent2 = sourceUser.Spouse; //these establishes the relationships among the parents and the child; but I also need to add another registry in the database for the spouse-child relationship
                        var record = new MemberRelationship
                        {
                            SourceUser = spouse.Id,
                            TargetUser = targetUser.Id, //this is the child
                            Relationship = 2,
                            Result = 1,
                            ApplyingTime = DateTime.Now
                        };
                        db.MemberRelationship.Add(record); //this adds the spouse-child relationship in the database
                    }
                    else
                    { //hopefully you've already tested that at least one of them is null
                        if (sourceUser.Child2 == null)
                        {
                            sourceUser.Child2 = relation.TargetUser;
                            spouse.Child2 = relation.TargetUser;
                            targetUser.Parent1 = relation.SourceUser;
                            targetUser.Parent2 = sourceUser.Spouse;
                            var record = new MemberRelationship
                            {
                                SourceUser = spouse.Id,
                                TargetUser = targetUser.Id, //this is the child
                                Relationship = 2,
                                Result = 1,
                                ApplyingTime = DateTime.Now
                            };
                            db.MemberRelationship.Add(record); //this adds the spouse-child relationship in the database
                        }
                        else
                        {
                            if (sourceUser.Child3 == null)
                            {
                                sourceUser.Child3 = relation.TargetUser;
                                spouse.Child3 = relation.TargetUser;
                                targetUser.Parent1 = relation.SourceUser;
                                targetUser.Parent2 = sourceUser.Spouse;
                                var record = new MemberRelationship
                                {
                                    SourceUser = spouse.Id,
                                    TargetUser = targetUser.Id, //this is the child
                                    Relationship = 2,
                                    Result = 1,
                                    ApplyingTime = DateTime.Now
                                };
                                db.MemberRelationship.Add(record); //this adds the spouse-child relationship in the database                  
                            }
                            else
                            {
                                sourceUser.Child4 = relation.TargetUser;
                                spouse.Child4 = relation.TargetUser;
                                targetUser.Parent1 = relation.SourceUser;
                                targetUser.Parent2 = sourceUser.Spouse;
                                var record = new MemberRelationship
                                {
                                    SourceUser = spouse.Id,
                                    TargetUser = targetUser.Id, //this is the child
                                    Relationship = 2,
                                    Result = 1,
                                    ApplyingTime = DateTime.Now
                                };
                                db.MemberRelationship.Add(record); //this adds the spouse-child relationship in the database                    
                            }
                        }
                    }
                }
                await db.SaveChangesAsync();
                await _userManager.UpdateAsync(sourceUser);
                await _userManager.UpdateAsync(targetUser);
                Source = sourceUser.UserName;
                OtherParent = (await _userManager.FindByIdAsync(sourceUser.Spouse))?.UserName;
                Type = relation.Relationship;
                var test = Json(new { Source, OtherParent, Type });

                return Json(new { Source, OtherParent, Type });
            }
            //老哥你要不先看一下marriage那个请求  adoption的我还没有试过所以可能会出其他问题。。你这里有些东西可能拿回来是null然后你没判断直接获取他的成员了， 这样就抛exception了
            //children这块是null我明白，因为我之前在processrequest的时候还有一些判定没有加
            //但是marriage这个我是真的不懂为啥，你可以试一下 我这边的sourceUser不管怎么样肯定都不会是null的
        } //你的ret定义里面没有parent1和parent2啊 但是目前就没有到那个框里去 现在应该只用了source才对吧


        public IActionResult AddMembers(string searchString)
        {

            //这个是确保case sensitivity?不是，这个是匹配前都弄成小写的这样就跟case无关了 嗯嗯 老哥稳的一批
            //这样？ 没事这个就不需要了 我等会给搜索栏旁边注明一下只能填写crsid 大家有逼数一点就好。。。
            //哇97年。。牛逼   我就说这个画风怎么这么奇怪233
            //你要懂得欣赏
            //二十年前拍成这样已经很牛逼了66666
            //那你慢慢折腾。还有其他问题没？
            //目前没了，今天我就把search bar整好
            //明天我再问你
            //我觉得searchbar你今天弄不好
            //因为你还不会通过js操作dom以及用js向后端发送请求
            //有没有教程
            //我给你弄个事例把更快一些
            //教程上的都贼大一滩用不上的东西
            //等等啊
            //光用左边这个东西里面的不够吗
            //你用左边这些东西做到的只是在后端实现了一个api，这个api可以根据你提供的patterns筛选出对应的users
            //但是你要怎么访问这个api呢，访问了之后拿到结果要怎么办呢
            //页面已经加载出来了，你不可能说点击一下搜索还刷新一下页面吧
            //hmmmm 左边这个教程的意思好像就是点搜索刷新一下页面的样子23333这样体验也太差了吧
            //那大佬求带
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
