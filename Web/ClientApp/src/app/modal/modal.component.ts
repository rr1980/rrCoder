import { Component, OnInit, OnDestroy, ElementRef, Input, Renderer2 } from '@angular/core';
import { ModalService } from '../helper/modal.service';




@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent implements OnInit, OnDestroy {

  @Input() id: string;
  private element: any;

  constructor(private modalService: ModalService, private el: ElementRef, private renderer: Renderer2) {
    this.element = el.nativeElement;
  }

  ngOnInit() {
    let modal = this;

    if (!this.id) {
      console.error('modal must have an id');
      return;
    }


    this.renderer.appendChild(document.body, this.element)
    this.element.addEventListener('click', function (e: any) {
      if (e.target.className === 'modal') {
        modal.close();
      }
    });

    this.modalService.add(this);
  }

  ngOnDestroy(): void {
    this.modalService.remove(this.id);
    this.element.remove();
  }

  open(): void {
    this.element.style.display = 'block';
    this.renderer.addClass(document.body, 'modal-open');
  }

  close(): void {
    this.element.style.display = 'none';
    this.renderer.removeClass(document.body, 'modal-open')
  }
}
