import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss'],
})
export class SidenavComponent implements OnInit {
  constructor( private readonly helper: JwtHelperService) {}

  ngOnInit(): void {}

  public isAdmin(): boolean {
    var decodedToken = this.helper.decodeToken(
      sessionStorage.getItem('userToken')!
    );
    if ('isAdmin' in decodedToken) {
      return true;
    }
    return false;
  }
}
