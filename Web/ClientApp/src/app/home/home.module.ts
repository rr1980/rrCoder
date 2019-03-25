import { NgModule } from '@angular/core';
import { HomeRoutingModule, routedComponents } from './home-routing.module';
import { CodeViewerModule } from '../code-viewer/code-viewer.module';
import { DevExtremeModule } from "devextreme-angular";



@NgModule({
  imports: [
    HomeRoutingModule,
    DevExtremeModule,
    CodeViewerModule
  ],
  declarations: [
    routedComponents
  ],
  providers: [
  ]
})
export class HomeModule { }
