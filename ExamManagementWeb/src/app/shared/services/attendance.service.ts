import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AttendanceModel } from '../models/attendance.model';

@Injectable({
  providedIn: 'root',
})
export class AttendanceService {
  private url: string = 'https://localhost:5000/api/Attendance';

  constructor(private readonly httpClient: HttpClient) {}

  public getAllAttendance(): Observable<HttpResponse<unknown>> {
    return this.httpClient.get<HttpResponse<unknown>>(this.url, {
      observe: 'response',
    });
  }

  public postAttendance(
    attendance: AttendanceModel
  ): Observable<HttpResponse<unknown>> {
    return this.httpClient.post<HttpResponse<unknown>>(this.url, attendance, {
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
