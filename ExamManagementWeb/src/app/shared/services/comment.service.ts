import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CommentModel } from '../models/comment.model';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  private url: string = 'https://localhost:5000/api/Comment';

  constructor(private readonly httpClient: HttpClient) {}

  public getAllComments(examId: string): Observable<HttpResponse<unknown>> {
    return this.httpClient.get<HttpResponse<unknown>>(this.url + "/" + examId,{
      observe: 'response',
    });
  }

  public postAttendance(
    comment: CommentModel
  ): Observable<HttpResponse<unknown>> {
    return this.httpClient.post<HttpResponse<unknown>>(this.url , comment, {
      observe: 'response',
    });
  }

  public delete(id: string)
  : Observable<HttpResponse<unknown>> {
    return this.httpClient.delete<HttpResponse<unknown>>(this.url + "/" + id, {
      observe: 'response',
    });
  }
}
