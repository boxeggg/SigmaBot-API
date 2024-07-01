import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpErrorComponent } from './http-error/http-error.component';
import { NotOnVoiceComponent } from './not-on-voice/not-on-voice.component';

const routes: Routes = [{ path: 'error', component: HttpErrorComponent }, { path: 'novoice', component: NotOnVoiceComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
