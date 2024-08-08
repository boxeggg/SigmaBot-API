import { Component, Input } from '@angular/core';
import { Requests } from '../../../interfaces/RequestInterface';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrl: './request.component.css'
})
export class RequestComponent {
  @Input() request: Requests;



}
