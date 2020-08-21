import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PublicGuard, ProtectedGuard } from 'ngx-auth';
import { LoginModule } from './login/login.module'
import { HomeComponent } from './home/home.component'
import { LoginComponent } from './login/login.component';
import { ImageRetrieveComponent } from './image-retrieve/image-retrieve.component';
import { UploadComponent } from './upload/upload.component';
import { UserListComponent } from './user-list/user-list.component';
import { ImageDetailsComponent } from './details/image-details.component';
import { AuthGuardService as AuthGuard } from './shared/authentication/auth-guard'
import { AuthRoleGuardService as AuthRoleGuard } from './shared/authentication/auth-role-guard'
import { RegisterComponent } from './register/register.component'

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'user-list',
    canActivate: [ AuthRoleGuard ],
    component: UserListComponent
  },
  {
    path: 'gallery',
    component: ImageRetrieveComponent
  },
  {
    path: 'details/:id',
    component: ImageDetailsComponent
  },
  {
    path: 'upload',
    canActivate: [ AuthGuard ],
    component: UploadComponent
  },
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomeComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
