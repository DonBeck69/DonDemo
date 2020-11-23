import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
//import { tap } from 'rxjs/operators/tap';
import { PdfData } from "./objects/PdfData";

@Injectable({
  providedIn: 'root'
})
export class DocumentService {



  constructor(private http: HttpClient) { }

  

  public GetPdfDoc(data: PdfData): Observable<any> {

    /*let headers: HttpHeaders = new HttpHeaders()
    .set("Accept", "application/pdf")
    .set("Content-Type", "application/pdf")
    .set("responseType", "blob")*/

    // set the response type to blob in options and let httpClient figure out the headers...
    // 
    return this.http.post("http://localhost:7071/api/DocFunction", data, { responseType: "blob" }).pipe(
      catchError((error: HttpErrorResponse) => {
        console.log(error);
        return throwError(error);
      })
      
    );
    
  }
}




/*

HttpEvent<Blob>

  public GetPdfDoc(data: PdfData): Promise<Blob> {
    return this.http.post<Blob>("http://localhost:7071/api/DocFunction", data, { headers: this.headers }).toPromise()
    .then((blob: any) => {
      return blob;
    });
  }



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