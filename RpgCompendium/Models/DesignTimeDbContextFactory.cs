using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RpgCompendium.Models
{
  public class RpgCompendiumContextFactory : IDesignTimeDbContextFactory<RpgCompendiumContext>
  {
    RpgCompendiumContext IDesignTimeDbContextFactory<RpgCompendiumContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<RpgCompendiumContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new RpgCompendiumContext(builder.Options);
    }
  }
}