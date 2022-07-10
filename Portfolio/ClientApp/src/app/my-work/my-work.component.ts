import { Component, OnInit } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { ApiException, BlogPostClient } from '../client-api/client-api';

@Component({
  selector: 'app-my-work',
  templateUrl: './my-work.component.html',
  styleUrls: ['./my-work.component.css']
})
export class MyWorkComponent implements OnInit {
  constructor(private testAPI: BlogPostClient) { }

  ngOnInit(): void {
  }
}
