import { Injectable, ErrorHandler, Injector, NgZone} from '@angular/core';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http'
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ErrorService implements ErrorHandler {
  constructor(private injector: Injector, private ngZone: NgZone) { }
  errorMessage: string = ""
  problem: string = ""
  handleError(error: any): Observable<never>{
    const router = this.injector.get(Router);
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      this.errorMessage = `Error: ${error.error.message}`;
      this.problem = "Client side error"
    } else {
      // Server-side error
      this.errorMessage = `Error Code: ${error.status}`;
      this.problem = error.message;
    }
    this.ngZone.run(() => router.navigate(['error']));
    throw new Error();
  }
}
