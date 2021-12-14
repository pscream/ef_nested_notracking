using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using Common;

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
                .Include(e => e.CreatedBy)
                .Include(e => e.UpdatedBy)
                .AsNoTracking()
                .Skip(1)
                .Take(5)
                .ToList();

            Console.WriteLine("List with EF Core 'NoTracking' & Skip+Take");
            tickets.PrintPretty();
            Console.WriteLine("============================");
        }
        
    }
}
