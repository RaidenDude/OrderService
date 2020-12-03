namespace OrderService
{
    public abstract class Product
    {
        protected Product(ProductPackage package)
        {
            ProductName = package;
        }

        public ProductPackage ProductName { get; }
        public int Price { get; protected set; }
    }
}