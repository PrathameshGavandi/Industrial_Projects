import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { WebService } from '../Service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  constructor(private router: Router,
    private http: HttpClient,
    private service: WebService) {
   
  }
  // isMenuOpen = false;

  // toggleMenu() {
  //   this.isMenuOpen = !this.isMenuOpen;
  // }


  logout() {
    // Clear session storage
    sessionStorage.clear();
    localStorage.clear();
    this.router.navigate(['/login']).then(() => {
      window.location.reload(); // Force reload to ensure that the login page is displayed fresh
    });
  }

}
