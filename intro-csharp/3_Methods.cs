using System;
using NUnit.Framework;

namespace intro_csharp
{
    [TestFixture]
    public class _3_Methods
    {
        public void Part_1_Void()
        {
            // Does something, returns nothing
            Console.WriteLine("What's up, doge");
        }

        public int Part_2_Function(int x)
        {
            // We can only return 1 thing
            return x * x;
        }

        public int Part_3_Out(string val, out bool isParseSuccessful)
        {
            // We can return more than 1 value by using the out keyword
            int parsedValue;
            isParseSuccessful = Int32.TryParse(val, out parsedValue);

            return parsedValue;
        }

        public IntegerParseResult Part_4_Return_An_Object(string val)
        {
            // Wrap our results in an object instead
            int parsedValue;
            bool isParseSuccessful = Int32.TryParse(val, out parsedValue);

            return new IntegerParseResult { IsParseSuccessful = isParseSuccessful, ParsedValue = parsedValue };
        }

        public class IntegerParseResult
        {
            public bool IsParseSuccessful { get; set; }
            public int ParsedValue { get; set; }
        }
    }
}