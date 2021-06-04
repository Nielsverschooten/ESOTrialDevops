import { Injectable } from '@angular/core';
import { AngularFireAuth } from '@angular/fire/auth';
import {Observable} from 'rxjs';
import * as firebase from 'firebase/app';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  public FAuthInfo: Observable<firebase.default.User>;
  public Token;

  constructor(private FAuth: AngularFireAuth,private router: Router) { 
    this.FAuthInfo = FAuth.authState;
  }

   login(email:string, password:string){
    
    this.FAuth.signInWithEmailAndPassword(email,password)
    .then((user)=>{
      firebase.default.auth().currentUser.getIdToken().then(
        (token:string)=>this.Token = token
      );
      this.router.navigate(['/home'])
      console.log(this.Token)
    });
  }

  logout(){
    this.FAuth.signOut().then(this.Token=null);
  }
}
