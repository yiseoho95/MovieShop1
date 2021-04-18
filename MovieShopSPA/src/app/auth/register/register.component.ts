import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { ValidatorService } from 'src/app/core/services/validator.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  loading = false;
  registerForm!: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder, private authService: AuthenticationService, private route: Router) { }

  get f() {return this.registerForm.controls; }

  buildForm(){
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: [null,{validators: [Validators.required, Validators.email]}],
      password:['', Validators.required],
      confirmPassword:['',Validators.required]
    });
  }
  ngOnInit(){
    this.buildForm();
  }

  onSubmit(){
    console.log(this.registerForm);
    this.submitted = true;
    if(this.registerForm.invalid){
      return;
    }

    this.loading = true;
    this.authService.register(this.registerForm.value).subscribe(response=>
      {
        this.route.navigate(['/']);
      });
  }

}
