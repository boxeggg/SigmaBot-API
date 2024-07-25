import { Component, Injector, Input } from '@angular/core';
import { Status } from '../interfaces/StatusInterface';
import { StatusService } from '../services/status.service';

@Component({
  selector: 'app-guild-list',
  templateUrl: './guild-list.component.html',
  styleUrl: './guild-list.component.css'
})
export class GuildListComponent {
  guildList: Status[] = [];
  constructor(private service: StatusService) { }
  ngOnInit() {
    this.service.getAllStatuses().subscribe((data: Status[]) => this.guildList = data)
   
  }
}

