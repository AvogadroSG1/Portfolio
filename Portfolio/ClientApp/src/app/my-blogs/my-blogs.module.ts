import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MyBlogsRoutingModule } from './my-blogs-routing.module';
import { BlogPostClient } from '../client-api/client-api';
import { MyTechBlogComponent } from './my-tech-blog/my-tech-blog.component';

@NgModule({
  declarations: [
    MyTechBlogComponent
  ],
  imports: [
    CommonModule,
    MyBlogsRoutingModule
  ],
  providers: [BlogPostClient]
})
export class MyBlogsModule { }
