import { Component } from '@angular/core';
import { Status } from '../interfaces/StatusInterface';
import { Router } from '@angular/router';
import { RequestService } from '../services/request.service';
import { Requests } from '../interfaces/RequestInterface';
import { UrlConveter } from '../Helper/UrlConveter';
import { DomSanitizer } from '@angular/platform-browser';
import { tap } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  constructor(private router: Router, private requestService: RequestService, private sanitizer: DomSanitizer) { }
  navigation = this.router.getCurrentNavigation();
  guild: Status = this.navigation.extras.state['guild'];
  playlist: Requests[] = [];
  currentlyPlayingUrl: string;
  currentlyPlaying: Requests;
  
 
  
  ngOnInit() {
    this.loadData();
  }
  loadData() {
    const id: string = this.guild.guildId;
    this.requestService.getRequests(id).subscribe((data: Requests[]) => {
      this.playlist = data;
      this.currentlyPlaying = data[0];
      this.currentlyPlayingUrl = UrlConveter.getEmbedUrl(data[0].url);
    });

  }
  skipRequest() {
    let guildId = this.guild.guildId;
    this.requestService.skipRequest(guildId).subscribe({
      complete: () => setTimeout(() => this.loadData(), 2000),
      error: (error) => console.error('Error occurred:', error)
    });

  }
  navigateToList() {
    this.router.navigate(["guilds"])
  }
  

}
