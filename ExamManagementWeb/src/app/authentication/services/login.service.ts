import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/login.model';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  constructor(private readonly httpClient: HttpClient) {}
  private url: string = 'https://localhoste:5000/authetication/login';

  public login(data: LoginModel): Observable<HttpResponse<unknown>> {
    return this.httpClient.post(this.url, data, { observe: 'response' });
  }
}
