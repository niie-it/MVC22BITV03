using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI.Data
{
	public class BankDbContext : DbContext
	{
		public BankDbContext(DbContextOptions<BankDbContext> options) : base(options) { }

		public DbSet<Account> Accounts { get; set; }
	}
}
