import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AuthenticationComponent } from './authentication/authentication.component';
import { LoginComponent } from './authentication/login/login.component';
import { RegisterComponent } from './authentication/register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SettingsComponent } from './settings/settings.component';
import { ExamsComponent } from './exams/exams.component';
import { FindExamComponent } from './find-exam/find-exam.component';
import { AddExamComponent } from './add-exam/add-exam.component';
import { AuthGuard } from './shared/helpers/auth.guard';
import { AdminGuard } from './shared/helpers/admin.guard';
import { ExamDetailsComponent } from './exams/exam-details/exam-details.component';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/authentication/login',
    pathMatch: 'full',
  },
  {
    path: 'authentication',
    component: AuthenticationComponent,
    children: [
      {
        path: '',
        redirectTo: '/authentication/login',
        pathMatch: 'full',
      },
      {
        path: 'login',
        component: LoginComponent,
      },
      {
        path: 'register',
        component: RegisterComponent,
      },
    ],
  },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'exams',
    component: ExamsComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'settings',
    component: SettingsComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'about',
    component: AboutComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'find-exam',
    component: FindExamComponent,
    canActivate: [AuthGuard],
  },
  {
    path: 'add-exam',
    component: AddExamComponent,
    canActivate: [AuthGuard, AdminGuard],
    children: [
      {
        path: '**',
        component: NotFoundComponent,
      },
    ]
  },
  {
    path: 'details/:id',
    pathMatch: 'full',
    component: ExamDetailsComponent,
    canActivate: [AuthGuard],
  },
  {
    path: '404',
    component: NotFoundComponent,
  },
  {
    path: '**',
    component: NotFoundComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
