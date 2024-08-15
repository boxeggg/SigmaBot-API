import { Component, Input } from '@angular/core';
import { Requests } from '../../../interfaces/RequestInterface';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrl: './request.component.css',
  providers: [DatePipe]
})
export class RequestComponent {
  @Input() request: Requests;
  formatedDate: string;

  constructor(private datePipe: DatePipe) {
  }
  ngOnInit() {
    this.formatedDate = this.datePipe.transform(this.request.dateTime, 'MM-dd HH:mm');
  }



}
