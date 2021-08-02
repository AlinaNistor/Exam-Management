import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { HttpResponse, HttpClient } from '@angular/common/http';
import jwt_decode from 'jwt-decode';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ExamService } from 'src/app/shared/services/exam.service';
import { ExamModel } from 'src/app/shared/models/exam.model';
import { FacultyService } from 'src/app/shared/services/faculty.service';
import { FacultyModel } from 'src/app/shared/models/faculty.model';

@Component({
  selector: 'app-exam-details',
  templateUrl: './exam-details.component.html',
  styleUrls: ['./exam-details.component.scss'],
})
export class ExamDetailsComponent implements OnInit, OnDestroy {
  private userId: string = '';
  private routeSub: Subscription = new Subscription();
  public exam!: ExamModel;
  public faculty!: FacultyModel;

  constructor(
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private examService: ExamService,
    private facultyService: FacultyService
  ) {}

  ngOnDestroy(): void {
    this.routeSub.unsubscribe();
  }

  ngOnInit(): void {
    this.routeSub = this.activatedRoute.params.subscribe((params) => {
      this.examService
        .getExam(params['id'])
        .subscribe((data: HttpResponse<any>) => {
          this.exam = data.body;

          this.facultyService
            .getFaculties()
            .subscribe((faculties: HttpResponse<any>) => {
              this.faculty = faculties.body.find((c:FacultyModel) => c.id == this.exam.facultyId).name;
            });

        });
    });

    //this.userId = jwt_decode(sessionStorage.getItem('userToken')!).userId;
  }
}
