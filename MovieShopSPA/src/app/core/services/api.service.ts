import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpParams} from '@angular/common/http';
import {environment} from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import {catchError, map} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(protected http: HttpClient) { }

  getAll(path: string) : Observable<any[]> { 

    return this.http.get(`${environment.apiUrl}${path}`).pipe(
      map(resp => resp as any[])   
      )
  }

  getById(path:string, id?:number): Observable<any>{
    return this.http.get(`${environment.apiUrl}${path}`+'/'+id).pipe(
      map(resp => resp as any)
    )
  }







  //  http status codes such as 400,400,403,404,500,503
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.log(error.error.errorMessage);
      console.error(
        `Backend returned code ${error.status}, ` + `body was: ${error.message}`
      );
    }
    // return an observable with a user-facing error message
    return throwError(error.error.errorMessage);

  }
}
