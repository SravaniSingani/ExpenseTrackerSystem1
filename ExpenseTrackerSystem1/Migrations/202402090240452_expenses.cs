namespace ExpenseTrackerSystem1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expenses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        CardName = c.String(),
                        CardType = c.String(),
                    })
                .PrimaryKey(t => t.CardId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        ExpenseName = c.String(),
                        Category = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpenseDate = c.DateTime(nullable: false),
                        CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExpenseId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .Index(t => t.CardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expenses", "CardId", "dbo.Cards");
            DropIndex("dbo.Expenses", new[] { "CardId" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Cards");
        }
    }
}
