using Microsoft.EntityFrameworkCore;

namespace DDR_Khudmadad.BusinessObjects
{
    public class Ef_DataContext : DbContext
    {
        public Ef_DataContext(DbContextOptions<Ef_DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasIndex(u => u.userName)
                .IsUnique();

            modelBuilder.Entity<Users>()
                .HasOne(p => p.Role)
                .WithMany(b => b.users)
                .HasForeignKey(p => p.roleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Gig>()
                .HasOne(p => p.Creator)
                .WithMany(b => b.gig)
                .HasForeignKey(p => p.creatorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Offers>()
                .HasKey(nameof(Offers.gigId), nameof(Offers.freelancerId));

            modelBuilder.Entity<Offers>()
                .HasOne(p => p.freelancer)
                .WithMany(b => b.offer)
                .HasForeignKey(p => p.freelancerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Offers>()
                .HasOne(p => p.gig)
                .WithMany(b => b.offer)
                .HasForeignKey(p => p.gigId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        public DbSet<Roles> roles { get; set; }

        public DbSet<Users> users { get; set; }

        public DbSet<Gig> gig { get; set; }

        public DbSet<Offers> offer { get; set; }
    }
}
