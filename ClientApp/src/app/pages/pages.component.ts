import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
import { Content } from "../objects/Content";
import { ContentPage } from "../objects/ContentPage";

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  styleUrls: ['./pages.component.css']
})
export class PagesComponent implements OnInit {

  public _pageContent: ContentPage;

  constructor(
    private router: Router,
    private http: HttpClient
  ) { 
    console.log("page says hi!");
  }

  ngOnInit(): void {
    this.http.get<Content>("assets/content.json").subscribe((result: Content) => {
      let rout: string = this.router.url;
      rout = rout.substring(1, rout.length);
      this._pageContent = result.contentPages.find((page: ContentPage) => {
        return page.rout === rout;
      });
    });
  }

}
