import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';





@Injectable()
export class AjaxService {

  preUrl: string = "api/";

  constructor(private http: HttpClient) { }

  public post<T>(url: string, data: any): Observable<T> {
    return this.http.post<T>(this.preUrl + url, data);
    //.pipe(
    //  map((response) => {
    //    return response as T;
    //  })
    //);
  }
}
