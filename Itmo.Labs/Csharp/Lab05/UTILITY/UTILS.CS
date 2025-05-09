namespace Utils
{
    using System;

    public class Utils
    {
        public static int Greater(int a, int b)
        {
            if (a > b)
                return a;
            else if (b > a)
                return b;
            else
                throw new ArgumentException("Both numbers are equal.");
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        // Calculate factorial
        // and return the result as an out parameter
        public static bool Factorial(int n, out int answer)
        {
            int k;
            int f;
            bool ok = true;

            // Check the input value            
            if (n < 0)
                ok = false;
            // Calculate the factorial value as the
            // product of all of the numbers from 2 to n
            try
            {
                checked
                {
                    f = 1;
                    for (k = 2; k <= n; ++k)
                    {
                        f = f * k;
                    }
                }
            }
            catch (Exception)
            {
                f = 0;
                ok = false;
            }
            answer = f;
            return ok;
        }
    }
}
