using System;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using Common.Entities;

namespace EfCore31
{

    public class TiketingContext : DbContext
    {

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TimesheetRow> TimesheetRows { get; set; }

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

            modelBuilder.Entity<TimesheetRow>(e =>
            {
                e.ToTable("TimesheetRows");
                e.HasKey(e => e.Id);
                e.HasMany(e => e.Details).WithOne(d => d.TimesheetRow).HasForeignKey(e => e.TimesheetRowId);
            });

            modelBuilder.Entity<TimesheetDetail>(e =>
            {
                e.ToTable("TimesheetDetails");
                e.HasOne(e => e.TimesheetRow).WithMany(e => e.Details).HasForeignKey(e => e.TimesheetRowId);
            });

        }

        public TimesheetRow GetTimesheetRow(Guid id)
        {
            var timesheetRows = TimesheetRows.Include(e => e.Details).ToList();
            return timesheetRows.FirstOrDefault(e => e.Id == id);
        }

        public TimesheetDetail GetTimesheetDetail(Guid rowId, Guid detailId)
        {
            var timesheetRow = GetTimesheetRow(rowId);
            return timesheetRow.Details.FirstOrDefault(e => e.Id == detailId);
        }

        public void UpdateHours(TimesheetDetail detail, decimal hours)
        {
            detail.Hours = hours;
            SaveChanges();
        }

    }

}