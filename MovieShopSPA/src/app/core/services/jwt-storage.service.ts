import { LocationStrategy } from '@angular/common';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtStorageService {

  constructor() { }

  getToken(){

    return localStorage.getItem('token');
  }

  saveToken(token: string){
    localStorage.setItem('token', token);
  }

  destroyToken(){
    localStorage.removeItem('token');
  }
}
