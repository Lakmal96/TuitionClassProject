namespace TuitionClassProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyRelationshipCourseAndInstructor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InstructorStudents", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.InstructorStudents", "InstructorId", "dbo.Instructors");
            DropPrimaryKey("dbo.Instructors");
            AddColumn("dbo.Courses", "InstructorId", c => c.Int(nullable: false));
            AddColumn("dbo.Instructors", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Instructors", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Instructors", "Id");
            CreateIndex("dbo.Instructors", "Id");
            AddForeignKey("dbo.Instructors", "Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.InstructorStudents", "Instructor_Id", "dbo.Instructors", "Id");
            AddForeignKey("dbo.InstructorStudents", "InstructorId", "dbo.Instructors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstructorStudents", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.InstructorStudents", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.Instructors", "Id", "dbo.Courses");
            DropIndex("dbo.Instructors", new[] { "Id" });
            DropPrimaryKey("dbo.Instructors");
            AlterColumn("dbo.Instructors", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Instructors", "CourseId");
            DropColumn("dbo.Courses", "InstructorId");
            AddPrimaryKey("dbo.Instructors", "Id");
            AddForeignKey("dbo.InstructorStudents", "InstructorId", "dbo.Instructors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InstructorStudents", "Instructor_Id", "dbo.Instructors", "Id");
        }
    }
}
