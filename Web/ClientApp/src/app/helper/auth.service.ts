import { Injectable } from '@angular/core';
import { AjaxService } from './ajax.service';
import { Router } from '@angular/router';
import { throwError } from 'rxjs';

interface User {
  id?: number;
  firstName: string;
  lastName: string;
  username: string;
  password: string;
  role: string;
  token: string;
}

@Injectable()
export class AuthService {

  preUrl: string = "api/";

  constructor(private ajaxService: AjaxService, private router: Router) {

  }

  isLogin(neededRoles: any): boolean {

    const currentUser = JSON.parse(sessionStorage.getItem('currentUser'));

    if (currentUser && currentUser.token) {

      var role = neededRoles.find(x => x.toLowerCase() === currentUser.role.toLowerCase());

      if (role || currentUser.role.toLowerCase() === 'admin') {
        return true;
      }
      else {
        return false;
      }
    }
  }

  login(data, returnUrl: string, err: (err) => void) {

    this.ajaxService.post<User>("Benutzer/authenticate", data).subscribe((response) => {

      sessionStorage.setItem('currentUser', JSON.stringify(response));

      this.router.navigate([returnUrl]);

    }, _err => {
      if (_err.status === 403) {
        if (err) {
          err(_err);
        }
      }
      else {
        throw _err;
      }
    });
  }
}
