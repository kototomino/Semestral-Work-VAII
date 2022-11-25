namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MtoMUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkoutCustomers", "Workout_Id", "dbo.Workouts");
            DropForeignKey("dbo.WorkoutCustomers", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.WorkoutCustomers", new[] { "Workout_Id" });
            DropIndex("dbo.WorkoutCustomers", new[] { "Customer_Id" });
            CreateTable(
                "dbo.Customer_Workout",
                c => new
                {
                    CustomerId = c.Int(nullable: false),
                    WorkoutId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.CustomerId, t.WorkoutId })
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Workouts", t => t.WorkoutId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.WorkoutId);

            DropColumn("dbo.Customers", "CustomerId");
            DropColumn("dbo.Workouts", "WorkoutId");
            DropTable("dbo.WorkoutCustomers");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.WorkoutCustomers",
                c => new
                {
                    Workout_Id = c.Int(nullable: false),
                    Customer_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Workout_Id, t.Customer_Id });

            AddColumn("dbo.Workouts", "WorkoutId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CustomerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Customer_Workout", "WorkoutId", "dbo.Workouts");
            DropForeignKey("dbo.Customer_Workout", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Customer_Workout", new[] { "WorkoutId" });
            DropIndex("dbo.Customer_Workout", new[] { "CustomerId" });
            DropTable("dbo.Customer_Workout");
            CreateIndex("dbo.WorkoutCustomers", "Customer_Id");
            CreateIndex("dbo.WorkoutCustomers", "Workout_Id");
            AddForeignKey("dbo.WorkoutCustomers", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkoutCustomers", "Workout_Id", "dbo.Workouts", "Id", cascadeDelete: true);
        }
    }
}
