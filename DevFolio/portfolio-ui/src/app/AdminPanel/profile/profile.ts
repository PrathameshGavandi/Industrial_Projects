import {
  Component,
  ViewChild,
  OnInit,
  ChangeDetectorRef,
  HostListener
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { ProfileService } from '../../Services/ProfileService';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './profile.html',
  styleUrls: ['./profile.scss']
})
export class ProfileComponent implements OnInit {

  profiles: any[] = [];

  profile = {
    name: '',
    email: '',
    role: '',
    phone: '',
    bio: '',
    status: 'Active'
  };

  @ViewChild('profileForm') profileForm!: NgForm;

  constructor(
  private profileService: ProfileService,
  private cdr: ChangeDetectorRef,
  private router: Router 
  ) { }

  ngOnInit(): void {
    this.loadProfiles();
  }

  /* ===============================
     LOAD
  ================================ */
  loadProfiles() {
    this.profileService.getallProfiles().subscribe({
      next: res => {
        this.profiles = res ?? [];
        this.cdr.detectChanges();
      },
      error: () => {
        Swal.fire('Error', 'Failed to load profiles', 'error');
      }
    });
  }

  /* ===============================
     SAVE
  ================================ */
  saveProfile(form: NgForm) {
    if (form.invalid) return;

    this.profileService.saveProfile(this.profile).subscribe({
      next: () => {
        Swal.fire('Success', 'Profile saved successfully', 'success');

        this.profile = {
          name: '',
          email: '',
          role: '',
          phone: '',
          bio: '',
          status: 'Active'
        };

        form.resetForm({ status: 'Active' });
        this.loadProfiles();
      },
      error: () => {
        Swal.fire('Error', 'Profile not saved', 'error');
      }
    });
  }

  /* ===============================
     DELETE
  ================================ */
  deleteProfile(id: number) {
    Swal.fire({
      title: 'Are you sure?',
      text: 'This profile will be deleted permanently',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#ef4444',
      confirmButtonText: 'Yes, delete'
    }).then(result => {
      if (result.isConfirmed) {
        this.profileService.deleteProfile(id).subscribe({
          next: () => {
            Swal.fire('Deleted', 'Profile removed', 'success');
            this.loadProfiles();
          },
          error: () => {
            Swal.fire('Error', 'Delete failed', 'error');
          }
        });
      }
    });
  }

  /* ===============================
     🔐 ADMIN SHORTCUT
     Ctrl + Shift + P
  ================================ */
  @HostListener('document:keydown', ['$event'])
  handleAdminShortcut(event: KeyboardEvent) {
    if (event.ctrlKey && event.shiftKey && event.key.toLowerCase() === 'u') {
      event.preventDefault();

      Swal.fire({
        icon: 'info',
        title: 'User Panel',
        text: 'Redirecting to User Profile...',
        timer: 1200,
        showConfirmButton: false,
        background: '#0b1c2d',
        color: '#ffffff'
      }).then(() => {
        this.router.navigate(['/userprofile']);
      });
    }
  }
}
