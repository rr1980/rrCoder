import { Component, OnInit } from '@angular/core';

export class Category {
  text: string;
  icon: string;
  badge?: number;
}

@Component({
  selector: 'app-nav-bar-up',
  templateUrl: './nav-bar-up.component.html',
  styleUrls: ['./nav-bar-up.component.scss']
})
export class NavBarUpComponent implements OnInit {

  navBarData: Category[] = [
    {
      text: "Contacts",
      icon: "user"
    }, {
      text: "Missed",
      icon: "clock",
      badge: 3
    }, {
      text: "Favorites",
      icon: "favorites"
    }
  ];

  constructor() { }

  ngOnInit() {
  }

  selectionChanged(e) {
    console.debug("nav", e);
  }
}
