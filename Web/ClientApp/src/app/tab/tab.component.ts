import { Component, OnInit, Input, ViewChild, ComponentFactoryResolver, QueryList, ViewChildren, AfterViewInit, OnChanges, SimpleChanges, ChangeDetectionStrategy, Renderer2 } from '@angular/core';
import { AdItem } from './ad-item';
import { AdDirective } from './ad.directive';
import { AdComponent } from './ad.component';


@Component({
  selector: 'app-tab',
  templateUrl: './tab.component.html',
  styleUrls: ['./tab.component.scss'],
  //changeDetection: ChangeDetectionStrategy.OnPush
})
export class TabComponent implements OnInit{

  init: boolean = true;

  _ads: AdItem[] = [];

  @ViewChildren(AdDirective) adHosts: QueryList<AdDirective>;


  constructor(private componentFactoryResolver: ComponentFactoryResolver, private renderer: Renderer2) {
  }

  ngOnInit() {
  }


  public add(ad: AdItem) {
    this._ads.push(ad);

    setTimeout(() => {
      this.set();
      this.isActive = ad.navId;
    }, 0);
  }

  private set() {
    if (!this.init) {
      return;
    }

    var _adHosts = this.adHosts.toArray().filter(x => x.init === false);

    for (var i = 0; i < _adHosts.length; i++) {
      var ad = this._ads.find(x => x.navId === _adHosts[i].navId);

      let componentFactory = this.componentFactoryResolver.resolveComponentFactory(ad.component);

      let viewContainerRef = _adHosts[i].viewContainerRef;
      viewContainerRef.clear();

      let componentRef = viewContainerRef.createComponent(componentFactory);
      (<AdComponent>componentRef.instance).data = ad.data;
      (<AdComponent>componentRef.instance).onEvent = ad.onEvent;


      console.debug(_adHosts[i], componentRef);


      this.renderer.appendChild(
        viewContainerRef.element.nativeElement,
        componentRef.location.nativeElement
      );
      _adHosts[i].init = true;
    }
  }

  isActive: string;

  onClickTabNav(ad: AdItem) {
    this.isActive = ad.navId;
  }

  onClickClose(ad: AdItem) {

    var index = this._ads.indexOf(ad);

    if (index > -1) {
      this._ads.splice(index, 1);
    }
  }
}
