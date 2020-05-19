using ItemScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemScanner.Services
{
    public interface IScanService
    {
        public Task<List<Item>> GetItems();
        public Task<ScannedItems> ScanItem(Item item, ScannedItems savedScannedItems);
    }
}
