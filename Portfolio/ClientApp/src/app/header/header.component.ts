import { Component, OnInit } from '@angular/core';

import { MyRoute, MyRoutes, routes } from '../app-routing.module';


@Component({
  selector: 'app-banner',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  routes: MyRoutes = routes.filter((route: MyRoute): boolean => route.displayOnNav ?? false);

  constructor() {
  }

  ngOnInit(): void {

  }

}
