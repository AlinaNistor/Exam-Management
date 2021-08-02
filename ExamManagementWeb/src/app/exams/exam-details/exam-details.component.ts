import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { HttpResponse, HttpClient } from '@angular/common/http';
import jwt_decode from 'jwt-decode';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ExamService } from 'src/app/shared/services/exam.service';
import { ExamModel } from 'src/app/shared/models/exam.model';
import { FacultyService } from 'src/app/shared/services/faculty.service';
import { FacultyModel } from 'src/app/shared/models/faculty.model';
import { AttendanceModel } from 'src/app/shared/models/attendance.model';

import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { AttendanceService } from 'src/app/shared/services/attendance.service';

@Component({
  selector: 'app-exam-details',
  templateUrl: './exam-details.component.html',
  styleUrls: ['./exam-details.component.scss'],
})
export class ExamDetailsComponent implements OnInit, OnDestroy {
  private userId: string;
  private routeSub: Subscription = new Subscription();
  public exam!: ExamModel;
  public faculty!: FacultyModel;
  public isMandatory!: string;
  public examType!: string;
  formGroup: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private examService: ExamService,
    private facultyService: FacultyService,
    private attendanceService:AttendanceService
  ) {
    this.userId = JSON.parse(sessionStorage.getItem('identity')!)['id'];

    this.formGroup = this.formBuilder.group({
      examId: ['', Validators.required],
      studentId: [this.userId, Validators.required],
      date: [new Date(), Validators.required],
    });
  }

  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
  }

  ngOnInit(): void {
    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      this.examService
        .getExam(params['id'])
        .subscribe((data: HttpResponse<any>) => {
          this.exam = data.body;

          this.formGroup.get('examId')?.patchValue(this.exam.id);

          this.facultyService
            .getFaculties()
            .subscribe((faculties: HttpResponse<any>) => {
              this.faculty = faculties.body.find((c:FacultyModel) => c.id == this.exam.facultyId).name;
            });

            this.isMandatory = this.examService.getIsMandatory(this.exam.mandatory);
            this.examType = this.examService.getExamType(this.exam.examType);
        });
    });
  }

  public attendToExam(){
    const attendanceModel: AttendanceModel = this.formGroup.getRawValue();
      this.attendanceService.postAttendance(attendanceModel).subscribe(
        (res: HttpResponse<any>) => {
          console.log(res.statusText);
          if (res.status == 201) {
            alert('Attendance saved!');
            window.location.reload();
          }
        },
        () => {
          alert('Error! Try Again!');
        }
      )
  }

  public deleteAttendance(){

  }
}
