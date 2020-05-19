using ItemScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemScanner.Services
{
    public class ScanService : IScanService
    {

        public async Task<List<Item>> GetItems()
        {
            var items = new List<Item> {
              new Item
               {
                Name ="A99",
                Price = 0.50,
                TotalItems = 0,
                TotalItemPrice = 0
                },
                new Item
               {
                Name ="B15",
                Price = 0.30,
                TotalItems = 0,
                TotalItemPrice = 0
                },
               new Item
               {
                Name ="C40",
                Price = 0.60,
                TotalItems = 0,
                TotalItemPrice = 0
                }
            };
            return items;
        }


        public async Task<ScannedItems> ScanItem(Item item, ScannedItems scannedItems)
        {
            //create new scanned Item list if not created //////////////////
            if (scannedItems == null)
            {
                ScannedItems scItems = new ScannedItems();

                //add to its total items
                item.TotalItems += 1;

                scItems.ScannedItemsList.Add(item);
                //increment the total
                scItems.GrandTotal += item.Price;

                return scItems;
            }

            //list already has items//////////////////////////////////////////

            //find if the item is alreadsy in the list
            var foundItem = scannedItems.ScannedItemsList.Where(x => x.Name == item.Name).FirstOrDefault();

            //no existing item add to the list
            if(foundItem == null)
            {
                //add to its total items
                item.TotalItems += 1;

                scannedItems.ScannedItemsList.Add(item);
                //increment the total
                scannedItems.GrandTotal += item.Price;
            }
            else
            {
                //add to its total items
                foundItem.TotalItems += 1;

                //increment the total
                scannedItems.GrandTotal += foundItem.Price;
            }

            return scannedItems;
        }

    }
}
