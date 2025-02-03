namespace Ecommorce.Model.ProductModels
{
    public class Product_Publish
    {


        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string PublishTimeFrom { get; set; }
        public string PublishTimeTo { get; set; }
        public string DisplayOrder { get; set; }
        public bool IsDisplay { get; set; }



    }

}
