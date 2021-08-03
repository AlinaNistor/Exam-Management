import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { HttpResponse, HttpClient } from '@angular/common/http';
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
import { CommentModel } from 'src/app/shared/models/comment.model';
import { CommentService } from 'src/app/shared/services/comment.service';

@Component({
  selector: 'app-exam-details',
  templateUrl: './exam-details.component.html',
  styleUrls: ['./exam-details.component.scss'],
})
export class ExamDetailsComponent implements OnInit, OnDestroy {
  public userId: string;
  private routeSub: Subscription = new Subscription();
  public exam!: ExamModel;
  public faculty!: FacultyModel;
  public isMandatory!: string;
  public examType!: string;
  public attendanceId: string = '';
  public comments!: CommentModel[];

  formGroup: FormGroup;
  commentForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private examService: ExamService,
    private facultyService: FacultyService,
    private attendanceService: AttendanceService,
    private commentService: CommentService
  ) {
    this.userId = JSON.parse(sessionStorage.getItem('identity')!)['id'];

    this.formGroup = this.formBuilder.group({
      examId: ['', Validators.required],
      studentId: [this.userId, Validators.required],
    });

    this.commentForm = this.formBuilder.group({
      userId: [this.userId, Validators.required],
      examId: ['' , Validators.required],
      text: ['',  Validators.required],
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
          this.getComments();
          this.formGroup.get('examId')?.patchValue(this.exam.id);
          this.commentForm.get('examId')?.patchValue(this.exam.id);

          this.facultyService
            .getFaculties()
            .subscribe((faculties: HttpResponse<any>) => {
              this.faculty = faculties.body.find(
                (c: FacultyModel) => c.id == this.exam.facultyId
              ).name;
            });

          this.isMandatory = this.examService.getIsMandatory(
            this.exam.mandatory
          );
          this.examType = this.examService.getExamType(this.exam.examType);
        });
        this.getAttendanceId();

    });
  }

  public attendToExam() {
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
    );
  }

  public getAttendanceId(){
    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      this.attendanceService
        .getAllAttendance()
        .subscribe((data: HttpResponse<any>) => {
          let attendance: AttendanceModel = data.body.find(
            (c: AttendanceModel) =>
              c.examId == this.exam?.id && c.studentId == this.userId
          );
          this.attendanceId = attendance?.id;
          console.log(this.attendanceId);
        });
    });
  }

  public deleteAttendance() {
    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      this.attendanceService
        .getAllAttendance()
        .subscribe((data: HttpResponse<any>) => {
          let attendanceList = data.body.filter(
            (c: AttendanceModel) =>
              c.examId == this.exam.id && c.studentId == this.userId
          );

          attendanceList.forEach((c: AttendanceModel) =>
            this.attendanceService
              .delete(c.id)
              .subscribe((data: HttpResponse<any>) => {
                if (data.status == 200) {
                  alert('Attendance deleted!');
                  window.location.reload();
                } else {
                  alert('Error!');
                  window.location.reload();
                }
              })
          );
        });
    });
  }

  public addComment()
  {
    const commentModel: CommentModel = this.commentForm.getRawValue();

    this.commentService.postAttendance(commentModel).subscribe(
      (res: HttpResponse<any>) => {
        console.log(res.statusText);
        if (res.status == 201) {
          alert('Comment send');
          window.location.reload();
        }
      },
      () => {
        alert('Error! Try Again!');
      }
    );

  }

  public deleteComment(commentId: string){
    this.commentService.delete(commentId).subscribe((data: HttpResponse<any>) => {
      window.location.reload();
    });
  }

  private getComments() {
    this.commentService.getAllComments(this.exam.id).subscribe((data: HttpResponse<any>) => {
      this.comments = data.body;
    });
  }
}
