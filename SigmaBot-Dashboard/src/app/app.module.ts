import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NgFor, NgIf } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ErrorService } from './services/error.service';
import { GuildListComponent } from './guild-list/guild-list.component';
import { GuildComponent } from './guild-list/guild/guild.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SafePipe } from '../Pipes/Safe';
import { NotfoundComponent } from './notfound/notfound.component';
import { PlaylistComponent } from './dashboard/playlist/playlist.component';
import { RequestComponent } from './dashboard/playlist/request/request.component';
import { SkipComponent } from './dashboard/skip/skip.component';
import { LoopComponent } from './dashboard/loop/loop.component';




@NgModule({
  declarations: [
    SafePipe,
    AppComponent,
    GuildListComponent,
    GuildComponent,
    DashboardComponent,
    NotfoundComponent,
    PlaylistComponent,
    RequestComponent,
    SkipComponent,
    LoopComponent,


  ],
  imports: [
    NgIf,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    NgFor
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
