import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routedComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { httpInterceptorProviders } from './helper/auth-interceptor';
import { DevExtremeModule } from "devextreme-angular";

import { PrismModule } from '@sgbj/angular-prism';

import 'prismjs/prism';
import 'prismjs/components/prism-typescript';
//import 'prismjs/components/prism-scss';
//import 'prismjs/components/prism-markup';


@NgModule({
  declarations: [
    AppComponent,
    routedComponents
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    DevExtremeModule,
    PrismModule,
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
