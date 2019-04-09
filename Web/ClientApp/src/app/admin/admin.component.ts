import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { slideInOutAnimation, fadeInAnimation } from '../helper/route-animation';
import { ModalService } from '../helper/modal.service';



@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
  animations: [fadeInAnimation],
  host: { '[@fadeInAnimation]': '' }
})
export class AdminComponent implements OnInit {

  constructor(private http: HttpClient, private modalService: ModalService) { }

  ngOnInit() {
  }


  onClickGetAllBenutzer() {

    var e;

    e.name.trim();
    //this.modalService.open("error-modal");
    //throw new Error("Na Nö");
    //this.ajax_post<any>("/api/Benutzer/GetAll", null).subscribe((response) => {

    //  console.debug({ "Test": response });

    //});
  }


  onClickGetAllCodeContent() {
    this.ajax_post<any>("/api/CodeSnippet/GetAll", null).subscribe((response) => {

      console.debug(response);

    });
  }



  ajax_post<T>(url: string, data: any): Observable<T> {
    return this.http.post<any>(url, data)
      .pipe(
        map((response) => {
          return response as T;
        })
      );
  }
}
