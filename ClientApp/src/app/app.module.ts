import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PagesComponent } from './pages/pages.component';
import { ListsComponent } from './lists/lists.component';
import { GetpdfComponent } from './getpdf/getpdf.component';
import { DocumentService } from "./document.service";

@NgModule({
  declarations: [
    AppComponent,
    PagesComponent,
    ListsComponent,
    GetpdfComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    DocumentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
