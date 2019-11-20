using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace Capstone.Classes
{
    class chips : Item, IDisplayMessage
    {
        public chips(string itemCode, string itemName, decimal itemCost, string itemType) : base(itemCode, itemName, itemCost, itemType)
        {
        }
        public string DisplayMessage()
        {
            return "Crunch Crunch, Yum!";
        }
    }
}
