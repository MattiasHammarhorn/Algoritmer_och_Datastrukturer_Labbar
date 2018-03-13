using System;

namespace FibonacciosTalföljdLabb
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialization of variables used to store the months,
            // the first and second value of last month's rabbit harvest
            // and the new month's rabbit harvest
            int n;
            int f1 = 0;
            int f2 = 1;
            int result = f1 + f2;

            Console.WriteLine("Please enter the amount of months: ");
            n = int.Parse(Console.ReadLine());

            // Start index at 2 in order to simulate month 0-2's batch
            // then add the value the previous 2 month's batches and
            // 
            for ( int i = 2; i <= n; i++)
            {
                result = f1 + f2;
                f1 = f2;
                f2 = result;
            }

            Console.WriteLine("The total amount of rabbits after " + n + " months: " + result);
        }
    }
}
