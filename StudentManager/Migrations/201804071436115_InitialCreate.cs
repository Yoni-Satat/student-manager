namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        Title = c.String(),
                        Level = c.String(),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        GroupTitle = c.String(),
                    })
                .PrimaryKey(t => t.GroupID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        MatricNumber = c.String(),
                        Gender = c.String(),
                        Adjustments = c.Boolean(nullable: false),
                        Origin = c.String(),
                        YearOfStudy = c.Int(nullable: false),
                        ImageURL = c.String(),
                        IsPresent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.StudentGroup",
                c => new
                    {
                        GroupID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupID, t.StudentID })
                .ForeignKey("dbo.Group", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.GroupID)
                .Index(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentGroup", "StudentID", "dbo.Student");
            DropForeignKey("dbo.StudentGroup", "GroupID", "dbo.Group");
            DropForeignKey("dbo.Group", "CourseID", "dbo.Course");
            DropIndex("dbo.StudentGroup", new[] { "StudentID" });
            DropIndex("dbo.StudentGroup", new[] { "GroupID" });
            DropIndex("dbo.Group", new[] { "CourseID" });
            DropTable("dbo.StudentGroup");
            DropTable("dbo.Student");
            DropTable("dbo.Group");
            DropTable("dbo.Course");
        }
    }
}
