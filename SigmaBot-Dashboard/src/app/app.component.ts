import { Component, Injector } from '@angular/core';
import { Status } from './interfaces/StatusInterface';
import { StatusService } from './services/status.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'SigmaBot Dashboard';
  onVoiceChannel: boolean | undefined = undefined;
  constructor(private service: StatusService, private injector: Injector) { }

  ngOnInit() {
    const router = this.injector.get(Router);
    this.service.getStatus().subscribe((data: Status) => {
      if (!data.onVoiceChannel) {
        router.navigate(['error']);
      }
    }

    )
  }

}
