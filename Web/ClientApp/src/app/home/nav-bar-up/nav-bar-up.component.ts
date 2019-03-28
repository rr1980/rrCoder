import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';

export class Category {
  text: string;
  icon: string;
  badge?: number;
  click: (e) => void;
}

@Component({
  selector: 'app-nav-bar-up',
  templateUrl: './nav-bar-up.component.html',
  styleUrls: ['./nav-bar-up.component.scss'],
  //encapsulation: ViewEncapsulation.Emulated
})
export class NavBarUpComponent implements OnInit {

  navBarData: Category[] = [
    {
      text: "Contacts",
      icon: "user",
      click: e => {
        this.router.navigate(['/intern/home', { outlets: { sideBar: 'sideBar1', content: 'codeContent' } }]);
      }
    },
    {
      text: "Favorites",
      icon: "favorites",
      click: e => {
        this.router.navigate(['/intern/home', { outlets: { sideBar: 'sideBar2', content: 'admin' } }]);
      }
    },
    {
      text: "Missed",
      icon: "clock",
      badge: 3,
      click: e => {
        localStorage.removeItem('currentUser');
        this.router.navigate(['/login']);
      }
    }
  ] as Category[];

  constructor(private router: Router) { }

  ngOnInit() {
  }

  onCodeClick(e) {
    this.router.navigate(['/intern/home', { outlets: { sideBar: 'sideBar1', content: 'codeContent' } }]);
  }

  onAdminClick(e) {
    this.router.navigate(['/intern/home', { outlets: { sideBar: 'sideBar2', content: 'admin' } }]);
  }

  onLogoutClick(e) {
    localStorage.removeItem('currentUser');
    this.router.navigate(['/login']);
  }
}
