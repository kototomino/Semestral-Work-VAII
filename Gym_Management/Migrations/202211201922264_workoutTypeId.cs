namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workoutTypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workouts", "WorkoutType_Id", "dbo.WorkoutTypes");
            DropIndex("dbo.Workouts", new[] { "WorkoutType_Id" });
            RenameColumn(table: "dbo.Workouts", name: "WorkoutType_Id", newName: "WorkoutTypeId");
            AlterColumn("dbo.Workouts", "WorkoutTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Workouts", "WorkoutTypeId");
            AddForeignKey("dbo.Workouts", "WorkoutTypeId", "dbo.WorkoutTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "WorkoutTypeId", "dbo.WorkoutTypes");
            DropIndex("dbo.Workouts", new[] { "WorkoutTypeId" });
            AlterColumn("dbo.Workouts", "WorkoutTypeId", c => c.Int());
            RenameColumn(table: "dbo.Workouts", name: "WorkoutTypeId", newName: "WorkoutType_Id");
            CreateIndex("dbo.Workouts", "WorkoutType_Id");
            AddForeignKey("dbo.Workouts", "WorkoutType_Id", "dbo.WorkoutTypes", "Id");
        }
    }
}
