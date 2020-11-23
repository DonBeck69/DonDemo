import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GetpdfComponent } from "./getpdf/getpdf.component";
const routes: Routes = [
  {
    path: "pdf",
    component: GetpdfComponent,
    runGuardsAndResolvers: "always"
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
