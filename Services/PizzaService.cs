using first_ASPNET_web_app.Data;
using first_ASPNET_web_app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace first_ASPNET_web_app.Services;

public class PizzaService : IPizzaService
{
    private readonly PizzaContext _context;

    public PizzaService(PizzaContext context)
    {
        _context = context;
    }
    public async Task<List<Pizza>> GetAllAsync() => await _context.Pizza.ToListAsync();

    public async Task<Pizza?> FindAsync(int id) => await _context.Pizza.FindAsync(id);

    public async Task CreateAsync(Pizza pizza)
    {
        // add validation exception throw 
        await _context.Pizza.AddAsync(pizza);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Pizza pizza, Pizza updatedPizza)
    {
        // add validation exception throw 
        pizza.update(updatedPizza);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Pizza pizza)
    {
        _context.Pizza.Remove(pizza);
        await _context.SaveChangesAsync();
    }
}