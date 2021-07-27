import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AuthenticationComponent } from './authentication/authentication.component';
import { LoginComponent } from './authentication/login/login.component';
import { RegisterComponent } from './authentication/register/register.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SettingsComponent } from './settings/settings.component';
import { ExamsComponent } from './exams/exams.component';

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
  },
  {
    path: 'exams',
    component: ExamsComponent,
  },
  {
    path: 'settings',
    component: SettingsComponent,

  },
  {
    path: 'about',
    component: AboutComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
