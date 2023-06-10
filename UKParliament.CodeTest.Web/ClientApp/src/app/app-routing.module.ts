import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MpManagerComponent } from './mp-manager/mp-manager.component';
import { HomeComponent } from './home/home.component';

export const routingComponents = [MpManagerComponent, HomeComponent]

const routes: Routes = [
  { path: '', component: HomeComponent, title: 'Home' },
  { path: 'manage', component: MpManagerComponent, title: 'MP Manager' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
