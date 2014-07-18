using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace intro_csharp
{
    [TestFixture]
    public class _5_Collections
    {
        [Test]
        public void Part_1_Declaration()
        {
            // Fixed length
            int[] myIntArray = new int[] { 3, 2, 1 };
            myIntArray[2] = 4;

            // Infinitely expandable
            List<int> myIntList = new List<int>();
            myIntList.Add(1);
            myIntList.Add(3);
            myIntList.Add(5);
            myIntList.Add(7);

            // Many other built in collection types (Dictionary, Hash, etc) but most times 
            // you'll be working with Lists
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();

            // A lot of times a method will return an Interface projection of the collection
            IReadOnlyCollection<int> myReadOnlyIntList = GetIntegers();

            // Even though the underlying type is a List, we can only access the methods exposed by IReadOnlyCollection
            //myReadOnlyIntList.Add(1);

            // When in doubt, just consider it an IEnumerable<T>. Most times, all you will 
            // need to do is traverse the list.
            IEnumerable<int> myReadOnlyEnumerableList = GetIntegers();
        }

        private IReadOnlyCollection<int> GetIntegers()
        {
            List<int> myIntList = new List<int>();
            myIntList.Add(1);
            myIntList.Add(3);

            return myIntList;
        }

        [Test]
        public void Part_2_Iterating()
        {
            // for loop
            int[] myIntArray = new int[] { 1, 2, 3 };
            for (int i = 0; i < myIntArray.Length; i++)
            {
                Console.WriteLine(myIntArray[i]);
            }

            // foreach loop
            List<int> myIntList = new List<int>();
            myIntList.Add(4);
            myIntList.Add(5);
            myIntList.Add(6);

            foreach (var myInt in myIntList)
            {
                Console.WriteLine(myInt);
            }
        }

        [Test]
        public void Part_3_Locating_Specific_Item()
        {
            var testCases = new List<TestCase>(new[]
                                                          {
                                                              new TestCase("Test Case 1"),
                                                              new TestCase("Test Case 2"),
                                                              new TestCase("Test Case 3"),
                                                              new TestCase("A Special Test Case") { IsPassing = true }
                                                          });

            TestCase specialTestCase1 = null;
            foreach (var testCase in testCases)
            {
                if (testCase.Name.Contains("Special"))
                {
                    specialTestCase1 = testCase;
                    break;
                }
            }
            Console.WriteLine("Special test case 1 {0} found", specialTestCase1 != null ? "was" : "was not");

            // Note bool operators for comparison available are
            // equals, ==
            // not equal, !=
            // greater than, >
            // greater than or equal to, >=
            // less than, <
            // less than or equal to, <=

            // Alternately, many short-cut methods built into the .NET framework
            TestCase specialTestCase2 = testCases.First(x => x.Name.Contains("Special"));
            Console.WriteLine("Special test case 2 {0} found", specialTestCase2 != null ? "was" : "was not");
        }
    }
}