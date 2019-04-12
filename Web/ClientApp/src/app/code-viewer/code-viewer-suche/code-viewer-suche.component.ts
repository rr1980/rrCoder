import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { AdComponent } from '../../tab/ad.component';
import { AjaxService } from '../../helper/ajax.service';

interface ICodeViewerSearchResponse {
  request: string;
  result: any;
}

@Component({
  selector: 'app-code-viewer-suche',
  templateUrl: './code-viewer-suche.component.html',
  styleUrls: ['./code-viewer-suche.component.scss']
})
export class CodeViewerSucheComponent implements AdComponent, OnInit, OnDestroy {


  @Input() context: any;
  @Input() onEvent: (event: any) => void;

  result: any;

  searchValue: string = "Test";

  constructor(private ajaxService: AjaxService) { }

  ngOnInit() {
    console.debug("Suche init");
  }

  ngOnDestroy(): void {
    console.debug("Suche destroy");
  }

  onClickSuche() {
    this.ajaxService.post<ICodeViewerSearchResponse>("CodeViewer/Search", { searchValue: this.searchValue}).subscribe(res => {
      console.debug("res", res);
      this.result = res.result;
    });
  }

  //onClickTest() {
  //  this.onEvent("Hallo");
  //}
}
