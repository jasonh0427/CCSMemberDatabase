using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MemberDatabase.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        private readonly string _connectionString;
        public ApplicationDbContext(string connectionString) //所以我就用这个了
        {
            _connectionString = connectionString;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)//这是底层的库用的consructor，咱们也可以用但是用起来代码比较繁杂所以我不想用这个
            : base(options)
        {
        }
        public virtual DbSet<MemberRelationship> MemberRelationship { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured) //如果没配置
                optionsBuilder.UseSqlite(_connectionString); //吧传进来的连接字符串设置一下
        }
        //以上这些是你后来加的吗是啊。我懒得打了直接从我这里面有的项目粘过来了23333 哇
        //你妈嗨
        //这几行是干什么的
        //IdentityDbContext和DbContext里面包含一个OnConfiguring，这个函数会在这个instance需要配置数据库连接的时候被调用
        //然后我就override把它重写了一下，这个ApplicationDbContext是从IdentityDbContext继承来的，里面包含了IdentityDbContext的缺省方法
        //ok这个  DbContextOptionsBuilder 是个啥，就是 DbContext的Option的builder   emmmm
        //这个method是本身就存在的吗是啊
        //给我一小时
        //我得自己消化一下
        //你先看番啥的吧23333没饭可看    看eva这是啥   eva你都不知道 活啥呢233   新世纪福音战士 神作 动漫圣经 b站就有66666看不出来你居然也是老人了233
        //我成功用这个暑假进化成了现充宅23333 +1 hhh
        //好了我先思考一下
        //11点左右再来找你
        //告辞 88



        //这个连接字符串是个啥啊。就是一个包含你数据库的位置、用户名、密码之类的连接字符串。连接数据库的时候会把这个链接字符串传给数据库进行连接hmmm
        //我自己先看看吧 你先忙你的
        //给我个一小时左右消化一下233333
        //不同数据库的连接字符串不一样的，想你这个sqlite就比较简单，直接DataSource=文件位置就ojbk了
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MemberUserInfo>();

            modelBuilder.Entity<MemberRelationship>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
