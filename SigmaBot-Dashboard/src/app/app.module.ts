import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NgFor, NgIf } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpErrorComponent } from './errors/http-error/http-error.component';
import { ErrorService } from './services/error.service';
import { NotOnVoiceComponent } from './errors/not-on-voice/not-on-voice.component';
import { GuildListComponent } from './guild-list/guild-list.component';
import { GuildComponent } from './guild-list/guild/guild.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    HttpErrorComponent,
    NotOnVoiceComponent,
    GuildListComponent,
    GuildComponent,
    DashboardComponent
  ],
  imports: [
    NgIf,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    NgFor
  ],
  providers: [{
    provide: ErrorHandler,
    useClass: ErrorService

  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
