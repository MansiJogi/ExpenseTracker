namespace ExpenseTracker2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expenses : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Expenses", "Category");
            DropColumn("dbo.Expenses", "CatList_DataGroupField");
            DropColumn("dbo.Expenses", "CatList_DataTextField");
            DropColumn("dbo.Expenses", "CatList_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Expenses", "CatList_DataValueField", c => c.String());
            AddColumn("dbo.Expenses", "CatList_DataTextField", c => c.String());
            AddColumn("dbo.Expenses", "CatList_DataGroupField", c => c.String());
            AddColumn("dbo.Expenses", "Category", c => c.String(nullable: false));
        }
    }
}
