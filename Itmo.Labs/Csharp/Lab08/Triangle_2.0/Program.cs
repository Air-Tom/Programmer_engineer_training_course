namespace Triangle_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Создаем обычный треугольник
                Triangle triangle1 = new Triangle(7, 4, 6);
                Console.WriteLine("Обычный треугольник:");
                triangle1.PrintSides();
                Console.WriteLine($"Периметр: {triangle1.CalculatePerimeter()}");
                Console.WriteLine($"Площадь: {triangle1.CalculateArea()}");
                Console.WriteLine();

                // Создаем равносторонний треугольник
                Triangle equilateralTriangle = new Triangle(5);
                Console.WriteLine("Равносторонний треугольник:");
                equilateralTriangle.PrintSides();
                Console.WriteLine($"Периметр: {equilateralTriangle.CalculatePerimeter()}");
                Console.WriteLine($"Площадь: {equilateralTriangle.CalculateArea()}");
                Console.WriteLine();

                // Проверяем существование треугольника
                Console.WriteLine($"Треугольник существует (3,4,5): {Triangle.IsValidTriangle(3, 4, 5)}");
                Console.WriteLine($"Треугольник существует (1,1,3): {Triangle.IsValidTriangle(1, 1, 3)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
