import { Component, OnInit, Input, ViewChild, AfterViewInit } from '@angular/core';
import { slideInOutAnimation, fadeInAnimation } from '../helper/route-animation';
import { AdItem } from '../tab/ad-item';
import { CodeViewerSucheComponent } from './code-viewer-suche/code-viewer-suche.component';
import { CodeViewerContentComponent } from './code-viewer-content/code-viewer-content.component';
import { TabComponent } from '../tab/tab.component';

@Component({
  selector: 'app-code-viewer',
  templateUrl: './code-viewer.component.html',
  styleUrls: ['./code-viewer.component.scss'],
  animations: [fadeInAnimation],
  host: { '[@fadeInAnimation]': '' }
})
export class CodeViewerComponent implements OnInit, AfterViewInit {

  ads: AdItem[];

  constructor() {
    this.onEvent = this.onEvent.bind(this);
  }

  counter: number = 0;

  onEvent(event) {
    this.counter++;
    this.ads.push(new AdItem(CodeViewerContentComponent, this.counter.toString(), true, null, { content: this.counter.toString() }));
  }

  ngOnInit() {
    this.ads = [new AdItem(CodeViewerSucheComponent, "Suche", false, this.onEvent, { name: 'Suche' })];
  }

  ngAfterViewInit(): void {
  }
}




var language = 'html';
var code = `import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  language = 'html';
  code = '<p>test</p>';

  title = 'ClientApp';

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }


  onClickGetAllBenutzer() {
    this.ajax_post<any>("/api/Benutzer/GetAll", null).subscribe((response) => {

      console.debug({ "Test": response });

    });
  }


  onClickGetAllCodeContent() {
    this.ajax_post<any>("/api/CodeContent/GetAll", null).subscribe((response) => {

      console.debug({ "Test": response });

    });
  }

  onClickLogout(): void {
    localStorage.removeItem('currentUser');
    this.router.navigate(['/login']);
  }

  ajax_post<T>(url: string, data: any): Observable<T> {
    return this.http.post<any>(url, data)
      .pipe(
        map((response) => {
          return response as T;
        })
      );
  }
}
`;
