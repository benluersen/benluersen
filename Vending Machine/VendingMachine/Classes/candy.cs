using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace Capstone.Classes
{
    class candy : Item, IDisplayMessage

    {
        public candy(string itemCode, string itemName, decimal itemCost, string itemType) : base(itemCode, itemName, itemCost, itemType)
        {
        }
        public string DisplayMessage()
        {
            return "Munch Munch, Yum!";
        }
    }
}
