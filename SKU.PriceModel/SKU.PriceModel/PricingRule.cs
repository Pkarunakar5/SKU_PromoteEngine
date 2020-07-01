using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKU.PriceModel
{
    public class PricingRule
    {
        public readonly char Item;
        public readonly int Count;
        public readonly decimal Price;

        public PricingRule(char item, decimal price) : this(item, 1, price)
        {

        }

        public PricingRule(char item, int count, decimal price)
        {
            Item = item;
            Count = count;
            Price = price;
        }
    }
}
