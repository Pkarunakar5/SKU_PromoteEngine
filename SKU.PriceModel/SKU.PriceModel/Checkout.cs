using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKU.PriceModel
{
    public class Checkout
    {
        private PricingRule[] _pricingRules;
        public Checkout()
        {
            PricingRules();
        }
        private void PricingRules()
        {
            //Pricing Rules
            _pricingRules = new PricingRule[]
           {
                new PricingRule('A', 50),
                new PricingRule('B', 30),
                new PricingRule('C', 20),
                new PricingRule('D', 15),
                new PricingRule('A', 3, 130),
                new PricingRule('B', 2, 45),
           };
        }
        public decimal DoCheckout(List<char> _items)
        {
            decimal total = 0m;
            var itemsGroups = _items.GroupBy(x => x).ToList();

            // Check for C and D Product available in Lists
            //To Do : If Multiple C and D Products in lists
            var itemsList = itemsGroups.Where(t => t.Key == 'C' || t.Key == 'D').ToList();
            if(itemsList.Count()>0)
            {
                if((itemsList.Where(t=>t.Key=='C').Count()==1) && (itemsList.Where(t => t.Key == 'D').Count() == 1))
                {
                    itemsGroups= itemsGroups.Except(itemsList).ToList();
                    total = 30;
                }
            }

            foreach (var @group in itemsGroups)
            {
                var rules = _pricingRules
                    .Where(r => r.Item == @group.Key)
                    .OrderByDescending(r => r.Count);
                var itemCount = @group.Count();

                while (itemCount > 0)
                {
                    var ruleToApply = rules.First(r => r.Count <= itemCount);
                    total += ruleToApply.Price;
                    itemCount -= ruleToApply.Count;
                }
            }
            return total;
        }

        public decimal GetProductPrice(List<char> items)
        {
            return DoCheckout(items);
        }

    }
}
