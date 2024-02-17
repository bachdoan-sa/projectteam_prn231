using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infaustructure
{
    public sealed partial class AppDbContext : DbContext,IDbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LocalConnection"));
            }
        }

    }
}
