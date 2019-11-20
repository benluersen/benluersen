using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone;

namespace Capstone.Classes
{
    public class Item
    {
        public string ItemCode { get; private set; }
        public string ItemName { get; private set; }
        public decimal ItemCost { get; private set; }
        public string ItemType { get; private set; }
        public int ItemQuantity { get; set; } = 5;


        public Item(string itemCode, string itemName, decimal itemCost, string itemType)
        {
            ItemCode = itemCode;
            ItemName = itemName;
            ItemCost = itemCost;
            ItemType = ItemType;
        }

        


        
    }
}
