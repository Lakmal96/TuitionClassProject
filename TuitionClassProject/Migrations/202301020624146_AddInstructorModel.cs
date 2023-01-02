namespace TuitionClassProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstructorModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ProfilePicture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Instructors");
        }
    }
}
