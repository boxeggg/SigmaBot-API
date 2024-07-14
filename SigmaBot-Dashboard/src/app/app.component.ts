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
  isLoading: boolean = false;
  constructor(private service: StatusService, private injector: Injector) { }

  ngOnInit() {
    const router = this.injector.get(Router);
    this.isLoading = true;
      this.service.getAllStatuses().subscribe((data: Status[]) => {
      this.isLoading = false;
      router.navigate(['guildlist']);

    }, () => this.isLoading = false
  
    );
    
    


    

    
  }

}
