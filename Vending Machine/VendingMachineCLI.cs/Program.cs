using System;
using System.Collections.Generic;
using System.Text;
using Capstone;
using Capstone.Classes;

namespace CapstoneCLI
{

   
    public class Program
    {
        public const string FILE_PATH = @"C:\Users\Student\workspace\team6-c-week4-pair-exercises\19_Capstone\Example Files\VendingMachine.txt";
        static void Main(string[] args)
        {
         
            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.CreateItemDictionary(FILE_PATH);
            Menu vendingMenu = new Menu(vendingMachine);
            vendingMenu.MainMenu();


        }
    }
}
