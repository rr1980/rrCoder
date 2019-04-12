import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routedComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { AjaxService } from './helper/ajax.service';
import { authInterceptorProviders } from './helper/auth.interceptor';
import { ajaxErrorInterceptorProviders } from './helper/ajax.interceptor';
import { errorHandlerProviders } from './helper/error.handler';
import { EventService } from './helper/event.service';
import { ModalService } from './helper/modal.service';
import { AuthService } from './helper/auth.service';



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
    ModalService,
    EventService,
    errorHandlerProviders,
    //ajaxErrorInterceptorProviders,
    authInterceptorProviders,
    AjaxService,
    AuthService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
