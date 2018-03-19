using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Inlämningsuppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            bool isProgramRunning = true;
            
            while(isProgramRunning)
            {
                int[] numbers = System.IO.File.ReadAllLines(@"Numbers.txt").Select(s => Convert.ToInt32(s)).ToArray();
                char[] letters = System.IO.File.ReadAllLines(@"Letters.txt").Select(s => Convert.ToChar(s)).ToArray();
                
                Console.Clear();
                Console.Write("1. Bubble Sort numbers");
                Console.Write("\t");
                Console.Write("2. Bubble Sort letters");
                Console.Write("\n");
                Console.Write("3. Merge Sort numbers");
                Console.Write("\t");
                Console.Write("4. Merge Sort letters");
                Console.Write("\n");
                Console.Write("5. Quick Sort numbers");
                Console.Write("\t");
                Console.Write("6. Quick Sort letters");
                Console.Write("\n");
                Console.Write("7. Exit");
                Console.Write("\n");
                Console.WriteLine("Choice: ");

                try
                {
                    Int32.TryParse(Console.ReadLine(), out int choice);

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            BubbleSort(numbers);
                            PrintOutArray(numbers);
                            break;
                        case 2:
                            Console.Clear();
                            BubbleSort(letters);
                            PrintOutArray(letters);
                            break;
                        case 3:
                            Console.Clear();
                            MergeSort(numbers);
                            PrintOutArray(numbers);
                            break;
                        case 4:
                            Console.Clear();
                            MergeSort(letters);
                            PrintOutArray(letters);
                            break;
                        case 5:
                            Console.Clear();
                            QuickSort(numbers, 0, numbers.Length - 1);
                            PrintOutArray(numbers);
                            break;
                        case 6:
                            Console.Clear();
                            QuickSort(letters, 0, letters.Length - 1);
                            PrintOutArray(letters);
                            break;
                        case 7:
                            Console.Clear();
                            isProgramRunning = false;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Please choose a valid number.");
                    Console.ReadKey();
                }
            }
        }

        private static void Swap<T>(ref T left, ref T right)
        {
            T temp;
            temp = left;
            left = right;
            right = temp;
        }

        public static T[] BubbleSort<T>(T[] arrayToSort) where T: IComparable<T>
        {
            bool continueSorting = true;    // Declare boolean for the for-loop condition

            for (int i = 0; i < arrayToSort.Length - 1 && continueSorting; i++) // Run iterations while the array still needs to be sorted
            {
                continueSorting = false;

                for (int j = 0; j < arrayToSort.Length - 1; j++)    // Run iterations and check if the current element in the array needs to be swapped
                {
                    if(arrayToSort[j].CompareTo(arrayToSort[j + 1]) > 0)    // If the current element in the array is bigger than the next,
                    {                                                       // set the boolean to continue the initial for-loop condition
                        continueSorting = true;                             // and swap the elements
                        Swap(ref arrayToSort[j], ref arrayToSort[j + 1]);
                    }
                }
            }

            return arrayToSort;
        }
        
        public static T[] MergeSort<T>(T[] arrayToSort) where T : IComparable<T>
        {
            if (arrayToSort.Length <= 1)    // Return the the array if it has been divided to the lowest point
                return arrayToSort;

            T[] mid = new T[arrayToSort.Length / 2];    // Store the middle lenth of the array

            T[] left = new T[mid.Length];   // Declare array to store all the values up to the middle

            for (int i = 0; i < mid.Length; i++)
            {
                left[i] = arrayToSort[i];
            }

            T[] right = new T[arrayToSort.Length - mid.Length]; // Declare array to store the values from the middle to the end
            int k = 0;

            for (int i = mid.Length; i < arrayToSort.Length; i++)
            {
                right[k] = arrayToSort[i];
                k++;
            }

            MergeSort(left);    // Recursive call to divide and merge all elements on the left side of the array
            MergeSort(right);   // Recursive call to divide and merge all elements on the right side of the array
            return Merge(left, right, arrayToSort);
        }

        public static T[] Merge<T>(T[] left, T[] right, T[] arrayToSort) where T : IComparable<T>
        {
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < left.Length && j < right.Length) // While the integers havn't exceeded the length of any the arrays
            {
                if (left[i].CompareTo(right[j]) <= 0)   // If the current i-index of the left array is smaller than the j-index of the right array
                {                                       // assign it's value to that of the k-index on the array and increment the value of the i-index
                    arrayToSort[k] = left[i];
                    i++;
                }
                else                                    // If the current i-index of the left array is smaller than the j-index of the right array
                {                                       // assign it's value to that of the k-index on the array and increment the value of the i-index
                    arrayToSort[k] = right[j];
                    j++;
                }

                k++;    // Increment the k-index of the array at the end of the while-condition
            }

            while (i < left.Length)         // While there are any remaining elements in the left array
            {
                arrayToSort[k] = left[i];   // Assign the value of any remaining elements in the left array to the array
                i++;                        // and increment the i and k-indexes.
                k++;
            }
            while (j < right.Length)        // While there are any remaining elements in the left array
            {
                arrayToSort[k] = right[j];  // Assign the value of any remaining elements in the left array to the array
                j++;                        // and increment the i and k-indexes.
                k++;
            }

            return arrayToSort; // Return the array after it has been properly sorted
        }

        public static T[] QuickSort<T>(T[] arrayToSort, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (startIndex < endIndex)
            {
                int partitionIndex = Partition(arrayToSort, startIndex, endIndex);  // Get the index of the last element to be partitioned.
                QuickSort(arrayToSort, startIndex, partitionIndex - 1);    // Quicksort the array from the left side to the last pivot.
                QuickSort(arrayToSort, partitionIndex + 1, endIndex);  // Quicksort the array from the right side to the end of the array.
            }

            return arrayToSort;
        }

        private static int Partition<T>(T[] arrayToPartition, int start, int end) where T : IComparable<T>
        {
            T pivot = arrayToPartition[end];
            int pIndex = start; // Set partition index as start initially

            for (int i = start; i < end; i++)
            {
                if (arrayToPartition[i].CompareTo(pivot) <= 0)  // If the element at the current index is lesser than or equal to pivot
                {
                    Swap(ref arrayToPartition[i], ref arrayToPartition[pIndex]);    // Swap places with the current element and the partition index
                    pIndex++;
                }
            }

            Swap(ref arrayToPartition[pIndex], ref arrayToPartition[end]);  // Swap places with the last partitioned element
                                                                            // and the last element in the array
            return pIndex;
        }

        public static void PrintOutArray<T>(T[] arrayToPrintOut)
        {
            foreach(T variable in arrayToPrintOut)
            {
                Console.WriteLine(variable);
            }
            PrintArrayToFile(arrayToPrintOut);
            Console.ReadKey();
        }

        public static void PrintArrayToFile<T>(T[] arrayToPrintToFile)
        {
            string directoryLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] linesToWriteOut = arrayToPrintToFile.Select(s => Convert.ToString(s)).ToArray();
            System.IO.File.WriteAllLines(directoryLocation + @"\WriteFile.txt", linesToWriteOut);
        }
    }
}
