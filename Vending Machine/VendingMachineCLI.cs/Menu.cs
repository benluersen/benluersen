using System;
using Capstone.Classes;
using Capstone;

namespace CapstoneCLI
{
    public class Menu
    {
        protected static VendingMachine _vendingMachine = null;
         
        public Menu(VendingMachine vendingMachine)
        {
            _vendingMachine = vendingMachine;
        }
        

        public void MainMenu()
        {
            bool exit = false;

            while(!exit)
            {
                Console.Clear();
                // Console.WriteLine($"Current Balance: {_vendingMachine._balance}");
                Console.WriteLine("Current Balance: {0:C}",_vendingMachine._balance);
                Console.WriteLine("1:Enter Money\n2:View Items\n3:Make Change\n4:Exit\n");
               
                Console.WriteLine("Make Selection...");

                var keySelection = Console.ReadKey();
                Console.Clear();

                if (keySelection.Key == ConsoleKey.D1 || keySelection.Key == ConsoleKey.NumPad1)
                {
                    decimal insertedMoney;
                    //Decimal.TryParse(Console.ReadLine(), out insertedMoney);
                    string validateInput;
                    do {
                        Console.WriteLine("Please enter your money in whole dollar amounts");
                        validateInput = Console.ReadLine();
                    }while(!Decimal.TryParse(validateInput, out insertedMoney));


                    _vendingMachine.FeedMoney(insertedMoney);
                   //Console.WriteLine($"Your current balance is {_vendingMachine._balance} \nPress any key to return to the main menu");
                   Console.WriteLine("Your current balance is {0:C} \nPress any key to return to the main menu", _vendingMachine._balance);
                }

                else if (keySelection.Key == ConsoleKey.D2 || keySelection.Key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine(_vendingMachine.PrintItems());
                    Console.WriteLine("Please enter the Slot corresponding to the item you'd like to purchase");
                    string itemCode = Console.ReadLine();
                    Console.WriteLine(_vendingMachine.Purchase(itemCode));
                }
                else if (keySelection.Key == ConsoleKey.D3 || keySelection.Key == ConsoleKey.NumPad3)
                {
                    Console.WriteLine(_vendingMachine.MakeChange());
                }

                else if (keySelection.Key == ConsoleKey.D4 || keySelection.Key == ConsoleKey.NumPad4)
                {
                    exit = true;
                }

                else if (keySelection.Key == ConsoleKey.D5 || keySelection.Key == ConsoleKey.NumPad5)
                {
                    Console.WriteLine("To retrieve sales report press 1\nTo retrieve log press 2");
                    keySelection = Console.ReadKey();
                    if (keySelection.Key == ConsoleKey.D1 || keySelection.Key == ConsoleKey.NumPad1)
                    {
                        _vendingMachine.WriteSales();
                    }
                    else if (keySelection.Key == ConsoleKey.D2 || keySelection.Key == ConsoleKey.NumPad2)
                    {
                        _vendingMachine.WriteLog("Log Recorded");
                    }
                    else
                    {
                        Console.WriteLine("Make a valid selection");
                    }
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid selection, press any key to continue...");

                }
                Console.ReadKey();






            }

            
        }




        
    }
}
