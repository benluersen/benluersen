﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date_Palindrome_finder
{
    class CLI
    {
        public void cli()
        {
            BusinessLogic bl = new BusinessLogic();
            Console.WriteLine("Please enter the year you'd like to stop at and press enter");
            string endYear = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"There are {bl.HowManyPalindromes(endYear).Count()} palindromic dates from now until the year {endYear}");
            Console.WriteLine("Would you like to see them all? (y/n)");
            if (Console.ReadKey().KeyChar == 'y')
            {
                Console.Clear();
                foreach (var date in bl.HowManyPalindromes(endYear))
                {
                    Console.WriteLine($"{date.Substring(0, 2)}/{date.Substring(2, 2)}/{date.Substring(4, 4)}");
                }
                Console.ReadKey();
            }
        }
    }
}
