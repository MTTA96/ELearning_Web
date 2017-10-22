namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCanceledColumnToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KhoaHocs", "IsCanceled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KhoaHocs", "IsCanceled");
        }
    }
}
