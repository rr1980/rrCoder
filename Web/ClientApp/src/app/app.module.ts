import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routedComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { httpInterceptorProviders } from './helper/auth-interceptor';



@NgModule({
  declarations: [
    AppComponent,
    routedComponents,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    httpInterceptorProviders
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
