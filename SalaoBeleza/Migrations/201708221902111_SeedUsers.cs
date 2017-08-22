namespace SalaoBeleza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab3d4853-6214-4d21-b27e-989ef15b6d5b', N'edujunque@gmail.com', 0, N'ADwGXPmDyApQPM1ipboByXmbickcBWB+nvuQYlPj2kt1EL/psUv6imShAA4MrVDkFw==', N'626c0527-6308-469a-8258-77637f257b43', NULL, 0, 0, NULL, 1, 0, N'edujunque@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cc3b867e-e7b0-4981-a75a-ca0bdabe4878', N'admin@admin.com', 0, N'AGf8Qgctwqs6LkvV92ptyuPm3jp9WDZ913uKWSTY6zqeehv0dP4lhpn8C+tqGDaHZA==', N'a02aba78-7614-46a6-9ea9-21da695a3f4f', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')                

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'62ab29db-5516-493e-9600-befde4882040', N'CanManageUsers')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cc3b867e-e7b0-4981-a75a-ca0bdabe4878', N'62ab29db-5516-493e-9600-befde4882040')

");
        }

        public override void Down()
        {
        }
    }
}
