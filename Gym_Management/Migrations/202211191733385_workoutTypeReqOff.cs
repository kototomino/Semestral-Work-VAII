namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workoutTypeReqOff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workouts", "WorkoutType_Id", "dbo.WorkoutTypes");
            DropIndex("dbo.Workouts", new[] { "WorkoutType_Id" });
            AlterColumn("dbo.Workouts", "WorkoutType_Id", c => c.Int());
            CreateIndex("dbo.Workouts", "WorkoutType_Id");
            AddForeignKey("dbo.Workouts", "WorkoutType_Id", "dbo.WorkoutTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "WorkoutType_Id", "dbo.WorkoutTypes");
            DropIndex("dbo.Workouts", new[] { "WorkoutType_Id" });
            AlterColumn("dbo.Workouts", "WorkoutType_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Workouts", "WorkoutType_Id");
            AddForeignKey("dbo.Workouts", "WorkoutType_Id", "dbo.WorkoutTypes", "Id", cascadeDelete: true);
        }
    }
}
