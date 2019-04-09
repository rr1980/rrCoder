import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { AdComponent } from '../../tab/ad.component';

@Component({
  selector: 'app-code-viewer-suche',
  templateUrl: './code-viewer-suche.component.html',
  styleUrls: ['./code-viewer-suche.component.scss']
})
export class CodeViewerSucheComponent implements AdComponent, OnInit, OnDestroy {


  @Input() data: any;
  @Input() onEvent: (event: any) => void;

  constructor() { }

  ngOnInit() {
    console.debug("Suche init");
  }

  ngOnDestroy(): void {
    console.debug("Suche destroy");
  }

  onClickTest() {
    this.onEvent("Hallo");
  }
}
