import { Component, OnInit, OnDestroy } from '@angular/core';

import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
} from '@angular/forms';

import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { RegisterModel } from '../models/register.model';
import { RegisterService } from '../services/register.service';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  providers: [RegisterService],
})
export class RegisterComponent implements OnInit, OnDestroy {
  toggle1: boolean = false;
  password: string = '';
  public formGroup: FormGroup;
  private subs: Subscription[];
  public isSetRegistered: boolean = false;

  constructor(
    private readonly router: Router,
    private readonly registerService: RegisterService,
    private readonly userService: UserService,
    private readonly formBuilder: FormBuilder
  ) {
    this.formGroup = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.maxLength(150)]],
      email: [
        '',
        [Validators.required, Validators.email, Validators.maxLength(100)],
      ],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.maxLength(50),
        ],
      ],
    });
    this.subs = new Array<Subscription>();
    this.userService.username = '';
  }

  ngOnDestroy(): void {
    this.subs.forEach((sub) => {
      sub.unsubscribe();
    });
  }

  ngOnInit(): void {
    sessionStorage.clear();
  }

  changeType(input_field_password: { type: string }, num: number) {
    if (input_field_password.type == 'password')
      input_field_password.type = 'text';
    else input_field_password.type = 'password';

    if (num == 1) this.toggle1 = !this.toggle1;
  }

  public setRegister(): void {
    this.isSetRegistered = !this.isSetRegistered;
    cleanErrorList();
    if (!this.isSetRegistered) {
      this.formGroup.markAsUntouched();
      this.formGroup.setValue({
        firstName: '',
        lastName: '',
        email: '',
        password: '',
      });
    }
  }

  public register(): void {
    const data: RegisterModel = this.formGroup.getRawValue();
    this.subs.push(
      this.registerService
        .register(data)
        .subscribe((data: HttpResponse<any>) => {
          if (data.status == 201) {
            this.setRegister();
            //document.getElementById('successful-register')!.innerHTML =
            //  'Successful register user, please log in!';
            console.log("registeer");
          }
        }, this.handleError)
    );
  }

  public isInvalid(form: AbstractControl): boolean {
    return form.invalid && form.touched && form.dirty;
  }

  private handleError(responseError: HttpErrorResponse): void {
    cleanErrorList();
    if (responseError.status == 400) {
      if ('errors' in responseError.error) {
        let errorList: Array<string> = responseError.error.errors;
        for (var error in errorList) {
          var newError = document.createElement('div');
          newError.className = 'error-item';
          newError.innerHTML = errorList[error][0];
          document.getElementById('error-list')?.appendChild(newError);
        }
      } else {
        var newError = document.createElement('div');
        newError.className = 'error-item';
        newError.innerHTML = responseError.error.message;
        document.getElementById('error-list')?.appendChild(newError);
      }
    }
  }
}

function cleanErrorList(): void {
  let errorList = document.getElementById('error-list')?.childNodes;
  errorList?.forEach((child) => {
    document.getElementById('error-list')?.removeChild(child);
  });
}
