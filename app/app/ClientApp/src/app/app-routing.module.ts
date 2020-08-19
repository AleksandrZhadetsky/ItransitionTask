import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PublicGuard, ProtectedGuard } from 'ngx-auth';
import { LoginModule } from './login/login.module'
import { HomeComponent } from './home/home.component'
import { LoginComponent } from './login/login.component';
import { ImageRetrieveComponent } from './image-retrieve/image-retrieve.component';
import { UploadComponent } from './upload/upload.component';
import { UserListComponent } from './user-list/user-list.component';

const routes: Routes = [
  {
    path: 'login',
    // canActivate: [ PublicGuard ],
    component: LoginComponent
  },
  // {
  //   path: 'register',
  //   canActivate: [ PublicGuard ],
  //   component: RegisterModule
  // },
  {
    path: 'user-list',
    // canActivate: [ PublicGuard ],
    component: UserListComponent
  },
  {
    path: 'gallery',
    canActivate: [ PublicGuard ],
    component: ImageRetrieveComponent
  },
  {
    path: 'upload',
    canActivate: [ PublicGuard ],
    component: UploadComponent
  },
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
