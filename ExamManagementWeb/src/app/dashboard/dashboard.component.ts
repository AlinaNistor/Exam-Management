import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Subscription } from 'rxjs';
import { AttendanceModel } from '../shared/models/attendance.model';
import { ExamModel } from '../shared/models/exam.model';
import { AttendanceService } from '../shared/services/attendance.service';
import { ExamService } from '../shared/services/exam.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit, OnDestroy {
  @Output() public examsList: ExamModel[] = new Array<ExamModel>();
  public upcomingExamsList: ExamModel[] = new Array<ExamModel>();
  private subs: Subscription[];
  public attendanceList!: AttendanceModel[];
  userId: any;

  constructor(
    private readonly examService: ExamService,
    private readonly attendanceService: AttendanceService
  ) {
    this.subs = new Array<Subscription>();
  }

  ngOnDestroy(): void {
    this.subs.forEach((sub) => {
      sub.unsubscribe();
    });
  }
  ngOnInit(): void {
    if (sessionStorage.getItem('identity') != null) {
      this.userId = JSON.parse(sessionStorage.getItem('identity')!)['id'];

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


            this.upcomingExamsList = this.examsList.sort(function (
              d1: ExamModel,
              d2: ExamModel
            ) {
              const date1 = new Date(d1.date).getDay();
              const date2 = new Date(d2.date).getDay();

              console.log(date1);
              console.log(date2);

              if (date1 > date2) return 1;
              if (date1 < date2) return -1;
              return 0;
            });

            //console.log(this.upcomingExamsList);
            console.log('test');
            console.log(this.examsList);
            console.log(this.examsList[0]);

          })

      );
    }
  }

  public getUpcomingExams() {}
}
