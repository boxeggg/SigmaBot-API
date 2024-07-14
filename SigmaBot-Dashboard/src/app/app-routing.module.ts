import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpErrorComponent } from './errors/http-error/http-error.component';
import { NotOnVoiceComponent } from './errors/not-on-voice/not-on-voice.component';
import { GuildListComponent } from './guild-list/guild-list.component';

const routes: Routes = [{ path: 'error', component: HttpErrorComponent }, { path: 'novoice', component: NotOnVoiceComponent }, { path: 'guildlist', component: GuildListComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
