using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculatorKata;

namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StringCalculator.Add("//;\n1;2;3"));
            Console.WriteLine(StringCalculator.Add("//***\n1***2***3"));
            Console.WriteLine(StringCalculator.Add("//[;][*][****]\n1;2*3****4"));
            Console.ReadLine();
        }
    }
}
