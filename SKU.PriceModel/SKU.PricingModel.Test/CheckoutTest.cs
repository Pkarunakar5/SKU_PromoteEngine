using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SKU.PriceModel;
using System.Collections.Generic;

namespace SKU.PricingModel.Test
{
    [TestClass]
    public class CheckoutTest
    {
      
        [TestMethod]
        public void Checkout_Price_Scenario1()
        {
            var checkout = new Checkout();
            var products = new List<char>() { 'A', 'B', 'C' };
            var price = checkout.GetProductPrice(products);
            Assert.AreEqual(100, price);
        }

        [TestMethod]
        public void Checkout_Price_Scenario2()
        {
            var checkout = new Checkout();
            var products = new List<char>()
            {
                'A','A','A','A','A',
                'B','B','B','B','B',
                'C'
            };
            var price = checkout.GetProductPrice(products);
            Assert.AreEqual(370, price);
        }

        [TestMethod]
        public void Checkout_Price_Scenario3()
        {
            var checkout = new Checkout();
            var products = new List<char>()
            {
                'A','A','A',
                'B','B','B','B','B',
                'C',
                'D'
            };
            var price = checkout.GetProductPrice(products);
            Assert.AreEqual(280, price);
        }
    }
}
