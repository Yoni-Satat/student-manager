namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendancy",
                c => new
                    {
                        AttendancyID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        TutorName = c.String(),
                        LessonStart = c.DateTime(),
                        LessonEnd = c.DateTime(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.AttendancyID)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.Lesson",
                c => new
                    {
                        LessonID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        LocationID = c.Int(),
                        Topic = c.String(),
                        LessonStart = c.DateTime(),
                        LessonEnd = c.DateTime(),
                        IsMandatory = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.LessonID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .Index(t => t.CourseID)
                .Index(t => t.LocationID);
            
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
            AlterColumn("dbo.Student", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Student", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendancy", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Lesson", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Lesson", "CourseID", "dbo.Course");
            DropForeignKey("dbo.GroupAttendancy", "AttendancyID", "dbo.Attendancy");
            DropForeignKey("dbo.GroupAttendancy", "GroupID", "dbo.Group");
            DropIndex("dbo.GroupAttendancy", new[] { "AttendancyID" });
            DropIndex("dbo.GroupAttendancy", new[] { "GroupID" });
            DropIndex("dbo.Lesson", new[] { "LocationID" });
            DropIndex("dbo.Lesson", new[] { "CourseID" });
            DropIndex("dbo.Attendancy", new[] { "LocationID" });
            AlterColumn("dbo.Student", "LastName", c => c.String());
            AlterColumn("dbo.Student", "FirstName", c => c.String());
            DropColumn("dbo.Student", "IsPresent");
            DropTable("dbo.GroupAttendancy");
            DropTable("dbo.Location");
            DropTable("dbo.Lesson");
            DropTable("dbo.Attendancy");
        }
    }
}
