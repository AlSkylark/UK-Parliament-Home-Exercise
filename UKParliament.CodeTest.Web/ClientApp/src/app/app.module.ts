import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { AppRoutingModule, routingComponents } from './app-routing.module';
import { WelcomeComponent } from './welcome/welcome.component';
import { MpItemComponent } from './components/mp-item/mp-item.component';
import { MpPaginationComponent } from './components/mp-pagination/mp-pagination.component';
import { PaginationControlsComponent } from './components/pagination-controls/pagination-controls.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    routingComponents,
    WelcomeComponent,
    MpItemComponent,
    MpPaginationComponent,
    PaginationControlsComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
