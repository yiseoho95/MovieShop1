import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cast } from 'src/app/shared/models/Cast';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class CastService {


  constructor(private apiService: ApiService) { }

  getCastDetailsWithMovies(id:number): Observable<Cast>{
    return this.apiService.getOne(`${'Cast/'}${id}`);
  }

}
