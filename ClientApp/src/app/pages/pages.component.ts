import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
import { content } from "../objects/content";
import { contentPage } from "../objects/contentPage";

@Component({
  selector: 'app-pages',
  templateUrl: './pages.component.html',
  styleUrls: ['./pages.component.css']
})
export class PagesComponent implements OnInit {

  public _pageContent: contentPage;

  constructor(
    private router: Router,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.http.get<content>("assets/content.json").subscribe((result: content) => {
      let rout: string = this.router.url;
      rout = rout.substring(1, rout.length);
      this._pageContent = result.contentPages.find((page: contentPage) => {
        return page.rout === rout;
      });
    });
  }

}
