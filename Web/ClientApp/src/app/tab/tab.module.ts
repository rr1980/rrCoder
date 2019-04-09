import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabComponent } from './tab.component';
import { AdDirective } from './ad.directive';

@NgModule({
   imports: [
      CommonModule
   ],
   declarations: [
      TabComponent,
      AdDirective
   ],
   exports: [
      TabComponent
   ]
})
export class TabModule { }
