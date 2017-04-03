namespace Core.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .ForeignKey("dbo.ApplicationRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.ApplicationId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonInfo_IIN = c.String(nullable: false),
                        PersonInfo_FirstName = c.String(nullable: false),
                        PersonInfo_LastName = c.String(nullable: false),
                        PersonInfo_MiddleName = c.String(),
                        PersonInfo_BirthDate = c.DateTime(),
                        UserName = c.String(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationRolesApplications",
                c => new
                    {
                        ApplicationRoles_Id = c.Int(nullable: false),
                        Application_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationRoles_Id, t.Application_Id })
                .ForeignKey("dbo.ApplicationRoles", t => t.ApplicationRoles_Id, cascadeDelete: true)
                .ForeignKey("dbo.Applications", t => t.Application_Id, cascadeDelete: true)
                .Index(t => t.ApplicationRoles_Id)
                .Index(t => t.Application_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationLists", "RoleId", "dbo.ApplicationRoles");
            DropForeignKey("dbo.ApplicationLists", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationLists", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.ApplicationRolesApplications", "Application_Id", "dbo.Applications");
            DropForeignKey("dbo.ApplicationRolesApplications", "ApplicationRoles_Id", "dbo.ApplicationRoles");
            DropIndex("dbo.ApplicationRolesApplications", new[] { "Application_Id" });
            DropIndex("dbo.ApplicationRolesApplications", new[] { "ApplicationRoles_Id" });
            DropIndex("dbo.ApplicationLists", new[] { "RoleId" });
            DropIndex("dbo.ApplicationLists", new[] { "UserId" });
            DropIndex("dbo.ApplicationLists", new[] { "ApplicationId" });
            DropTable("dbo.ApplicationRolesApplications");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.ApplicationRoles");
            DropTable("dbo.Applications");
            DropTable("dbo.ApplicationLists");
        }
    }
}
