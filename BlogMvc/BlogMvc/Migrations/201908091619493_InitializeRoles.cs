namespace BlogMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'97602cd3-40e4-42fa-94e8-4805b5fc7949', N'CanManage')");
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [FullName], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c7ced0e-646b-4a0b-9332-fe86327236eb', N'johnsmith', N'jsmith@fake.fake', 0, N'AOxt/vsZS/vDZvXxpjJYHnq4m3Qe/jKri4W3/ZkcYF5Pxcmq5m45PuGZTPaOUJj6kw==', N'671366c4-c06b-45cc-9ceb-cf9f12a67469', NULL, 0, 0, NULL, 1, 0, N'jsmith@fake.fake')");
            Sql(@"INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0c7ced0e-646b-4a0b-9332-fe86327236eb', N'97602cd3-40e4-42fa-94e8-4805b5fc7949')");
        }
        
        public override void Down()
        {
        }
    }
}
