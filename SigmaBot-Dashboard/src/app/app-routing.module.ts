import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GuildListComponent } from './guild-list/guild-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotfoundComponent } from './notfound/notfound.component';


const routes: Routes = [{ path: 'guilds', component: GuildListComponent }, { path: 'guilds/:data', component: DashboardComponent }, {
  path: '**', pathMatch: 'full',
  component: NotfoundComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
