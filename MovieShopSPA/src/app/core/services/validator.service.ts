import { AbstractControl, AsyncValidator, ValidationErrors, AsyncValidatorFn, FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';
import { UserService } from './user.service';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ValidatorService {

  constructor(private userService: UserService) {

  }

  // emailExistsValidator(): AsyncValidatorFn {

  //   return (control: AbstractControl): Observable<ValidationErrors | null> => {

  //     return this.userService.isEmailExists(control.value).pipe(
  //       map(emailTaken => (emailTaken ? { uniqueEmail: true } : null))
  //     );
  //   };
  // }

  // passwordValidator(control: AbstractControl) {

  //   if (control.value.match(/^(?=.*\d)(?=.*[a-zA-Z!@#$%^&*])(?!.*\s).{6,100}$/)) {
  //     return null;
  //   } else {
  //     return { invalidPassword: true };
  //   }
  // }

  // passwordMatch(group: FormGroup) {

  //   const pass = group.get('password').value;
  //   const confirmPassword = group.get('confirmPassword').value;

  //   return pass === confirmPassword ? null : { passwordNotMatch: true };
  // }

}