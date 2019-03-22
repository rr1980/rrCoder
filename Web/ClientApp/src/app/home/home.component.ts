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
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  title = 'ClientApp';

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }


  onClickTest() {
    this.ajax_post<User>("/api/Users/GetAll", null).subscribe((response) => {

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
