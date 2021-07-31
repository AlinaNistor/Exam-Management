import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

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
}
