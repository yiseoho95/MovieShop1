import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CastService } from 'src/app/core/services/cast.service';
import { MovieService } from 'src/app/core/services/movie.service';
import { CastDetail } from 'src/app/shared/models/cast-detail';
import { MovieCard } from 'src/app/shared/models/movie-card';

@Component({
  selector: 'app-casts',
  templateUrl: './casts.component.html',
  styleUrls: ['./casts.component.css']
})
export class CastsComponent implements OnInit {
  @Input() cast: CastDetail | undefined;
  @Input() id!: number;

  constructor(private castService: CastService, private route: ActivatedRoute) { }

  ngOnInit() {
    console.log('inside ngOnInit method');

    this.route.paramMap.subscribe(
      params => {
        this.id = +params.getAll('id');
        this.castService.getCastDetailsWithMovies(this.id).subscribe(
          c => {
            this.cast = c;
            console.log(this.cast);
          }
        )
      }
    );
  }

}
