import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NotOnVoiceComponent } from './not-on-voice.component';

describe('NotOnVoiceComponent', () => {
  let component: NotOnVoiceComponent;
  let fixture: ComponentFixture<NotOnVoiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NotOnVoiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NotOnVoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
