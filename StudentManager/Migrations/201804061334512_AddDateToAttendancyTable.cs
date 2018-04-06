namespace StudentManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToAttendancyTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendancy", "AttendancyDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attendancy", "AttendancyDate");
        }
    }
}
