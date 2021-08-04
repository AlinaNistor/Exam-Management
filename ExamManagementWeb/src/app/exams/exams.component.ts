import { Component, OnDestroy, OnInit } from '@angular/core';
import { ExamModel } from '../shared/models/exam.model';
import { ExamService } from '../shared/services/exam.service';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { FacultyService } from 'src/app/shared/services/faculty.service';
import { FacultyModel } from 'src/app/shared/models/faculty.model';
import { AttendanceModel } from '../shared/models/attendance.model';
import { AttendanceService } from '../shared/services/attendance.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.scss'],
})
export class ExamsComponent implements OnInit, OnDestroy {
  public examsList: ExamModel[] = new Array<ExamModel>();
  public attendanceList!: AttendanceModel[];
  public faculties!: FacultyModel[];
  private subs: Subscription[];
  private userId!: string;

  constructor(
    private readonly examService: ExamService,
    private readonly facultyService: FacultyService,
    private readonly attendanceService: AttendanceService,
    private readonly helper: JwtHelperService,
    private readonly router: Router
  ) {
    this.subs = new Array<Subscription>();
  }

  ngOnInit(): void {
    if (sessionStorage.getItem('identity') != null) {
      this.userId = JSON.parse(sessionStorage.getItem('identity')!)['id'];
      console.log(this.userId);

      if (this.isAdmin()) {
        this.subs.push(
          this.examService
            .getAllExams()
            .subscribe((data: HttpResponse<any>) => {
              this.examsList = data.body.filter(
                (c: ExamModel) => c.headProfessor == this.userId
              );
            }),

          this.facultyService
            .getFaculties()
            .subscribe((faculties: HttpResponse<any>) => {
              this.faculties = faculties.body;
            })
        );
      } else {
        this.subs.push(
          this.attendanceService
            .getAllAttendance()
            .subscribe((data: HttpResponse<any>) => {
              this.attendanceList = data.body.filter(
                (c: AttendanceModel) => c.studentId == this.userId
              );

              this.attendanceList.forEach((c: AttendanceModel) =>
                this.examService
                  .getExam(c.examId)
                  .subscribe((data: HttpResponse<any>) => {
                    this.examsList.push(data.body);
                  })
              );

              this.facultyService
                .getFaculties()
                .subscribe((faculties: HttpResponse<any>) => {
                  this.faculties = faculties.body;
                });
            })
        );
      }
    }
  }

  ngOnDestroy(): void {
    this.subs.forEach((sub) => {
      sub.unsubscribe();
    });
  }

  public getFacultyName(facultyId: string) {
    return this.faculties.find((c: FacultyModel) => c.id == facultyId)?.name;
  }

  public isAdmin(): boolean {
    var decodedToken = this.helper.decodeToken(
      sessionStorage.getItem('userToken')!
    );
    if ('isAdmin' in decodedToken) {
      return true;
    }
    return false;
  }
}
