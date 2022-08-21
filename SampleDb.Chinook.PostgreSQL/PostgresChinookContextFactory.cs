using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;

namespace SampleDb.Chinook.PostgreSQL;

public class PostgresChinookContextFactory : IDesignTimeDbContextFactory<PostgresChinookContext>
{
    public PostgresChinookContext CreateDbContext(string[] args)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var isDevelopment = environmentName == Environments.Development;
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .AddEnvironmentVariables();
        var config = builder.Build();
        var connectionString = config.GetConnectionString("DefaultConnection") ?? "Host=localhost;Port=15432;Database=chinook;Username=postgres;Password=postgres";
        var optionBuilder = new DbContextOptionsBuilder();
        optionBuilder.UseNpgsql(connectionString);
        optionBuilder.UseSnakeCaseNamingConvention();
        optionBuilder.EnableSensitiveDataLogging(true);
        if (isDevelopment)
        {
            try
            {
                using var context = new PostgresChinookContext(optionBuilder.Options);
                context.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                var logger = new LoggerFactory().CreateLogger<PostgresChinookContext>();
                logger.LogError(ex, "An error occurred while seeding the database");
            }
        }
        return new PostgresChinookContext(optionBuilder.Options);
    }
}