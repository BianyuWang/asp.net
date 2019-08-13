namespace BlogMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                        UserFullName = c.String(nullable: false),
                        PostId = c.Int(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
