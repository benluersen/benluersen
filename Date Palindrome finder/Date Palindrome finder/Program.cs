using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_Palindrome_finder
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessLogic bl = new BusinessLogic();
            Console.WriteLine("Please enter the year you'd like to stop at and press enter");
            string endYear = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"There are {bl.HowManyPalindromes(endYear)} palindromic dates from now until the year {endYear}");
            Console.ReadKey();
        }
    }
}
