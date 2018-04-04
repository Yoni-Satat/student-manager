namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSeedConig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lesson", "StartTime", c => c.DateTime());
            AlterColumn("dbo.Lesson", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lesson", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Lesson", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
