import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routedComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { httpInterceptorProviders } from './helper/auth-interceptor';
import { DevExtremeModule } from "devextreme-angular";



@NgModule({
  declarations: [
    AppComponent,
    routedComponents,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    DevExtremeModule,
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
