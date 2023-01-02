namespace TuitionClassProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Courses", name: "Category_Id", newName: "CategoryId");
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Student_Id = c.Int(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.CourseId, t.StudentId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.InstructorStudents",
                c => new
                    {
                        InstructorId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Instructor_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.InstructorId, t.StudentId })
                .ForeignKey("dbo.Instructors", t => t.Instructor_Id)
                .ForeignKey("dbo.Instructors", t => t.InstructorId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.InstructorId)
                .Index(t => t.StudentId)
                .Index(t => t.Instructor_Id)
                .Index(t => t.Student_Id);
            
            AddColumn("dbo.Instructors", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Students", "CategoryId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Courses", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Courses", "CategoryId");
            CreateIndex("dbo.Students", "CategoryId");
            CreateIndex("dbo.Instructors", "CategoryId");
            AddForeignKey("dbo.Students", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Instructors", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CourseStudents", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.CourseStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.InstructorStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.InstructorStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.InstructorStudents", "InstructorId", "dbo.Instructors");
            DropForeignKey("dbo.InstructorStudents", "Instructor_Id", "dbo.Instructors");
            DropForeignKey("dbo.Instructors", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CourseStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CourseStudents", "CourseId", "dbo.Courses");
            DropIndex("dbo.Instructors", new[] { "CategoryId" });
            DropIndex("dbo.InstructorStudents", new[] { "Student_Id" });
            DropIndex("dbo.InstructorStudents", new[] { "Instructor_Id" });
            DropIndex("dbo.InstructorStudents", new[] { "StudentId" });
            DropIndex("dbo.InstructorStudents", new[] { "InstructorId" });
            DropIndex("dbo.Students", new[] { "CategoryId" });
            DropIndex("dbo.CourseStudents", new[] { "Course_Id" });
            DropIndex("dbo.CourseStudents", new[] { "Student_Id" });
            DropIndex("dbo.CourseStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseStudents", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            AlterColumn("dbo.Courses", "CategoryId", c => c.Byte());
            DropColumn("dbo.Students", "CategoryId");
            DropColumn("dbo.Instructors", "CategoryId");
            DropTable("dbo.InstructorStudents");
            DropTable("dbo.CourseStudents");
            RenameColumn(table: "dbo.Courses", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Courses", "Category_Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
