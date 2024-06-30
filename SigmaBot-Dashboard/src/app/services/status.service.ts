import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Status } from '../interfaces/StatusInterface';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class StatusService {
  private apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getStatus(): Observable<Status> {
    return this.http.get<Status>(this.apiUrl + "/api/" + "Status");
  }

}
