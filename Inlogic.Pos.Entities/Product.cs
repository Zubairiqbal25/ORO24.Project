using System.ComponentModel.DataAnnotations;

namespace Inlogic.Pos.Entities
{
    public class Product
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; } = null;
        public string? Image { get; set; } = null;
        public string? Price { get; set; } = null;
        public string? Quantity { get; set; } = null;

    }
}
