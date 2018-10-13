import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ItemsList } from '../models/items.model';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders(
    {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    }
  )
};

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

  itemsApiUrl: string;
  constructor(private http: HttpClient) { }

  getItems(restaurantId: number): Observable<ItemsList[]>{
    this.itemsApiUrl = 'https://localhost:44335/api/items/' + restaurantId;
    return this.http.get<ItemsList[]>(this.itemsApiUrl);
  }
}
