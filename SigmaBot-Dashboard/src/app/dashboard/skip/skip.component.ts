import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-skip',
  templateUrl: './skip.component.html',
  styleUrl: './skip.component.css'
})
export class SkipComponent {
  @Output() action = new EventEmitter<void>();
  notifyClicked() {
    this.action.emit();
  }

}
