import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NgIf } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpErrorComponent } from './http-error/http-error.component';
import { ErrorService } from './services/error.service';
import { NotOnVoiceComponent } from './not-on-voice/not-on-voice.component';

@NgModule({
  declarations: [
    AppComponent,
    HttpErrorComponent,
    NotOnVoiceComponent
  ],
  imports: [
    NgIf,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [{
    provide: ErrorHandler,
    useClass: ErrorService

  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
