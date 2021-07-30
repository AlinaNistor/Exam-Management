import { Component, OnInit, OnDestroy } from '@angular/core';

import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
} from '@angular/forms';

import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoginModel } from '../models/login.model';
import { LoginService } from '../services/login.service';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { UserService } from '../../shared/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  toggle1: boolean = false;
  password: string = '';

  public formGroup: FormGroup;
  private subs: Subscription[];
  public isSetRegistered: boolean = false;

  constructor(
    private readonly router: Router,
    private readonly loginService: LoginService,
    private readonly userService: UserService,
    private readonly formBuilder: FormBuilder
  ) {
    this.formGroup = this.formBuilder.group({
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

  public login(): void {
    const data: LoginModel = this.formGroup.getRawValue();
    this.subs.push(
      this.loginService
        .login(data)
        .subscribe((data: HttpResponse<any>) => {
          if (data.status == 200) {
            sessionStorage.setItem('userToken', data.body['token']);
            sessionStorage.setItem('identity', JSON.stringify(data.body));
            this.userService.username = data.body.username;
            this.router.navigate(['dashboard']);
          }
        }, this.handleError)
    );
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
