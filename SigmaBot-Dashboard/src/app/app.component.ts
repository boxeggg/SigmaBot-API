import { Component } from '@angular/core';
import { Status } from './interfaces/StatusInterface';
import { StatusService } from './services/status.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'SigmaBot Dashboard';
  onVoiceChannel: boolean | undefined = undefined;
  constructor(private service: StatusService) { }

  ngOnInit() {
    this.service.getStatus().subscribe((data: Status) =>
      this.onVoiceChannel = data.onVoiceChannel

    )
  }

}
