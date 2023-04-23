using first_ASPNET_web_app.Data;
using first_ASPNET_web_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace first_ASPNET_web_app.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly PizzaContext _context;
    public PizzaController(PizzaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Pizza>> GetAll() => await _context.Pizza.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Pizza>> Get(int id)
    {
        var pizza = await _context.Pizza.FindAsync(id);

        if (pizza is null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pizza pizza)
    {
        await _context.Pizza.AddAsync(pizza);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pizza updatePizza)
    {
        if (id != updatePizza.Id)
            return BadRequest();

        var pizza = await _context.Pizza.FindAsync(id);
        if (pizza is null)
            return NotFound();

        pizza.update(updatePizza);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var pizza = await _context.Pizza.FindAsync(id);
        if (pizza is null)
            return NotFound();

        _context.Pizza.Remove(pizza);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

