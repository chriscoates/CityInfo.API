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
        private readonly IConfiguration _configuration;

        public CityInfoContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CityInfoContext CreateDbContext(string[] args)
        {
            var connectionString = _configuration["connectionStrings:DefaultConnection"];

            var optionsBuilder = new DbContextOptionsBuilder<CityInfoContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CityInfoContext(optionsBuilder.Options);
        }
    }
}
