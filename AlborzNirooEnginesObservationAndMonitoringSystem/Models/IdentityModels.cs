using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AlborzNirooEnginesObservationAndMonitoringSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DataModels.AssemblyPartDefinition>().HasOptional(z => z.ParentPartDefinition).WithMany(z => z.SubPartDefinitions).HasForeignKey(z => z.ParentPartDefinitionId);
            modelBuilder.Entity<DataModels.PartNumberModel>().HasRequired(z => z.AssemblyPartDefinition).WithMany(z => z.PartNumberModels).HasForeignKey(z => z.AssemblyPartDefinitionId);
            modelBuilder.Entity<DataModels.Part>().HasRequired(z => z.AssemblyPartDefinition).WithMany(z => z.Parts).HasForeignKey(z => z.AssemblyPartDefinitionId);
            modelBuilder.Entity<DataModels.DocumentReference>().HasRequired(z => z.ThirdPerson).WithMany(z => z.DocumentReferences).HasForeignKey(z => z.ThirdPersonId);
            modelBuilder.Entity<DataModels.Evaluation>().HasOptional(z => z.DocumentReference).WithMany(z => z.Evaluations).HasForeignKey(z => z.DocumentReferenceId);
            modelBuilder.Entity<DataModels.Evaluation>().HasRequired(z => z.Part).WithMany(z => z.Evaluations).HasForeignKey(z => z.PartId);
            modelBuilder.Entity<DataModels.Montage>().HasMany(z => z.Parts).WithMany(z => z.Montages).Map(z=>{
                z.MapLeftKey("MontageId");
                z.MapRightKey("PartId");
                z.ToTable("MontageParts");
            });
            modelBuilder.Entity<DataModels.Demontage>().HasMany(z => z.Parts).WithMany(z => z.Demontages).Map(z => {
                z.MapLeftKey("DemontageId");
                z.MapRightKey("PartId");
                z.ToTable("DemontageParts");
            });
            modelBuilder.Entity<DataModels.Montage>().HasOptional(z => z.EngineProject).WithMany(z => z.Montages).HasForeignKey(z => z.EngineProjectId);
            modelBuilder.Entity<DataModels.Demontage>().HasOptional(z => z.EngineProject).WithMany(z => z.Demontages).HasForeignKey(z => z.EngineProjectId);
            modelBuilder.Entity<DataModels.DocumentReference>().HasOptional(z => z.EngineProject).WithMany(z => z.DocumentReferences).HasForeignKey(z => z.EngineProjectId);
        }
        public DbSet<DataModels.PartNumberModel> PartNumberModels { get; set; }
        public DbSet<DataModels.AssemblyPartDefinition> AssemblyPartDefinitions { get; set; }
        public DbSet<DataModels.Part> Parts { get; set; }
        public DbSet<DataModels.DocumentReference> DocumentReferences { get; set; }
        public DbSet<DataModels.ThirdPerson> ThirdPeople { get; set; }
        public DbSet<DataModels.Evaluation> Evaluations { get; set; }
        public DbSet<DataModels.Montage> Montages { get; set; }
        public DbSet<DataModels.Demontage> Demontages { get; set; }
        public DbSet<DataModels.EngineProject> EngineProjects { get; set; }
    }
}