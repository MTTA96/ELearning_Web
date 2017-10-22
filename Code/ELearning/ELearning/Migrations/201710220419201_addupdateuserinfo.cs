namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addupdateuserinfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "NamSinh", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "NgheNghiep", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "BangCap", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BangCap");
            DropColumn("dbo.AspNetUsers", "NgheNghiep");
            DropColumn("dbo.AspNetUsers", "NamSinh");
            DropColumn("dbo.AspNetUsers", "Address");
        }
    }
}
