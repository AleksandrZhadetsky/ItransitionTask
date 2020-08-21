import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../shared';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  public username = "";
  public password = "";
  public email = "";

  isRegistrationRequested = false;
  isLoginRequested = true;

  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) { }

  public login() {
    this.authService
      .login(this.username, this.password)
      .subscribe(() => { });
    setTimeout(() => {
      location.reload(true);

    }, 100);
  }

  public register() {
    this.authService
      .register(this.username, this.email, this.password)
      .subscribe(() => { });

    // location.reload(true);
  }

  LoginRequested() {
    this.isLoginRequested = true;
    this.isRegistrationRequested = false;
  }

  RegistrationRequested() {
    this.isRegistrationRequested = true;
    this.isLoginRequested = false;
  }

}
