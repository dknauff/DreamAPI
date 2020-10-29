using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DreamAPI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {

            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

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

        public DbSet<Dream> Dreams { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Emotion> Emotions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());

            modelBuilder.Entity<Comment>()
                .HasRequired<Dream>(c => c.Dream)
                .WithMany(d => d.Comments)
                .HasForeignKey<int>(c => c.DreamId);

            modelBuilder.Entity<Dream>()
                .HasRequired<Emotion>(d => d.Emotion)
                .WithMany(e => e.Dreams)
                .HasForeignKey<int?>(d => d.EmotionId);

            //modelBuilder.Entity<Dream>()
            //    .HasMany<Emotion>(d => d.Emotions)
            //    .WithMany(e => e.Dreams)
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("DreamRefId");
            //        cs.MapRightKey("EmotionRefId");
            //        cs.ToTable("DreamEmotion");
            //    });
        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}