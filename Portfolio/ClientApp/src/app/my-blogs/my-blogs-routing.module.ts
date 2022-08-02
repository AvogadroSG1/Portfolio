import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MyRoutes } from '../app-routing.module';
import { MyTechBlogComponent } from './my-tech-blog/my-tech-blog.component';
import { NewBlogPostComponent } from './new-blog-post/new-blog-post.component';

export const routes: MyRoutes = [
  {
    path: '',
    component: MyTechBlogComponent,
    pathMatch: 'full',
    displayOnNav: true
  },
  {
    path: 'NewBlogPost',
    component: NewBlogPostComponent,
    displayOnNav: false
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyBlogsRoutingModule { }
