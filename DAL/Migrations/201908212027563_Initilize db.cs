namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initilizedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Content = c.String(),
                        AuthorId = c.String(),
                        AuthorName = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        PublishedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        AllowShow = c.Boolean(nullable: false),
                        ViewCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblPosts");
        }
    }
}
