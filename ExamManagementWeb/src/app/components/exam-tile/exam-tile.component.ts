import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-exam-tile',
  templateUrl: './exam-tile.component.html',
  styleUrls: ['./exam-tile.component.scss']
})
export class ExamTileComponent implements OnInit {
  @Input() public title: string = '';
  @Input() public prof: string = '';
  @Input() public date: string = '';
  @Input() public description: string = '';
  @Input() public link: string = '';

  constructor() { }

  ngOnInit(): void {
  }

}
