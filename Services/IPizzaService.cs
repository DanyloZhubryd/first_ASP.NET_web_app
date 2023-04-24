using first_ASPNET_web_app.Models;

namespace first_ASPNET_web_app.Services;

public interface IPizzaService
{
    Task<List<Pizza>> GetAllAsync();

    Task<Pizza?> FindAsync(int id);

    Task CreateAsync(Pizza pizza);

    Task UpdateAsync(Pizza pizza, Pizza updatedPizza);

    Task DeleteAsync(Pizza pizza);
}