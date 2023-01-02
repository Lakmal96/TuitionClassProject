namespace TuitionClassProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Duration", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Courses", "Schedule", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Students", "IndexNumber", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "ContactNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Instructors", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Instructors", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Instructors", "Description", c => c.String());
            AlterColumn("dbo.Instructors", "Name", c => c.String());
            AlterColumn("dbo.Students", "ContactNumber", c => c.String());
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "IndexNumber", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Schedule", c => c.String());
            AlterColumn("dbo.Courses", "Duration", c => c.String());
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
