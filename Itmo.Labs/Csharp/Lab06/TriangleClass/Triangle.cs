using System;

public class Triangle
{
    // Поля для хранения длин сторон треугольника
    private double sideA;
    private double sideB;
    private double sideC;

    // Конструктор для инициализации сторон треугольника
    public Triangle(double a, double b, double c)
    {
        // Проверка на существование треугольника при инициализации
        if (!IsValidTriangle(a, b, c))
        {
            throw new ArgumentException("Треугольник с такими сторонами не существует");
        }

        this.sideA = a;
        this.sideB = b;
        this.sideC = c;
    }

    // Метод для проверки существования треугольника
    public static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a && a > 0 && b > 0 && c > 0;
    }

    // Метод для расчета периметра
    public double CalculatePerimeter()
    {
        return sideA + sideB + sideC;
    }

    // Метод для расчета площади по формуле Герона
    public double CalculateArea()
    {
        double p = CalculatePerimeter() / 2;
        return Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
    }

    // Метод для вывода длин сторон на экран
    public void PrintSides()
    {
        Console.WriteLine($"Стороны треугольника: a = {sideA}, b = {sideB}, c = {sideC}");
    }

    // Свойства для доступа к сторонам (опционально)
    public double SideA { get => sideA; }
    public double SideB { get => sideB; }
    public double SideC { get => sideC; }
}
