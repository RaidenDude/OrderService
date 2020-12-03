using OrderService.Products;

namespace OrderService
{
    public class ReceiptLine
    {
        private Product Product { get; }
        private int Quantity { get; }
        public double Amount { get; }

        public ReceiptLine(Product product, int quantity, double amount)
        {
            Product = product;
            Quantity = quantity;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"{Quantity} x {Product} = {Amount:C}";
        }
    }
}
