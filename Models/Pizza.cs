
using System.ComponentModel.DataAnnotations;
namespace first_ASPNET_web_app.Models;

public class Pizza
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required]
    //[Range(typeof(bool), "true", "false")]
    public bool IsGlutenFree { get; set; }

    public void update(Pizza pizza)
    {
        Name = pizza.Name;
        IsGlutenFree = pizza.IsGlutenFree;
    }
}
