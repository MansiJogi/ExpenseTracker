namespace ExpenseTracker2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalLimit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Total_Limit",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        totLimit = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Total_Limit");
        }
    }
}
