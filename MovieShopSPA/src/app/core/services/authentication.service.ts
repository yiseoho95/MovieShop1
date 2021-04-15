import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor() { }

  login(){

    //take username/pw from login Component and post it to API

    // once API returns token, we need to store the token in the localstorage of the browser
    // otherwise return false to the component to that component can show the message in the UI
    
  }

  logout(){
    // we remove the token from the local storage
  }

  decodeToken(){

    // it will read the token from localstorage and decode it and put it in user object
  }
}
