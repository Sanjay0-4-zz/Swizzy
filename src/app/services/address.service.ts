import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable()
export class AddressService {
  constructor(private http: HttpClient) { }
  postAddress(form){
    console.log('service',form);
    this.http.post('https://localhost:44335/api/addresses', form).subscribe(res => {
      console.log(res)
    })
  }

}
