import { Component, Input } from '@angular/core';

import { Requests } from '../../interfaces/RequestInterface';

@Component({
  selector: 'app-playlist',
  templateUrl: './playlist.component.html',
  styleUrl: './playlist.component.css'
})
export class PlaylistComponent {
  @Input() playlist: Requests[];

}
