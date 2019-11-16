using System;
using System.Collections.Generic;
using _538_10_sided_die;

namespace _538_10_sided_die
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessLogic bl = new BusinessLogic();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Please enter the number of times you'd like to simulate the game");
                int numPlays = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine(bl.RollGame(numPlays));
                Console.WriteLine("To test again press enter to exit press (Q)");
                string leaveOrStay = Console.ReadLine();
                if (leaveOrStay == "q" || leaveOrStay == "Q")
                {
                    exit = true;
                }
            }
        }
    }
}



