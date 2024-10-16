using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MMABooksBusinessClasses;


namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product def;
        private Product c;
        [SetUp]

        public void Setup() 
        {  
            def = new Product();
            c = new Product("A4CS", "Murach's C# 2010", "50", 5136);
        }
        [Test]
        public void TestConstructor() 
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(null, def.UnitPrice);
            Assert.AreEqual(null, def.OnHandsQuantity);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.ProductCode);
            Assert.AreNotEqual(null, c.Description);
            Assert.AreNotEqual(null, c.UnitPrice);
            Assert.AreNotEqual(null, c.OnHandsQuantity);
        }
        [Test]
        public void TestProductCodeSetter()
        {
            c.ProductCode = "A4CS";
            Assert.AreNotEqual ("123", c.ProductCode);
            Assert.AreEqual ("A4CS", c.ProductCode);
        }
    
    }
}
