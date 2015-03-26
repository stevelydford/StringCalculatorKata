using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiter = ",";
            if (numbers.StartsWith("//"))
            {
                delimiter = SetCustomDelimiter(numbers);
                numbers = RemoveDelimiterSubstring(numbers);
            }

            return SumNumbers(CreateNumberCollectionFromString(numbers, delimiter));
        }

        private static int SumNumbers(IEnumerable<string> numberArray)
        {
            var result = 0;
            foreach (var number in numberArray.Where(x => int.Parse(x) <= 1000))
            {
                if (int.Parse(number) < 0)
                {
                    throw new Exception("negatives not allowed");
                }

                result += int.Parse(number);
            }
            return result;
        }

        private static IEnumerable<string> CreateNumberCollectionFromString(string numbers, string delimiter)
        {
            return numbers.Replace("\\n", delimiter).Split(delimiter.ToCharArray());
        }

        private static string SetCustomDelimiter(string numbers)
        {
            return numbers.Substring(2, 1);
        }

        private static string RemoveDelimiterSubstring(string numbers)
        {
            numbers = numbers.Remove(0, 5);
            return numbers;
        }
    }
}
