import { Component, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

import { MyRoute, MyRoutes, routes } from '../app-routing.module';


@Component({
  selector: 'nav-menu',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  routes: MyRoutes = routes.filter((route: MyRoute): boolean => route.displayOnNav ?? false);

  constructor(private authorizeService: AuthorizeService) {
  }

  ngOnInit(): void {

  }

}
