import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import {CastsComponent} from './casts/casts.component';
import { HomeComponent } from './home/home.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { from } from 'rxjs';

const routes: Routes = 
[

  {path: "", component: HomeComponent},
  {path: "genres/movies/:id", component: MovieCardListComponent},
  {path: "movies/:id", component: MovieDetailsComponent},
  {path: "login", component: LoginComponent},
  {path: "cast/:id", component:CastsComponent},
  {path: 'register', component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
