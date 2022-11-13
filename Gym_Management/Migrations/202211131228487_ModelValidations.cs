namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Coaches", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Coaches", "SurName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Coaches", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "SurName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Customers", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Gears", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Gears", "GearType", c => c.String(maxLength: 20));
            AlterColumn("dbo.Messages", "Title", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "ProductType", c => c.String(maxLength: 20));
            AlterColumn("dbo.Workouts", "Name", c => c.String(nullable: false, maxLength: 70));
            AlterColumn("dbo.WorkoutTypes", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkoutTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Workouts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductType", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Gears", "GearType", c => c.String());
            AlterColumn("dbo.Gears", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Description", c => c.String());
            AlterColumn("dbo.Customers", "SurName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Coaches", "Description", c => c.String());
            AlterColumn("dbo.Coaches", "SurName", c => c.String(nullable: false));
            AlterColumn("dbo.Coaches", "Name", c => c.String(nullable: false));
        }
    }
}
