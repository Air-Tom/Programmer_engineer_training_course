namespace AreaTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Выберите тип треугольника: 'Равносторонний - нажмите 1' или 'Произвольный - нажмите 2'");

                // Experience of entering into a number
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice) && (choice == 1 || choice == 2))
                {
                    validInput = true; // Input is valid
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите 1 или 2.");
                }

                if (choice == 1)
                { // Input the side of an equitriangle
                    Console.WriteLine("Введите длину стороны: ");
                    double side = double.Parse(Console.ReadLine());
                    double area = Operation.CalcArea(side);
                    Console.WriteLine($"Площадь равностороннего треугольника = {area:F2}");
                    Thread.Sleep(5000);
                }
                else if (choice == 2)
                { // Input the sides of an equitriangle
                    Console.WriteLine("Введите сторону a: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите сторону b: ");
                    double b = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите сторону c: ");
                    double c = double.Parse(Console.ReadLine());

                    try
                    {
                        double area = Operation.CalcArea(a, b, c);
                        Console.WriteLine($"Площадь произвольного треугольника = {area:F2}");
                        Thread.Sleep(5000);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Thread.Sleep(3000);
                    }
                }
            }
        }
    }
}
