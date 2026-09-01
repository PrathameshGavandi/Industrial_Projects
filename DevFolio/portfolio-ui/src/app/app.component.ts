import { Component } from '@angular/core';
import { Router, NavigationEnd, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { filter } from 'rxjs/operators';

import { NavComponent } from './AdminPanel/nav/nav';
import { FooterComponent } from './AdminPanel/footer/footer';
import { UserNav } from './UserPanel/user-nav/user-nav';
import { UserFooter } from './UserPanel/user-footer/user-footer';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    NavComponent,
    FooterComponent,
    UserNav,
    UserFooter
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.scss']
})
export class AppComponent {
  //title = 'My Portfolio';
  isAdminPage = false;

  constructor(private router: Router) {
    this.router.events
      .pipe(filter((event): event is NavigationEnd => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        const url = event.urlAfterRedirects;

        const adminPages = [
          '/login',
          '/profile',
          '/skills',
          '/experience',
          '/projects',
          '/education'
        ];

        this.isAdminPage = adminPages.some(p => url.startsWith(p));
      });
  }
}
