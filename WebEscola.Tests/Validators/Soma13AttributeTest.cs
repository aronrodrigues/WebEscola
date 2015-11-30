using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebEscola.Validators;

namespace WebEscola.Tests.Validators
{
    [TestClass]
    public class Soma13AttributeTest
    {
        private Soma13Attribute attribute;

        [TestInitialize]
        public void setup()
        {
            attribute = new Soma13Attribute();
        }

        [TestCleanup]
        public void tearDown()
        {
            attribute = null;
        }

        [TestMethod]
        public void TestaSomando13()
        {
            Assert.IsFalse(attribute.IsValid(4423));
        }

        [TestMethod]
        public void TestaNaoSomando13()
        {
            Assert.IsTrue(attribute.IsValid(1111));
        }

        [TestMethod]
        public void TestaString()
        {
            Boolean isValid = attribute.IsValid("1111");
            Assert.IsFalse(isValid);
        }
    }
}
