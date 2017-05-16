namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9db9e418-68a8-46dc-899e-175ec4c3aa3f', N'admin@vidly.com', 0, N'AMlqKWBRX5HXNTYUSajngJ3BLHpLudfGJXZBahyKkrOzcZl2M94jwfwF41pdwBOqaQ==', N'212eedd4-a3d4-4ebc-a0d9-ad3796a8ce2a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a219bbf3-6008-437b-af17-d6ecf60acfec', N'guest@vidly.com', 0, N'ACEq+iIVB1+k4xMXwVuOSSlOVa7GW48XPsy65odHdqPAzYqQEnevNaJ8eDLx8t2l3g==', N'e9df0778-d8b9-4117-82ff-212a14a2bb5b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
    
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3840840e-698e-4b57-a016-182ee00b45fc', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9db9e418-68a8-46dc-899e-175ec4c3aa3f', N'3840840e-698e-4b57-a016-182ee00b45fc')

                ");

        }
        
        public override void Down()
        {
        }
    }
}
