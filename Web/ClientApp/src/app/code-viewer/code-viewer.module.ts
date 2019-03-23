import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CodeViewerComponent } from './code-viewer.component';

import { PrismModule } from '@sgbj/angular-prism';

import 'prismjs/prism';
import 'prismjs/components/prism-typescript';
//import 'prismjs/components/prism-scss';
//import 'prismjs/components/prism-markup';

@NgModule({
  imports: [
    CommonModule,
    PrismModule,

  ],
  declarations: [CodeViewerComponent],
  exports: [CodeViewerComponent]
})
export class CodeViewerModule { }
