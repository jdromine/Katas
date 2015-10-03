using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void should_calculate_zero_when_provided_empty_string()
        {
            int result = StringCalculator.Add("");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void should_return_value_provided_when_provided_one_value()
        {
            int result = StringCalculator.Add("1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void should_add_two_values_when_provided_two_values()
        {
            int result = StringCalculator.Add("1,2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void should_add_three_values_when_provided_three_values()
        {
            int result = StringCalculator.Add("1,2,3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void should_calculate_when_provided_newline_character()
        {
            int result = StringCalculator.Add("1,2\n3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void should_work_with_different_delimeters()
        {
            int result = StringCalculator.Add("//;\n1;2;3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
    "The negative values [-3,-4] were included in the calculation request.  Negative values are not allowed.")]
        public void should_return_exception_with_negative_numbers(){
            int result = StringCalculator.Add("1,2,-3,-4");
        }

        [TestMethod]
        public void should_ignore_numbers_greater_than_1000()
        {
            int result = StringCalculator.Add("1,2,3,1001");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void should_handle_multicharacter_delimeters()
        {
            int result = StringCalculator.Add("//***\n1***2***3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void should_handle_multiple_delimeters()
        {
            int result = StringCalculator.Add("//[;][*][***]\n1;2*3***4");
            Assert.AreEqual(10, result);
        }
    }
}
