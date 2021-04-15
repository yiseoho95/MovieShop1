import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import {MovieCard} from 'src/app/shared/models/movie-card';
import { Movie } from 'src/app/shared/models/movie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private apiService: ApiService) { }

  getTop30GrossingMovies(): Observable<MovieCard[]>{
    return this.apiService.getAll('movies/toprevenue');
  }

  getMovieDetails(id: number): Observable<Movie> {
    
    return this.apiService.getById(`${'movies'}`, id);
  }
}
