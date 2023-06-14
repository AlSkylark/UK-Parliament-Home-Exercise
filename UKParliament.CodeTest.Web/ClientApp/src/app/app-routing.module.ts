import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MpManagerComponent } from './mp-manager/mp-manager.component';
import { WelcomeComponent } from './welcome/welcome.component';

export const routingComponents = [MpManagerComponent, WelcomeComponent]

const routes: Routes = [
  { path: '', component: WelcomeComponent, title: 'Home' },
  { path: 'manage', component: MpManagerComponent, title: 'MP Manager' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
