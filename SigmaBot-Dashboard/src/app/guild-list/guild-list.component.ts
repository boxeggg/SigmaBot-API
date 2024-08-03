import { Component, Injector, Input } from '@angular/core';
import { Status } from '../interfaces/StatusInterface';
import { StatusService } from '../services/status.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-guild-list',
  templateUrl: './guild-list.component.html',
  styleUrl: './guild-list.component.css'
})
export class GuildListComponent {
  guildList: Status[] = [];
  notNull: boolean;

  constructor(private service: StatusService, private injector: Injector) { }
  ngOnInit() {
    const router = this.injector.get(Router);
    this.service.getAllStatuses().subscribe((data: Status[]) => {
      if (data.length) {
        this.guildList = data;
        this.notNull = true;
        return
      }
      this.notNull = false;
    },


      () => router.navigate(['**']));
   
  }
}

