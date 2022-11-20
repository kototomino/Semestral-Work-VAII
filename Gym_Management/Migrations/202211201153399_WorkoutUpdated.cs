namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkoutUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workouts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Workouts", new[] { "Customer_Id" });
            AddColumn("dbo.Customers", "Workout_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Workout_Id");
            AddForeignKey("dbo.Customers", "Workout_Id", "dbo.Workouts", "Id");
            DropColumn("dbo.Workouts", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workouts", "Customer_Id", c => c.Int());
            DropForeignKey("dbo.Customers", "Workout_Id", "dbo.Workouts");
            DropIndex("dbo.Customers", new[] { "Workout_Id" });
            DropColumn("dbo.Customers", "Workout_Id");
            CreateIndex("dbo.Workouts", "Customer_Id");
            AddForeignKey("dbo.Workouts", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
