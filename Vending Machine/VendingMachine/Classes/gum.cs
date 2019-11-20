using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace Capstone.Classes
{
    class gum : Item, IDisplayMessage
    {
        public gum(string itemCode, string itemName, decimal itemCost, string itemType) : base(itemCode, itemName, itemCost, itemType)
        {
        }
        public string DisplayMessage()
        {
            return "Chew Chew, Yum!";
        }
    }
}
