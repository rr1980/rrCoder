import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { map, first } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

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

  loading = false;
  loginForm: FormGroup;
  returnUrl: string;
  submitted = false;

  constructor(private http: HttpClient, private router: Router, private formBuilder: FormBuilder, private route: ActivatedRoute, ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() { return this.loginForm.controls; }

  onClickLogin() {
    this.submitted = true;

    if (this.loginForm.invalid) {
      console.debug("invalid");

      return;
    }


    this.loading = true;
    this.ajax_post<User>("/api/Benutzer/authenticate", { username: this.f.username.value, password: this.f.password.value }).pipe(first()).subscribe((response) => {

      localStorage.setItem('currentUser', JSON.stringify(response));

      this.router.navigate([this.returnUrl]);
    }, (error) => {
      this.loading = false;
      console.debug({ username: this.f.username.value, password: this.f.password.value }, error);
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
