import { Component, OnInit, OnDestroy } from '@angular/core';

import {
  FormBuilder,
  FormGroup,
  Validators,
  AbstractControl,
} from '@angular/forms';

import { Router } from '@angular/router';
import { RegisterModel } from '../models/register.model';
import { RegisterService } from '../services/register.service';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { FacultyModel } from 'src/app/shared/models/faculty.model';
import { FacultyService } from 'src/app/shared/services/faculty.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
  providers: [RegisterService],
})
export class RegisterComponent implements OnInit, OnDestroy {
  toggle1: boolean = false;

  public formGroup: FormGroup;
  private subs: Subscription[];
  public faculties: FacultyModel[] = new Array<FacultyModel>();

  changeType(input_field_password: { type: string }, num: number) {
    if (input_field_password.type == 'password')
      input_field_password.type = 'text';
    else input_field_password.type = 'password';

    if (num == 1) this.toggle1 = !this.toggle1;
  }

  constructor(
    private readonly router: Router,
    private readonly registerService: RegisterService,
    private readonly formBuilder: FormBuilder,
    private readonly facultyService: FacultyService
  ) {
    this.formGroup = this.formBuilder.group({
      lastName: ['', [Validators.required, Validators.maxLength(150), Validators.minLength(2)]],
      firstName: ['', [Validators.required, Validators.maxLength(50), Validators.minLength(2)]],
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
      facultyId: ['', [Validators.required]],
    });

    this.subs = new Array<Subscription>();
  }

  ngOnDestroy(): void {
    this.subs.forEach((sub) => {
      sub.unsubscribe();
    });
  }

  ngOnInit(): void {
    this.subs.push(
      this.facultyService
        .getFaculties()
        .subscribe((data: HttpResponse<any>) => {
          this.faculties = data.body;
          this.formGroup.get('facultyId')!.setValue(this.faculties[0].id);
        })
    );
  }

  public register(): void {
    const data: RegisterModel = this.formGroup.getRawValue();
    this.subs.push(
      this.registerService
        .register(data)
        .subscribe((data: HttpResponse<any>) => {
          if (data.status == 201) {
            this.router.navigate(['authentication/login']);
          }
        }, this.handleErrors)
    );
  }

  private handleErrors(responseError: HttpErrorResponse): void {
    cleanErrors();

    var errorElement = document.createElement('div');
    errorElement.className = 'alert alert-danger';
    errorElement.innerHTML = 'User can not be registred!';
    document.getElementById('errors')?.appendChild(errorElement);
  }

  public isInvalid(form: AbstractControl): boolean {
    return form.invalid && form.dirty;
  }

}

function cleanErrors(): void {
  let errorList = document.getElementById('errors')?.childNodes;
  errorList?.forEach((child) => {
    document.getElementById('errors')?.removeChild(child);
  });
}
