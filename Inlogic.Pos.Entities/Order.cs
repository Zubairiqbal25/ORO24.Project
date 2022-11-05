using System.ComponentModel.DataAnnotations;

namespace Inlogic.Pos.Entities
{
    public class Order
    {
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Qunatity { get; set; }
        public DateTime? Created { get; set; }
        public string? Address { get; set; }
        public string? PaymentId { get; set; }
    }
}
