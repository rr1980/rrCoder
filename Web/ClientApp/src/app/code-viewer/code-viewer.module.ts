import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CodeViewerComponent } from './code-viewer.component';

import { PrismModule } from '@sgbj/angular-prism';

import 'prismjs/prism';
import 'prismjs/components/prism-typescript';
//import 'prismjs/components/prism-scss';
//import 'prismjs/components/prism-markup';

import { TabModule } from '../tab/tab.module';
import { CodeViewerSucheComponent } from './code-viewer-suche/code-viewer-suche.component';
import { CodeViewerContentComponent } from './code-viewer-content/code-viewer-content.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    PrismModule,
    TabModule
  ],
  declarations: [CodeViewerComponent, CodeViewerSucheComponent, CodeViewerContentComponent],
  entryComponents: [CodeViewerSucheComponent, CodeViewerContentComponent],
  exports: [CodeViewerComponent]
})
export class CodeViewerModule { }
