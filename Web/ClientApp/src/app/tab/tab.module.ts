import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabComponent } from './tab.component';
import { TabContentComponent } from './tab-content/tab-content.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    TabComponent,
    TabContentComponent,
  ],
  exports: [
    TabComponent
  ]
})
export class TabModule { }
