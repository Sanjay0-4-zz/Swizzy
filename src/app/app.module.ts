import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule  } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatCheckboxModule } from '@angular/material';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import { HomeComponent } from './components/home/home.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule, MatFormFieldModule, MatMenuModule, MatInputModule, MatRadioModule, MatTableModule, MatStepperModule  } from '@angular/material';
import { IndexComponent } from './components/index/index.component';
import { LoginComponent } from './components/login/login.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { TeamComponent } from './components/team/team.component';
import { RestDetailsComponent } from './components/rest-details/rest-details.component';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { TrackingComponent } from './components/tracking/tracking.component';
import { AgmCoreModule } from '@agm/core';
import { AddressService } from './services/address.service';
import { RestaurantdetailsService} from './services/restaurantdetails.service';
import { UserService } from './services/user.service';

const routes: Routes = [
  {
    path: 'index',
    component: IndexComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'sign-up',
    component: SignUpComponent
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'team',
    component: TeamComponent
  },
  {
    path: 'rest-details/:id',
    component: RestDetailsComponent
  },
  {
    path: '',
    redirectTo: '/index',
    pathMatch: 'full'
  }
  
];

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    SignUpComponent,
    HomeComponent,
    LoginComponent,
    IndexComponent,
    TeamComponent,
    RestDetailsComponent,
    TrackingComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAfJTVKnpLl0ULuuwDuix-9ANpyQhP6mfc'
    }),
    BrowserAnimationsModule,
    NoopAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatCheckboxModule,
    MatListModule,
    MatGridListModule,
    MatIconModule,
    MatSidenavModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatRadioModule,
    MatTableModule, 
    MatStepperModule,
    ReactiveFormsModule,
    MatMenuModule,
    AgmCoreModule,
  ],
  exports: [
    MatToolbarModule,
    MatButtonModule,
    MatCheckboxModule,
    MatListModule,
    MatGridListModule,
    MatIconModule,
    MatSidenavModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatRadioModule,
    MatTableModule, 
    MatStepperModule
  ],
  providers: [
    AddressService,
    RestaurantdetailsService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }