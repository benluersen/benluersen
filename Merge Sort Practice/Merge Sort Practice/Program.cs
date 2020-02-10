using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort_Practice_Vs_Bubble_Sort_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessLogic bl = new BusinessLogic();
            List<int> userMergeList = new List<int>();
            List<int> bubbleList = new List<int>();
            List<int> sorted;
            Random random = new Random();
            Console.WriteLine("If you want a random list to be made press any key other than 2\nIf you want to enter your own list press 2");
            char userOrAuto = Console.ReadKey().KeyChar;
            if (userOrAuto == '2')
            {
                Console.Clear();
                Console.WriteLine("Enter what you want to be sorted (space separated)");
                string userInput = Console.ReadLine();
                try
                {
                    userMergeList = userInput.Split(' ').Select(Int32.Parse).ToList();
                }
                catch
                {
                    Console.WriteLine("you entered something you weren't supposed to baddie");
                    Console.WriteLine("I don't feel like programming another loop so restart to program to try again");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("How long should your list be?");
                int listLength = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Random List");
                for (int i = 0; i < listLength; i++)
                {
                    userMergeList.Add(random.Next(0, 1000));
                    Console.Write(userMergeList[i] + " ");
                }
            }
            bubbleList = userMergeList;
            Console.WriteLine();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            sorted = bl.MergeSort(userMergeList);
            watch.Stop();
            var elapsedMsMerge = watch.ElapsedMilliseconds;
            Console.WriteLine($"Hey, your list is in order now I hope: \t\t\t\t\t({elapsedMsMerge}ms) ");
            foreach (int num in sorted)
            {
                Console.Write(num + " ");
            }
            var bubbleWatch = System.Diagnostics.Stopwatch.StartNew();
            bubbleList = bl.BubbleSort(bubbleList);
            bubbleWatch.Stop();
            var elapsedMsBubble = bubbleWatch.ElapsedMilliseconds;
            Console.Write($"\n Merge : {elapsedMsMerge}ms \t\t\t\t Bubble {elapsedMsBubble}ms");
            Console.Read();
        }
    }  
}
