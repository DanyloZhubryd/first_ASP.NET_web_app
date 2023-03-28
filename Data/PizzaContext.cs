using Microsoft.EntityFrameworkCore;
using first_ASPNET_web_app.Models;

namespace first_ASPNET_web_app.Data;

public class PizzaContext : DbContext
{
    public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }

    public DbSet<Pizza> Pizza => Set<Pizza>();
    
}