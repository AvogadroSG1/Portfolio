import { Component, OnInit } from '@angular/core';
import { map, Observable, of } from 'rxjs';
import { BlogPostClient, BlogView, PostView } from '../../client-api/client-api';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
@Component({
  selector: 'app-my-tech-blog',
  templateUrl: './my-tech-blog.component.html',
  styleUrls: ['./my-tech-blog.component.css']
})
export class MyTechBlogComponent implements OnInit {

  faPlus = faPlus;

  posts: Observable<PostView[]> = of([] as PostView[]);

  constructor(private client: BlogPostClient) {
    this.posts = this.client.getPosts();
  }

  ngOnInit(): void {
  }

  newPost(blogId: number): void {

  }
}
