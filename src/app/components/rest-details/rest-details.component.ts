import { Component, OnInit, Input} from '@angular/core';
import { RestaurantdetailsService } from '../../services/restaurantdetails.service';
import { RestaurantDetails } from '../../models/restaurant.model';
import { ActivatedRoute } from '@angular/router';
import { ItemsList } from '../../models/items.model';
import { ItemsService } from '../../services/items.service';
import { MatButtonModule, MatToolbarModule, MatCheckboxModule } from '@angular/material'; 
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-rest-details',
  templateUrl: './rest-details.component.html',
  styleUrls: ['./rest-details.component.css']
})

export class RestDetailsComponent implements OnInit {
  @Input() restaurant: RestaurantDetails[];
  id: number;
  @Input() items: ItemsList[];
  qty1: number;
  qty2: number;
  qty3: number;
  qty4: number;
  qty5: number;
  tmpqty: number;
  firstFormGroup: FormGroup;
  formFlag=false;

  lat: number = 28.4259961; 
  lng: number = 77.0326803;
  locationChosen=false;

  constructor(private restdetail: RestaurantdetailsService, private rt: ActivatedRoute, private itmService: ItemsService, private _formBuilder: FormBuilder) { }
 ndx1:number;

  ngOnInit() {
    this.id= +this.rt.snapshot.paramMap.get('id');
    // console.log(this.id);
    this.restdetail.getRestaurant(this.id).subscribe(res => this.restaurant = res);

    this.itmService.getItems(this.id).subscribe(resp => this.items = resp);
    this.qty1 = 1;
    this.qty2 = 1;
    this.qty3 = 1;
    this.qty4 = 1;
    this.qty5 = 1;
 
    this.firstFormGroup = this._formBuilder.group({
      Floor: ['', Validators.required],
      Locality: ['', Validators.required]
    });

  
  }
  
  btnqty1inc (){
    ++this.qty1;
  }
  btnqty2inc (){
    ++this.qty2;
  }
  btnqty3inc (){
    ++this.qty3;
  }
  btnqty4inc (){
    ++this.qty4;
  }
  btnqty5inc(){
    ++this.qty5;
  }

  btnqty1dec(){
    --this.qty1;
  }
 
  btnqty2dec(){
    --this.qty2;
  }
  btnqty3dec(){
    --this.qty3;
  }
  btnqty4dec(){
    --this.qty4;
  }
  btnqty5dec(){
    --this.qty5;
  }
  toggle(){
    this.formFlag = !this.formFlag;
  }
}