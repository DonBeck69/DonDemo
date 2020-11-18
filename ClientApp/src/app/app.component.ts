import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
//import { content} from "./objects/content";
import { routing} from "./objects/routing";
import { PagesComponent } from "./pages/pages.component";
import { ListsComponent } from "./lists/lists.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  //title = 'ClientApp';
  
  //public _htttpClient: HttpClient;

  constructor(private http: HttpClient, private router: Router){
    //this._htttpClient = http;
  }


  ngOnInit(): void {
      this.http.get<routing>("assets/routing.json").subscribe(rout => {
        rout.lists.forEach((list: string) => {
          this.router.config.push({ path: list, component: ListsComponent });
        });
        rout.pages.forEach((page: string) => {
          this.router.config.push({ path: page, component: PagesComponent });
        });
    });
  }

  public btnClick() {
    this.router.navigateByUrl("pages/page-one");
  }

}
