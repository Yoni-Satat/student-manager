namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLesson : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        LessonID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        LessonLocationID = c.Int(nullable: false),
                        Topic = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        IsMandatory = c.Boolean(nullable: false),
                        LessonLocation_LessonLocationID = c.Int(),
                    })
                .PrimaryKey(t => t.LessonID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.LessonLocation", t => t.LessonLocation_LessonLocationID)
                .Index(t => t.CourseID)
                .Index(t => t.LessonLocation_LessonLocationID);
            
            CreateTable(
                "dbo.LessonLocation",
                c => new
                    {
                        LessonLocationID = c.Int(nullable: false, identity: true),
                        LessonID = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.LessonLocationID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lesson", "LessonLocation_LessonLocationID", "dbo.LessonLocation");
            DropForeignKey("dbo.Lesson", "CourseID", "dbo.Course");
            DropIndex("dbo.Lesson", new[] { "LessonLocation_LessonLocationID" });
            DropIndex("dbo.Lesson", new[] { "CourseID" });
            DropTable("dbo.LessonLocation");
            DropTable("dbo.Lesson");
        }
    }
}
