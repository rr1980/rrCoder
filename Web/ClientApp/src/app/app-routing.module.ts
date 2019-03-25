import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './login/login.component';
import { AuthGuard } from './helper/auth-guard';

const routes: Routes = [
  { path: '', redirectTo: 'intern', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'intern', loadChildren: "./home/home.module#HomeModule", canActivate: [AuthGuard], data: { roles: ["User"] } },
  { path: '**', redirectTo: 'intern' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { enableTracing: false, useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routedComponents = [LoginComponent];
