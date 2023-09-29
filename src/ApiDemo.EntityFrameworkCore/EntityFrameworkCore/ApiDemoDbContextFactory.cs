using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ApiDemo.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ApiDemoDbContextFactory : IDesignTimeDbContextFactory<ApiDemoDbContext>
{
    public ApiDemoDbContext CreateDbContext(string[] args)
    {
        ApiDemoEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var connectString = configuration.GetConnectionString("Default");
        var builder = new DbContextOptionsBuilder<ApiDemoDbContext>()
            .UseMySql(connectString, ServerVersion.AutoDetect(connectString));

        return new ApiDemoDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ApiDemo.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
