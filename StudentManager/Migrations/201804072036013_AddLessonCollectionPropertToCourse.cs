namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLessonCollectionPropertToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lesson", "Date", c => c.DateTime());
            DropColumn("dbo.Student", "IsPresent");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "IsPresent", c => c.Boolean(nullable: false));
            DropColumn("dbo.Lesson", "Date");
        }
    }
}
