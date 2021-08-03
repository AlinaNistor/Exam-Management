import { Component, OnInit, ViewEncapsulation, Renderer2 } from '@angular/core';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.scss'],
})
export class CalendarComponent implements OnInit {
  ngOnInit(): void {}

  //selected = new Date();

  constructor(private renderer: Renderer2) {}
  Today = [{ date: this.dateToString(new Date()), text: 'Today' }];

  dates = [
    { date: '2021-08-01', text: 'Special Day 1' },
    { date: '2021-08-20', text: 'Special Day 2' },
  ];
  dateClass = (d: Date) => {
    if (d.getDate() == 1) this.displayMonth();
    const dateSearch = this.dateToString(d);
    if (this.Today.find((f) => f.date == dateSearch)) {
      return this.Today.find((f) => f.date == dateSearch)
        ? 'todays_class'
        : 'normal';
    } else {
      return this.dates.find((f) => f.date == dateSearch)
        ? 'example-custom-date-class'
        : 'normal';
    }
  };

  displayMonth() {
    setTimeout(() => {
      let elements = document.querySelectorAll('.endDate');
      console.log('*', elements.length);
      let x = document.querySelectorAll('.mat-calendar-body-cell');
      x.forEach((y) => {
        const dateSearch = this.dateToString(
          new Date(y.getAttribute('aria-label')!)
        );
        const data = this.dates.find((f) => f.date == dateSearch);
        const data_today = this.Today.find((f) => f.date == dateSearch);
        if (data) y.setAttribute('aria-label', data.text);
        if (data_today) y.setAttribute('aria-label', data_today.text);
      });
    });
  }
  streamOpened() {
    setTimeout(() => {
      let buttons = document.querySelectorAll('mat-calendar .mat-icon-button');

      buttons.forEach((btn) =>
        this.renderer.listen(btn, 'click', () => {
          setTimeout(() => {
            //debugger
            this.displayMonth();
          });
        })
      );
      this.displayMonth();
    });
  }
  dateToString(date: any) {
    return (
      date.getFullYear() +
      '-' +
      ('0' + (date.getMonth() + 1)).slice(-2) +
      '-' +
      ('0' + date.getDate()).slice(-2)
    );
  }
}
