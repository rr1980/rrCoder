import { Type } from '@angular/core';

export class AdItem {

  public navId: string;


  constructor(public component: Type<any>, public name: string, public onEvent: (event) => void, public data: any) {
    this.navId = this.newGuid();
  }

  newGuid() {
    return 'xxxxxxxx'.replace(/[xy]/g, function (c) {
      var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
      return v.toString(16); 
    });
  }
} 
