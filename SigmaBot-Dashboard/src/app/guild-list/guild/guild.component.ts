import { Component, Injector, Input } from '@angular/core';
import { Status } from '../../interfaces/StatusInterface';
@Component({
  selector: 'app-guild',
  templateUrl: './guild.component.html',
  styleUrl: './guild.component.css'
})
export class GuildComponent {
  @Input() guild: Status
  imageUrl: string;
  ngOnInit() {
    if (this.guild.onVoiceChannel) this.imageUrl = "assets/green.png"
    else this.imageUrl = "assets/red.png"
  }



}
