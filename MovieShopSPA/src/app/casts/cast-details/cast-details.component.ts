import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CastService } from 'src/app/core/services/cast.service';
import { Cast } from 'src/app/shared/models/Cast';

@Component({
  selector: 'app-cast-details',
  templateUrl: './cast-details.component.html',
  styleUrls: ['./cast-details.component.css']
})
export class CastDetailsComponent implements OnInit {


  cast : Cast | undefined;
  id: number | undefined;

  constructor(private castService: CastService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(){
    this.route.paramMap.subscribe(
      params => {
        this.id = +params.getAll('id');
        this.castService.getCastDetailsWithMovies(this.id).subscribe(
          c=>{
            this.cast=c;
            console.log(this.cast);
          }
        );
      }
    );
  }

}

// this.movieService.getMovieDetails(this.id).subscribe(
//   m=>{
//     this.movie=m;
//     console.log(this.movie);
//   });
