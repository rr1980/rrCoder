import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router/src/utils/preactivation';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  path: ActivatedRouteSnapshot[];
  route: ActivatedRouteSnapshot;

  constructor(private router: Router, private authService: AuthService) { }


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    if (this.authService.isLogin(route.data["roles"])) {
      return true;
    }

    console.warn("Keine Rechte! Benötigt wird '" + JSON.stringify(route.data["roles"]) + "'");

    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }

  // canActivate(route: ActivatedRouteSnapshot) {


  //     this.router.navigate(['/login']);
  //     return false;
  // }
}
