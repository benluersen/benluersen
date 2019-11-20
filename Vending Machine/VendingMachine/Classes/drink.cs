using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace Capstone.Classes
{ 
    class drink : Item, IDisplayMessage
    {
        public drink(string itemCode, string itemName, decimal itemCost, string itemType) : base(itemCode, itemName, itemCost, itemType)
        {
        }
        public string DisplayMessage()
        {
            return "Glug Glug, Yum!";
        }
    }
}
