import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './footer/footer.component';
import { MyselfComponent } from './myself/myself.component';
import { MySocialComponent } from './my-social/my-social.component';
import { MyWorkComponent } from './my-work/my-work.component';
import { HeaderComponent } from './header/header.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { LoginComponent } from './login/login.component';
import { BlogPostClient } from './client-api/client-api';
import { MyBlogsModule } from './my-blogs/my-blogs.module';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MyselfComponent,
    MySocialComponent,
    MyWorkComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    MyBlogsModule,
    ApiAuthorizationModule,
    AppRoutingModule,
  ],
  providers: [
    BlogPostClient,
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
