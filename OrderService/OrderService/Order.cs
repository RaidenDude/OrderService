using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderService
{
    public class Order
    {
        private readonly IList<OrderLine> _orderLines = new List<OrderLine>();

        public Order(string company)
        {
            Company = company;
        }

        private string Company { get; set; }

        public void AddLine(OrderLine orderLine)
        {
            _orderLines.Add(orderLine);
        }

        public string GenerateReceipt()
        {
            var totalAmount = 0d;
            var result = new StringBuilder($"Order receipt for '{Company}'{Environment.NewLine}");
            foreach (var line in _orderLines)
            {
                var thisAmount = Prices.CalculateLinePrice(line); ;

                result.AppendLine(
                    $"\t{line} = {thisAmount:C}");
                totalAmount += thisAmount;
            }

            result.AppendLine($"Subtotal: {totalAmount:C}");
            var totalTax = totalAmount * Prices.TaxRate;
            result.AppendLine($"MVA: {totalTax:C}");
            result.Append($"Total: {totalAmount + totalTax:C}");
            return result.ToString();
        }

        public string GenerateHtmlReceipt()
        {
            var totalAmount = 0d;
            var result = new StringBuilder($"<html><body><h1>Order receipt for '{Company}'</h1>");
            if (_orderLines.Any())
            {
                result.Append("<ul>");
                foreach (var line in _orderLines)
                {
                    var thisAmount = Prices.CalculateLinePrice(line); ;

                    result.Append(
                        $"<li>{line} = {thisAmount:C}</li>");
                    totalAmount += thisAmount;
                }

                result.Append("</ul>");
            }

            result.Append($"<h3>Subtotal: {totalAmount:C}</h3>");
            var totalTax = totalAmount * Prices.TaxRate;
            result.Append($"<h3>MVA: {totalTax:C}</h3>");
            result.Append($"<h2>Total: {totalAmount + totalTax:C}</h2>");
            result.Append("</body></html>");
            return result.ToString();
        }
    }
}