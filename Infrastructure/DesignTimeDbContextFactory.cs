using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(
                "server=localhost;database=fitnessdb;user=root;password=Hamster1!",
                new MySqlServerVersion(new Version(8, 0, 34)) // përshtate nëse ndryshon
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
