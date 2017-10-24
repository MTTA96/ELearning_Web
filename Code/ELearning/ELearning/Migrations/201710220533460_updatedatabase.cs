namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiaDiems",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.KhoaHocs", "DiaDiemId", c => c.Byte(nullable: false));
            CreateIndex("dbo.KhoaHocs", "DiaDiemId");
            AddForeignKey("dbo.KhoaHocs", "DiaDiemId", "dbo.DiaDiems", "Id", cascadeDelete: true);
            DropColumn("dbo.KhoaHocs", "DiaDiem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KhoaHocs", "DiaDiem", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.KhoaHocs", "DiaDiemId", "dbo.DiaDiems");
            DropIndex("dbo.KhoaHocs", new[] { "DiaDiemId" });
            DropColumn("dbo.KhoaHocs", "DiaDiemId");
            DropTable("dbo.DiaDiems");
        }
    }
}
