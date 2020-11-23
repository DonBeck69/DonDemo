import { Component, OnInit } from '@angular/core';
import { saveAs } from "file-saver";

import { PdfData } from "../objects/PdfData";
import { DocumentService } from "../document.service";

@Component({
  selector: 'app-getpdf',
  templateUrl: './getpdf.component.html',
  styleUrls: ['./getpdf.component.css']
})
export class GetpdfComponent implements OnInit {



  constructor(private docServe: DocumentService) { }

  ngOnInit(): void {
  }

  public GetPdfDoc() {

    let data: PdfData = new PdfData({
      Title: "Demonstration ADA document",
      Name: "Donovan",
      Paragraph: "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
      Data: [
        [11, 12, 13],
        [14, 15, 16]
    ]
    });

    
    this.docServe.GetPdfDoc(data).toPromise<Blob>()
    .then((doc: Blob) => {
      // save as, from "file-saver"
      saveAs(doc, "Test.pdf");
    })
    .catch((error: any) => { console.log(error)});

  }


}


/*

    this.docServe.GetPdfDoc(data)
    .then((doc: Blob) => {
      saveAs(doc, "Test.pdf")
    })
    .catch((error: any) => {
      console.log(error);
    });

    this.http.post<Blob>("http://localhost:7071/api/DocFunction", data, { headers: this.headers }).toPromise()
    .then((blob: any) => {
      saveAs(blob, "Test.pdf");;
      //console.log(result);
    })
    .catch((error) =>{
      console.error(error)
    });


    this.http.post<Blob>("http://localhost:7071/api/DocFunction", data, { headers: this.headers }).subscribe((blob: any) => {
      saveAs(blob, "Test.pdf");;
      //console.log(result);
    }, (error) => {
      console.error(error)
    });  }




  private headers: HttpHeaders = new HttpHeaders({
    "Content-Type": "application/octet-stream",//application/pdf
    "Access-Control-Allow-Origin": "*",
    "Access-Control-Allow-Methods": "GET,OPTIONS",
    "Access-Control-Allow-Headers": "Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers"
  });
*/