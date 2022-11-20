namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSignedCustomerToWorkout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SignedCustomerToWorkouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkoutId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SignedCustomerToWorkouts");
        }
    }
}
