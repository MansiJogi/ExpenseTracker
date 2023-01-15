namespace ExpenseTracker2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        exId = c.Long(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Category = c.String(nullable: false),
                        Amount = c.Single(nullable: false),
                        catId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.exId)
                .ForeignKey("dbo.Categories", t => t.catId, cascadeDelete: true)
                .Index(t => t.catId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "catId", "dbo.Categories");
            DropIndex("dbo.Expenses", new[] { "catId" });
            DropTable("dbo.Expenses");
        }
    }
}
