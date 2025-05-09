using System;


namespace AreaTriangle
{
    internal class AreaOFTriangle
    {
        static void Main(string[] args)
        {

            bool validInput = false; // Flag to check the correctness of the input

            while (!validInput) // The cycle continues as long as the input is incorrect.
            {

                try
                {
                    Console.WriteLine("Please enter the value perimeter");
                    string temp = Console.ReadLine();
                    double p = double.Parse(temp);

                    // Checking for a positive perimeter
                    if (p <= 0)
                    {
                        throw new ArgumentOutOfRangeException("The perimeter must be a positive number.");
                    }

                    //Calculating the side of a triangle
                    double side = p / 3;

                    // Calculating area using Heron's formula
                    double semiPerimeter = p / 2;
                    double area = Math.Sqrt(semiPerimeter * (semiPerimeter - side) * (semiPerimeter - side) * (semiPerimeter - side));

                    Console.WriteLine("\nSide\t\tArea");
                    Console.WriteLine($"{side:F2}\t\t{area:F2}");

                    validInput = true; // Set flag to true if input is correct

                }
                catch (FormatException e)
                {
                    Console.WriteLine($"An format exception was thrown: {e.Message}");
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"An argument out of range exception was thrown: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An exception was thrown: {e.Message}");
                }
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
            }
        }
    }
}