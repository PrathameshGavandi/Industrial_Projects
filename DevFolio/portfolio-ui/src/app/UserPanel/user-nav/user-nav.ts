import {
  Component,
  HostListener
} from '@angular/core';

import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-user-nav',

  standalone: true,

  imports: [
    CommonModule,
    RouterModule
  ],

  templateUrl: './user-nav.html',

  styleUrls: ['./user-nav.scss']
})


export class UserNav {

  /* =====================================================
     MOBILE MENU STATE
  ===================================================== */

  isMenuOpen = false;


  /* =====================================================
     TOGGLE MOBILE MENU
  ===================================================== */

  toggleNavbar(): void {

    this.isMenuOpen = !this.isMenuOpen;

  }


  /* =====================================================
     CLOSE MOBILE MENU
  ===================================================== */

  

  /* =====================================================
     SMOOTH SCROLL
  ===================================================== */

  
scrollToSection(sectionId: string): void {
  const element = document.getElementById(sectionId);

  if (element) {
    element.scrollIntoView({
      behavior: 'smooth',
      block: 'start'
    });
  }

  this.closeNavbar();
}

closeNavbar(): void {
  this.isMenuOpen = false;
}



  /* =====================================================
     CLOSE WHEN CLICKING OUTSIDE
  ===================================================== */

  @HostListener(
    'document:click',
    ['$event']
  )

  onDocumentClick(event: MouseEvent): void {

    /*
     * Nothing to do when menu closed
     */
    if (!this.isMenuOpen) {
      return;
    }


    /*
     * Get clicked element
     */
    const target =
      event.target as HTMLElement;


    /*
     * Check if click is inside navbar
     */
    const navbar =
      target.closest('.portfolio-navbar');


    /*
     * Close if outside
     */
    if (!navbar) {

      this.closeNavbar();

    }

  }


  /* =====================================================
     CLOSE WITH ESCAPE
  ===================================================== */

  @HostListener(
    'document:keydown.escape'
  )

  onEscape(): void {

    this.closeNavbar();

  }


  /* =====================================================
     RESET MENU ON DESKTOP
  ===================================================== */

  @HostListener(
    'window:resize'
  )

  onWindowResize(): void {

    /*
     * Desktop breakpoint
     */
    if (window.innerWidth > 1024) {

      this.closeNavbar();

    }

  }

}