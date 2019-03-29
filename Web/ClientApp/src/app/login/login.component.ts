import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { fadeInAnimation } from '../helper/route-animation';
import { AjaxService } from '../helper/ajax.service';

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
  styleUrls: ['./login.component.scss'],
  animations: [fadeInAnimation],
  host: { '[@fadeInAnimation]': '' }
})
export class LoginComponent implements OnInit {

  title = 'ClientApp';

  loading = false;
  loginForm: FormGroup;
  returnUrl: string;
  submitted = false;

  constructor(private router: Router, private formBuilder: FormBuilder, private route: ActivatedRoute, private ajaxService: AjaxService) { }

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

    this.ajaxService.post<User>("Benutzer/authenticate", { username: this.f.username.value, password: this.f.password.value }).subscribe((response) => {

      localStorage.setItem('currentUser', JSON.stringify(response));

      this.router.navigate([this.returnUrl]);
    }, (error) => {
      this.loading = false;
      console.debug({ username: this.f.username.value, password: this.f.password.value }, error);
    });
  }
}
