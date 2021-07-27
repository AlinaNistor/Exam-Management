import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { PageComponent } from './page/page.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
  ],
  declarations: [
    PageComponent,
  ],
  exports: [
  ]
})
export class ComponentsModule { }
