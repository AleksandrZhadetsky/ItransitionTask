import { Component } from '@angular/core';
import { AuthenticationService } from '../shared';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isAuthorized: boolean;

  constructor(private _authService: AuthenticationService){
    this.isAuthorized = _authService.userValue && _authService.userValue.token;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  public logout(){
    this._authService.logout();
  }
}
