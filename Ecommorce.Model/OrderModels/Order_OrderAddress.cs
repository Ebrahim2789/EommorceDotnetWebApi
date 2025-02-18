using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ecommorce.Model.ProductModels;

namespace Ecommorce.Model.OrderModels
{
    public class OrderAddress : Common
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }

        public required string ContactName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string AddressLine { get; set; }

        public virtual required Order Order { get; set; }




    }

}
