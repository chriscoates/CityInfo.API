using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CityInfo.API
{
    public class CityInfoContextFactory : IDesignTimeDbContextFactory<CityInfoContext>
    {

        public CityInfoContextFactory()
        {
        }

        public CityInfoContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CityInfoDB;Trusted_Connection=True;";

            var optionsBuilder = new DbContextOptionsBuilder<CityInfoContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CityInfoContext(optionsBuilder.Options);
        }
    }
}
