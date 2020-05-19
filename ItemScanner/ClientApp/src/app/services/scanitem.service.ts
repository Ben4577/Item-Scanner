import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Item, ScannedItems } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class ScanitemService {

  baseUrl: string = 'https://localhost:44303/api/scanning/';

  constructor(private http: HttpClient) { }

  getItemList() {
    return this.http.get<Item[]>(this.baseUrl + 'getItems');
  }


  scanItem(item: Item): Observable<ScannedItems> {
    const url = this.baseUrl + 'scanItem/';
    return this.http.post(url, item) as Observable<ScannedItems>;
  }



}

