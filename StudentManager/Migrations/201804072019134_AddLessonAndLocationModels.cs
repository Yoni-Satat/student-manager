namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLessonAndLocationModels : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lesson", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Lesson", "CourseID", "dbo.Course");
            DropIndex("dbo.Lesson", new[] { "LocationID" });
            DropIndex("dbo.Lesson", new[] { "CourseID" });
            DropTable("dbo.Location");
            DropTable("dbo.Lesson");
        }
    }
}
