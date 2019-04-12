import { Component, OnInit, Input, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { AdComponent } from '../../tab/ad.component';
import { AjaxService } from '../../helper/ajax.service';
import { fromEvent, Subscription } from 'rxjs';
import { map, debounceTime, distinctUntilChanged } from 'rxjs/operators';

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

  @ViewChild('searchInputElem') searchInputElem: ElementRef;

  @Input() context: any;
  @Input() onEvent: (event: any) => void;

  searchSub: Subscription;

  result: any;

  //searchValue: string = "Test";

  constructor(private ajaxService: AjaxService) { }

  ngOnInit() {
    console.debug("Suche init");

    this.searchSub =  fromEvent(this.searchInputElem.nativeElement, 'keyup').pipe(
      map((evt: any) => evt.target.value),
      debounceTime(1000),
      distinctUntilChanged()
    ).subscribe((text: string) => this.search(text));

  }

  ngOnDestroy(): void {
    console.debug("Suche destroy");

    if (this.searchSub) {
      this.searchSub.unsubscribe();
    }
  }

  search(text) {
    this.ajaxService.post<ICodeViewerSearchResponse>("CodeViewer/Search", { searchValue: text }).subscribe(res => {
      console.debug("res", res);
      this.result = res.result;
    });
  }

  onClickSuche() {
    this.search(this.searchInputElem.nativeElement.value);
  }

  //onClickTest() {
  //  this.onEvent("Hallo");
  //}
}
