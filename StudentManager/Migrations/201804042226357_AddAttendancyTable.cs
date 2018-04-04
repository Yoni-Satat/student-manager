namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendancyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendancy",
                c => new
                    {
                        AttendancyID = c.Int(nullable: false, identity: true),
                        TutorName = c.String(),
                        LessonLocationID = c.Int(nullable: false),
                        LessonTopic = c.String(),
                        StudentName = c.String(),
                        IsPresent = c.Boolean(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.AttendancyID);
            
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
                        Building = c.String(),
                        RoomNumber = c.Double(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.LessonLocationID);
            
            CreateTable(
                "dbo.GroupAttendancy",
                c => new
                    {
                        GroupID = c.Int(nullable: false),
                        AttendancyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupID, t.AttendancyID })
                .ForeignKey("dbo.Attendancy", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.AttendancyID, cascadeDelete: true)
                .Index(t => t.GroupID)
                .Index(t => t.AttendancyID);
            
            AlterColumn("dbo.Student", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupAttendancy", "AttendancyID", "dbo.Group");
            DropForeignKey("dbo.GroupAttendancy", "GroupID", "dbo.Attendancy");
            DropForeignKey("dbo.Lesson", "LessonLocation_LessonLocationID", "dbo.LessonLocation");
            DropForeignKey("dbo.Lesson", "CourseID", "dbo.Course");
            DropIndex("dbo.GroupAttendancy", new[] { "AttendancyID" });
            DropIndex("dbo.GroupAttendancy", new[] { "GroupID" });
            DropIndex("dbo.Lesson", new[] { "LessonLocation_LessonLocationID" });
            DropIndex("dbo.Lesson", new[] { "CourseID" });
            AlterColumn("dbo.Student", "LastName", c => c.String());
            AlterColumn("dbo.Student", "FirstName", c => c.String());
            DropTable("dbo.GroupAttendancy");
            DropTable("dbo.LessonLocation");
            DropTable("dbo.Lesson");
            DropTable("dbo.Attendancy");
        }
    }
}
