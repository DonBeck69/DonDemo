import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
//import { content} from "./objects/content";
import { Routing} from "./objects/Routing";
import { RoutData } from "./objects/RoutData";
import { PagesComponent } from "./pages/pages.component";
import { ListsComponent } from "./lists/lists.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  //title = 'ClientApp';
  
  public _routing: Routing;

  constructor(private http: HttpClient, private router: Router){
    //this._htttpClient = http;
  }


  ngOnInit(): void {
      this.http.get<Routing>("assets/routing.json").subscribe((rout: Routing) => {
        this._routing = rout;
        rout.lists.forEach((list: RoutData) => {
          this.router.config.push({ path: list.rout, component: ListsComponent, runGuardsAndResolvers: "always" });
        });
        rout.pages.forEach((page: RoutData) => {
          this.router.config.push({ path: page.rout, component: PagesComponent, runGuardsAndResolvers: "always" });
        });

        console.log(this.router.config);
    });
  }

  public btnClick(rout: string) {
    this.router.navigateByUrl(rout);
  }

}
