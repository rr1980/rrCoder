import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule, routedComponents } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { httpInterceptorProviders } from './helper/auth-interceptor';
import { DevExtremeModule } from "devextreme-angular";
import { CodeViewerModule } from './code-viewer/code-viewer.module';




@NgModule({
  declarations: [
    AppComponent,
    routedComponents
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    DevExtremeModule,
    CodeViewerModule,
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
