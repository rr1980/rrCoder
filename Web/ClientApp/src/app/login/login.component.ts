import { Component, OnInit, setTestabilityGetter, ChangeDetectorRef, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { fadeInAnimation } from '../helper/route-animation';
import { AjaxService } from '../helper/ajax.service';
import { EventService } from '../helper/event.service';
import { IAppError } from '../helper/error.handler';
import { Subscription } from 'rxjs';

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

  sub_error: Subscription;

  constructor(private router: Router, private formBuilder: FormBuilder, private route: ActivatedRoute, private ajaxService: AjaxService, private eventService: EventService, private ref: ChangeDetectorRef) {
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

    this.sub_error = this.eventService.register("error").subscribe(error => {

      this.loading = false;

      if (error.statusCode === 403) {
        this.errorMsg = error.msg;
      }

      this.ref.detectChanges();
    });
  }

  ngOnDestroy(): void {
    if (this.sub_error) {
      this.sub_error.unsubscribe();
    }
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

    this.ajaxService.post<User>("Benutzer/authenticate", { username: this.f.username.value, password: this.f.password.value }, false).subscribe((response) => {

      localStorage.setItem('currentUser', JSON.stringify(response));

      this.router.navigate([this.returnUrl]);
    });
  }
}
