using Juan.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Juan.Contexts
{
    public class JuanDbContext : DbContext
    {
        public JuanDbContext(DbContextOptions<JuanDbContext> options) : base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; } = null!;
        public DbSet<Shipping> Shippings { get; set; } = null!;
        public DbSet<Category> Categories { get; set; }= null!;
        public DbSet<Product> Products { get; set; } = null!;
    }
}
