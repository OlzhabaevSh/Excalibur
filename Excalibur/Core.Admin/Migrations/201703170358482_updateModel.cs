namespace Core.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationRolesApplications",
                c => new
                    {
                        ApplicationRoles_Id = c.String(nullable: false, maxLength: 128),
                        Application_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationRoles_Id, t.Application_Id })
                .ForeignKey("dbo.AspNetRoles", t => t.ApplicationRoles_Id, cascadeDelete: true)
                .ForeignKey("dbo.Applications", t => t.Application_Id, cascadeDelete: true)
                .Index(t => t.ApplicationRoles_Id)
                .Index(t => t.Application_Id);
            
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationRolesApplications", "Application_Id", "dbo.Applications");
            DropForeignKey("dbo.ApplicationRolesApplications", "ApplicationRoles_Id", "dbo.AspNetRoles");
            DropIndex("dbo.ApplicationRolesApplications", new[] { "Application_Id" });
            DropIndex("dbo.ApplicationRolesApplications", new[] { "ApplicationRoles_Id" });
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropTable("dbo.ApplicationRolesApplications");
        }
    }
}
