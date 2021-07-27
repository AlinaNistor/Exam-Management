import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ExamTileComponent } from './exam-tile/exam-tile.component';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MatCardModule,
  ],
  declarations: [

  ],
  exports: [
  ]
})
export class ComponentsModule { }
