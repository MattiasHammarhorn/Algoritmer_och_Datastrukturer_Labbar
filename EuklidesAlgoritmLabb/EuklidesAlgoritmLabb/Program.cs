using System;

namespace EuklidesAlgoritmLabb
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;

            Console.WriteLine("Please enter the first number: ");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the second number: ");
            b = int.Parse(Console.ReadLine());

            while (b > 0)
            {
                c = a % b;
                a = b;
                b = c;
            }

            Console.WriteLine("The greatest common factor is: " + a);
        }
    }
}
