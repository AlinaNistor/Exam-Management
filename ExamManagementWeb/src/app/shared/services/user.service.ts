import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NewPasswordModel } from '../models/newPassword.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  public firstName: string = '';
  public lastName: string = '';
  public email: string = '';

  private url: string = 'https://localhost:5000/api/Auth/change-password';

  constructor(private readonly httpClient: HttpClient) {}

  public changePassword(
    pass: NewPasswordModel
  ): Observable<HttpResponse<unknown>> {
    return this.httpClient.put<HttpResponse<unknown>>(this.url, pass, {
      observe: 'response',
    });
  }
}
