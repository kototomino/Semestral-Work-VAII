namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedWorkoutIncidentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SignedCoachToWorkouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoachId = c.Int(nullable: false),
                        WorkoutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            CreateTable(
                "dbo.SignedWorkoutTypeToWorkouts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    WorkoutId = c.Int(nullable: false),
                    WorkoutTypeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropTable("dbo.SignedCoachToWorkouts");
            DropTable("dbo.SignedWorkoutTypeToWorkouts");
        }
    }
}
