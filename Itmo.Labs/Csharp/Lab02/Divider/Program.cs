﻿namespace Divider
{
    internal class DivideIt
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter the first integer");
                string temp = Console.ReadLine();
                int i = Int32.Parse(temp);

                Console.WriteLine("Please enter the second integer");
                temp = Console.ReadLine();
                int j = Int32.Parse(temp);
                int k = i / j;
                Console.WriteLine($"The result of dividing {i} by {j} is {k}");
            }
            catch (FormatException e)
            {
                Console.WriteLine("An format exception was thrown: {0}",
                e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception was thrown: {0}", e.Message);
            }
        }
    }
}
