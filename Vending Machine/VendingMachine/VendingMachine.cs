using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Classes;
using System.Globalization;

namespace Capstone
{
    public class VendingMachine
    {

        public Dictionary<string, Item> _itemDictionary = new Dictionary<string, Item>(); //Holds the location of the item as well as the "Item" type.
        


        public Dictionary<string,Item> ReturnDictionary()
        {
            return _itemDictionary;
        }

        public void CreateItemDictionary(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    decimal cost;
                    string line = sr.ReadLine();
                    var itemProperties = line.Split("|");
                    Decimal.TryParse(itemProperties[2],out cost);
                    string code = itemProperties[0];
                    string name = itemProperties[1];
                    string type = itemProperties[3];

                    if (type.ToLower() == "gum")
                    {
                        _itemDictionary.Add(code, new gum(code, name, cost, type));
                    }
                    else if (type.ToLower() == "candy")
                    {
                        _itemDictionary.Add(code,new candy(code, name, cost, type));
                    }
                    else if (type.ToLower() == "drink")
                    {
                        _itemDictionary.Add(code, new drink(code, name, cost, type));
                    }
                    else if (type.ToLower() == "chip")
                    {
                        _itemDictionary.Add(code, new chips(code, name, cost, type));
                    }
                }
            }
        }
    


        
        public decimal _totalMoney;
        public decimal _moneyInput;
        public decimal _balance;

        public decimal FeedMoney(decimal insertedMoney)
        {
            _balance += insertedMoney;
            WriteLog($"FeedMoney ${insertedMoney} ${_balance}");
            return _balance;
            
        }

        public string PrintItems()
        {
            string result = "";
            foreach(var item in _itemDictionary.Values)
            {
                if(item.ItemQuantity == 0)
                {
                    result = result+$"{item.ItemName}            SOLD OUT"+"\n";
                }
                else
                {
                    //result = result+$"{item.ItemCode}  {item.ItemName} \t                  ${item.ItemCost} "+"\n";

                   result = result+ string.Format("{0,0} {1, -20} {2:C,2}\n", item.ItemCode,item.ItemName,item.ItemCost.ToString("C2"));
                }

            }
            return result;
        }

        public string Purchase(string code)
        {
            string result;
            code = code.ToUpper();

            if(_itemDictionary.ContainsKey(code))
            {
               var price =  _itemDictionary[code].ItemCost;
               var quantity = _itemDictionary[code].ItemQuantity;

                if (_balance < price)
                {
                    result = "You don't have enough money!";
                }
                else if (quantity <= 0)
                {
                    result = "There aren't any of those left!";
                }
                else
                {
                    _itemDictionary[code].ItemQuantity--;
                    _balance -= price;
                    _totalMoney += price;
                    result = ((IDisplayMessage)_itemDictionary[code]).DisplayMessage();
                    WriteLog($"{_itemDictionary[code].ItemName} {_itemDictionary[code].ItemCode} ${_itemDictionary[code].ItemCost} ${_balance}");
                }

            }
            else
            {
                result = "Not a valid selection";
            }


            return result;

        }

        public string MakeChange()
        {
            decimal priorBalance = _balance;
            int numQuarters = (int)(_balance / .25M);
            _balance -= numQuarters * .25M;
            int numDimes = (int)(_balance / .1M);
            _balance -= numDimes * .1M;
            int numNickels = (int)(_balance / .05M);
            _balance -= numNickels * .05M;
            WriteLog($"MakeChange ${priorBalance} ${_balance}");

            string result = $"Your change is {numQuarters} Quarters, {numDimes} Dimes, and {numNickels} Nickels";
            return result;
        }

        public void WriteSales()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\workspace\team6-c-week4-pair-exercises\19_Capstone\Example Files\VendingSalesReport.txt"))
            { foreach (Item kvp in _itemDictionary.Values)
                {
                    sw.WriteLine($"{kvp.ItemName}| {5 - kvp.ItemQuantity}");
                }

                sw.WriteLine($"{_totalMoney}");
            }
        }

        public void WriteLog(string writing)
        {
          
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\workspace\team6-c-week4-pair-exercises\19_Capstone\Example Files\VendingLog.txt", true))
            {
                sw.WriteLine($"{DateTime.UtcNow} {writing}");
            }
       }
}
}
