namespace OpsPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initdata07 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.jenkins_jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        service_name = c.String(nullable: false),
                        start_at = c.DateTime(nullable: false),
                        end_at = c.DateTime(nullable: false),
                        later_at = c.DateTime(nullable: false),
                        build_number = c.String(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.release_jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        release_plan_id = c.Int(nullable: false),
                        deployment_status = c.Int(nullable: false),
                        start_at = c.DateTime(nullable: false),
                        finished_at = c.DateTime(nullable: false),
                        deployment_log_path = c.String(nullable: false),
                        deployment_service_path = c.String(nullable: false),
                        deployment_package_archive_path = c.String(nullable: false),
                        create_by = c.String(nullable: false),
                        create_at = c.DateTime(nullable: false),
                        update_by = c.String(nullable: false),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.release_plans", t => t.release_plan_id, cascadeDelete: false)
                .Index(t => t.release_plan_id);
            
            CreateTable(
                "dbo.release_plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        planned_release_at = c.DateTime(nullable: false),
                        dev_owner = c.String(nullable: false),
                        ops_owner = c.String(nullable: false),
                        test_owner = c.String(nullable: false),
                        product_owner = c.String(nullable: false),
                        notification_list = c.String(nullable: false),
                        notification_cc_list = c.String(nullable: false),
                        release_notes = c.String(nullable: false),
                        git_repo_tag = c.String(nullable: false),
                        git_repo_ref_tag = c.String(nullable: false),
                        git_repo_commit_id = c.String(nullable: false),
                        jenkins_build_no = c.Int(nullable: false),
                        replease_package_name = c.String(nullable: false),
                        release_env = c.String(nullable: false),
                        service = c.String(nullable: false),
                        service_git_path = c.String(nullable: false),
                        status = c.Int(nullable: false),
                        create_by = c.String(nullable: false),
                        create_at = c.DateTime(nullable: false),
                        update_by = c.String(nullable: false),
                        update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.release_jobs", "release_plan_id", "dbo.release_plans");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.release_jobs", new[] { "release_plan_id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.release_plans");
            DropTable("dbo.release_jobs");
            DropTable("dbo.jenkins_jobs");
        }
    }
}
