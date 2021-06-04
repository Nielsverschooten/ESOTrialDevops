import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from './login.service';
import {take,map,tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GuardService implements CanActivate{

  constructor(private router:Router, private authService:LoginService) { }
  canActivate():Observable<boolean>{
    return this.authService.FAuthInfo
    .pipe(take(1))
    .pipe(map(FAuthInfo =>!!FAuthInfo))
    .pipe(tap(auth=>!auth?this.router.navigate(['/home']):true))
  }
}
