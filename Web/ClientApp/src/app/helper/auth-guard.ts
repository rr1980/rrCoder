import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router/src/utils/preactivation';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { JsonpCallbackContext } from '@angular/common/http/src/jsonp';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  path: ActivatedRouteSnapshot[];
  route: ActivatedRouteSnapshot;

  constructor(private router: Router) { }


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    return true;
    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    const neededRoles = route.data["roles"];

    console.debug(currentUser, neededRoles);

    if (currentUser && currentUser.token) {

      var role = neededRoles.find(x => x.toLowerCase() === currentUser.role.toLowerCase());

      if (role || currentUser.role.toLowerCase() === 'admin') {
        return true;
      }
      else {
        console.warn("Keine Rechte! Benötigt wird '" + JSON.stringify(neededRoles) + "'");
        return false;
      }
    }

    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }

  // canActivate(route: ActivatedRouteSnapshot) {


  //     this.router.navigate(['/login']);
  //     return false;
  // }
}
