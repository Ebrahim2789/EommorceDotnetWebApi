using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ecommorce.Model.ProductModels;

namespace Ecommorce.Model.OrderModels
{
    public class OrderItem : Common
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public virtual required Order Order { get; set; }
        public virtual required Product Product { get; set; }
        public decimal ProductPrice { get; set; }
        public required string ProductName { get; set; }
        public required string ProductMediaUrl { get; set; }
        public int Quantity { get; set; }
        public int ShippedQuantity { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal ItemAmount { get; set; }
        public decimal ItemWeight { get; set; }
        public required string Note { get; set; }
        public required string CreatedById { get; set; }
        public required string UpdatedById { get; set; }




    }

}
