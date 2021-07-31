import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  public user: string = '';
  title = 'Exam management';
  isLogin = true;
  sideBarOpen = true;

  constructor(public readonly userService: UserService) {}
  ngOnInit(): void {
    this.getUserName();
  }

  sideBarToggler() {
    this.sideBarOpen = !this.sideBarOpen;
  }

  public getUserName(): void {
    if (sessionStorage.getItem('identity') != null)
      this.userService.email = JSON.parse(
        sessionStorage.getItem('identity')!.toString()
      )['email'];
    this.user = this.userService.email;
  }
}
