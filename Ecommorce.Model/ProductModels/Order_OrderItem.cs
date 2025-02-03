namespace Ecommorce.Model.ProductModels
{
    public class Order_OrderItem
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public string OrderId { get; set; }
        public string ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductMediaUrl { get; set; }
        public string Quantity { get; set; }
        public string ShippedQuantity { get; set; }
        public string DiscountAmount { get; set; }
        public string ItemAmount { get; set; }
        public string ItemWeight { get; set; }
        public string Note { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }




    }

}
