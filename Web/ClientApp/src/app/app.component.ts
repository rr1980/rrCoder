import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

interface User {
  id?: number;
  firstName: string;
  lastName: string;
  username: string;
  password: string;
  role: string;
  token: string;
}


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';

  constructor(private http: HttpClient) {
  }

  onClickLogin() {
    this.ajax_post<User>("/api/Users/authenticate", { username: "admin", password: "admin" }).subscribe(response => {

      localStorage.setItem('currentUser', JSON.stringify(response));
      console.debug({ "Login": response });

    });
  }

  onClickLogout(): void {
    localStorage.removeItem('currentUser');
  }

  onClickTest() {
    this.ajax_post<User>("/api/Users/GetAll", null).subscribe(response => {

      console.debug({ "Test": response });

    });
  }

  ajax_post<T>(url: string, data: any): Observable<T> {
    return this.http.post<any>(url, data)
      .pipe(
        map(response => {
          return response as T;
        })
      );
  }
}
