import { Component, OnInit } from '@angular/core';
import { Observable, map } from 'rxjs';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  isAuthenticated: Observable<boolean>;
  userName: Observable<string | null | undefined>;

  constructor(private authorizeService: AuthorizeService) {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
  }
  ngOnInit(): void {
  }

}
