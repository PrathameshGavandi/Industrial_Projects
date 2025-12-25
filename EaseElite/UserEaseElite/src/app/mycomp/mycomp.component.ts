import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mycomp',
  templateUrl: './mycomp.component.html',
  styleUrls: ['./mycomp.component.scss']
})
export class MycompComponent {

  constructor(private router: Router) { }

  // KYC form model object
  kyc: any = {
    Name: '',
    Email: '',
    Contact: '',
    PanCard: null,
    Address: null
  };

  // Method to handle form submission
  onSubmit(): void {
    // If form is valid, process form submission
    if (this.kyc.Name) {
      console.log('Form Submitted', this.kyc);
      // Here you can add the logic to submit the form to a backend API or process the data
    } else {
      console.error('Form is incomplete or invalid');
    }
  }

  // Additional method to handle file uploads (if needed for PanCard/Address)
  onFileChange(event: any, field: string): void {
    const file = event.target.files[0];  // Get the file from the input
    if (file) {
      if (field === 'PanCard') {
        this.kyc.PanCard = file;  // Assign the selected file to PanCard field
      } else if (field === 'Address') {
        this.kyc.Address = file;  // Assign the selected file to Address field
      }
    }
  }

  logout() {
    // Clear user session or perform logout logic here

    // Navigate to home page
    this.router.navigate(['/home']);
  }
}