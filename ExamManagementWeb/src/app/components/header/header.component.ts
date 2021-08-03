import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  @Output() toggleSidebarForMe: EventEmitter<any> = new EventEmitter();
  public firstName: string = '';
  public lastName: string = '';
  public user: string = '';

  constructor(
    private router: Router,
    public readonly userService: UserService,
  ) {}

  ngOnInit(): void {
    if (sessionStorage.getItem('identity') != null) {
      this.firstName = titleCaseWord(
        JSON.parse(sessionStorage.getItem('identity')!)['firstName']
      );
      this.lastName = titleCaseWord(
        JSON.parse(sessionStorage.getItem('identity')!)['lastName']
      );
      this.user = titleCaseWord(
        JSON.parse(sessionStorage.getItem('identity')!)['email']
      );
    }
  }

  toggleSidebar() {
    this.toggleSidebarForMe.emit();
  }

  public logout(): void {
    sessionStorage.clear();
    this.router.navigate(['authentication']);
  }
}

function titleCaseWord(word: string) {
  if (!word) return word;
  return word[0].toUpperCase() + word.substr(1).toLowerCase();
}
