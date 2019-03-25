import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import notify from 'devextreme/ui/notify';

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

  data: any = {
    username: "",
    password: ""
  };


  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
  }

  onClickLogin(params) {


    var validation_results = params.validationGroup.validate();


    if (validation_results.isValid) {
      this.ajax_post<User>("/api/Benutzer/authenticate", this.data).subscribe((response) => {

        localStorage.setItem('currentUser', JSON.stringify(response));

        this.router.navigate(['/home']);
      });
    }
    else {
      var msg = "";
      for (let err of validation_results.brokenRules) {
        msg += err.message + "\r\n";
      }

      notify({
        message: msg,
        width: 600
      }, "error", 3000);

    }
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
