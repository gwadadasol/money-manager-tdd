using Microsoft.EntityFrameworkCore;

namespace TransactionMicroService.Models
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
    }
}
