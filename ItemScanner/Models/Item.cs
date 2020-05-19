using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemScanner.Models
{
    public class Item
    {

        public Item()
        {
            discount = new Discount();
        }

        public string Name { get; set; } = "";
        public double Price { get; set; } = 0;
        public int TotalItems { get; set; } = 0;
        public double TotalDiscountedItemPrice { get; set; } = 0;
        public double TotalItemPrice { get; set; } = 0;
        public Discount discount { get; set; }
        public string DiscountText { get; set; } = "";
    }
}
