namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixesWorkouts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Workout_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Workout_Id");
            AddForeignKey("dbo.Customers", "Workout_Id", "dbo.Workouts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Workout_Id", "dbo.Workouts");
            DropIndex("dbo.Customers", new[] { "Workout_Id" });
            DropColumn("dbo.Customers", "Workout_Id");
        }
    }
}
