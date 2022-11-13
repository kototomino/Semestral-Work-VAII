namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "TimeSend", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Coaches", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "StartDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "EndDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Workouts", "StartDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Workouts", "EndDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workouts", "EndDateTime", c => c.String(nullable: false));
            AlterColumn("dbo.Workouts", "StartDateTime", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EndDateTime", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "StartDateTime", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.String(nullable: false));
            AlterColumn("dbo.Coaches", "DateOfBirth", c => c.String(nullable: false));
            DropColumn("dbo.Messages", "TimeSend");
        }
    }
}
