import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MyRoutes } from '../app-routing.module';
import { MyTechBlogComponent } from './my-tech-blog/my-tech-blog.component';

export const routes: MyRoutes = [
  {
    path: 'my-blogs',
    component: MyTechBlogComponent,
    displayText: 'Myself',
    routeIcon: 'person',
    displayOnNav: true,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyBlogsRoutingModule { }
