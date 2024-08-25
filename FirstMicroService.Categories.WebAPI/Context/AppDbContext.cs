using FirstMicroService.Categories.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstMicroService.Categories.WebAPI.Context
{
	public sealed class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		 public DbSet<Category>	Categories { get; set; }
	}
}
