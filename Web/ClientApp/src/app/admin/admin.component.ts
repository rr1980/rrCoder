import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  constructor(private http: HttpClient) { }

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



  ajax_post<T>(url: string, data: any): Observable<T> {
    return this.http.post<any>(url, data)
      .pipe(
        map((response) => {
          return response as T;
        })
      );
  }
}
