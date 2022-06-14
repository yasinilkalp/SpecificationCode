namespace SpecificationCodeSample.Models
{
    public class Product
    {
        public Product()
        {

        }

        public Product(int id, string name, string brand, int qty, double listPrice, double salePrice)
        {
            this.Id = id;
            this.Name = name;
            this.BrandName = brand;
            this.Quantity = qty;
            this.ListPrice = listPrice;
            this.SalePrice = salePrice;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public int Quantity { get; set; }
        public double ListPrice { get; set; }
        public double SalePrice { get; set; }
    }
}
