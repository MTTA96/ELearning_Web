namespace ELearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataDiaDiem : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO DIADIEMS VALUES (1,'HCM')");
            Sql("INSERT INTO DIADIEMS VALUES (2,'HN')");
            Sql("INSERT INTO DIADIEMS VALUES (3,'TÂY NINH')");
            Sql("INSERT INTO DIADIEMS VALUES (4,'BÌNH THUẬN')");
            Sql("INSERT INTO DIADIEMS VALUES (5,'KHÁNH HÒA')");
            Sql("INSERT INTO DIADIEMS VALUES (6,'CAO BẰNG')");
            Sql("INSERT INTO DIADIEMS VALUES (7,'LẠNG SƠN')");
            Sql("INSERT INTO DIADIEMS VALUES (8,'BR-VT')");
            Sql("INSERT INTO DIADIEMS VALUES (9,'CÀ MAU')");
            Sql("INSERT INTO DIADIEMS VALUES (10,'AN GIANG')");
        }
        
        public override void Down()
        {
        }
    }
}
