namespace AreaTriangle
{
    internal class Operation
    {
        // Static method for calculating the square of a triangle using Heron's formula
        public static double CalcArea(double a, double b, double c)
        {
            // Nested method to check if triangle exists
            bool isTriangle(double a, double b, double c)
            {
                return (a + b > c) && (a + c > b) && (b + c > a);
            }

            if (!isTriangle(a, b, c))
            {
                throw new ArgumentException("A triangle with such sides does not exist.");
            }

            double semiPerimeter = (a + b + c) / 2; // Calculate Semiperimeter
            return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c)); // Area by Heron's formula                       
            
        }

        // Overloaded static method to calculate area of ​​equilateral triangle
        public static double CalcArea(double side)
        {
          return (Math.Sqrt(3) / 4) * Math.Pow(side, 2);  // Area of ​​an equilateral triangle
        }
    }
}
