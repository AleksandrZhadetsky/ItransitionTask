import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from '../shared';

@Component({
  selector: 'register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {

public username = "";
public password = "";
public email = "";

  constructor(
    private router: Router,
    private authService: AuthenticationService
  ) { }

  public register() {
    this.authService
      .register(this.username, this.email, this.password)
      .subscribe(() => {});

    //   location.reload(true);
  }

}
