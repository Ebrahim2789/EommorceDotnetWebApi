namespace Ecommorce.Model.ProductModels
{
    public class ProductBrand : Common
    {

        public int Id { get; set; }
        public string Name { set; get; }
        public int Code { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }


    }

}
