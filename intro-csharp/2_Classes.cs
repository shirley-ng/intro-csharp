using System;
using NUnit.Framework;

namespace intro_csharp
{
    // Part 1 Declaration
    // Normally there's a 1-1 correspondence between a named file and a class. You can declare more than 1 per file.
    // You should have a good reason for doing this. In most circumstances, don't do this.
    public class TestCase
    {
        // These are members of the class
        public string Name { get; private set; }
        public bool IsPassing { get; set; }

        // The get; set; syntax is called an auto property. It is short-hand for the following
       /* private string _name;
        private bool _isPassing;
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public bool IsPassing
        {
            get
            {
                return _isPassing;
            }
            set
            {
                _isPassing = value;
            }
        }*/

        // We can add constructors
        public TestCase(string name)
        {
            Name = name;
        }

        // By default, Equals will compare the references held in memory.
        // Override to make a more logical comparison.
        public override bool Equals(object obj)
        {
            if (!(obj is TestCase))
            {
                return false;
            }
            var objAsTestCase = (TestCase)obj;
            return Name.ToLower() == objAsTestCase.Name.ToLower()
                   && IsPassing == objAsTestCase.IsPassing;
        }

        // By default, ToString will write out the name of your class.
        // Override to make it write something more useful.
        public override string ToString()
        {
            return String.Format("Name: {0}, Is Passing: {1}", Name, IsPassing);
        }
    }

    [TestFixture]
    public class _2_Classes
    {
        [Test]
        public void Part_2_Instantiating()
        {
            // aka "new up"
            var myTestCase1 = new TestCase("Plain old test case");
            myTestCase1.IsPassing = true;
            Console.WriteLine(myTestCase1);

            // Note, when we added the constructor above, that removed the default constructor 
            // so we can no longer new up a TestCase without passing in a name
            //var myTestCase2 = new TestCase();

            // We can also use a property initializer to set values on the object
            var myTestCase3 = new TestCase("Failing test case")
                              {
                                  IsPassing = false
                              };
            Console.WriteLine(myTestCase3);
        }


        // Part 3 Nested Classes
        // You can declare a class within another class.
        public class ProductPage
        {
            public class Product
            {
                public string Name { get; set; }
                public string Description { get; set; }
            }

            private class ProductRow
            {
                public string Name { get; set; }
            }

            public void Save(Product product)
            {
                Console.WriteLine("Called productPage.Save(...)");
            }

            public bool IsProductAvailable(string productName)
            {
                Console.WriteLine("Called productPage.IsProductAvailable(...)");
                
                // You can new up the private nested class from anywhere within ProductsPage
                var productRow = new ProductRow();

                return false;
            }
        }

        [Test]
        public void Part_4_Instantiating_Nested_Classes()
        {
            // Product is public so I can create an instance of it outside of ProductPage
            var productPage = new ProductPage();
            var product = new ProductPage.Product();
            productPage.Save(product);

            // ProductRow is private so I cannot create an instance of it outside of ProductsPage
            //var productRow = new ProductPage.ProductRow();

            productPage.IsProductAvailable("Test");
        }

        // Part 5 Inheritance
        // "Is a" relationship
        public class Rectangle
        {
            private readonly decimal _length;
            private readonly decimal _width;

            public Rectangle(decimal length, decimal width)
            {
                _length = length;
                _width = width;
            }

            public decimal CalculateArea()
            {
                return _length * _width;
            }

            public override string ToString()
            {
                return String.Format("Length: {0}, Width: {1}", _length, _width);
            }
        }

        public class Square : Rectangle
        {
            public Square(decimal length)
                : base(length, length)
            {
            }
        }

        [Test]
        public void Part_6_Using_Squares_and_Rectangles()
        {
            var rectangle = new Rectangle(3, 4);
            Console.WriteLine("Rectangle " + rectangle);
            Console.WriteLine("Area: {0}", rectangle.CalculateArea());

            var square = new Square(3);
            Console.WriteLine("Square " + square);
            Console.WriteLine("Area: {0}", square.CalculateArea());

            var squareAsARectangle = (Rectangle)square;
            Console.WriteLine("Square as a Rectangle " + squareAsARectangle);
            Console.WriteLine("Area: {0}", squareAsARectangle.CalculateArea());
        }

        // Part 7 Interfaces
        // Contracts
        public interface IShape
        {
            decimal CalculateArea();
        }

        public class Circle : IShape
        {
            private readonly decimal _radius;

            public decimal Radius
            {
                get
                {
                    return _radius;
                }
            }

            public Circle(decimal radius)
            {
                _radius = radius;
            }
            public decimal CalculateArea()
            {
                return (decimal)(Math.PI * Math.Pow((double)_radius, 2));
            }

            public override string ToString()
            {
                return String.Format("Radius: {0}", _radius);
            }
        }

        [Test]
        public void Part_8_Using_Circles()
        {
            Circle circle1 = new Circle(3);
            Console.WriteLine("Circle 1 " + circle1);
            Console.WriteLine("Area: {0}", circle1.CalculateArea());

            IShape circle2 = new Circle(3);
            Console.WriteLine("Circle 2 " + circle2);
            Console.WriteLine("Area: {0}", circle2.CalculateArea());

            // Note when I have an IShape, I can only use properties and methods exposed by the interface
            //Console.WriteLine(circle2.Radius);
        }

        // Part 9 Abstract Classes
        public abstract class NinetyDegreeShape : IShape
        {
            private readonly decimal _length;
            private readonly decimal _width;

            protected decimal Length
            {
                get
                {
                    return _length;
                }
            }

            protected decimal Width
            {
                get
                {
                    return _width;
                }
            }

            protected NinetyDegreeShape(decimal length, decimal width)
            {
                _length = length;
                _width = width;
            }

            public decimal CalculateArea()
            {
                Console.WriteLine("Calculating area.");

                decimal area = Calculate();

                Console.WriteLine("Done calculating area.");

                return area;
            }

            protected abstract decimal Calculate();

            public override string ToString()
            {
                return String.Format("Length: {0}, Width: {1}", _length, _width);
            }
        }

        public class RightTriangle : NinetyDegreeShape
        {
            public RightTriangle(decimal length, decimal width)
                : base(length, width)
            {   
            }

            protected override decimal Calculate()
            {
                return (Length * Width) / 2;
            }
        }

        [Test]
        public void Part_10_Using_Right_Triangles()
        {
            // This is an abstract class so we can never construct an instance of it
            //NinetyDegreeShape shape1 = new NinetyDegreeShape(10, 10);

            RightTriangle shape2 = new RightTriangle(10, 2);
            Console.WriteLine("Shape 2 " + shape2);
            Console.WriteLine("Area: {0}", shape2.CalculateArea());

            // We made Length and Width protected earlier so we can't access their values
            //var x1 = shape2.Length * shape2.Width;
        }
    }
}