import { Component, OnInit } from '@angular/core';
import { RestaurantdetailsService } from '../../services/restaurantdetails.service';
import { RestaurantDetails } from '../../models/restaurant.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  restaurant: RestaurantDetails[];
  constructor(private restdetail: RestaurantdetailsService) { }

  ngOnInit() {
  }

  bkDetails(){
    this.restdetail.getRestaurant(1).subscribe(res => this.restaurant = res);
  }

  ddDetails(){
    this.restdetail.getRestaurant(2).subscribe(res => this.restaurant = res); 
  }

  kkhDetails(){
    this.restdetail.getRestaurant(4).subscribe(res => this.restaurant = res);
  }

  hDetails(){
    this.restdetail.getRestaurant(5).subscribe(res => this.restaurant = res); 
  }

  dDetails(){
    this.restdetail.getRestaurant(6).subscribe(res => this.restaurant = res); 
  }
}
