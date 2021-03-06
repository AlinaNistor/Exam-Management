import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FacultyModel } from '../models/faculty.model';

@Injectable({
  providedIn: 'root',
})
export class FacultyService {
  private url: string = 'https://localhost:5000/api/Faculty';
  constructor(private readonly httpClient: HttpClient) {}

  public getFaculties(): Observable<HttpResponse<unknown>> {
    return this.httpClient.get<HttpResponse<unknown>>(this.url, {
      observe: 'response',
    });
  }

  public getFaculty(id: string): Observable<HttpResponse<FacultyModel>> {
    return this.httpClient.get<HttpResponse<FacultyModel>>(this.url + '/' + id);
  }
}
