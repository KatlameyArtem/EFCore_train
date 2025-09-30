using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>(); // Correct initialization syntax  
}
public class Product
{
    public int ProductId {  get; set; }
    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;
    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; }

    [Column("UnitsInStock")]
    public short? Stock { get; set; }
    public bool Discontinued { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}