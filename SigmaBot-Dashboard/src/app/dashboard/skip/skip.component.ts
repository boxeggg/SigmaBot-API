import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-skip',
  templateUrl: './skip.component.html',
  styleUrl: './skip.component.css'
})
export class SkipComponent {
  @Output() action = new EventEmitter<void>();
  onCooldown: boolean = false;

  notifyClicked() {
    this.onCooldown = true
    this.action.emit();
    setTimeout(() => this.onCooldown = false, 5000)
  }

}
