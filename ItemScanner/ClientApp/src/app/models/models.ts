
export class ScannedItems {
  scannedItemsList: Item[]
  grandTotal: number = 0;
  grandTotalDiscounted: number = 0;
}


export class Item {
  name: string = "";
  price: number = 0;
  totalItems: number = 0;
  totalItemPrice: number = 0;
  totalDiscountedItemPrice: number = 0;
  discountText = "";
}


