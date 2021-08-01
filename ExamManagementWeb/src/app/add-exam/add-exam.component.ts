import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { FacultyModel } from 'src/app/shared/models/faculty.model';
import { FacultyService } from 'src/app/shared/services/faculty.service';
import { Subscription } from 'rxjs';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-add-exam',
  templateUrl: './add-exam.component.html',
  styleUrls: ['./add-exam.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class AddExamComponent implements OnInit {
  toggle1: boolean = false;
  toggle2: boolean = false;
  toggle3: boolean = false;
  toggle4: boolean = false;
  title: string = '';
  formGroup: FormGroup;
  submitted: boolean = false;

  private subs: Subscription[];
  public faculties: FacultyModel[] = new Array<FacultyModel>();

  constructor(private formBuilder: FormBuilder,
    private readonly facultyService: FacultyService) {
    this.formGroup = this.formBuilder.group({
      title: new FormControl(null, [Validators.required]),
      professor: new FormControl(null, [Validators.required]),
      date: new FormControl(null, [Validators.required]),
      description: new FormControl(null, [Validators.required]),
    });

    this.subs = new Array<Subscription>();
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

  changeType(input_field_password: { type: string }, num: number) {
    if (input_field_password.type == 'title')
      input_field_password.type = 'text';
    else input_field_password.type = 'title';

    if (num == 1) this.toggle1 = !this.toggle1;
    if (num == 2) this.toggle2 = !this.toggle2;
    if (num == 3) this.toggle3 = !this.toggle3;
    if (num == 4) this.toggle4 = !this.toggle4;
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
}
