import { Directive, ViewContainerRef, Input } from '@angular/core';

@Directive({
  selector: '[ad-host]',
})


export class AdDirective {

  @Input() navId: string;
  public init: boolean = false;

  constructor(public viewContainerRef: ViewContainerRef) { }

}
