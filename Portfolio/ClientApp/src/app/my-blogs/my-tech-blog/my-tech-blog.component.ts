import { Component, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { BlogPostClient, BlogView } from '../../client-api/client-api';

@Component({
  selector: 'app-my-tech-blog',
  templateUrl: './my-tech-blog.component.html',
  styleUrls: ['./my-tech-blog.component.css']
})
export class MyTechBlogComponent implements OnInit {

  blogs: Observable<BlogView[]> = of([] as BlogView[]);

  constructor(private client: BlogPostClient) {
    this.blogs = this.client.getBlogs();
  }

  ngOnInit(): void {
  }

}
