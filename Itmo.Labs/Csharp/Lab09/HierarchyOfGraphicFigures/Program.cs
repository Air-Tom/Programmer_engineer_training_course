namespace HierarchyOfGraphicFigures
{

    public abstract class Shape
    {
        public abstract double CalculatePerimeter();
        public abstract double CalculateArea();
    }
    public class Triangle : Shape
    {
        public double x;

        public Triangle(double x)
        {
            this.x = x;
        }
        public override double CalculatePerimeter()
        {
            return x * 3;
        }
        public override double CalculateArea()
        {
            double s = CalculatePerimeter() / 2;
            return Math.Sqrt(s * (s - x) * (s - x) * (s - x));
        }
    }
    public class Circle : Shape
    {
        public double r;

        public Circle(double r)
        {
            this.r = r;
        }
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * r;
        }

        public override double CalculateArea()
        {
            return Math.PI * r * r;
        }
    }
    public class Square : Shape
    {
        public double x;

        public Square(double x)
        {
            this.x = x;
        }
        public override double CalculatePerimeter()
        {
            return 4 * x;
        }
        public override double CalculateArea()
        {
            return x * x;
        }
    }
    class Program
    {
        static void Main()
        {
            Triangle triangle = new Triangle(14);
            Console.WriteLine($"Периметр треугольника: {triangle.CalculatePerimeter()}");
            Console.WriteLine($"Площадь треугольника: {triangle.CalculateArea():##.##}");
            Console.WriteLine("Поворот треугольника");

            Circle circle = new Circle(10);
            Console.WriteLine($"Радиус круга: {circle.r}");
            Console.WriteLine($"Периметр круга: {circle.CalculatePerimeter():##.##}");
            Console.WriteLine($"Площадь круга: {circle.CalculateArea():##.##}");

            Square square = new Square(8);
            Console.WriteLine($"Длина стороны квадрата: {square.x}");
            Console.WriteLine($"Периметр квадрата: {square.CalculatePerimeter()}");
            Console.WriteLine($"Площадь квадрата: {square.CalculateArea()}");
            Console.WriteLine("Поворот квадрата");
        }
    }
}
