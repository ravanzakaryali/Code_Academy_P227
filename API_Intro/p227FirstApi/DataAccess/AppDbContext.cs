using Microsoft.EntityFrameworkCore;
using p227FirstApi.Entities;

namespace p227FirstApi.DataAccess;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
	public DbSet<Student> Students => Set<Student>();
}
