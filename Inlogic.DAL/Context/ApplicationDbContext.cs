using Inlogic.Pos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inlogic.DAL.Context
{
    public partial class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ApplicationDbContext(DbContextOptions<DbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Users> Users { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        public virtual DbSet<Order> Orders { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {      
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetSection("ConnectionStrings").Get<Connection>().DefaultConnection);
            }
        }

    }
}
