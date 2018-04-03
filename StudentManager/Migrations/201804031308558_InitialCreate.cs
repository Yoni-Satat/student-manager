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
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        MatricNumber = c.String(),
                        Gender = c.String(),
                        Adjustments = c.Boolean(nullable: false),
                        Origin = c.String(),
                        YearOfStudy = c.Int(nullable: false),
                        ImageURL = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
            CreateTable(
                "dbo.GroupStudent",
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
            DropForeignKey("dbo.Group", "CourseID", "dbo.Course");
            DropForeignKey("dbo.GroupStudent", "StudentID", "dbo.Student");
            DropForeignKey("dbo.GroupStudent", "GroupID", "dbo.Group");
            DropIndex("dbo.GroupStudent", new[] { "StudentID" });
            DropIndex("dbo.GroupStudent", new[] { "GroupID" });
            DropIndex("dbo.Group", new[] { "CourseID" });
            DropTable("dbo.GroupStudent");
            DropTable("dbo.Student");
            DropTable("dbo.Group");
            DropTable("dbo.Course");
        }
    }
}
