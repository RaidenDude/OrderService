namespace OrderService
{
    public class DisabilityInsurance : Product
    {
        public DisabilityInsurance(ProductPackage package) : base(package)
        {
            Price = Prices.GetPriceForProduct(this);
        }

        public override string ToString() => "Disability Insurance";
    }
}
