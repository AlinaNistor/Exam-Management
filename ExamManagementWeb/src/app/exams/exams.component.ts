import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: ['./exams.component.scss'],
})
export class ExamsComponent implements OnInit {
  constructor() {}

  public examsList = [
    {
      title: 'Title1',
      prof: 'Prof1',
      date: 'Date1',
      description:
        'Description1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam velit nisi, tristique sed erat ac,scelerisque tempor metus. Curabitur mi velit, pharetra in lacinia tristique, commodo ac enim. Integer rutrum varius elit ut ultricies. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.',
      link: 'link1',
    },

    {
      title: 'Title2',
      prof: 'Prof2',
      date: 'Date2',
      description:
        'Description2 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam velit nisi, tristique sed erat ac,scelerisque tempor metus. Curabitur mi velit, pharetra in lacinia tristique, commodo ac enim. Integer rutrum varius elit ut ultricies. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.',
      link: 'link2',
    },
  ];

  ngOnInit(): void {}
}
