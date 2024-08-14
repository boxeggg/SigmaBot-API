import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { ErrorService } from './error.service';
import { Observable, catchError, tap } from 'rxjs';
import { Requests } from '../interfaces/RequestInterface';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  private apiUrl = environment.apiUrl;
  constructor(private http: HttpClient, private errorService: ErrorService) { }

  getRequests(id: string): Observable<Requests[]> {
    return this.http.get<Requests[]>(this.apiUrl + "/api/" + "Requests", { params: {guildId: id }})
  }
  skipRequest(guildId: string): Observable<any> {
    const url = `${this.apiUrl}/api/Status?guildId=${guildId}`; 
    const body = [
      
      {
        value: true,
        path: '/SkipQueued',
        op: 'replace'
      }
    ];

    return this.http.patch(url, body);
  }
  loopRequests(guildId: string, mode: number): Observable<any> {
    const url = `${this.apiUrl}/api/Status?guildId=${guildId}`;
    const body = [

      {
        value: mode,
        path: '/LoopMode',
        op: 'replace'
      }
    ];

    return this.http.patch(url, body);
  }
}
