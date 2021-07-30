import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RegisterModel } from '../models/register.model';

@Injectable({
  providedIn: 'root',
})
export class RegisterService {
  constructor(private readonly httpClient: HttpClient) {}
  private url: string = 'https://localhost:5001/authetication/register';

  public register(data: RegisterModel): Observable<HttpResponse<any>> {
    return this.httpClient.post<HttpResponse<any>>(this.url, data, {
      observe: 'response',
    });
  }
}
