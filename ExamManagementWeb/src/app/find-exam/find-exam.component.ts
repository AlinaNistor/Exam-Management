import { Component, OnDestroy, OnInit } from '@angular/core';
import { ExamModel } from '../shared/models/exam.model';
import { ExamService } from '../shared/services/exam.service';
import { HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { FacultyService } from 'src/app/shared/services/faculty.service';
import { FacultyModel } from 'src/app/shared/models/faculty.model';
import { UserService } from '../shared/services/user.service';
import { UserModel } from '../shared/models/user.model';

@Component({
  selector: 'app-find-exam',
  templateUrl: './find-exam.component.html',
  styleUrls: ['./find-exam.component.scss'],
})
export class FindExamComponent implements OnInit, OnDestroy {
  public examsList: ExamModel[] = new Array<ExamModel>();
  public filteredList: ExamModel[] = new Array<ExamModel>();

  public faculties: FacultyModel[] = new Array<FacultyModel>();
  private subs: Subscription[];
  searchText: string = '';

  constructor(
    private readonly examService: ExamService,
    private facultyService: FacultyService,
    private router: Router,
    private userService: UserService
  ) {
    this.subs = new Array<Subscription>();
  }

  ngOnInit(): void {
    this.subs.push(
      this.examService.getAllExams().subscribe((data: HttpResponse<any>) => {
        this.examsList = data.body;
        this.filteredList = data.body;

        this.examsList.forEach((exam:ExamModel) =>
        this.getName(exam));

        this.facultyService
          .getFaculties()
          .subscribe((faculties: HttpResponse<any>) => {
            this.faculties = faculties.body;
          });
      })
    );
  }

  ngOnDestroy(): void {
    this.subs.forEach((sub) => {
      sub.unsubscribe();
    });
  }

  public getFacultyName(facultyId: string) {
    return this.faculties.find((c: FacultyModel) => c.id == facultyId)?.name;
  }

  goToExam(id: string): void {
    this.router.navigate([`/exam/details/${id}`]);
  }

  filter() {
    var e = document.getElementById('searchType') as HTMLSelectElement;
    var sel = e.selectedIndex;
    var searchCriteria = e.options[sel].value;

    if (searchCriteria == 'Title')
      this.filteredList = this.examsList.filter((c: ExamModel) =>
        c.name.toUpperCase().startsWith(this.searchText.toUpperCase())
      );

    if (searchCriteria == 'Teacher')
      this.filteredList = this.examsList.filter((c: ExamModel) =>
        c.headProfessor.toUpperCase().startsWith(this.searchText.toUpperCase())
      );
  }

  public getName(exam: ExamModel) {
     this.userService.getUser(exam.headProfessor).subscribe((user: HttpResponse<any>) => {
      exam.profesor = user.body;
    });
  }
}
