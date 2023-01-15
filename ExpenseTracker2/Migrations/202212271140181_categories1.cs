namespace ExpenseTracker2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categories1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenses", "CatList_DataGroupField", c => c.String());
            AddColumn("dbo.Expenses", "CatList_DataTextField", c => c.String());
            AddColumn("dbo.Expenses", "CatList_DataValueField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenses", "CatList_DataValueField");
            DropColumn("dbo.Expenses", "CatList_DataTextField");
            DropColumn("dbo.Expenses", "CatList_DataGroupField");
        }
    }
}
