using System;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DbSet<CharacterDream> CharacterDreams { get; set; }
        public DbSet<EmotionDream> EmotionDreams { get; set; }

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
                .HasRequired(c => c.Dream)
                .WithMany(d => d.Comments)
                .HasForeignKey<int>(c => c.DreamId);

            modelBuilder.Entity<CharacterDream>().HasKey(cd => new { cd.CharacterId, cd.DreamId });

            modelBuilder.Entity<CharacterDream>()
                .HasRequired(cd => cd.Character)
                .WithMany(c => c.CharacterDreams)
                .HasForeignKey(cd => cd.CharacterId);

            modelBuilder.Entity<CharacterDream>()
                .HasRequired(cd => cd.Dream)
                .WithMany(d => d.CharacterDreams)
                .HasForeignKey(cd => cd.DreamId);


            modelBuilder.Entity<EmotionDream>().HasKey(ed => new { ed.EmotionId, ed.DreamId });

            modelBuilder.Entity<EmotionDream>()
                .HasRequired(ed => ed.Emotion)
                .WithMany(e => e.EmotionDreams)
                .HasForeignKey(ed => ed.EmotionId);

            modelBuilder.Entity<EmotionDream>()
                .HasRequired(ed => ed.Dream)
                .WithMany(d => d.EmotionDreams)
                .HasForeignKey(ed => ed.DreamId);
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