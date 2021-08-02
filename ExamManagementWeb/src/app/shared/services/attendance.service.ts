import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {

  private url: string = 'https://localhost:5000/api/Attendance';

  constructor(private readonly httpClient: HttpClient) {}

  public getAllAttendance(): Observable<HttpResponse<unknown>> {
    return this.httpClient.get<HttpResponse<unknown>>(this.url, {
      observe: 'response',
    });
  }
}
