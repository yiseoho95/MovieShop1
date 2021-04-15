import { Component, OnInit } from '@angular/core';
import { GenreService } from '../core/services/genre.service.service';
import { Genre } from '../shared/models/genre';

@Component({
  selector: 'app-genres',
  templateUrl: './genres.component.html',
  styleUrls: ['./genres.component.css']
})
export class GenresComponent implements OnInit {

  //this property will be available to view so that it can use to display data.
  // get genres data from API
  //HttpClient
  genres: Genre[] = [];

  constructor(private genreService: GenreService) { }

  ngOnChanges(){
    console.log('inside ngOnChanges method');

  }

  //This is where we call our API to get the data
  ngOnInit(){
    console.log('inside ngOnInit method');
    this.genreService.getAllGenres().subscribe(
      g=>{
        this.genres = g;
        console.log(this.genres +'genres')
      }
    )
    
  }

  ngOnDestroy(){
    console.log('inside ngOnDestroy method');
  }
}
