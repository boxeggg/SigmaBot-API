import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError } from 'rxjs';
import { Status } from '../interfaces/StatusInterface';
import { environment } from '../../environments/environment.development';
import { ErrorService } from './error.service';

@Injectable({
  providedIn: 'root'
})
export class StatusService {
  private apiUrl = environment.apiUrl;
  constructor(private http: HttpClient, private errorService: ErrorService) { }

  getStatus(): Observable<Status>{
    return this.http.get<Status>(this.apiUrl + "/api/" + "Status").pipe(catchError(error => this.errorService.handleError(error)));
  }

  }
