namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaoTableKhoaHoc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buois",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KhoaHocs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThanhVienId = c.String(nullable: false, maxLength: 128),
                        Mon = c.String(nullable: false),
                        DiaDiem = c.String(nullable: false, maxLength: 255),
                        NgayDang = c.DateTime(nullable: false),
                        SoBuoi = c.Int(nullable: false),
                        HocPhi = c.Double(nullable: false),
                        Buoi_Id = c.Byte(nullable: false),
                        Thu_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buois", t => t.Buoi_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ThanhVienId, cascadeDelete: true)
                .ForeignKey("dbo.Thus", t => t.Thu_Id, cascadeDelete: true)
                .Index(t => t.ThanhVienId)
                .Index(t => t.Buoi_Id)
                .Index(t => t.Thu_Id);
            
            CreateTable(
                "dbo.Thus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KhoaHocs", "Thu_Id", "dbo.Thus");
            DropForeignKey("dbo.KhoaHocs", "ThanhVienId", "dbo.AspNetUsers");
            DropForeignKey("dbo.KhoaHocs", "Buoi_Id", "dbo.Buois");
            DropIndex("dbo.KhoaHocs", new[] { "Thu_Id" });
            DropIndex("dbo.KhoaHocs", new[] { "Buoi_Id" });
            DropIndex("dbo.KhoaHocs", new[] { "ThanhVienId" });
            DropTable("dbo.Thus");
            DropTable("dbo.KhoaHocs");
            DropTable("dbo.Buois");
        }
    }
}
