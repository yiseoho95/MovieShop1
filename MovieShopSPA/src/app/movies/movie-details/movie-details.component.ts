import { Component, Input, OnInit } from '@angular/core';
import {  ActivatedRoute, Router } from '@angular/router';
import { MovieService } from 'src/app/core/services/movie.service';
import { Movie } from 'src/app/shared/models/movie';


@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {

  @Input() movie: Movie | undefined;
  @Input() id!: number;

  constructor(private movieService: MovieService, private router: Router, private route: ActivatedRoute ) { }

  ngOnInit(){
   this.route.paramMap.subscribe(
     params=> {
       this.id = +params.getAll('id');
       this.movieService.getMovieDetails(this.id).subscribe(
         m=>{
           this.movie=m;
           console.log(this.movie);
         });
     });
  }
  
}
