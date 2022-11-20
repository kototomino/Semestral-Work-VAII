namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workoutTypeReqNameOf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkoutTypes", "Name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkoutTypes", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
