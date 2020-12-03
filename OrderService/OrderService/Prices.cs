using System;

namespace OrderService
{
    public static class Prices
    {
        private const int OneThousand = 1000;
        private const int TwoThousand = 2000;
        public const double TaxRate = .25d;

        public static int GetPriceForProduct(Product product) => product switch
        {
            CarInsurance when product.ProductName is ProductPackage.Basic => OneThousand,
            CarInsurance when product.ProductName is ProductPackage.Super => TwoThousand,
            DisabilityInsurance => OneThousand,
            _ => throw new NotImplementedException("Type of product is unknown!")
        };

        public static double CalculateLinePrice(OrderLine line)
        {
            var discountMultiplier = 0d;

            if (line.Product.Price >= TwoThousand)
            {
                discountMultiplier = line.Quantity >= 3 ? .8d : 1d;
            }

            else if (line.Product.Price >= OneThousand)
            {
                discountMultiplier = line.Quantity >= 5 ? .9d : 1d;
            }

            return line.Quantity * line.Product.Price * discountMultiplier;
        }
    }
}
