import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
  AbstractControl,
} from '@angular/forms';
import { NewPasswordModel } from '../shared/models/newPassword.model';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss'],
})
export class SettingsComponent implements OnInit {
  toggle1: boolean = false;
  toggle2: boolean = false;
  toggle3: boolean = false;
  password: string = '';
  formGroup: FormGroup;
  submitted: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService
  ) {
    this.formGroup = this.formBuilder.group({
      id: [
        JSON.parse(sessionStorage.getItem('identity')!)['id'],
        [Validators.required],
      ],
      newPassword: [null, [Validators.required, Validators.minLength(8)]],
      confirmPassword: [null, [Validators.required, Validators.minLength(8)]],
      oldPassword:[null]
    });
  }
  get f() {
    return this.formGroup.controls;
  }

  onSubmit() {
    this.submitted = true;
    if (this.formGroup.invalid) {
      return;
    }
  }
  ngOnInit(): void {}
  changeType(input_field_password: { type: string }, num: number) {
    if (input_field_password.type == 'password')
      input_field_password.type = 'text';
    else input_field_password.type = 'password';

    if (num == 1) this.toggle1 = !this.toggle1;
    if (num == 2) this.toggle2 = !this.toggle2;
    if (num == 3) this.toggle3 = !this.toggle3;
  }

  changePassword() {
    const pass: NewPasswordModel = {
      id: JSON.parse(sessionStorage.getItem('identity')!)['id'],
      newPassword: this.formGroup.get('newPassword')!.value,
      oldPassword: this.formGroup.get('oldPassword')!.value,
    };

    this.userService
      .changePassword(pass)
      .subscribe((response: HttpResponse<any>) => {
        if (response.status == 200) {
          document.getElementById('response')!.innerHTML = 'Password changed!';
          this.formGroup.reset();
        }
      });
    this.formGroup.reset();
  }

  public isInvalid(form: AbstractControl): boolean {
    return form.invalid && form.dirty;
  }
}
