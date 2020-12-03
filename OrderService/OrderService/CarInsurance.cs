namespace OrderService
{
    public class CarInsurance : Product 
    {
        public CarInsurance(ProductPackage package) : base(package)
        {
            Price = Prices.GetPriceForProduct(this);
        }

        public override string ToString() => $"Car Insurance {ProductName}";
    }
}
