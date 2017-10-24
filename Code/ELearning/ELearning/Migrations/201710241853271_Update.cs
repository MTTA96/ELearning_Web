namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        KhoaHocId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.KhoaHocId, t.AttendeeId })
                .ForeignKey("dbo.AspNetUsers", t => t.AttendeeId, cascadeDelete: true)
                .ForeignKey("dbo.KhoaHocs", t => t.KhoaHocId)
                .Index(t => t.KhoaHocId)
                .Index(t => t.AttendeeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false),
                        NamSinh = c.String(nullable: false),
                        NgheNghiep = c.String(nullable: false),
                        BangCap = c.String(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.KhoaHocs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsCanceled = c.Boolean(nullable: false),
                        ThanhVienId = c.String(nullable: false, maxLength: 128),
                        Mon = c.String(nullable: false),
                        DiaDiemId = c.Byte(nullable: false),
                        NgayDang = c.DateTime(nullable: false),
                        BuoiId = c.Byte(nullable: false),
                        SoBuoi = c.Int(nullable: false),
                        ThuId = c.Byte(nullable: false),
                        HocPhi = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buois", t => t.BuoiId, cascadeDelete: true)
                .ForeignKey("dbo.DiaDiems", t => t.DiaDiemId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ThanhVienId, cascadeDelete: true)
                .ForeignKey("dbo.Thus", t => t.ThuId, cascadeDelete: true)
                .Index(t => t.ThanhVienId)
                .Index(t => t.DiaDiemId)
                .Index(t => t.BuoiId)
                .Index(t => t.ThuId);
            
            CreateTable(
                "dbo.Buois",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiaDiems",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Thus",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Attendances", "KhoaHocId", "dbo.KhoaHocs");
            DropForeignKey("dbo.KhoaHocs", "ThuId", "dbo.Thus");
            DropForeignKey("dbo.KhoaHocs", "ThanhVienId", "dbo.AspNetUsers");
            DropForeignKey("dbo.KhoaHocs", "DiaDiemId", "dbo.DiaDiems");
            DropForeignKey("dbo.KhoaHocs", "BuoiId", "dbo.Buois");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.KhoaHocs", new[] { "ThuId" });
            DropIndex("dbo.KhoaHocs", new[] { "BuoiId" });
            DropIndex("dbo.KhoaHocs", new[] { "DiaDiemId" });
            DropIndex("dbo.KhoaHocs", new[] { "ThanhVienId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropIndex("dbo.Attendances", new[] { "KhoaHocId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Thus");
            DropTable("dbo.DiaDiems");
            DropTable("dbo.Buois");
            DropTable("dbo.KhoaHocs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Attendances");
        }
    }
}
