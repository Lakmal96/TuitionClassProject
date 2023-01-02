namespace TuitionClassProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'English')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Physical Science')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Bio Science')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Commerce')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (5, 'Art')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (6, 'Other')");
        }
        
        public override void Down()
        {
        }
    }
}
