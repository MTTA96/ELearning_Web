namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDSThu : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO DIADIEMS VALUES (1,'HCM')");
            Sql("INSERT INTO DIADIEMS VALUES (2,'HN')");
        }
        
        public override void Down()
        {
        }
    }
}
