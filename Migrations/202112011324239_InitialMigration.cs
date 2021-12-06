namespace BOOK_LIBRARY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorName = c.String(maxLength: 40),
                        Author_Nationality = c.String(),
                        Birthyear = c.Int(nullable: false),
                        Quotes = c.String(),
                        Biography = c.String(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Book_Info",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Author = c.String(nullable: false, maxLength: 30),
                        genre = c.String(maxLength: 25),
                        Plot = c.String(maxLength: 700),
                        page = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Book_Info_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book_Info", t => t.Book_Info_Id)
                .Index(t => t.Book_Info_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Title = c.String(maxLength: 70),
                        Content = c.String(maxLength: 1500),
                        Published = c.DateTime(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                        Read = c.Long(nullable: false),
                        Review_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reviews", t => t.Review_Id)
                .Index(t => t.Review_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Review_Id", "dbo.Reviews");
            DropForeignKey("dbo.Book_Info", "Book_Info_Id", "dbo.Book_Info");
            DropForeignKey("dbo.Authors", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Reviews", new[] { "Review_Id" });
            DropIndex("dbo.Book_Info", new[] { "Book_Info_Id" });
            DropIndex("dbo.Authors", new[] { "Author_Id" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Book_Info");
            DropTable("dbo.Authors");
        }
    }
}
