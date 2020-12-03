using System;
using OrderService.Products;

namespace OrderService
{
    public static class Prices
    {
        private const int OneThousand = 1000;
        private const int TwoThousand = 2000;
        private const double TenProductDiscount = 0.5d;
        private const double ThreeProductDiscountForTwoThousandOrder = 0.8d;
        private const double FiveProductDiscountForOneThousandOrder = 0.9d;
        private const int FlatDiscountAmount = 100;
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
            var discountMultiplier = 1d;

            if (line.Quantity >= 10)
            {
                discountMultiplier = TenProductDiscount;
            }

            else if (line.Product.Price >= TwoThousand && line.Quantity >= 3)
            {
                discountMultiplier = ThreeProductDiscountForTwoThousandOrder;
            }

            else if (line.Product.Price >= OneThousand && line.Quantity >= 5)
            {
                discountMultiplier = FiveProductDiscountForOneThousandOrder;
            }

            return line.Quantity * line.Product.Price * discountMultiplier - FlatDiscountAmount;
        }
    }
}
