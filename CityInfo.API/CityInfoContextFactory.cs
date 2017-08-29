using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CityInfo.API
{
    public class CityInfoContextFactory : IDesignTimeDbContextFactory<CityInfoContext>
    {
        public CityInfoContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=(localdb)\\ProjectsV13;Database=CityInfoDB;Trusted_Connection=True;";

            var optionsBuilder = new DbContextOptionsBuilder<CityInfoContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CityInfoContext(optionsBuilder.Options);
        }
    }
}
