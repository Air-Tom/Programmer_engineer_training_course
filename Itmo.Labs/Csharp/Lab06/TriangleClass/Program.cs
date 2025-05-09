namespace TriangleClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Создаем треугольник
                Triangle triangle = new Triangle(7, 4, 6);

                // Выводим стороны
                triangle.PrintSides();

                // Вычисляем и выводим периметр
                Console.WriteLine($"Периметр: {triangle.CalculatePerimeter()}");

                // Вычисляем и выводим площадь
                Console.WriteLine($"Площадь: {triangle.CalculateArea()}");

                // Проверяем существование треугольника
                Console.WriteLine($"Треугольник существует: {Triangle.IsValidTriangle(3, 4, 5)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
