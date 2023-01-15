namespace ExpenseTracker2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        catId = c.Int(nullable: false, identity: true),
                        catName = c.String(nullable: false),
                        catExpLimit = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.catId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
