import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthenticationService } from './authentication.service';
@Injectable()
export class AuthRoleGuardService implements CanActivate {
  constructor(public auth: AuthenticationService, public router: Router) {}
  canActivate(): boolean {
    let role = this.auth.userValue == null ? null : this.auth.userValue.role;
    if (!this.auth.isAuthorized() || role == null || role != "admin") {
      this.router.navigate(['home']);
      return false;
    }
    return true;
  }
}