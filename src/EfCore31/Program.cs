using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using Common;
using Common.Entities;

namespace EfCore31
{
    class Program
    {
        static void Main(string[] args)
        {
            var location = Assembly.GetExecutingAssembly().Location;

            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Path.GetDirectoryName(location), "appsettings.json"))
                .AddEnvironmentVariables();

            var configuration = configurationBuilder.Build();


            var dbOptionsBuilder = new DbContextOptionsBuilder<TiketingContext>()
                .UseSqlServer(configuration.GetConnectionString("Connection"));

            var context = new TiketingContext(dbOptionsBuilder.Options);

            Console.WriteLine("EF Core 3.1");

            var tickets = 
                context.Tickets
                .Include(e => e.OpenedBy)
                .Include(e => e.CreatedBy)
                .Include(e => e.UpdatedBy)
                .AsTracking()
                .Skip(1)
                .Take(5)
                .ToList();

            Console.WriteLine("List with EF Core 'Tracking' & Skip+Take");
            tickets.PrintPretty();
            Console.WriteLine("============================");

            tickets = 
                context.Tickets
                .Include(e => e.OpenedBy)
                .ThenInclude(e => e.User)
                .Include(e => e.CreatedBy)
                .Include(e => e.UpdatedBy)
                .AsNoTracking()
                 .Skip(1)
                 .Take(5)
                .ToList();

            Console.WriteLine("List with EF Core 'NoTracking' & Skip+Take");
            tickets.PrintPretty();
            Console.WriteLine("============================");

            Console.WriteLine("Update TimesheetRow");

            var timesheetDetail = context.GetTimesheetDetail(new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0001-000000000002"));

            Console.WriteLine($"Detail Id = '{timesheetDetail.Id}' => Hours = {timesheetDetail.Hours} (Initial)");

            context.UpdateHours(timesheetDetail, 5);

            timesheetDetail = context.GetTimesheetDetail(new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0001-000000000002"));

            Console.WriteLine($"Detail Id = '{timesheetDetail.Id}' => Hours = {timesheetDetail.Hours} (Updated)");

            context.UpdateHours(timesheetDetail, 8);

            Console.WriteLine($"Detail Id = '{timesheetDetail.Id}' => Hours = {timesheetDetail.Hours} (Restored)");

            var newTimesheetRow = new TimesheetRow()
            {
                Id = Guid.NewGuid(),
                IsBillable = true,
                Details = new List<TimesheetDetail>(),
                CreatedById = new Guid("00000000-0000-0000-0000-000000000001"),
                UpdatedById = new Guid("00000000-0000-0000-0000-000000000001"),
                IsActive = true,
            };

            var detail20220808 = new TimesheetDetail()
            {
                Id = Guid.NewGuid(),
                WorkDay = new DateTime(2022, 08, 08),
                Hours = 8,
                CreatedById = new Guid("00000000-0000-0000-0000-000000000001"),
                UpdatedById = new Guid("00000000-0000-0000-0000-000000000001"),
                IsActive = true,
            };

            newTimesheetRow.Details.Add(detail20220808);
            context.TimesheetRows.Add(newTimesheetRow);
            context.SaveChanges();

            Console.WriteLine("============================");
        }
        
    }
}
