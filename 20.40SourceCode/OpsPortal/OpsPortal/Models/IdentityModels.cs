using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OpsPortal.App_Start;
using OpsPortal.Entities;
using OpsPortal.EntityConfigurations;

namespace OpsPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("bmwone_opscenter_db",  throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        public virtual void Commit()
        {
            try
            {
                SaveChanges();
            }
            catch
            {
                // TODO:
                throw;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // http://stackoverflow.com/questions/5532810/entity-framework-code-first-defining-relationships-keys
            // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ReleasePlanConfiguration());
            modelBuilder.Configurations.Add(new ReleaseJobConfiguration());
            modelBuilder.Configurations.Add(new JenkinsJobConfiguration());
        }



        private static string GetConnectionString()
        {
            return Bootstrap.ServiceConfiguration.OpsPortalDbConnectionString;
        }

        public DbSet<ReleaseJobEntity> ReleaseJobEntities { get; set; }

        public DbSet<ReleasePlanEntity> ReleasePlanEntities { get; set; }

        public DbSet<JenkinsJobEntity> JenkinsJobEntities { get; set; }
    }
}