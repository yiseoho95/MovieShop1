import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/user';
import { Login } from 'src/app/shared/models/login';
import { AuthenticationService} from 'src/app/core/services/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { JsonpClientBackend } from '@angular/common/http';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //two-way binding --> UI is bound to the Model  
  //one-way binding
  invalidLogin: boolean = false;
  returnUrl: string | undefined;
  user: User | undefined;
  userLogin: Login = {
    
    email: '',
    password: ''
  };

  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(){
    this.route.queryParams.subscribe(params => this.returnUrl = params.returnUrl || '/');
  }

  login() {
    console.log("form submitted");
    this.authService.login(this.userLogin)
      .subscribe( (response) => {
        if(response){
          console.log('this is returnURL: ' + this.returnUrl);
          this.router.navigate([this.returnUrl]);
        }else{
          this.invalidLogin = true;
        }
      },
      (err: any) => {this.invalidLogin = true, console.log(err); });
  
    }

    get twowayInfo(){
      return JSON.stringify(this.userLogin);
    }
}
