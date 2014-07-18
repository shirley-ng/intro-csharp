using System;
using NUnit.Framework;

namespace intro_csharp
{
    [TestFixture]
    public class _1_Variables
    {
        [Test]
        public void Part_1_Declaration()
        {
            // Type and name declaration
            int x1 = 0, x2;

            // Name must start with an alpha or underscore
            //int 2x;
            int _x3;
            
            // You will need to initialize it before you use it.
            //int y1 = x2 + 1;

            // Try to give it some reasonable initial value.
            x2 = 0;

            int y2 = x1 + x2;

            // You can also use the var keyword but this is not recommended for code 
            // clarity unless you can see the type being returned on the right-hand side
            var coordinates = new Coordinates(); // Obvious what it is, so short-hand is ok here
            var randomThing = RandomFactory.GenerateThing(); // Not obvious what this is returning; don't use var
        }

        public static class RandomFactory
        {
            public static Coordinates GenerateThing()
            {
                var randomGenerator = new Random();
                return new Coordinates()
                       {
                           X = randomGenerator.Next(1, 10),
                           Y = randomGenerator.Next(1, 10)
                       };
            }

            public static dynamic GenerateRandomType()
            {
                var randomGenerator = new Random();
                int randomNumber = randomGenerator.Next(1, 3);
                switch (randomNumber)
                {
                    case 1:
                        return 3;
                    case 2:
                        return 3m;
                    default:
                        return 3f;
                }
            }
        }

        [Test]
        public void Part_2_Value_vs_Reference_Types()
        {
            // Structs (Numeric types, bool), Enumerations
            int z1 = 0;
            decimal z2 = 3m;
            float z3 = 3f;
            bool isVisible = false;
            Coordinates myCoordinates = new Coordinates();
            myCoordinates.X = 10;
            myCoordinates.Y = 20;

            // Enumerations
            BrowserType browserType = BrowserType.Chrome;

            // Reference type
            TestCase myTestCase = new TestCase() { Name = "Plain Test", IsPassing = false };

            // Important distinction
            Console.WriteLine("[Before Coordinates] " + myCoordinates);
            Console.WriteLine("[Before Test Case] " + myTestCase);

            MangleVariables(myCoordinates, myTestCase);

            Console.WriteLine("[After Coordinates] " + myCoordinates);
            Console.WriteLine("[After Test Case] " + myTestCase);
        }

        public struct Coordinates
        {
            public int X;
            public int Y;

            public override string ToString()
            {
                return String.Format("X: {0}, Y: {1}", X, Y);
            }
        }

        public class TestCase
        {
            public string Name;
            public bool IsPassing;

            public override string ToString()
            {
                return String.Format("Name: {0}, Is Passing: {1}", Name, IsPassing);
            }
        }

        public enum BrowserType
        {
            FireFox,
            Chrome,
            InternetExplorer,
            Safari
        }

        public void MangleVariables(Coordinates coordinates, TestCase testCase)
        {
            coordinates.X *= 1000;
            coordinates.Y *= 1000;

            testCase.Name += " No More";
            testCase.IsPassing = !testCase.IsPassing;
        }

        [Test]
        public void Part_3_Scope()
        {
            // By default, variables declared in a method are scoped to that method 
            // meaning you cannot access it from another method or anywhere else in 
            // the class.
            int methodScopedVariable = new Random().Next(1, 1000);

            if (methodScopedVariable % 2 == 1)
            {
                // Name taken
                //int methodScopedVariable = 0;

                // We can reference outer scope variables
                int scopedToIf = 22 + methodScopedVariable;

                if (methodScopedVariable % 3 == 1)
                {
                    // Name taken
                    //int scopedToIf;
                    //int methodScopedVariable;
                }
            }
            else
            {
                // You can repeat the variable name
                int scopedToIf = 33;
            }
            
            // Inner scope can access outer scoped variables. Outer cannot access inner.
            //scopedToIf = 2;
        }

        private int privateClassScopedVariable;
        // Default is private meaning I can only access it from within this class only

        protected int ProtectedClassScopedVariable;
        // This variable can be accessed from anywhere within the class AND from any class which inherits from it

        public int PublicClassScopedVariable;
        // This variable can be accessed from anywhere within the class AND from any instance of the class
    }
}