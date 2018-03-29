using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Inlämningsuppgift3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isProgramRunning = true;

            while (isProgramRunning)
            {
                Console.Clear();
                Console.Write("1. Sortera medlemmar efter ålder (äldst först)" + "\t");
                Console.Write("2. Sortera medlemmar efter efternamn (A till Ö)" + "\n");
                Console.Write("3. Sortera medlemmar efter betalning (icke betald först)" + "\t");
                Console.Write("4. Sök medlem" + "\n");
                Console.Write("5. Bubbelsortera 10000 slumpartade tal" + "\n");
                Console.Write("6. Bubbelsortera 20000 slumpartade tal" + "\n");
                Console.Write("7. Bubbelsortera 40000 slumpartade tal" + "\n");
                Console.Write("8. Mergesortera 10000 slumpartade tal" + "\n");
                Console.Write("9. Mergesortera 20000 slumpartade tal" + "\n");
                Console.Write("10. Mergesortera 40000 slumpartade tal" + "\n");

                Console.Write("11. Exit" + "\n");
                Console.WriteLine("Choice: ");

                try
                {
                    Int32.TryParse(Console.ReadLine(), out int choice);

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            members = members.OrderBy(o => o.PersonalIdentityNumber).ToList();
                            PrintArray(members);
                            break;
                        case 2:
                            Console.Clear();
                            members = members.OrderBy(o => o.LastName).ToList();
                            PrintArray(members);
                            break;
                        case 3:
                            Console.Clear();
                            members = members.OrderBy(o => o.HasPayedMembershipFee).ToList();
                            PrintArray(members);
                            break;
                        case 4:
                            Console.Clear();
                            string userInput = Console.ReadLine();
                            PrintMemberByLastName(userInput);
                            break;
                        case 5:
                            Console.Clear();
                            Stopwatch stopwatchBubble1 = new Stopwatch();
                            List<long> listToBubbleSort = CreateRandomList(10000);
                            stopwatchBubble1.Start();
                            listToBubbleSort = BubbleSort(listToBubbleSort);
                            Console.WriteLine(stopwatchBubble1.Elapsed);
                            stopwatchBubble1.Stop();
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.Clear();
                            Stopwatch stopwatchBubble2 = new Stopwatch();
                            List<long> listToBubbleSort2 = CreateRandomList(20000);
                            stopwatchBubble2.Start();
                            listToBubbleSort2 = BubbleSort(listToBubbleSort2);
                            Console.WriteLine(stopwatchBubble2.Elapsed);
                            stopwatchBubble2.Stop();
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Clear();
                            Stopwatch stopwatchBubble3 = new Stopwatch();
                            List<long> listToBubbleSort3 = CreateRandomList(40000);
                            stopwatchBubble3.Start();
                            listToBubbleSort3 = BubbleSort(listToBubbleSort3);
                            Console.WriteLine(stopwatchBubble3.Elapsed);
                            stopwatchBubble3.Stop();
                            Console.ReadKey();
                            break;
                        case 8:
                            Console.Clear();
                            Stopwatch stopwatchMerge1 = new Stopwatch();
                            List<long> listToMergeSort1 = CreateRandomList(10000);
                            stopwatchMerge1.Start();
                            listToMergeSort1 = Split(listToMergeSort1);
                            Console.WriteLine(stopwatchMerge1.Elapsed);
                            stopwatchMerge1.Stop();
                            Console.ReadKey();
                            break;
                        case 9:
                            Console.Clear();
                            Stopwatch stopwatchMerge2 = new Stopwatch();
                            List<long> listToMergeSort2 = CreateRandomList(20000);
                            stopwatchMerge2.Start();
                            listToMergeSort2 = Split(listToMergeSort2);
                            Console.WriteLine(stopwatchMerge2.Elapsed);
                            stopwatchMerge2.Stop();
                            Console.ReadKey();
                            break;
                        case 10:
                            Console.Clear();
                            Stopwatch stopwatchMerge3 = new Stopwatch();
                            List<long> listToMergeSort3 = CreateRandomList(40000);
                            stopwatchMerge3.Start();
                            listToMergeSort3 = Split(listToMergeSort3);
                            Console.WriteLine(stopwatchMerge3.Elapsed);
                            stopwatchMerge3.Stop();
                            Console.ReadKey();
                            break;
                        case 11:
                            Console.Clear();
                            isProgramRunning = false;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Välj ett nummer i menyn.");
                    Console.ReadKey();
                }
            }
        }

        private static void PrintArray(List<Member> membersToPrint)
        {
            for (int i = 0; i < membersToPrint.Count; i++)
            {

                if (membersToPrint[i].HasPayedMembershipFee)
                    Console.WriteLine("Person nr: " + membersToPrint[i].PersonalIdentityNumber + " Efternamn: " + membersToPrint[i].LastName + " Förnamn: " + membersToPrint[i].FirstName + " <PAID>");
                else
                    Console.WriteLine("Person nr: " + membersToPrint[i].PersonalIdentityNumber + " Efternamn: " + membersToPrint[i].LastName + " Förnamn: " + membersToPrint[i].FirstName + " <NOT PAID>");
            }

            Console.ReadKey();
        }

        private static void PrintMemberByLastName(string lastName)
        {
            for (int i = 0; i < members.Count; i++)
            {
                if (lastName == members[i].LastName)
                {
                    if (members[i].HasPayedMembershipFee)
                        Console.WriteLine("Person nr: " + members[i].PersonalIdentityNumber + " Förnamn: " + members[i].LastName + " FirstName: " + members[i].FirstName + " <PAID>");
                    else
                        Console.WriteLine("Person nr: " + members[i].PersonalIdentityNumber + " Förnamn: " + members[i].LastName + " FirstName: " + members[i].FirstName + " <NOT PAID>");
                }
            }

            Console.ReadKey();
        }

        private static void Swap<T>(List<T> listToSort, int a, int b)
        {
            T temp;
            temp = listToSort[a];
            listToSort[a] = listToSort[b];
            listToSort[b] = temp;
        }

        public static List<long> CreateRandomList(int choice)
        {
            Random r = new Random();
            List<long> randomizedNumberList = new List<long>();
            int maxValue = int.MaxValue;
            int minValue = int.MinValue;
            for (int i = 0; i <= choice; i++)
            {
            Stopwatch stopwatchBubble1 = new Stopwatch();
                long j = r.Next(minValue, maxValue);

                randomizedNumberList.Add(j);
            }

            return randomizedNumberList;
        }

        public static List<T> BubbleSort<T>(List<T> listToSort) where T : IComparable<T>
        {
            int i = 0;
            bool continueSorting = true;    // Declare boolean for the for-loop condition

            while (i < listToSort.Count - 1 && continueSorting) // Run iterations while the array still needs to be sorted
            {
                continueSorting = false;

                for (int j = 0; j < listToSort.Count - 1; j++)    // Run iterations and check if the current element in the array needs to be swapped
                {
                    if (listToSort[j].CompareTo(listToSort[j + 1]) > 0)    // If the current element in the array is bigger than the next,
                    {                                                       // set the boolean to continue the initial for-loop condition
                        continueSorting = true;                             // and swap the elements
                        Swap(listToSort, j, j + 1);
                    }
                }

                i++;
            }
            
            return listToSort;
        }

        public static List<T> Split<T>(List<T> numbers) where T : IComparable<T>
        {
            if (numbers.Count <= 1)
            {
                return numbers;
            }

            List<T> left = new List<T>();
            List<T> right = new List<T>();

            int middle = numbers.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(numbers[i]);
            }
            
            for (int i = middle; i < numbers.Count; i++)
            {
                right.Add(numbers[i]);
            }

            left = Split(left);
            right = Split(right);

            return Merge(left, right);
        }

        private static List<T> Merge<T>(List<T> left, List<T> right) where T : IComparable<T>
        {
            List<T> result = new List<T>();
            
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First().CompareTo(right.First()) <= 0)
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
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

            return result;
        }

        public static List<Member> members = new List<Member>()
        {
            new Member { PersonalIdentityNumber = 199512230123, LastName = "Ernst", FirstName = "Albert", HasPayedMembershipFee = true },
            new Member { PersonalIdentityNumber = 200009101434, LastName = "Hoffmeister", FirstName = "Ludwig", HasPayedMembershipFee = false },
            new Member { PersonalIdentityNumber = 196508251234, LastName = "Kim", FirstName = "Seung-ya", HasPayedMembershipFee = true },
            new Member { PersonalIdentityNumber = 199803199876, LastName = "Johnson", FirstName = "Edwin", HasPayedMembershipFee = false },
            new Member { PersonalIdentityNumber = 193405061337, LastName = "Brutus", FirstName = "Matthew", HasPayedMembershipFee = true },
            new Member { PersonalIdentityNumber = 193405061321, LastName = "Brutus", FirstName = "Marcus", HasPayedMembershipFee = false },
            new Member { PersonalIdentityNumber = 193612011998, LastName = "Pierovich", FirstName = "Svoloch", HasPayedMembershipFee = true },
            new Member { PersonalIdentityNumber = 197801211923, LastName = "Jakobwicz", FirstName = "Gregor", HasPayedMembershipFee = false },
            new Member { PersonalIdentityNumber = 194504121384, LastName = "Durst", FirstName = "Fredric", HasPayedMembershipFee = true },
            new Member { PersonalIdentityNumber = 195605231312, LastName = "Ngugi", FirstName = "Nuewe", HasPayedMembershipFee = false },
            new Member { PersonalIdentityNumber = 197606301930, LastName = "Li", FirstName = "Chang", HasPayedMembershipFee = true },
            new Member { PersonalIdentityNumber = 199807091939, LastName = "Frigas", FirstName = "Emaneul", HasPayedMembershipFee = false },
            new Member { PersonalIdentityNumber = 193408091338, LastName = "Darc", FirstName = "Jeanne", HasPayedMembershipFee = true },
            new Member { PersonalIdentityNumber = 195409251397, LastName = "Ali", FirstName = "Mahmut", HasPayedMembershipFee = false },
            new Member { PersonalIdentityNumber = 196511211336, LastName = "Dien", FirstName = "Xuoc", HasPayedMembershipFee = true },
            new Member { PersonalIdentityNumber = 198910121395, LastName = "Oystein", FirstName = "Anne", HasPayedMembershipFee = false },
            new Member { PersonalIdentityNumber = 198704221934, LastName = "Tsuruya", FirstName = "Miho", HasPayedMembershipFee = true },
            new Member { PersonalIdentityNumber = 197403111333, LastName = "Surayaa", FirstName = "Laksmhi", HasPayedMembershipFee = false },
            new Member { PersonalIdentityNumber = 196806081332, LastName = "Ngugi", FirstName = "Achiba", HasPayedMembershipFee = true },
            new Member { PersonalIdentityNumber = 197407281331, LastName = "Inoue", FirstName = "Akika", HasPayedMembershipFee = false }
        };
    }
}
