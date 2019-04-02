import { Component, OnInit, OnDestroy, ChangeDetectorRef } from '@angular/core';
import { ModalService } from '../helper/modal.service';
import { Subscription } from 'rxjs';
import { EventService } from '../helper/event.service';
import { IAppError } from '../helper/error.handler';



@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent implements OnInit, OnDestroy {

  error: IAppError;
  sub_error: Subscription;

  constructor(private modalService: ModalService, private eventService: EventService, private ref: ChangeDetectorRef) {
  }

  ngOnInit() {
    this.sub_error = this.eventService.register("error").subscribe(error => {
      if (error.hasOwnProperty("showAlert")) {
        if (error.showAlert === true) {
          this.error = error;
          this.modalService.open("error-modal");
          this.ref.detectChanges();
        }
      }
      else {
        this.error = error;
        this.modalService.open("error-modal");
        this.ref.detectChanges();
      }
    });
  }

  ngOnDestroy(): void {
    if (this.sub_error) {
      this.sub_error.unsubscribe();
    }
  }

  closeModal() {
    this.modalService.close("error-modal", () => {
      this.error = null;
    });
  }
}
