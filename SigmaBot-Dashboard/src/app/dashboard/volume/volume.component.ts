import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-volume',
  templateUrl: './volume.component.html',
  styleUrl: './volume.component.css'
})
export class VolumeComponent {
  @Output() action = new EventEmitter<number>();
  @Input() initialVolume: number;
  volumeControl: FormControl;
  constructor() {
    this.volumeControl = new FormControl(this.initialVolume);
    this.volumeControl.valueChanges.pipe(
      debounceTime(300) 
    ).subscribe(value => {
      this.volumeChanged(value);
    });
  }


  volumeChanged(volume: number) {
    this.action.emit(volume);
  }



}
