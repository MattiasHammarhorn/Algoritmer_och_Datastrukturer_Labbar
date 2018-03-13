using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Inlämningsuppgift1
{
    class Program
    {
        public static int splitIteration = 0;
        public static int mergeIteration = 0;
        static void Main(string[] args)
        {
            
            Start();

            void Start()
            {
                bool programIsOver = false;
                
                 while (!programIsOver)
                {
                    string[] lines = System.IO.File.ReadAllLines(@"Talfil.txt");
                    int[] parsedLines = lines.Select(s => Convert.ToInt32(s)).ToArray();
                    int[] arrayToSort = new int[parsedLines.Length];

                    Array.Clear(arrayToSort, 0, arrayToSort.Length);
                    arrayToSort = parsedLines;
                    Console.Clear();
                    Console.WriteLine("Start menu");
                    Console.WriteLine("1. Bubblesort \t 2. Mergesort \t 3. Quicksort \t 4. Exit");
                    Console.WriteLine("Choice: ");
                    int menuChoice = int.Parse(Console.ReadLine());

                    switch (menuChoice)
                    {
                        case 1:
                            arrayToSort = BubbleSort(arrayToSort);
                            PrintArrayAfterSort(arrayToSort);
                            break;
                        case 2:
                            splitIteration = 0;
                            mergeIteration = 0;
                            List<int> numbers = parsedLines.Select(s => Convert.ToInt32(s)).ToList();
                            numbers = Split(numbers);
                            arrayToSort = numbers.ToArray();
                            PrintArrayAfterSort(arrayToSort);
                            break;
                        case 3:
                            arrayToSort = QuickSort(arrayToSort, 0, arrayToSort.Length - 1);
                            PrintArrayAfterSort(arrayToSort);
                            break;
                        case 4:
                            programIsOver = true;
                            break;
                    }
                }
            }
        }

        public static int[] BubbleSort(int[] arrayToSort)
        {
            // Store the variables of the last array
            bool continueSorting = true;
            int iteration = 0;

            for (int i = 0; i < arrayToSort.Length - 1 && continueSorting; i++)
                {
                    continueSorting = false;

                    iteration++;
                    Console.Clear();
                    Console.WriteLine("\nStart Index: " + iteration);

                    for (int j = 0; j < arrayToSort.Length - 1; j++)
                    {
                        Console.Clear();
                        foreach (int a in arrayToSort)
                        {
                            if (a == arrayToSort[i])
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            else if (a == arrayToSort[j])
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else if (a == arrayToSort[j + 1])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }

                            Console.Write("|" + a + " ");
                        }
                        Console.WriteLine("\n\nÄr " + arrayToSort[j] + " större än " + arrayToSort[j + 1] + "?\n");
                        Console.ReadKey();
                        if (arrayToSort[j] > arrayToSort[j + 1])
                        {
                            continueSorting = true;
                            Console.WriteLine("\n\nJa! Byt " + arrayToSort[j] + " med " + arrayToSort[j + 1] + "\n");
                            Swap(ref arrayToSort[j], ref arrayToSort[j + 1]);
                        }
                        else
                        {
                            Console.WriteLine("\nNej, gör inget!\n");
                        }

                        foreach (int a in arrayToSort)
                        {
                            if (a == arrayToSort[i])
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            }
                            else if (a == arrayToSort[j])
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else if (a == arrayToSort[j + 1])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                            }

                            Console.Write("|" + a + " ");
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.ReadKey();
                    }
                }

            return arrayToSort;
        }


        public static List<int> Split(List<int> numbers)
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }
            Console.Clear();
            splitIteration += 1;
            Console.WriteLine("split-iteration" + splitIteration);

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            foreach (var i in numbers)
            {
                Console.Write("|" + i + "|");
            }

            int middle = numbers.Count / 2;
            Console.WriteLine("\n" + "vänster partition");
            for (int i = 0; i < middle; i++)
            {
                left.Add(numbers[i]);
                Console.Write("|" + numbers[i] + "|");
            }

            Console.WriteLine("\n" + "höger partition");
            for (int i = middle; i < numbers.Count; i++)
            {
                right.Add(numbers[i]);
                Console.Write("|" + numbers[i] + "|");
            }
            Console.ReadLine();
            left = Split(left);
            right = Split(right);

            Console.WriteLine("merge börjar");
            Console.ReadLine();
            return Merge(left, right);

        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            Console.Clear();
            mergeIteration += 1;
            Console.WriteLine("merge-iteration" + mergeIteration);

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    Console.WriteLine("vänster partition");
                    foreach (var i in left)
                    {
                        Console.Write("|" + i + "|");
                    }
                    Console.WriteLine("\n" + "höger partition");
                    foreach (var i in right)
                    {
                        Console.Write("|" + i + "|");
                    }

                    if (left.First() <= right.First())
                    {
                        Console.Write("\n" + left.First() + " är mindre än " + right.First() + " ," + left.First() + " läggs till i result" + "\n");
                        result.Add(left.First());
                        left.Remove(left.First());

                    }

                    else
                    {
                        Console.Write("\n" + left.First() + " är större än " + right.First() + " ," + right.First() + " läggs till i result" + "\n");
                        result.Add(right.First());

                        right.Remove(right.First());

                    }

                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            Console.ReadLine();
            return result;
        }

        public static int[] QuickSort(int[] array, int start, int end)
        {
            Console.Clear();
            Console.WriteLine("Start Index: " + start + " End Index: " + end);

            for (int i = start; i <= end; i++)
            {
                Console.Write("| " + array[i] + " ");
            }

            Console.ReadKey();
            Console.Clear();

            if (start < end)
            {
                int partitionIndex = Partition(array, start, end);  // Get the index of the last element to be partitioned.
                QuickSort(array, start, partitionIndex - 1);    // Quicksort the array from the left side to the last pivot.
                QuickSort(array, partitionIndex + 1, end);  // Quicksort the array from the right side to the end of te array.
            }

            return array;
        }

            // This method will take an array, a start and end index, and then
            // store the array's pivot to the last element, the length of the array,
            // and the partitionIndex with the same value as start. We do this in order
            // to constantly partition all the smaller arrays so that they will be sorted.
            // The start and end indexes variables represent the start and end of the array.
         private static int Partition(int[] A, int start, int end)
         {
             int temp = 0;
             int pivot = A[end];
             int pIndex = start; // Set partition index as start initially

             // We iterate from the start of the array to the end, and if
             // the current index in the array is less than or equal to the
             // pivot we swap that position in the array with the partitionIndex
             // and then increment the it by 1.
             for (int i = start; i < end; i++)
             {
                 Console.Clear();
                 Console.ForegroundColor = ConsoleColor.Gray;
                 Console.WriteLine("Start index: " + start + " End index: " + end + "\n");
                 Console.WriteLine("Iteration: " + i + " Partitionsindex: " + pIndex + "\n");

                 foreach (int a in A)
                 {
                     if (a == pivot)
                     {
                         Console.ForegroundColor = ConsoleColor.Green;
                     }
                     else if (a == A[i])
                     {
                         Console.ForegroundColor = ConsoleColor.Yellow;
                     }
                     else if (a == A[pIndex])
                     {
                         Console.ForegroundColor = ConsoleColor.Red;
                     }
                     else
                     {
                         Console.ForegroundColor = ConsoleColor.Gray;
                     }

                     Console.Write("| " + a + " ");
                 }

                 Console.ForegroundColor = ConsoleColor.Gray;
                 Console.WriteLine("\n\nÄr " + A[i] + " mindre än " + pivot + "?");
                 Console.ReadKey();

                 if (A[i] <= pivot)  // Swap if if element is lesser than or equal to pivot
                 {
                     Console.WriteLine("\nJa! Byt " + A[i] + " med " + A[pIndex] + "\n");
                     Swap(ref A[i], ref A[pIndex]);
                     pIndex++;
                 }
                 else
                 {
                     Console.WriteLine("\n\nNej, gör inget!\n");
                 }
                 Console.ReadKey();
             }

             // At the end of this method we swap places with in the array
             // with the positions of the partitionIndex and the last one,
             // and return the partitionIndex;
             temp = A[pIndex];
             Console.WriteLine("Byt " + A[pIndex] + " med " + A[end] + "\n");
             A[pIndex] = A[end];
             A[end] = temp;

             foreach (int a in A)
             {
                 if (a == pivot)
                 {
                     Console.ForegroundColor = ConsoleColor.Green;
                 }
                 else if (a == temp)
                 {
                     Console.ForegroundColor = ConsoleColor.Yellow;
                 }
                 else if (a == A[pIndex])
                 {
                     Console.ForegroundColor = ConsoleColor.Red;
                 }
                 else
                 {
                     Console.ForegroundColor = ConsoleColor.Gray;
                 }

                 Console.Write("|" + a + " ");
             }

             Console.ForegroundColor = ConsoleColor.Gray;
             Console.ReadKey();
             return pIndex;
         }

        public static void Swap(ref int number1, ref int number2)
        {
            int temp = number1;
            number1 = number2;
            number2 = temp;
        }

        public static void PrintArrayAfterSort(int[] arrayToPrint)
        {
            foreach (int sortedNumber in arrayToPrint)
            {
                Console.WriteLine(sortedNumber);
            }
            PrintArrayToFile(arrayToPrint);
        }

        public static void PrintArrayToFile(int[]arrayToPrintToFile)
        {
            string directoryLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string[] linesToWriteOut = arrayToPrintToFile.Select(s => Convert.ToString(s)).ToArray();
            System.IO.File.WriteAllLines(directoryLocation + @"\WriteFile.txt", linesToWriteOut);
            Console.ReadKey();
        }
    }  
}
