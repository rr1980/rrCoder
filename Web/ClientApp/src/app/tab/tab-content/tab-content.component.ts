import { Component, OnInit, Input, ViewContainerRef, ComponentFactoryResolver, Renderer2, OnChanges } from '@angular/core';
import { AdItem } from '../ad-item';
import { AdComponent } from '../ad.component';

@Component({
  selector: 'app-tab-content',
  templateUrl: './tab-content.component.html',
  styleUrls: ['./tab-content.component.scss']
})
export class TabContentComponent implements OnInit, OnChanges {

  @Input() ad: AdItem;
  @Input() isHidden: boolean = true;

  constructor(private viewContainerRef: ViewContainerRef, private componentFactoryResolver: ComponentFactoryResolver, private renderer: Renderer2) { }

  ngOnInit() {
    let componentFactory = this.componentFactoryResolver.resolveComponentFactory(this.ad.component);
    this.viewContainerRef.clear();
    let componentRef = this.viewContainerRef.createComponent(componentFactory);
    (<AdComponent>componentRef.instance).data = this.ad.data;
    (<AdComponent>componentRef.instance).onEvent = this.ad.onEvent;

    this.renderer.appendChild(
      this.viewContainerRef.element.nativeElement, 
      componentRef.location.nativeElement
    );
  }

  ngOnChanges() {
    if (this.isHidden) {
      this.renderer.setStyle(this.viewContainerRef.element.nativeElement, 'display', 'none');
    } else {
      this.renderer.setStyle(this.viewContainerRef.element.nativeElement, 'display', 'block');
    }
  }
}
