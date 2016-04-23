using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckAmountStringCalculator
{
    public class CheckAmountCalculator
    {
        public CheckAmountCalculator() { }

        public static string CalculateAmount(double amount){
            return ConvertInteger(amount) + " and " + ConvertCents(amount);
        }

        private static string ConvertCents(double amount){
            int cents = (int)(Math.Round(amount - Math.Truncate(amount),2) * 100);
            return cents.ToString() + "/100";
        }

        private static string ConvertInteger(double amount)
        {


            if ((int)amount == 0) return "Zero";
            else return "One hundred";
        }

        enum DoubleDigitString
        {
            "0"
            "One"=1,
            "Twenty"
        }
    }
}
