using Microsoft.EntityFrameworkCore;
using first_ASPNET_web_app.Models;

namespace first_ASPNET_web_app.Data;

public class PizzaContext : DbContext
{
    public PizzaContext(DbContextOptions options) : base(options) { }
    public DbSet<Pizza> Pizza => Set<Pizza>();
}
