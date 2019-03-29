import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routedComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AjaxService } from './helper/ajax.service';
import { authInterceptorProviders } from './helper/auth.interceptor';
import { ajaxErrorInterceptorProviders } from './helper/ajax.interceptor';
import { errorHandlerProviders } from './helper/error.handler';



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
    errorHandlerProviders,
    //ajaxErrorInterceptorProviders,
    authInterceptorProviders,
    AjaxService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
