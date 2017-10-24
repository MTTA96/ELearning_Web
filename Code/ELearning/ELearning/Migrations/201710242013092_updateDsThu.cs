namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDsThu : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO THUS (ID, NAME) VALUES (1, 'T2')");
            Sql("INSERT INTO THUS (ID, NAME) VALUES (2, 'T3')");
            Sql("INSERT INTO THUS (ID, NAME) VALUES (3, 'T4')");
            Sql("INSERT INTO THUS (ID, NAME) VALUES (4, 'T5')");
            Sql("INSERT INTO THUS (ID, NAME) VALUES (5, 'T6')");
            Sql("INSERT INTO THUS (ID, NAME) VALUES (6, 'T7')");
            Sql("INSERT INTO THUS (ID, NAME) VALUES (7, 'CN')");
        }
        
        public override void Down()
        {
        }
    }
}
