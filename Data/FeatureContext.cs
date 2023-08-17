using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Entities;

namespace webapi.Data
{
    public class FeatureContext : DbContext
    {
        public FeatureContext(DbContextOptions<FeatureContext> options) : base(options)
        {
        }

        public DbSet<Feature> Features { get; set; }
    }
}
