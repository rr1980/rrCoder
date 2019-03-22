import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

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
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  title = 'ClientApp';
  login = '';
  password = '';

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }

  onClickLogin() {
    this.ajax_post<User>("/api/Users/authenticate", { username: this.login, password: this.password }).subscribe((response) => {

      localStorage.setItem('currentUser', JSON.stringify(response));
      console.debug({ "Login": response });

      this.router.navigate(['/home']);
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
