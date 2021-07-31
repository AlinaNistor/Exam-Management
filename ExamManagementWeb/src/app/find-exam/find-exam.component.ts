import { Component, OnDestroy, OnInit } from '@angular/core';
import { ExamModel } from '../shared/models/exam.model';
import { ExamService } from '../shared/services/exam.service';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-find-exam',
  templateUrl: './find-exam.component.html',
  styleUrls: ['./find-exam.component.scss'],
})
export class FindExamComponent implements OnInit, OnDestroy {
  public examsList: ExamModel[] = new Array<ExamModel>();
  private subs: Subscription[];

  constructor(private readonly examService: ExamService) {
    this.subs = new Array<Subscription>();
  }

  ngOnInit(): void {
    this.subs.push(
      this.examService.getAllExams().subscribe((data: HttpResponse<any>) => {
        this.examsList = data.body;
      })
    );
  }

  ngOnDestroy(): void {
    this.subs.forEach((sub) => {
      sub.unsubscribe();
    });
  }
}
