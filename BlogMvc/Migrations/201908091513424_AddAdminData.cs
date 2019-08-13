namespace BlogMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminData : DbMigration
    {
        public override void Up()


        {

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'CanManage')");
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a0121e3d-365e-480c-9043-e437332fdb1d', N'Bianyu Wang', N'admin@test.com', 0, N'ANDfT0NaYAuKUktHnSz7NS7l0M8EGBt7VF/ox+MJUl6nrp0sl4kRVilHOojWS11MrQ==', N'694f55a8-80c6-47c9-a43f-97c1840445a3', NULL, 0, 0, NULL, 1, 0, N'admin@test.com')
");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a0121e3d-365e-480c-9043-e437332fdb1d', N'1')");
        }
        
        public override void Down()
        {
        }
    }
}
