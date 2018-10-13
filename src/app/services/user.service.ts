import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDetails } from '../models/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  details: UserDetails[];
  userApiUrl: string;
  constructor(private http: HttpClient) { }

  getUDetails(id: number): Observable<UserDetails[]>{
      this.userApiUrl = 'https://localhost:44335/api/users/' + id;
      return this.http.get<UserDetails[]>(this.userApiUrl);
  }

  postUDetails(form){
    this.http.post('https://localhost:44335/api/users', form).subscribe(res => {
      console.log(res)
    });
  }
}
