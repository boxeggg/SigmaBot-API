import { Component } from '@angular/core';
import { Status } from '../interfaces/StatusInterface';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import { filter } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {
  constructor(private router: Router) { }
  navigation = this.router.getCurrentNavigation();
  guild: Status = this.navigation.extras.state['guild'];;
  
  
  ngOnInit() {
    console.log(this.guild)

  }
  

}
