import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../shared';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {

public username = "";
public password = "";

  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) { }

  public login() {
    this.authService
      .login(this.username, this.password)
      .subscribe(_ => {});
  }

}
