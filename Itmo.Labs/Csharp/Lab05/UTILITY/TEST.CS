namespace Utils
{
    using System;
    using System.Threading;

    /// <summary>
    ///   This is the test harness
    /// </summary>

    public class Test
    {
        public static void Main()
        {
            int x;
            int y;
            int greater;

            Console.WriteLine("Enter first number:");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            y = int.Parse(Console.ReadLine());

            greater = Utils.Greater(x, y);
            Console.WriteLine("The greater value is " + greater);

            Thread.Sleep(1000);

            Console.WriteLine("\nBefore swap: " + x + ", " + y);
            Utils.Swap(ref x, ref y);
            Console.WriteLine("After swap: " + x + ", " + y);
            Thread.Sleep(5000);

            int f; // Factorial result
            bool ok; // Factorial success or failure
            Console.WriteLine("\nNumber for factorial:");
            x = int.Parse(Console.ReadLine());
            // Test the factorial function
            ok = Utils.Factorial(x, out f);
            // Output factorial results
            if (ok)
                Console.WriteLine("Factorial(" + x + ") = " + f);
            else
                Console.WriteLine("Cannot compute this factorial");

        }
    }
}