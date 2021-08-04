import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ExamModel } from '../models/exam.model';

@Injectable({
  providedIn: 'root',
})
export class ExamService {
  private url: string = 'https://localhost:5000/api/Exam';

  constructor(private readonly httpClient: HttpClient) {}

  public getAllExams(): Observable<HttpResponse<unknown>> {
    return this.httpClient.get<HttpResponse<unknown>>(this.url, {
      observe: 'response',
    });
  }

  public getUserExams(userId: string): Observable<HttpResponse<unknown>> {
    throw 'TODO';
  }

  public getExam(id: string): Observable<HttpResponse<unknown>> {
    return this.httpClient.get<HttpResponse<unknown>>(this.url + '/' + id, {
      observe: 'response',
    });
  }

  public post(exam: ExamModel): Observable<HttpResponse<unknown>> {
    return this.httpClient.post<HttpResponse<unknown>>(this.url, exam, {
      observe: 'response',
    });
  }

  public delete(id: string): Observable<HttpResponse<unknown>> {
    return this.httpClient.delete<HttpResponse<unknown>>(this.url +"/" + id, {
      observe: 'response',
    });
  }

  public getExamType(examType: number): string {
    switch (examType) {
      case 0: {
        return 'Essay exam';
      }
      case 1: {
        return 'Oral exam';
      }
      case 2: {
        return 'Practical exam';
      }
    }
    return 'error';
  }

  public getIsMandatory(examType: number): string {
    switch (examType) {
      case 0: {
        return 'No';
      }
      case 1: {
        return 'Yes';
      }
    }
    return 'error';
  }
}
