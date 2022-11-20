namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkoutUpdated2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workouts", "Coach_Id", "dbo.Coaches");
            DropIndex("dbo.Workouts", new[] { "Coach_Id" });
            RenameColumn(table: "dbo.Workouts", name: "Coach_Id", newName: "CoachId");
            AlterColumn("dbo.Workouts", "CoachId", c => c.Int(nullable: false));
            CreateIndex("dbo.Workouts", "CoachId");
            AddForeignKey("dbo.Workouts", "CoachId", "dbo.Coaches", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "CoachId", "dbo.Coaches");
            DropIndex("dbo.Workouts", new[] { "CoachId" });
            AlterColumn("dbo.Workouts", "CoachId", c => c.Int());
            RenameColumn(table: "dbo.Workouts", name: "CoachId", newName: "Coach_Id");
            CreateIndex("dbo.Workouts", "Coach_Id");
            AddForeignKey("dbo.Workouts", "Coach_Id", "dbo.Coaches", "Id");
        }
    }
}
