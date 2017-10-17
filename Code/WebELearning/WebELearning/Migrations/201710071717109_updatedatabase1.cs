namespace BigShool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "LectureId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "LectureId");
        }
    }
}
