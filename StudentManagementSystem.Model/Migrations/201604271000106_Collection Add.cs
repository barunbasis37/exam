namespace StudentManagementSystem.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CollectionAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "FeeId", "dbo.Fees");
            DropIndex("dbo.Payments", new[] { "FeeId" });
            CreateTable(
                "dbo.CollectionDetails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FeeId = c.String(nullable: false, maxLength: 128),
                        CollectionId = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        Remarks = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collections", t => t.CollectionId, cascadeDelete: true)
                .ForeignKey("dbo.Fees", t => t.FeeId, cascadeDelete: true)
                .Index(t => t.FeeId)
                .Index(t => t.CollectionId);
            
            CreateTable(
                "dbo.Collections",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Memo = c.String(),
                        Total = c.Double(nullable: false),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        Remarks = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        Modified = c.DateTime(nullable: false),
                        ModifiedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            AddColumn("dbo.Payments", "Memo", c => c.String());
            DropColumn("dbo.Payments", "FeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "FeeId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.CollectionDetails", "FeeId", "dbo.Fees");
            DropForeignKey("dbo.Collections", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CollectionDetails", "CollectionId", "dbo.Collections");
            DropIndex("dbo.Collections", new[] { "StudentId" });
            DropIndex("dbo.CollectionDetails", new[] { "CollectionId" });
            DropIndex("dbo.CollectionDetails", new[] { "FeeId" });
            DropColumn("dbo.Payments", "Memo");
            DropTable("dbo.Collections");
            DropTable("dbo.CollectionDetails");
            CreateIndex("dbo.Payments", "FeeId");
            AddForeignKey("dbo.Payments", "FeeId", "dbo.Fees", "Id", cascadeDelete: true);
        }
    }
}
