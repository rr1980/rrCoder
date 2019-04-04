import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { fadeInAnimation } from '../helper/route-animation';
import { AuthService } from '../helper/auth.service';

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
export class LoginComponent implements OnInit, OnDestroy {

  title = 'ClientApp';

  loading = false;
  loginForm: FormGroup;
  returnUrl: string;
  submitted = false;
  errorMsg: string;

  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute, private authService: AuthService) {
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  ngOnDestroy(): void {
  }

  get f() { return this.loginForm.controls; }

  onClickLogin() {
    this.errorMsg = "";
    this.submitted = true;

    if (this.loginForm.invalid) {
      console.debug("invalid");

      return;
    }

    this.loading = true;

    this.authService.login({ username: this.f.username.value, password: this.f.password.value }, this.returnUrl, (err) => {
      this.loading = false;
      if (err.status === 403) {
        this.errorMsg = err.error.Message;
      }
    });
  }
}
