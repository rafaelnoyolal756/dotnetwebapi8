using dotnetwebapi8.Model;
using Microsoft.EntityFrameworkCore;

namespace dotnetwebapi8.Entity
{
    public class OurHeroDbContext: DbContext
    {
        public OurHeroDbContext(DbContextOptions<OurHeroDbContext> options) : base(options)
        {
        }
        // Registered DB Model in OurHeroDbContext file
        public DbSet<OurHero> OurHeros { get; set; }
        public DbSet<Power> Powers { get; set; }

        /*
         OnModelCreating mainly used to configured our EF model
         And insert master data if required
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting a primary key in OurHero model
            modelBuilder.Entity<OurHero>().HasKey(x => x.Id);

            modelBuilder.Entity<OurHero>()
            .HasMany(h => h.Powers)
            .WithOne(p => p.Hero)
            .HasForeignKey(p => p.HeroId)
            .OnDelete(DeleteBehavior.Cascade);

            // Ensure that a hero cannot have duplicate powers (by Name)
            modelBuilder.Entity<Power>()
                .HasIndex(p => new { p.HeroId, p.Name })
                .IsUnique();

            // Inserting record in OurHero table
            modelBuilder.Entity<OurHero>().HasData(
                new OurHero
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "",
                    isActive = true,
                }
            );
        }
    }
}
