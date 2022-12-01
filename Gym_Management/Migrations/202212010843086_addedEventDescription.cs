namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEventDescription : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coaches", "Event_Id", "dbo.Events");
            DropIndex("dbo.Coaches", new[] { "Event_Id" });
            AddColumn("dbo.Events", "Description", c => c.String(maxLength: 200));
            DropColumn("dbo.Coaches", "Event_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coaches", "Event_Id", c => c.Int());
            DropColumn("dbo.Events", "Description");
            CreateIndex("dbo.Coaches", "Event_Id");
            AddForeignKey("dbo.Coaches", "Event_Id", "dbo.Events", "Id");
        }
    }
}
