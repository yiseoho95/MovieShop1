import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService) { }

  // isEmailExists(email: string): Observable<boolean> {
  //   const myMap = new Map();
  //   myMap.set('email', email);
  //   return this.apiService.getOne('/account', null, myMap).pipe(map(val => val.emailExists));

  // }
}
