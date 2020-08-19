import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

import { AuthenticationModule } from './shared';
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
    UserListComponent
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
