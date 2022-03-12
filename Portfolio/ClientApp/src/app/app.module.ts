import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './footer/footer.component';
import { MyselfComponent } from './myself/myself.component';
import { MySocialComponent } from './my-social/my-social.component';
import { MyWorkComponent } from './my-work/my-work.component';
import { HeaderComponent } from './header/header.component';
import { MyBlogComponent } from './my-blog/my-blog.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MyselfComponent,
    MySocialComponent,
    MyWorkComponent,
    MyBlogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
