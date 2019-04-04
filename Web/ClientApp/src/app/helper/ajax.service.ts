import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';


@Injectable()
export class AjaxService {

  preUrl: string = "api/";

  constructor(private http: HttpClient) { }

  public post<T>(url: string, data: any): Observable<T> {
    return this.http.post<T>(this.preUrl + url, data)
      .pipe(
        catchError((_err) => {
          return throwError(_err);
        })
      );
  }
}
