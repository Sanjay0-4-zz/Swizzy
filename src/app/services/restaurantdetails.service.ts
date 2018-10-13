import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { RestaurantDetails } from '../models/restaurant.model';
import { Observable } from '../../../node_modules/rxjs';

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
export class RestaurantdetailsService {

  restaurantdetailApiUrl: string;

  constructor(private http: HttpClient) { }

  getRestaurant(restaurantId: number): Observable<RestaurantDetails[]> {
    this.restaurantdetailApiUrl = 'https://localhost:44335/api/restaurants/' + restaurantId;  
    return this.http.get<RestaurantDetails[]>(this.restaurantdetailApiUrl);
  }
}
