import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { AdComponent } from '../../tab/ad.component';

@Component({
  selector: 'app-code-viewer-content',
  templateUrl: './code-viewer-content.component.html',
  styleUrls: ['./code-viewer-content.component.scss']
})
export class CodeViewerContentComponent implements AdComponent, OnInit, OnDestroy {

  @Input() context: any;
  @Input() onEvent: (event: any) => void;

  constructor() { }

  ngOnInit() {
    console.debug("Content init");
  }

  ngOnDestroy(): void {
    console.debug("Content destroy");
  }

}
