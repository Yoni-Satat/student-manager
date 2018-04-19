namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewGroupAttendancyTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseAttendancyRecord", "Course_CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord");
            DropForeignKey("dbo.GroupAttendancyRecord", "Group_GroupID", "dbo.Group");
            DropForeignKey("dbo.GroupAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord");
            DropForeignKey("dbo.StudentAttendancyRecord", "Student_StudentID", "dbo.Student");
            DropForeignKey("dbo.StudentAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord");
            DropForeignKey("dbo.LessonAttendancyRecord", "Lesson_LessonID", "dbo.Lesson");
            DropForeignKey("dbo.LessonAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord");
            DropForeignKey("dbo.LocationAttendancyRecord", "Location_LocationID", "dbo.Location");
            DropForeignKey("dbo.LocationAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord");
            DropIndex("dbo.CourseAttendancyRecord", new[] { "Course_CourseID" });
            DropIndex("dbo.CourseAttendancyRecord", new[] { "AttendancyRecord_AttendancyRecordID" });
            DropIndex("dbo.GroupAttendancyRecord", new[] { "Group_GroupID" });
            DropIndex("dbo.GroupAttendancyRecord", new[] { "AttendancyRecord_AttendancyRecordID" });
            DropIndex("dbo.StudentAttendancyRecord", new[] { "Student_StudentID" });
            DropIndex("dbo.StudentAttendancyRecord", new[] { "AttendancyRecord_AttendancyRecordID" });
            DropIndex("dbo.LessonAttendancyRecord", new[] { "Lesson_LessonID" });
            DropIndex("dbo.LessonAttendancyRecord", new[] { "AttendancyRecord_AttendancyRecordID" });
            DropIndex("dbo.LocationAttendancyRecord", new[] { "Location_LocationID" });
            DropIndex("dbo.LocationAttendancyRecord", new[] { "AttendancyRecord_AttendancyRecordID" });
            CreateTable(
                "dbo.Attendancy",
                c => new
                    {
                        AttendancyID = c.Int(nullable: false, identity: true),
                        IsPresent = c.Boolean(nullable: false),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.AttendancyID);
            
            CreateTable(
                "dbo.GroupAttendancy",
                c => new
                    {
                        GroupID = c.Int(nullable: false),
                        AttendancyID = c.Int(nullable: false),
                        StudentName = c.String(),
                        TutorName = c.String(),
                        notes = c.String(),
                        Date = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => new { t.GroupID, t.AttendancyID })
                .ForeignKey("dbo.Attendancy", t => t.AttendancyID, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.Location_LocationID)
                .Index(t => t.GroupID)
                .Index(t => t.AttendancyID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "dbo.GroupAttendancy1",
                c => new
                    {
                        Group_GroupID = c.Int(nullable: false),
                        Attendancy_AttendancyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_GroupID, t.Attendancy_AttendancyID })
                .ForeignKey("dbo.Group", t => t.Group_GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Attendancy", t => t.Attendancy_AttendancyID, cascadeDelete: true)
                .Index(t => t.Group_GroupID)
                .Index(t => t.Attendancy_AttendancyID);
            
            DropTable("dbo.AttendancyRecord");
            DropTable("dbo.CourseAttendancyRecord");
            DropTable("dbo.GroupAttendancyRecord");
            DropTable("dbo.StudentAttendancyRecord");
            DropTable("dbo.LessonAttendancyRecord");
            DropTable("dbo.LocationAttendancyRecord");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LocationAttendancyRecord",
                c => new
                    {
                        Location_LocationID = c.Int(nullable: false),
                        AttendancyRecord_AttendancyRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Location_LocationID, t.AttendancyRecord_AttendancyRecordID });
            
            CreateTable(
                "dbo.LessonAttendancyRecord",
                c => new
                    {
                        Lesson_LessonID = c.Int(nullable: false),
                        AttendancyRecord_AttendancyRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Lesson_LessonID, t.AttendancyRecord_AttendancyRecordID });
            
            CreateTable(
                "dbo.StudentAttendancyRecord",
                c => new
                    {
                        Student_StudentID = c.Int(nullable: false),
                        AttendancyRecord_AttendancyRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentID, t.AttendancyRecord_AttendancyRecordID });
            
            CreateTable(
                "dbo.GroupAttendancyRecord",
                c => new
                    {
                        Group_GroupID = c.Int(nullable: false),
                        AttendancyRecord_AttendancyRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_GroupID, t.AttendancyRecord_AttendancyRecordID });
            
            CreateTable(
                "dbo.CourseAttendancyRecord",
                c => new
                    {
                        Course_CourseID = c.Int(nullable: false),
                        AttendancyRecord_AttendancyRecordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_CourseID, t.AttendancyRecord_AttendancyRecordID });
            
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
            
            DropForeignKey("dbo.GroupAttendancy", "Location_LocationID", "dbo.Location");
            DropForeignKey("dbo.GroupAttendancy", "GroupID", "dbo.Group");
            DropForeignKey("dbo.GroupAttendancy", "AttendancyID", "dbo.Attendancy");
            DropForeignKey("dbo.GroupAttendancy1", "Attendancy_AttendancyID", "dbo.Attendancy");
            DropForeignKey("dbo.GroupAttendancy1", "Group_GroupID", "dbo.Group");
            DropIndex("dbo.GroupAttendancy1", new[] { "Attendancy_AttendancyID" });
            DropIndex("dbo.GroupAttendancy1", new[] { "Group_GroupID" });
            DropIndex("dbo.GroupAttendancy", new[] { "Location_LocationID" });
            DropIndex("dbo.GroupAttendancy", new[] { "AttendancyID" });
            DropIndex("dbo.GroupAttendancy", new[] { "GroupID" });
            DropTable("dbo.GroupAttendancy1");
            DropTable("dbo.GroupAttendancy");
            DropTable("dbo.Attendancy");
            CreateIndex("dbo.LocationAttendancyRecord", "AttendancyRecord_AttendancyRecordID");
            CreateIndex("dbo.LocationAttendancyRecord", "Location_LocationID");
            CreateIndex("dbo.LessonAttendancyRecord", "AttendancyRecord_AttendancyRecordID");
            CreateIndex("dbo.LessonAttendancyRecord", "Lesson_LessonID");
            CreateIndex("dbo.StudentAttendancyRecord", "AttendancyRecord_AttendancyRecordID");
            CreateIndex("dbo.StudentAttendancyRecord", "Student_StudentID");
            CreateIndex("dbo.GroupAttendancyRecord", "AttendancyRecord_AttendancyRecordID");
            CreateIndex("dbo.GroupAttendancyRecord", "Group_GroupID");
            CreateIndex("dbo.CourseAttendancyRecord", "AttendancyRecord_AttendancyRecordID");
            CreateIndex("dbo.CourseAttendancyRecord", "Course_CourseID");
            AddForeignKey("dbo.LocationAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord", "AttendancyRecordID", cascadeDelete: true);
            AddForeignKey("dbo.LocationAttendancyRecord", "Location_LocationID", "dbo.Location", "LocationID", cascadeDelete: true);
            AddForeignKey("dbo.LessonAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord", "AttendancyRecordID", cascadeDelete: true);
            AddForeignKey("dbo.LessonAttendancyRecord", "Lesson_LessonID", "dbo.Lesson", "LessonID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord", "AttendancyRecordID", cascadeDelete: true);
            AddForeignKey("dbo.StudentAttendancyRecord", "Student_StudentID", "dbo.Student", "StudentID", cascadeDelete: true);
            AddForeignKey("dbo.GroupAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord", "AttendancyRecordID", cascadeDelete: true);
            AddForeignKey("dbo.GroupAttendancyRecord", "Group_GroupID", "dbo.Group", "GroupID", cascadeDelete: true);
            AddForeignKey("dbo.CourseAttendancyRecord", "AttendancyRecord_AttendancyRecordID", "dbo.AttendancyRecord", "AttendancyRecordID", cascadeDelete: true);
            AddForeignKey("dbo.CourseAttendancyRecord", "Course_CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
        }
    }
}
