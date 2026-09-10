import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProfileService } from '../../Services/ProfileService';

@Component({
  selector: 'app-user-profile',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-profile.html',
  styleUrls: ['./user-profile.scss']
})
export class UserProfileComponent implements OnInit {

  /* ==========================================
     PROFILE DATA
  ========================================== */
  profile: any = {
    name: 'Your Name',
    title: 'Full Stack Developer',
    email: '',
    phone: '',
    location: '',
    about: '',
    profileImage: '',
    github: '',
    linkedin: '',
    bio: '' /* bio property ॲड केली आहे */
  };

  isLoading = true;

  constructor(
    private profileService: ProfileService,
    private cdr: ChangeDetectorRef
  ) {}

  /* ==========================================
     INIT
  ========================================== */
  ngOnInit(): void {
    /*
     * API starts immediately when
     * UserProfileComponent is created.
     *
     * It does NOT depend on parent loader.
     */
    this.loadProfile();
  }

  /* ==========================================
     LOAD PROFILE
  ========================================== */
  loadProfile(): void {
    this.isLoading = true;

    this.profileService.getallProfiles().subscribe({
      next: (res: any[]) => {
        console.log('USER PROFILE → API RESPONSE:', res);

        /*
         * If API returns an array,
         * use the first profile.
         */
        if (res && res.length > 0) {
          this.profile = {
            ...this.profile,
            ...res[0]
          };
        }

        this.isLoading = false;

        /*
         * Immediately update UI.
         */
        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error('USER PROFILE → API ERROR:', error);

        /*
         * Keep default profile data
         * if API fails.
         */
        this.isLoading = false;
        this.cdr.detectChanges();
      }
    });
  }

  /* ==========================================
     मिसिंग फंक्शन्स (ज्यामुळे एरर येत होता)
  ========================================== */

  // १. ईमेलवर क्लिक केल्यावर मेल बॉक्स उघडण्यासाठी फंक्शन
  openMail(email: string): void {
    if (email) {
      window.location.href = `mailto:${email}`;
    }
  }

  // २. बायोमधील मजकूर पॉईंट्समध्ये (Array) रुपांतरित करण्यासाठी फंक्शन
  getBioPoints(bio: string): string[] {
    if (!bio) return [];
    // जर बायोमध्ये फुलस्टॉप (.) असेल तर त्यानुसार त्याचे तुकडे पाडून लिस्ट बनवेल
    return bio.split('.').map(point => point.trim()).filter(point => point.length > 0);
  }
}
