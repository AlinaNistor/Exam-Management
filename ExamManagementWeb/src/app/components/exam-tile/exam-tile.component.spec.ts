import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamTileComponent } from './exam-tile.component';

describe('ExamTileComponent', () => {
  let component: ExamTileComponent;
  let fixture: ComponentFixture<ExamTileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExamTileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExamTileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
