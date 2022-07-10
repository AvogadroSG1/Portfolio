import { NgModule } from '@angular/core';
import { Route, RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { LoginComponent } from './login/login.component';
import { MyBlogComponent } from './my-blog/my-blog.component';
import { MySocialComponent } from './my-social/my-social.component';
import { MyWorkComponent } from './my-work/my-work.component';
import { MyselfComponent } from './myself/myself.component';

export interface MyRoute extends Route {
  displayText?: string;
  routeIcon?: string;
  displayOnNav?: boolean;
}

export declare type MyRoutes = MyRoute[];

export const routes: MyRoutes = [
  {
    path: '',
    component: MyselfComponent,
    displayText: 'Myself',
    routeIcon: 'person',
    displayOnNav: true,
    pathMatch: 'full'
  },
  {
    path: 'battlestar',
    component: LoginComponent,
    displayText: 'Myself',
    routeIcon: 'person',
    displayOnNav: false,
    pathMatch: 'full'
  },
  {
    path: 'my-work',
    component: MyWorkComponent,
    displayText: 'My Work',
    routeIcon: 'person',
    displayOnNav: true
  },
  {
    path: 'my-social',
    component: MySocialComponent,
    displayText: 'My Social',
    routeIcon: 'person',
    displayOnNav: true
  },
  {
    path: 'my-blog',
    component: MyBlogComponent,
    displayText: 'My Blog',
    routeIcon: 'person',
    displayOnNav: true,
    canActivate: [AuthorizeGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
