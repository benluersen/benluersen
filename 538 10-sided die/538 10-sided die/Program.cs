using System;
using System.Collections.Generic;
using _538_10_sided_die;

namespace _538_10_sided_die
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of times you'd like to simulate the game");
            int numPlays = Convert.ToInt32(Console.ReadLine());
            BusinessLogic bl = new BusinessLogic();
            Console.WriteLine(bl.RollGame(numPlays));
            Console.ReadKey();
        }
    }
}


