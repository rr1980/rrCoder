import { Component, OnInit } from '@angular/core';

export class List {
  id: number;
  text: string;
  icon: string;
}

@Component({
  selector: 'app-nav-bar-side-2',
  templateUrl: './nav-bar-side-2.component.html',
  styleUrls: ['./nav-bar-side-2.component.scss']
})
export class NavBarSide2Component implements OnInit {

  navigation: List[] = [
    { id: 1, text: "Edit", icon: "edit" },
    { id: 2, text: "Delete", icon: "remove" },
  ];

  selected_navigation: any = [];

  constructor() { }

  ngOnInit() {
    this.selected_navigation = [this.navigation[0]];
  }

  onItemClick(e) {
    console.debug(e);
  }

}
