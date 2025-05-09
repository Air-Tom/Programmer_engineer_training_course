namespace ShootingGame
{
    internal class Program
    {
        static void Main()
        {
            Random random = new Random();

            // Определяем случайный центр мишени
            double targetX = random.NextDouble() * 20 - 10; // Случайное значение от -10 до 10
            double targetY = random.NextDouble() * 20 - 10; 
            

            List<(double x, double y)> shots = new List<(double, double)>(); // Список для хранения выстрелов
            int totalScore = 0; // Общая сумма очков

            while (true)
            {
                Console.Write("Введите координату x (или 'exit' для выхода): ");
                string inputX = Console.ReadLine();
                if (inputX.ToLower() == "exit") break;

                Console.Write("Введите координату y: ");
                string inputY = Console.ReadLine();

                if (!double.TryParse(inputX, out double x) || !double.TryParse(inputY, out double y))
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    continue;
                }

                // Добавляем случайную помеху к выстрелу
                double noiseX = random.NextDouble() * 2 - 1; // Случайное значение от -1 до 1
                double noiseY = random.NextDouble() * 2 - 1; 
                x += noiseX;
                y += noiseY;

                // Сохраняем выстрел
                shots.Add((x, y));

                // Вычисляем расстояние до центра мишени
                double distance = Math.Sqrt(Math.Pow(x - targetX, 2) + Math.Pow(y - targetY, 2));

                // Рассчитываем очки
                int score = CalculateScore(distance);
                totalScore += score;

                Console.WriteLine($"Выстрел в ({x:F2}, {y:F2}) - Очки: {score}");
                Console.WriteLine($"Общая сумма очков: {totalScore}");
                Console.WriteLine($"Центр мишени находится в ({targetX:F2}, {targetY:F2})");
            }

            Console.WriteLine("Игра окончена.");
            Console.WriteLine("Ваши выстрелы:");
            foreach (var shot in shots)
            {
                Console.WriteLine($"({shot.x:F2}, {shot.y:F2})");
            }
            Console.WriteLine($"Итоговая сумма очков: {totalScore}");
        }

        static int CalculateScore(double distance)
        {
            if (distance < 1)
                return 10;
            else if (distance < 3)
                return 5;
            else if (distance < 5)
                return 1;
            else
                return 0;
        }
    }
}