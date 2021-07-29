import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FindExamComponent } from './find-exam.component';

describe('FindExamComponent', () => {
  let component: FindExamComponent;
  let fixture: ComponentFixture<FindExamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FindExamComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FindExamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
