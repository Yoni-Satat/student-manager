namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProjectModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GroupStudent", "GroupID", "dbo.Group");
            DropForeignKey("dbo.GroupStudent", "StudentID", "dbo.Student");
            DropIndex("dbo.GroupStudent", new[] { "GroupID" });
            DropIndex("dbo.GroupStudent", new[] { "StudentID" });
            CreateTable(
                "dbo.Attendancy",
                c => new
                    {
                        AttendancyID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(),
                        TutorName = c.String(),
                        LessonStart = c.DateTime(),
                        LessonEnd = c.DateTime(),
                        AttendancyDate = c.DateTime(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.AttendancyID)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        LessonID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        LocationID = c.Int(),
                        AttendancyID = c.Int(),
                        Topic = c.String(),
                        LessonStart = c.DateTime(),
                        LessonEnd = c.DateTime(),
                        IsMandatory = c.Boolean(nullable: false),
                        Group_GroupID = c.Int(),
                    })
                .PrimaryKey(t => t.LessonID)
                .ForeignKey("dbo.Attendancy", t => t.AttendancyID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .ForeignKey("dbo.Group", t => t.Group_GroupID)
                .Index(t => t.CourseID)
                .Index(t => t.LocationID)
                .Index(t => t.AttendancyID)
                .Index(t => t.Group_GroupID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        Building = c.String(),
                        RoomNumber = c.Double(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.GroupAttendancy",
                c => new
                    {
                        GroupID = c.Int(nullable: false),
                        AttendancyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupID, t.AttendancyID })
                .ForeignKey("dbo.Group", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.Attendancy", t => t.AttendancyID, cascadeDelete: true)
                .Index(t => t.GroupID)
                .Index(t => t.AttendancyID);
            
            AddColumn("dbo.Student", "IsPresent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Student", "Group_GroupID", c => c.Int());
            AlterColumn("dbo.Student", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "LastName", c => c.String(nullable: false));
            CreateIndex("dbo.Student", "Group_GroupID");
            AddForeignKey("dbo.Student", "Group_GroupID", "dbo.Group", "GroupID");
            DropTable("dbo.GroupStudent");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GroupStudent",
                c => new
                    {
                        GroupID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GroupID, t.StudentID });
            
            DropForeignKey("dbo.Attendancy", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Student", "Group_GroupID", "dbo.Group");
            DropForeignKey("dbo.Lesson", "Group_GroupID", "dbo.Group");
            DropForeignKey("dbo.Lesson", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Lesson", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Lesson", "AttendancyID", "dbo.Attendancy");
            DropForeignKey("dbo.GroupAttendancy", "AttendancyID", "dbo.Attendancy");
            DropForeignKey("dbo.GroupAttendancy", "GroupID", "dbo.Group");
            DropIndex("dbo.GroupAttendancy", new[] { "AttendancyID" });
            DropIndex("dbo.GroupAttendancy", new[] { "GroupID" });
            DropIndex("dbo.Student", new[] { "Group_GroupID" });
            DropIndex("dbo.Lesson", new[] { "Group_GroupID" });
            DropIndex("dbo.Lesson", new[] { "AttendancyID" });
            DropIndex("dbo.Lesson", new[] { "LocationID" });
            DropIndex("dbo.Lesson", new[] { "CourseID" });
            DropIndex("dbo.Attendancy", new[] { "LocationID" });
            AlterColumn("dbo.Student", "LastName", c => c.String());
            AlterColumn("dbo.Student", "FirstName", c => c.String());
            DropColumn("dbo.Student", "Group_GroupID");
            DropColumn("dbo.Student", "IsPresent");
            DropTable("dbo.GroupAttendancy");
            DropTable("dbo.Location");
            DropTable("dbo.Lesson");
            DropTable("dbo.Attendancy");
            CreateIndex("dbo.GroupStudent", "StudentID");
            CreateIndex("dbo.GroupStudent", "GroupID");
            AddForeignKey("dbo.GroupStudent", "StudentID", "dbo.Student", "StudentID", cascadeDelete: true);
            AddForeignKey("dbo.GroupStudent", "GroupID", "dbo.Group", "GroupID", cascadeDelete: true);
        }
    }
}
