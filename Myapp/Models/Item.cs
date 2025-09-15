namespace Myapp.Models;

using System.ComponentModel.DataAnnotations;


public class Item
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public decimal Price { get; set; }
}

