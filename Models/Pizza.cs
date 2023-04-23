
using System.ComponentModel.DataAnnotations;
namespace first_ASPNET_web_app.Models;

public class Pizza
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    public bool? IsGlutenFree { get; set; }

    public void update(Pizza pizza)
    {
        this.Name = pizza.Name;
        this.IsGlutenFree = pizza.IsGlutenFree;
    }
}
