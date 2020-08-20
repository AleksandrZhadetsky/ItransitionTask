import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

import { AuthenticationModule, AuthenticationService, DataService } from './shared';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component'
import { LoginComponent } from './login/login.component';
import { ImageRetrieveComponent } from './image-retrieve/image-retrieve.component';
import { UploadComponent } from './upload/upload.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatSelectModule } from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ScrollingModule } from '@angular/cdk/scrolling';
import { FormsModule } from '@angular/forms';
import { UserListComponent } from './user-list/user-list.component';
import { AuthRoleGuardService } from './shared/authentication/auth-role-guard';
import { AuthGuardService } from './shared/authentication/auth-guard';
import { JwtInterceptor } from './shared/authentication/jwt.interceptor';
import { ImageDetailsComponent } from './details/image-details.component';

@NgModule({
  imports: [
    BrowserModule,
    HttpClientModule,
    AuthenticationModule,
    AppRoutingModule,
    MatCardModule,
    MatMenuModule,
    MatSelectModule,
    ScrollingModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    ImageRetrieveComponent,
    UploadComponent,
    UserListComponent,
    ImageDetailsComponent
  ],
  bootstrap: [
    AppComponent
  ],
  providers:[
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    AuthRoleGuardService,
    AuthGuardService,
    AuthenticationService,
    DataService
  ]
})
export class AppModule { }
