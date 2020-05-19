using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemScanner.Models
{
    public class ScannedItems
    {
        public ScannedItems()
        {
            ScannedItemsList = new List<Item>();
        }

        public List<Item> ScannedItemsList { get; set; }
        public double GrandTotal { get; set; }
        public double GrandTotalDiscounted { get; set; }

    }
}
