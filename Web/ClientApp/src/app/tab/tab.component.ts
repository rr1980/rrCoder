import { Component, OnInit, Input, IterableDiffers, DoCheck, IterableDiffer } from '@angular/core';
import { AdItem } from './ad-item';


@Component({
  selector: 'app-tab',
  templateUrl: './tab.component.html',
  styleUrls: ['./tab.component.scss']
})
export class TabComponent implements OnInit, DoCheck {

  @Input() ads: AdItem[] = [];

  isActive: string;
  differ: IterableDiffer<any>;

  constructor(differs: IterableDiffers) {
    this.differ = differs.find(this.ads).create(null);
  }

  ngOnInit() {
    this.isActive = this.ads[0].navId;
  }

  ngDoCheck() {
    const changes = this.differ.diff(this.ads);
    if (changes) {
      changes.forEachAddedItem((change) => {
        this.isActive = change.item.navId;
      });
    }
  }

  onClickTabNav(ad: AdItem) {
    this.isActive = ad.navId;
  }

  onClickClose(ad: AdItem) {

    var index = this.ads.indexOf(ad);

    if (index > -1) {
      this.ads.splice(index, 1);
    }

    if (ad.navId === this.isActive && this.ads[0] != null) {
      this.isActive = this.ads[0].navId
    }
  }
}
