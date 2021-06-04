import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginService } from './login.service';
import { ItemService } from './item.service';
@Injectable({
  providedIn: 'root'
})

export class InterceptorService implements HttpInterceptor{

  constructor(private loginService:LoginService, private itemService:ItemService) { }
  intercept(req:HttpRequest<any>, next:HttpHandler):Observable<HttpEvent<any>>{
    if (req.url.includes(this.itemService.baseUrl,0)) {
      const userToken = this.loginService.Token;
      const modifiedRequest = req.clone({
        headers : req.headers.set('Authorization',`Bearer `+ userToken)
      });
      return next.handle(modifiedRequest)
    }
    return next.handle(req);
  }
}
