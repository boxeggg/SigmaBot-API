import { Component, Injector, Input } from '@angular/core';
import { Status } from '../../interfaces/StatusInterface';
import { Router } from '@angular/router';
@Component({
  selector: 'app-guild',
  templateUrl: './guild.component.html',
  styleUrl: './guild.component.css'
})
export class GuildComponent {
  constructor(private router: Router) { }
  @Input() guild: Status
  imageUrl: string;
  guildName: string;
  ngOnInit() {
    if (this.guild.onVoiceChannel) this.imageUrl = "assets/green.png"
    else this.imageUrl = "assets/red.png"
    this.guildName = this.guild.guildName;
  }
  navigateToDashboard() {

    this.router.navigate(['/guilds', this.guildName], { state: { guild: this.guild } });
  }



}
