import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from '../helper/auth-guard';

import { HomeComponent } from './home.component';
import { NavBarUpComponent } from './nav-bar-up/nav-bar-up.component';
import { NavBarSide1Component } from './nav-bar-side-1/nav-bar-side-1.component';
import { CodeViewerComponent } from '../code-viewer/code-viewer.component';
import { NavBarSide2Component } from './nav-bar-side-2/nav-bar-side-2.component';
import { AdminComponent } from '../admin/admin.component';



const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'home', component: HomeComponent, canActivate: [AuthGuard], data: { roles: ["User"] }, children: [

      // sideBar
      { path: '', redirectTo: 'sideBar1', pathMatch: 'full', outlet: 'sideBar' },
      { path: 'sideBar1', component: NavBarSide1Component, outlet: 'sideBar' },
      { path: 'sideBar2', component: NavBarSide2Component, outlet: 'sideBar' },
      { path: '**', redirectTo: 'sideBar1', outlet: 'sideBar' },

      // content
      { path: '', redirectTo: 'codeContent', pathMatch: 'full', outlet: 'content' },
      { path: 'codeContent', component: CodeViewerComponent, outlet: 'content' },
      { path: 'admin', component: AdminComponent, outlet: 'content' },
      { path: '**', redirectTo: 'codeContent', outlet: 'content' },
    ]
  },
  { path: '**', redirectTo: 'home' }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }

export const routedComponents = [HomeComponent, NavBarUpComponent, NavBarSide1Component, NavBarSide2Component, AdminComponent];
