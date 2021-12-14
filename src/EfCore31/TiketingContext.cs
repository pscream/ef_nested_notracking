using Microsoft.EntityFrameworkCore;
using EfCore31.Entities;

namespace EfCore31
{

    public class TiketingContext : DbContext
    {
        public TiketingContext(DbContextOptions<TiketingContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
            });

            modelBuilder.Entity<Resource>(e =>
            {
                e.ToTable("Resources");
                e.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Ticket>(e =>
            {
                e.ToTable("Tickets");
                e.HasOne(e => e.OpenedBy).WithMany().HasForeignKey(e => e.OpenedById);
                e.HasOne(e => e.CreatedBy).WithMany().HasForeignKey(e => e.CreatedById);
                e.HasOne(e => e.UpdatedBy).WithMany().HasForeignKey(e => e.UpdatedById);
            });
        }

        public DbSet<Ticket> Tickets { get; set; }

    }

}