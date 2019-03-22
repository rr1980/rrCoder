import { HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpInterceptor, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Observable, from } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor() { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    const token = currentUser && currentUser.token;

    if (token) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    console.debug({ "request": request });

    return next.handle(request);




    //return from(this.handleAccess(request, next));
  }

  //private async handleAccess(request: HttpRequest<any>, next: HttpHandler): Promise<HttpEvent<any>> {

  //  const currentUser = JSON.parse(localStorage.getItem('currentUser'));
  //  const token = currentUser && currentUser.token;

  //  let changedRequest = request;

  //  // HttpHeader object immutable - copy values
  //  const headerSettings: { [name: string]: string | string[]; } = {};

  //  for (const key of request.headers.keys()) {
  //    headerSettings[key] = request.headers.getAll(key);
  //  }
  //  if (token) {
  //    headerSettings['Authorization'] = 'Bearer ' + token;
  //  }
  //  headerSettings['Content-Type'] = 'application/json';
  //  const newHeader = new HttpHeaders(headerSettings);

  //  changedRequest = request.clone({
  //    headers: newHeader
  //  });

  //  console.debug(changedRequest);

  //  return next.handle(changedRequest).toPromise();
  //}

}

export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
];
