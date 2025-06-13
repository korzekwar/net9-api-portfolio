using System.ComponentModel.DataAnnotations;

namespace Core;

public class Product
{
    public Guid Id { get; set; } 

    [Required] 
    [MaxLength(100)] 
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; } 

    public DateTime CreatedAt { get; set; } 
}