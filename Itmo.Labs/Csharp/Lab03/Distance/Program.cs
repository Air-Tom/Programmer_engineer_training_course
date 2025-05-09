namespace Distance
{
    internal class Program
    {
        public struct Distance
        { 
            public int Feet { get; set; }
            public int Inches { get; set; }
        

        // Constructor for initializing Distance
        public Distance(int feet, int inches)
        {
            Feet = feet;
            Inches = inches;
        }
        // Method for adding two Distance
        public static Distance operator +(Distance d1, Distance d2)
        {
            int totalInches = d1.Inches + d2.Inches;
            int totalFeet = d1.Feet + d2.Feet + (totalInches / 12); // Converting Inches to Feet
            totalInches = totalInches % 12; // Remaining inches

            return new Distance(totalFeet, totalInches);
        }
            // Overriding the ToString method to output correctlyа
            public override string ToString()
            {
                return $"{Feet}' - {Inches}\"";
            }
        }


        static void Main(string[] args)
        {
            // Definition of three variables of type Distance
            Distance distance1, distance2, distance3;

            // Entering the first variable
            Console.WriteLine("Enter the first distance (feet and inches) separated by a space (e.g. 15 8):");
            string[] input1 = Console.ReadLine().Split(' ');
            int feet1 = int.Parse(input1[0]);
             int inches1 = int.Parse(input1[1]);
            distance1 = new Distance(feet1, inches1);

            // Entering the second variable
            Console.WriteLine("Enter the second distance (feet and inches) separated by a space (e.g. 10 5):");
            string[] input2 = Console.ReadLine().Split(' ');
            int feet2 = int.Parse(input2[0]);
            int inches2 = int.Parse(input2[1]);
            distance2 = new Distance(feet2, inches2);

            // Addition of two variables
            distance3 = distance1 + distance2;

            // Output of the result
            Console.WriteLine($"Sum of distances: {distance3}");
        }
    }
}