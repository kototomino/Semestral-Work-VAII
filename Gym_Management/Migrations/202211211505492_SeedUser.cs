namespace Gym_Management.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'82a410cb-c661-4247-ae48-18da4ac4430f', N'admin@gym.sk', 0, N'AGk4EV3AWptxEndXrpLP71aYHpmIU6xdbvzpRXe5LpzpCHvZQJxg5ZG1nwteenq1/w==', N'634081df-1d17-4665-94ef-dc170ff6d920', NULL, 0, 0, NULL, 1, 0, N'admin@gym.sk')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'89c2543a-5072-49d4-a5df-ef48d2f864a7', N'customer@gym.sk', 0, N'AAZTWpoSGoQf8LTI707AkqJZSuGaKvS6NH3pou2kzf/coORsvrwOIyT1x6M12eGfWA==', N'5313d9b8-1f0f-423e-879a-fde75e3b6106', NULL, 0, 0, NULL, 1, 0, N'customer@gym.sk')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ec9b2772-6948-48cc-963e-33d4646047b5', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'82a410cb-c661-4247-ae48-18da4ac4430f', N'ec9b2772-6948-48cc-963e-33d4646047b5')

");
        }

        public override void Down()
        {
        }
    }
}
