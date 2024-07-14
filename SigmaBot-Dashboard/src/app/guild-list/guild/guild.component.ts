import { Component, Injector, Input } from '@angular/core';
import { Status } from '../../interfaces/StatusInterface';
@Component({
  selector: 'app-guild',
  templateUrl: './guild.component.html',
  styleUrl: './guild.component.css'
})
export class GuildComponent {
  @Input() guild: Status



}
