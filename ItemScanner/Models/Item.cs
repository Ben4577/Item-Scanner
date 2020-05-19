using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemScanner.Models
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int TotalItems { get; set; }
        public int TotalItemPrice { get; set; }
    }
}
