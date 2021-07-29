import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-find-exam',
  templateUrl: './find-exam.component.html',
  styleUrls: ['./find-exam.component.scss']
})
export class FindExamComponent implements OnInit {

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

    {
      title: 'Title3',
      prof: 'Prof3',
      date: 'Date3',
      description:
        'Description3 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam velit nisi, tristique sed erat ac,scelerisque tempor metus. Curabitur mi velit, pharetra in lacinia tristique, commodo ac enim. Integer rutrum varius elit ut ultricies. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.',
      link: 'link3',
    },

    {
      title: 'Title4',
      prof: 'Prof4',
      date: 'Date4',
      description:
        'Description1 Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam velit nisi, tristique sed erat ac,scelerisque tempor metus. Curabitur mi velit, pharetra in lacinia tristique, commodo ac enim. Integer rutrum varius elit ut ultricies. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.',
      link: 'link4',
    },
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
