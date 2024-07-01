import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpErrorComponent } from './http-error/http-error.component';

const routes: Routes = [{ path: 'error', component: HttpErrorComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
