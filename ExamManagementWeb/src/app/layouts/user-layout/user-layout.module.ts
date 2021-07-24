import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { UserLayoutRoutingModule } from './user-layout-routing.module';
import { UserLayoutRoutes } from './user-layout-routing.module';
import { DashboardComponent } from 'src/app/dashboard/dashboard.component';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    UserLayoutRoutingModule,
    RouterModule.forChild(UserLayoutRoutes),
  ]
})
export class UserLayoutModule { }
