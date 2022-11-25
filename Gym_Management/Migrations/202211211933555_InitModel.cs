namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coaches",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    SurName = c.String(nullable: false, maxLength: 50),
                    DateOfBirth = c.DateTime(nullable: false),
                    SkillDegree = c.Int(nullable: false),
                    Description = c.String(maxLength: 500),
                    Event_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .Index(t => t.Event_Id);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerId = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    SurName = c.String(nullable: false, maxLength: 50),
                    DateOfBirth = c.DateTime(nullable: false),
                    Description = c.String(maxLength: 500),
                    Email = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Workouts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    WorkoutId = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 70),
                    WorkoutTypeId = c.Int(nullable: false),
                    StartDateTime = c.DateTime(nullable: false),
                    EndDateTime = c.DateTime(nullable: false),
                    CoachId = c.Int(nullable: false),
                    Capacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coaches", t => t.CoachId, cascadeDelete: true)
                .ForeignKey("dbo.WorkoutTypes", t => t.WorkoutTypeId, cascadeDelete: true)
                .Index(t => t.WorkoutTypeId)
                .Index(t => t.CoachId);

            CreateTable(
                "dbo.WorkoutTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(maxLength: 20),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Events",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    StartDateTime = c.DateTime(nullable: false),
                    EndDateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Gears",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    GearType = c.String(maxLength: 20),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Messages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 20),
                    Content = c.String(nullable: false, maxLength: 500),
                    TimeSend = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ProductType = c.String(maxLength: 20),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.WorkoutCustomers",
                c => new
                {
                    Workout_Id = c.Int(nullable: false),
                    Customer_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Workout_Id, t.Customer_Id })
                .ForeignKey("dbo.Workouts", t => t.Workout_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Workout_Id)
                .Index(t => t.Customer_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Coaches", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Workouts", "WorkoutTypeId", "dbo.WorkoutTypes");
            DropForeignKey("dbo.WorkoutCustomers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.WorkoutCustomers", "Workout_Id", "dbo.Workouts");
            DropForeignKey("dbo.Workouts", "CoachId", "dbo.Coaches");
            DropIndex("dbo.WorkoutCustomers", new[] { "Customer_Id" });
            DropIndex("dbo.WorkoutCustomers", new[] { "Workout_Id" });
            DropIndex("dbo.Workouts", new[] { "CoachId" });
            DropIndex("dbo.Workouts", new[] { "WorkoutTypeId" });
            DropIndex("dbo.Coaches", new[] { "Event_Id" });
            DropTable("dbo.WorkoutCustomers");
            DropTable("dbo.Products");
            DropTable("dbo.Messages");
            DropTable("dbo.Gears");
            DropTable("dbo.Events");
            DropTable("dbo.WorkoutTypes");
            DropTable("dbo.Workouts");
            DropTable("dbo.Customers");
            DropTable("dbo.Coaches");
        }
    }
}
