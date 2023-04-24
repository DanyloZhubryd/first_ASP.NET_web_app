using first_ASPNET_web_app.Models;
using first_ASPNET_web_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace first_ASPNET_web_app.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _service;
    public PizzaController(IPizzaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<Pizza>> GetAll() => await _service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Pizza>> Get(int id)
    {
        var pizza = await _service.FindAsync(id);
        if (pizza is null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Pizza pizza)
    {
        await _service.CreateAsync(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Pizza updatePizza)
    {
        if (updatePizza.Id != id)
            return BadRequest();

        var pizza = await _service.FindAsync(id);
        if (pizza is null)
            return NotFound();

        await _service.UpdateAsync(pizza, updatePizza);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pizza = await _service.FindAsync(id);
        if (pizza is null)
            return NotFound();

        await _service.DeleteAsync(pizza);

        return NoContent();
    }
}

