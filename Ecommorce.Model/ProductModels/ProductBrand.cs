namespace Ecommorce.Model.ProductModels
{
    public class ProductBrand : Common
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
