using System;

namespace GenericsLabb
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isProgramRunning = true;

            while(isProgramRunning)
            {
                int[] x = new int[2] { 10, 5 };
                char[] y = new char[2] { 'b', 'a' };
                int choice;

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("1. Sort integers\t");
                    Console.WriteLine("2. Sort chars\t");
                    Console.WriteLine("3. Exit program\t");
                    Console.WriteLine("Choice: ");

                    if (Int32.TryParse(Console.ReadLine(), out choice))
                        break;

                    Console.WriteLine("Please choose a valid number in the menu.");
                    Console.ReadKey();
                }

                switch (choice)
                {
                    case 1:
                        SwapIfGreater(ref x[0], ref x[1]);
                        PrintArray(x);
                        Console.ReadKey();
                        break;
                    case 2:
                        SwapIfGreater(ref y[0], ref y[1]);
                        PrintArray(y);
                        Console.ReadKey();
                        break;
                    case 3:
                        isProgramRunning = false;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        static void PrintArray<T>(T[] arrayToPrintOut)
        {
            for(int i = 0; i < arrayToPrintOut.Length; i++)
            {
                Console.WriteLine(arrayToPrintOut[i]);
            }
        }

        static void SwapIfGreater<T>(ref T lhs, ref T rhs) where T : IComparable
        {
            if (lhs.CompareTo(rhs) > 0)
            {
                T temp;
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
        }
    }
}
