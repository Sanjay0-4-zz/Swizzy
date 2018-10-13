import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  constructor(private http: HttpClient) { }
  getRestaurantDetails(){
    this.http.get('https://localhost:44335/api/restaurants').subscribe(data => console.log(data));
  }
}
