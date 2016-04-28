namespace StudentManagementSystem.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentEdit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "FeeId", "dbo.Fees");
            DropIndex("dbo.Payments", new[] { "FeeId" });
            AddColumn("dbo.Payments", "PayBy", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "FeeId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Payments", "FeeId");
            AddForeignKey("dbo.Payments", "FeeId", "dbo.Fees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "FeeId", "dbo.Fees");
            DropIndex("dbo.Payments", new[] { "FeeId" });
            AlterColumn("dbo.Payments", "FeeId", c => c.String(maxLength: 128));
            DropColumn("dbo.Payments", "PayBy");
            CreateIndex("dbo.Payments", "FeeId");
            AddForeignKey("dbo.Payments", "FeeId", "dbo.Fees", "Id");
        }
    }
}
