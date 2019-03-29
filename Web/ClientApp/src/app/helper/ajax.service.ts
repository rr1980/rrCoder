import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';


@Injectable()
export class AjaxService {

  preUrl: string = "api/";

  constructor(private http: HttpClient) { }

  public post<T>(url: string, data: any, showError: boolean = true): Observable<T> {
    return this.http.post<T>(this.preUrl + url, data)
      .pipe(
        catchError((err) => {
          err.showAlert = showError;
          return throwError(err);
        })
      );
    //.pipe(
    //  map((response) => {
    //    return response as T;
    //  })
    //);
  }
}
