import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-loop',
  templateUrl: './loop.component.html',
  styleUrl: './loop.component.css'
})
export class LoopComponent {
  @Output() action = new EventEmitter<string>();
  @Input() selected: number;
  optionsVisible = false;

  showOptions() {
    this.optionsVisible = true;
  }

  hideOptions() {
    this.optionsVisible = false;
  }

  selectOption(option: string, optionNumber: number) {
    this.selected = optionNumber;
    this.hideOptions();
    this.action.emit(option)

  }

}
