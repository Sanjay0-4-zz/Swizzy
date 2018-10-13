import { Component, OnInit } from '@angular/core';
import{MatFormFieldModule } from '@angular/material';
import {MatInputModule} from'@angular/material';
import{MatIconModule} from '@angular/material';
import{MatButtonModule} from '@angular/material';
import { UserService } from '../../services/user.service';
import { UserDetails } from '../../models/user.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  hide = true;
  userdt: UserDetails[];
  loginForm: FormGroup;
  constructor(private userser: UserService, private formb: FormBuilder) { }

  ngOnInit() {
    this.loginForm = this.formb.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  checkUDetails(){
    this.userser.getUDetails(1).subscribe(res => this.userdt = res);
  }
}
