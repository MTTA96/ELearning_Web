namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.AspNetUsers", "Address", c => c.String());
            AlterColumn("dbo.AspNetUsers", "NamSinh", c => c.String());
            AlterColumn("dbo.AspNetUsers", "NgheNghiep", c => c.String());
            AlterColumn("dbo.AspNetUsers", "BangCap", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "BangCap", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "NgheNghiep", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "NamSinh", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
