import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../helper/auth-guard';

import { HomeComponent } from './home.component';
import { NavBarUpComponent } from './nav-bar-up/nav-bar-up.component';
import { NavBarSideComponent } from './nav-bar-side/nav-bar-side.component';



const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard], data: { roles: ["User"] } },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }

export const routedComponents = [HomeComponent, NavBarUpComponent, NavBarSideComponent];
