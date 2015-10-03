using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private const int LARGEST_NUMBER = 1000;

        #region Constructors

        public StringCalculator()
        { 

        }

        #endregion


        #region Public Methods
        public static int Add(string numbers)
        {
            int result = 0;
            List<int> negativeValues = new List<int>();

            //get all of the delimeters
            List<string> delimeters = getDelimeters(numbers);

            string delimeter = delimeters[0];

            //replace any part of the string associated with delimeters
            numbers = replaceDelimeterString(numbers);
            //replace the new line (\n) with the first delimeter
            numbers = numbers.Replace("\n", delimeter);

            //normalize all delimeters in the string to one value - this will limit the complexity in the string split
            foreach (string delimeterToReplace in delimeters)
            {
                numbers.Replace(delimeterToReplace, delimeter);
            }
            
            //split the string 
            string[] chars = numbers.Split(delimeter.ToCharArray());

            foreach (string number in chars)
            {
                int value = 0;
                Int32.TryParse(number, out value);
                
                //the string calculator doesn't support negative numbers - this block stores the value - an exception will be raised later
                if (value < 0)
                {
                    negativeValues.Add(value);
                }

                //the string calculator doesn't support ints greater than a certain threshold
                if(value <= LARGEST_NUMBER)
                {
                    result += value;
                }
            }

            //handle the negative values
            if (negativeValues.Count != 0)
            {
                StringBuilder exceptionMessage = new StringBuilder("The negative values [");

                for (int i=0; i<negativeValues.Count; i++)
                {
                    exceptionMessage.Append(negativeValues[i].ToString());
                    if (i != negativeValues.Count - 1)
                    {
                        exceptionMessage.Append(", ");
                    }
                }

                exceptionMessage.Append("] were included in the calculation request.  Negative values are not allowed.");

                throw new Exception(exceptionMessage.ToString());
            }

            return result;
        }
        #endregion


        #region Private Methods
        private static List<string> getDelimeters(string numbers)
        {
            List<string> delimetersList = new List<string>();

            //check if the program should the use the default delimeter
            if (numbers.Length >= 2 && numbers.Substring(0,2).Equals("//")){
                int allDelimetersEnd = numbers.IndexOf("\n");
                int delimeterEnd = -1;
                int delimeterStart = -1;

                //check if there are multiple delimeters
                if (numbers.Substring(3,1).Equals("[")){
                    delimeterStart = 4;
                    delimeterEnd = numbers.IndexOf("]", delimeterStart) - 1;

                    //loop through each delimeter and add to list
                    while (delimeterStart < allDelimetersEnd && delimeterStart != -1)
                    {
                        delimetersList.Add(numbers.Substring(delimeterStart, delimeterEnd));
                        delimeterStart = numbers.IndexOf("[", delimeterEnd) + 1;
                        delimeterEnd = numbers.IndexOf("]") - 1;
                    }
                } else {
                    delimeterStart = 2;
                    delimetersList.Add(numbers.Substring(delimeterStart, allDelimetersEnd - delimeterStart));
                }
            }
            else //the default delimeter is a comma
            {
                delimetersList.Add(",");
            }

            return delimetersList;
        }

        private static string replaceDelimeterString(string numbers)
        {
            //check if any delimeters were provided
            if (numbers.Length >= 2 && numbers.Substring(0, 2).Equals("//"))
            {
                int delimeterStart = 0;
                int delimeterEnd = numbers.IndexOf("\n") + 1;

                return numbers.Replace(numbers.Substring(delimeterStart, delimeterEnd), "");
            }
            else
            {
                return numbers;
            }
        }

        #endregion
    }
}
