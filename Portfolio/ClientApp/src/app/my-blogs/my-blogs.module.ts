import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyBlogsRoutingModule } from './my-blogs-routing.module';
import { BlogPostClient } from '../client-api/client-api';
import { MyTechBlogComponent } from './my-tech-blog/my-tech-blog.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NewBlogPostComponent } from './new-blog-post/new-blog-post.component';

@NgModule({
  declarations: [
    MyTechBlogComponent,
    NewBlogPostComponent
  ],
  imports: [
    CommonModule,
    MyBlogsRoutingModule,
    FontAwesomeModule
  ],
  providers: [BlogPostClient]
})
export class MyBlogsModule { }
