namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KhoiTaoTableBuoi : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO BUOIS (ID, NAME) VALUES (1, 'Sáng')");
            Sql("INSERT INTO BUOIS (ID, NAME) VALUES (2, 'Chiều')");
            Sql("INSERT INTO BUOIS (ID, NAME) VALUES (3, 'Tối')");
        }
        
        public override void Down()
        {
        }
    }
}
