import { Component } from '@angular/core';
import { ErrorService } from '../services/error.service';

@Component({
  selector: 'app-http-error',
  templateUrl: './http-error.component.html',
  styleUrl: './http-error.component.css'
})
export class HttpErrorComponent {
  errorCode: string = "";
  message: string = ""
  constructor(private errorService: ErrorService) { }
  ngOnInit() {
    this.errorCode = this.errorService.errorMessage;
    this.message = this.errorService.problem;
  }


}
