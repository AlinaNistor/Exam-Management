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

  changeType(input_field_password: { type: string }, num: number) {
    if (input_field_password.type == 'password')
      input_field_password.type = 'text';
    else input_field_password.type = 'password';

    if (num == 1) this.toggle1 = !this.toggle1;
  }

  constructor(
    private readonly router: Router,
    private readonly registerService: RegisterService,
    private readonly userService: UserService,
    private readonly formBuilder: FormBuilder
  ) {
    this.formGroup = this.formBuilder.group({
      lastName: ['', [Validators.required, Validators.maxLength(150)]],
      firstName: ['', [Validators.required, Validators.maxLength(50)]],
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
      yearOfStudy: [1, [Validators.required]],
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

  public register(): void {
    const data: RegisterModel = this.formGroup.getRawValue();
    console.log(data);
    this.subs.push(
      this.registerService
        .register(data)
        .subscribe((data: HttpResponse<any>) => {
          if (data.status == 201) {
            console.log('registeer');
            this.router.navigate(['authentication/login']);
          }
        }, this.handleErrors)
    );
  }

  private handleErrors(responseError: HttpErrorResponse): void {
    cleanErrors();
    if (responseError.status == 400) {
      var error = responseError.error;
      var errorElement = document.createElement('div');
      errorElement.className = 'alert alert-danger';
      errorElement.innerHTML = error;
      document.getElementById('errors')?.appendChild(errorElement);
    }
  }
}

function cleanErrors(): void {
  let errorList = document.getElementById('errors')?.childNodes;
  errorList?.forEach((child) => {
    document.getElementById('errors')?.removeChild(child);
  });
}
