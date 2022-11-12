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
                        Name = c.String(nullable: false),
                        SurName = c.String(nullable: false),
                        DateOfBirth = c.String(nullable: false),
                        SkillDegree = c.Int(nullable: false),
                        Description = c.String(),
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
                        Name = c.String(nullable: false),
                        SurName = c.String(nullable: false),
                        DateOfBirth = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDateTime = c.String(nullable: false),
                        EndDateTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GearType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDateTime = c.String(nullable: false),
                        EndDateTime = c.String(nullable: false),
                        Capacity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Coach_Id = c.Int(),
                        Customer_Id = c.Int(),
                        WorkoutType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Coaches", t => t.Coach_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.WorkoutTypes", t => t.WorkoutType_Id, cascadeDelete: true)
                .Index(t => t.Coach_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.WorkoutType_Id);
            
            CreateTable(
                "dbo.WorkoutTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workouts", "WorkoutType_Id", "dbo.WorkoutTypes");
            DropForeignKey("dbo.Workouts", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Workouts", "Coach_Id", "dbo.Coaches");
            DropForeignKey("dbo.Coaches", "Event_Id", "dbo.Events");
            DropIndex("dbo.Workouts", new[] { "WorkoutType_Id" });
            DropIndex("dbo.Workouts", new[] { "Customer_Id" });
            DropIndex("dbo.Workouts", new[] { "Coach_Id" });
            DropIndex("dbo.Coaches", new[] { "Event_Id" });
            DropTable("dbo.WorkoutTypes");
            DropTable("dbo.Workouts");
            DropTable("dbo.Products");
            DropTable("dbo.Messages");
            DropTable("dbo.Gears");
            DropTable("dbo.Events");
            DropTable("dbo.Customers");
            DropTable("dbo.Coaches");
        }
    }
}
