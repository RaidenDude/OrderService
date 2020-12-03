using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace OrderService
{
    public class Receipt
    {
        private string Company { get; }
        private IList<ReceiptLine> ReceiptLines { get; }
        private double Subtotal { get; }
        private double VAT { get; }
        private double Total => Subtotal + VAT;

        public Receipt(string company, IList<ReceiptLine> receiptLines, double subtotal, double vat)
        {
            Company = company;
            ReceiptLines = receiptLines;
            Subtotal = subtotal;
            VAT = vat;
        }

        public string GetJson() => JsonSerializer.Serialize(this);

        public string GetHtml()
        {
            var result = new StringBuilder($"<html><body><h1>Order receipt for '{Company}'</h1>");

            result.Append("<ul>");

            ReceiptLines.ToList().ForEach(line =>
            {
                result.Append(
                    $"<li>{line}</li>");
            });

            result.Append("</ul>");
            result.Append($"<h3>Subtotal: {Subtotal:C}</h3>");
            result.Append($"<h3>MVA: {VAT:C}</h3>");
            result.Append($"<h2>Total: {Total:C}</h2>");
            result.Append("</body></html>");

            return result.ToString();
        }

        public string Get()
        {
            var result = new StringBuilder($"Order receipt for '{Company}'{Environment.NewLine}");

            ReceiptLines.ToList().ForEach(line =>
            {
                result.AppendLine(
                        $"\t{line}");
            });

            result.AppendLine($"Subtotal: {Subtotal:C}");
            result.AppendLine($"MVA: {VAT:C}");
            result.AppendLine($"Total: {Total:C}");

            return result.ToString();
        }
    }
}
