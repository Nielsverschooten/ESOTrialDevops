import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { ItemComponent } from './item/item.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { PlayerComponent } from './player/player.component';
import { RouterModule } from '@angular/router';
import { NavigationComponent } from './navigation/navigation.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AngularFireAuthModule } from "@angular/fire/auth";
import { AngularFireModule } from '@angular/fire';
import { LoginService } from './services/login.service';
import { GuardService } from './services/guard.service';
import { InterceptorService } from './services/interceptor.service';
import { WeatherComponent } from './weather/weather.component';

const firebaseConfig = {
  apiKey: "AIzaSyCJxygU6TwXXo2RmkIlqAHhkkVlUwMIN7s",
  authDomain: "cloud-api-2021.firebaseapp.com",
  projectId: "cloud-api-2021",
  storageBucket: "cloud-api-2021.appspot.com",
  messagingSenderId: "490907923087",
  appId: "1:490907923087:web:cb99b7101a2252445ab6fa",
  measurementId: "G-XEN6WPWKT4"

}

@NgModule({
  declarations: [
    AppComponent,
    ItemComponent,
    PlayerComponent,
    NavigationComponent,
    LoginComponent,
    HomeComponent,
    WeatherComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path:'items',component:ItemComponent, canActivate:[GuardService]},
      {path:'players',component:PlayerComponent, canActivate:[GuardService]},
      {path:'home',component:HomeComponent, canActivate:[GuardService]},


      {path:'login',component:LoginComponent},
      {path:'', redirectTo: '/login',pathMatch:'full'},
      {path: '**', redirectTo: '/login',pathMatch:'full'}
    ]),
    AngularFireModule.initializeApp(firebaseConfig)
  ],
  providers: [
  LoginService,
  GuardService,
  {provide:HTTP_INTERCEPTORS,useClass:InterceptorService,multi:true}
],
  bootstrap: [AppComponent]
})
export class AppModule { }
