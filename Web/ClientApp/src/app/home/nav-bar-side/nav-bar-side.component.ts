import { Component, OnInit } from '@angular/core';

export class List {
  id: number;
  text: string;
  icon: string;
}

@Component({
  selector: 'app-nav-bar-side',
  templateUrl: './nav-bar-side.component.html',
  styleUrls: ['./nav-bar-side.component.scss']
})
export class NavBarSideComponent implements OnInit {

  navigation: List[] = [
    { id: 1, text: "Products", icon: "product" },
    { id: 2, text: "Sales", icon: "money" },
    { id: 3, text: "Customers", icon: "group" },
    { id: 4, text: "Employees", icon: "card" },
    { id: 5, text: "Reports", icon: "chart" }
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
