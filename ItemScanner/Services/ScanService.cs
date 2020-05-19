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
                TotalItemPrice = 0,
                discount = new Discount
                {
                 DiscountNumber = 2,
                 DiscountCalc = 0.8
                }
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
                TotalItemPrice = 0,
                  discount = new Discount
                {
                 DiscountNumber = 2,
                 DiscountCalc = 0.5
                }
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
                item.TotalItemPrice += item.Price;

                scItems.ScannedItemsList.Add(item);

                //increment the total
                scItems.GrandTotal += item.TotalItemPrice;

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
                item.TotalItemPrice += item.Price;

                scannedItems.ScannedItemsList.Add(item);
            }
            else
            {
                //add to its total items
                foundItem.TotalItems += 1;

                //calculate for items with no discount number
                if (foundItem.discount.DiscountNumber == 0)
                {
                    foundItem.TotalItemPrice += foundItem.Price;
                }
                else
                {

                    //see if there is a discount for this number (there could be multiples. remainder should be = 0)
                    if (foundItem.TotalItems % foundItem.discount.DiscountNumber == 0)
                    {
                        //re calculate the total item price
                        foundItem.TotalItemPrice = 0;
                        foundItem.TotalItemPrice = foundItem.TotalItems * foundItem.Price;

                        //get the discount
                        foundItem.TotalItemPrice = foundItem.TotalItemPrice * foundItem.discount.DiscountCalc;
                    }
                    else
                    {
                        foundItem.TotalItemPrice += foundItem.Price;
                    }
                }

            }


            //get the new grand total
            scannedItems.GrandTotal = 0;
            foreach (var i in scannedItems.ScannedItemsList)
            {
                scannedItems.GrandTotal += i.TotalItemPrice;
            }

            return scannedItems;
        }




    }
}
