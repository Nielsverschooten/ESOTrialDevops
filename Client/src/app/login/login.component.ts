import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import {Router} from "@angular/router"

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email ="test@ap.be";
  password="test123";
  user;
  constructor(private loginService:LoginService, private router: Router) {
    this.user = loginService.FAuthInfo;
   }

  ngOnInit(): void {
  }

  login(){
    this.loginService.login(this.email,this.password)
  }
  logout(){
    this.loginService.logout();
    this.email = null;
    this.password=null;
  }
}
