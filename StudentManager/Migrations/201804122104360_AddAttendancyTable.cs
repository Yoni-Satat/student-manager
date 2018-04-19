namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendancyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendancyRecord",
                c => new
                    {
                        AttendancyRecordID = c.Int(nullable: false, identity: true),
                        IsPresent = c.Boolean(nullable: false),
                        Comments = c.String(),
                        DateAndTime = c.DateTime(nullable: false),
                        TutorName = c.String(),
                    })
                .PrimaryKey(t => t.AttendancyRecordID);
            
            CreateTable(
                "dbo.CourseAttendancyRecord",
                c => new
                    {
                        Course_CourseID = c.Int(nullable: false),
                        AttendancyRecord_AttendancyRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_CourseID, t.AttendancyRecord_AttendancyRecordID })
                .ForeignKey("dbo.Course", t => t.Course_CourseID, cascadeDelete: true)
                .ForeignKey("dbo.AttendancyRecord", t => t.AttendancyRecord_AttendancyRecordID, cascadeDelete: true)
                .Index(t => t.Course_CourseID)
                .Index(t => t.AttendancyRecord_AttendancyRecordID);
            
            CreateTable(
                "dbo.GroupAttendancyRecord",
                c => new
                    {
                        Group_GroupID = c.Int(nullable: false),
                        AttendancyRecord_AttendancyRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_GroupID, t.AttendancyRecord_AttendancyRecordID })
                .ForeignKey("dbo.Group", t => t.Group_GroupID, cascadeDelete: true)
                .ForeignKey("dbo.AttendancyRecord", t => t.AttendancyRecord_AttendancyRecordID, cascadeDelete: true)
                .Index(t => t.Group_GroupID)
                .Index(t => t.AttendancyRecord_AttendancyRecordID);
            
            CreateTable(
                "dbo.StudentAttendancyRecord",
                c => new
                    {
                        Student_StudentID = c.Int(nullable: false),
                        AttendancyRecord_AttendancyRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentID, t.AttendancyRecord_AttendancyRecordID })
                .ForeignKey("dbo.Student", t => t.Student_StudentID, cascadeDelete: true)
                .ForeignKey("dbo.AttendancyRecord", t => t.AttendancyRecord_AttendancyRecordID, cascadeDelete: true)
                .Index(t => t.Student_StudentID)
                .Index(t => t.AttendancyRecord_AttendancyRecordID);
            
            CreateTable(
                "dbo.LessonAttendancyRecord",
                c => new
                    {
                        Lesson_LessonID = c.Int(nullable: false),
                        AttendancyRecord_AttendancyRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lesson_LessonID, t.AttendancyRecord_AttendancyRecordID })
                .ForeignKey("dbo.Lesson", t => t.Lesson_LessonID, cascadeDelete: true)
                .ForeignKey("dbo.AttendancyRecord", t => t.AttendancyRecord_AttendancyRecordID, cascadeDelete: true)
                .Index(t => t.Lesson_LessonID)
                .Index(t => t.AttendancyRecord_AttendancyRecordID);
            
            CreateTable(
                "dbo.LocationAttendancyRecord",
                c => new
                    {
                        Location_LocationID = c.Int(nullable: false),
                        AttendancyRecord_AttendancyRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Location_LocationID, t.AttendancyRecord_AttendancyRecordID })
                .ForeignKey("dbo.Location", t => t.Location_LocationID, cascadeDelete: true)
                .ForeignKey("dbo.AttendancyRecord", t => t.AttendancyRecord_AttendancyRecordID, cascadeDelete: true)
                .Index(t => t.Location_LocationID)
                .Index(t => t.AttendancyRecord_AttendancyRecordID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LocationAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord");
            DropForeignKey("dbo.LocationAttendancyRecord", "Location_LocationID", "dbo.Location");
            DropForeignKey("dbo.LessonAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord");
            DropForeignKey("dbo.LessonAttendancyRecord", "Lesson_LessonID", "dbo.Lesson");
            DropForeignKey("dbo.StudentAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord");
            DropForeignKey("dbo.StudentAttendancyRecord", "Student_StudentID", "dbo.Student");
            DropForeignKey("dbo.GroupAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord");
            DropForeignKey("dbo.GroupAttendancyRecord", "Group_GroupID", "dbo.Group");
            DropForeignKey("dbo.CourseAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord");
            DropForeignKey("dbo.CourseAttendancyRecord", "Course_CourseID", "dbo.Course");
            DropIndex("dbo.LocationAttendancyRecord", new[] { "AttendancyRecord_AttendancyRecordID" });
            DropIndex("dbo.LocationAttendancyRecord", new[] { "Location_LocationID" });
            DropIndex("dbo.LessonAttendancyRecord", new[] { "AttendancyRecord_AttendancyRecordID" });
            DropIndex("dbo.LessonAttendancyRecord", new[] { "Lesson_LessonID" });
            DropIndex("dbo.StudentAttendancyRecord", new[] { "AttendancyRecord_AttendancyRecordID" });
            DropIndex("dbo.StudentAttendancyRecord", new[] { "Student_StudentID" });
            DropIndex("dbo.GroupAttendancyRecord", new[] { "AttendancyRecord_AttendancyRecordID" });
            DropIndex("dbo.GroupAttendancyRecord", new[] { "Group_GroupID" });
            DropIndex("dbo.CourseAttendancyRecord", new[] { "AttendancyRecord_AttendancyRecordID" });
            DropIndex("dbo.CourseAttendancyRecord", new[] { "Course_CourseID" });
            DropTable("dbo.LocationAttendancyRecord");
            DropTable("dbo.LessonAttendancyRecord");
            DropTable("dbo.StudentAttendancyRecord");
            DropTable("dbo.GroupAttendancyRecord");
            DropTable("dbo.CourseAttendancyRecord");
            DropTable("dbo.AttendancyRecord");
        }
    }
}
