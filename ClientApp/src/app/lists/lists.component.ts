import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
import { Content } from "../objects/Content";
import { ContentList } from "../objects/ContentList";

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {

  public _listContent: ContentList;

  constructor(
    private router: Router,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.http.get<Content>("assets/content.json").subscribe((result: Content) => {
      let rout: string = this.router.url;
      rout = rout.substring(1, rout.length);
      this._listContent = result.contentLists.find((list: ContentList) => {
        return list.rout === rout;
      });
    });  
  }
}
