import { Component, ViewChild, ElementRef } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

declare var bootstrap: any;

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './nav.html',
  styleUrls: ['./nav.scss']
})
export class NavComponent {

  @ViewChild('adminNavbar') adminNavbar!: ElementRef;

  closeNavbar() {
    if (!this.adminNavbar) return;

    const collapse =
      bootstrap.Collapse.getInstance(this.adminNavbar.nativeElement)
      || new bootstrap.Collapse(this.adminNavbar.nativeElement);

    collapse.hide();
  }
}
