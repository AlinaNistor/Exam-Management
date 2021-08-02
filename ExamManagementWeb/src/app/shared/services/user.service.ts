import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  public firstName: string = '';
  public lastName: string = '';
  public email: string = '';
  constructor() {}
}
