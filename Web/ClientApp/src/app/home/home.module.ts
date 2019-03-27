import { NgModule } from '@angular/core';
import { HomeRoutingModule, routedComponents } from './home-routing.module';
import { CodeViewerModule } from '../code-viewer/code-viewer.module';



@NgModule({
  imports: [
    HomeRoutingModule,
    CodeViewerModule
  ],
  declarations: [
    routedComponents
  ],
  providers: [
  ]
})
export class HomeModule { }
