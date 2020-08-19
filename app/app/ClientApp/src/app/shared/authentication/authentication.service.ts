import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, map, switchMap, catchError } from 'rxjs/operators';
import { AuthService } from 'ngx-auth';

import { TokenStorage } from './token-storage.service';

interface AccessData {
  accessToken: string;
  // refreshToken: string;
}

@Injectable()
export class AuthenticationService implements AuthService {

  public readonly ApiUrl = 'http://localhost:61955';

  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorage
  ) { }

  public isAuthorized(): Observable<boolean> {
    return this.tokenStorage
      .getAccessToken()
      .pipe(map(token => !!token));
  }

  public getAccessToken(): Observable<string> {
    return this.tokenStorage.getAccessToken();
  }

  public refreshToken(): Observable<AccessData> {
    return this.tokenStorage
      .getRefreshToken()
      .pipe(
        switchMap((refreshToken: string) =>
          this.http.post(`${this.ApiUrl}/refresh`, { refreshToken })
        ),
        tap((tokens: AccessData) => this.saveAccessData(tokens)),
        catchError((err) => {
          this.logout();

          return Observable.throw(err);
        })
      );
  }

  public refreshShouldHappen(response: HttpErrorResponse): boolean {
    return response.status === 401
  }

  public verifyTokenRequest(url: string): boolean {
    return url.endsWith('/refresh');
  }

  public login(_username: string, _password: string): Observable<any> {
    return this.http
      .post(`${this.ApiUrl}/api/authentication/login`, { username: _username, password: _password })
      .pipe(tap((token) => {this.saveAccessData(token.token); console.log(token.token)}));
  }

  public logout(): void {
    this.tokenStorage.clear();
    location.reload(true);
  }

  private saveAccessData(accessToken) {
    this.tokenStorage
      .setAccessToken(accessToken);
  }

}
