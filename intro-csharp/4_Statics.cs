using System;
using NUnit.Framework;

namespace intro_csharp
{
    [TestFixture]
    public class _4_Statics
    {
        // Part 1 Declaration
        // Static modifier can be added to a class or class variable
        public static class CandyBox
        {
            // All variables in a static class must also be static
            private static int _candyCount = 0;

            public static int CandyCount
            {
                get
                {
                    return _candyCount;
                }
            }

            // All methods in a static class must also be static
            /*public void EmptyCandyBox()
            {
            }*/

            public static void AddCandy(int numberOfCandies)
            {
                _candyCount += numberOfCandies;

                Console.WriteLine("Added {0} to the box.", numberOfCandies);
            }

            public static void RemoveCandy(int numberOfCandies)
            {
                _candyCount -= numberOfCandies;

                Console.WriteLine("Removed {0} from the box.", numberOfCandies);
            }
        }

        [Test]
        public void Part_2_Using_static_class()
        {
            // We cannot new up an instance of CandyBox because there's only one
            //CandyBox myCandyBox = new CandyBox();

            // To use our class
            CandyBox.AddCandy(1000);
            CandyBox.RemoveCandy(300);
            Console.WriteLine("Candy Count {0}", CandyBox.CandyCount);
        }

        // Part 3 static variable in a non-static class
        public class CandyBoxCandy : IDisposable
        {
            private static int _totalCandyCount;
            private readonly string _name;

            public static int TotalCandyCount
            {
                get
                {
                    return _totalCandyCount;
                }
            }

            public string Name
            {
                get
                {
                    return _name;
                }
            }

            public CandyBoxCandy(string name)
            {
                _totalCandyCount += 1;
                _name = name;
            }

            public void Dispose()
            {
                _totalCandyCount -= 1;
            }
        }

        [Test]
        public void Part_4_Using_static_variable()
        {
            var jollyRancher = new CandyBoxCandy("Jolly Rancher");
            var nowAndLater = new CandyBoxCandy("Now And Later");
            var fancyKetchup = new CandyBoxCandy("Fancy Ketchup");

            // Note, we don't need an instance of CandyBoxCandy to access the static property
            Console.WriteLine("Candy Count {0}", CandyBoxCandy.TotalCandyCount);

            fancyKetchup.Dispose();

            Console.WriteLine("Candy Count {0}", CandyBoxCandy.TotalCandyCount);

            jollyRancher.Dispose();
            nowAndLater.Dispose();

            Console.WriteLine("Candy Count {0}", CandyBoxCandy.TotalCandyCount);
        }
    }
}