using FirstMicroService.Todos.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstMicroService.Todos.WebAPI.Context
{
	public sealed class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Todo> Todos { get; set; }
	}
}
