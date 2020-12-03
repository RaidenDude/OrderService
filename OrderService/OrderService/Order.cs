using System.Collections.Generic;
using System.Linq;

namespace OrderService
{
    public class Order
    {
        private readonly IList<OrderLine> orderLines = new List<OrderLine>();
        private string Company { get; set; }

        public Order(string company)
        {
            Company = company;
        }

        public void AddLine(OrderLine orderLine)
        {
            orderLines.Add(orderLine);
        }

        private Receipt CreateReceipt()
        {
            IList<ReceiptLine> receiptLines = orderLines.Select(orderLine => new ReceiptLine(orderLine.Product, orderLine.Quantity,
                Prices.CalculateLinePrice(orderLine))).ToList();

            var totalAmount = receiptLines.Sum(receiptLine => receiptLine.Amount);
            var totalTax = totalAmount * Prices.TaxRate;

            return new Receipt(Company, receiptLines, totalAmount, totalTax);
        }

        public string GenerateReceipt()
        {
            var receipt = CreateReceipt();
            return receipt.Get();
        }

        public string GenerateHtmlReceipt()
        {
            var receipt = CreateReceipt();
            return receipt.GetHtml();
        }

        public string GenerateJsonReceipt()
        {
            var receipt = CreateReceipt();
            return receipt.GetJson();
        }
    }
}