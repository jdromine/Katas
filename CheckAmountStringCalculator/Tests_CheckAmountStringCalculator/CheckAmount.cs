using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckAmountStringCalculator;


namespace Tests_CheckAmountStringCalculator
{
    [TestClass]
    public class CheckAmount
    {
        [TestCategory("Base Cases")]
        [TestMethod]
        public void should_return_ZeroDollars_for_0()
        {
            Assert.AreEqual("Zero and 0/100", CheckAmountCalculator.CalculateAmount(0));
        }

        [TestCategory("Base Cases")]
        [TestMethod]
        public void should_properly_handle_cents()
        {
            Assert.AreEqual("Zero and 50/100", CheckAmountCalculator.CalculateAmount(0.50));
        }

        [TestCategory("Base Cases")]
        [TestMethod]
        public void should_properly_handle_hundreds(){
            Assert.AreEqual("One hundred and 50/100", CheckAmountCalculator.CalculateAmount(150.50));
        }
    }
}
