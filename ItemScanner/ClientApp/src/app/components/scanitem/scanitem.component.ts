import { Component, OnInit } from '@angular/core';
import { ScanitemService } from '../../services/scanitem.service';
import { Item, ScannedItems } from '../../models/models';
import {map} from 'rxjs/operators';

@Component({
  selector: 'app-scanitem',
  templateUrl: './scanitem.component.html',
  styleUrls: ['./scanitem.component.css']
})
export class ScanitemComponent implements OnInit {

  constructor(private scanService: ScanitemService) { }

  items: Item[];
  selectedItem: string;
  scannedItems: ScannedItems;
  scItems: Item[]
  grandTotal: number = 0;
  grandTotalDiscounted: number = 0;


  ngOnInit() {
    //Get the items
    this.scanService.getItemList().subscribe(result => {
      this.items = result;
      console.log(this.items);
    });
  }


  onItemSelected() {
    //get the item data from the list
    let item = this.items.find(x => x.name === this.selectedItem);

    this.scanService.scanItem(item).subscribe(
      result => {

        this.grandTotal = result.grandTotal;
        this.grandTotalDiscounted = result.grandTotalDiscounted;
        this.scItems = result.scannedItemsList;
      });

  };

  }

