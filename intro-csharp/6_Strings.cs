using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace intro_csharp
{
    [TestFixture]
    public class _6_Strings
    {
        [Test]
        public void Part_1_String_Format()
        {
            var integerList = new List<int> { 99, 66, 33};

            string output1 = "This is a string containing 0 placeholders: " + integerList[0] + integerList[1] + integerList[2];
            Console.WriteLine(output1);

            string output2 = String.Format("This is a string containing {0} placeholders: {1}, {2}, {3}", 
                integerList.Count + 1, integerList[0], integerList[1], integerList[2]);
            Console.WriteLine(output2);

            Console.WriteLine("This is a string containing {0} placeholders: {1}, {2}, {3}", 
                integerList.Count + 1, integerList[0], integerList[1], integerList[2]);
        }

        [Test]
        public void Part_2_String_Comparison()
        {
            Console.WriteLine("String a" == "String A");
            Console.WriteLine(String.Compare("String a", "String A", CultureInfo.InvariantCulture, CompareOptions.IgnoreCase)); // 0 equal, - for less than, + for greater than
            Console.WriteLine("String a".ToLower() == "String A".ToLower());
        }

        [Test]
        public void Part_3_Formatting()
        {
            // See http://msdn.microsoft.com/en-us/library/dwhawy9k(v=vs.110).aspx
            
            const decimal numberWithDecimals = 9.99m;

            Console.WriteLine(numberWithDecimals.ToString("C"));
            Console.WriteLine(numberWithDecimals.ToString("N4"));
            Console.WriteLine(numberWithDecimals.ToString("P3"));
        }
    }
}