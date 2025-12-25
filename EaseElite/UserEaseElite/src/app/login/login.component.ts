import { Component } from '@angular/core';
import { Registration } from '../Class';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { WebService } from '../Service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  registration: Registration;
  submitted: boolean = false;
  passwordVisible: boolean = false;
  myRegistrationId: any;
  myresult: any;

  constructor(private router: Router, private http: HttpClient, private service: WebService) {
    this.registration = new Registration();
    this.registration.Role = '1'; // Default role option
  }

  togglePasswordVisibility() {
    this.passwordVisible = !this.passwordVisible;
  }

  onRoleChange(event: any) {
    const selectedRole = event.target.value;
    console.log("Role selected:", selectedRole);  // Debugging
    this.registration.DefaultRole = selectedRole;
  }

  OnSubmit() {
    console.log(this.registration); // Debugging: Check what role is being submitted

    this.service.Login(this.registration.Email, this.registration.Password).subscribe((result) => {
        console.log("my ID is ", result.RegistrationId);
        this.myRegistrationId = result.RegistrationId;

        if (result.RegistrationId === 0) {
            // If login fails, show an error alert
            Swal.fire({
                icon: 'error',
                title: 'Invalid Email or Password',
                text: 'Please check your login credentials and try again.',
                confirmButtonText: 'Okay'
            });
        } else {
            sessionStorage.setItem('SID', result.RegistrationId);

            this.service.GetRegistrationById(this.myRegistrationId).subscribe((result) => {
                this.myresult = result;
                console.log("Registration Detail", result);

                if (this.myresult && this.myresult) {
                    console.log("Selected Role:", this.registration.DefaultRole);
                    // console.log("Default Role from backend:", this.myresult.DefaultRole);

                    if (this.registration.DefaultRole === this.myresult.DefaultRole) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Login successful!',
                            text: 'You will be redirected shortly.',
                            timer: 2000,
                            showConfirmButton: false
                        }).then(() => {
                            switch (this.myresult.DefaultRole) {
                                case "1":
                                    this.router.navigate(['/fttpanel']);
                                    break;
                                case "2":
                                    this.router.navigate(['/companionpanel']);
                                    break;
                                case "3":
                                    this.router.navigate(['/carrierpanel']);
                                    break;
                                case "4":
                                    this.router.navigate(['/packagesenderrpanel']);
                                    break;
                                default:
                                    console.error("Invalid role");
                                    break;
                            }
                        });
                    } else {
                      
                    }
                } else {
                    console.error("No DefaultRole found in the response.");
                }
            }, (error) => {
                console.error("Error fetching registration details:", error);
            });
        }
    }, (error) => {
        console.error("Login error:", error);
        Swal.fire({
            icon: 'error',
            title: 'Login Failed',
            text: 'There was an issue with the login. Please try again later.',
            confirmButtonText: 'Okay'
        });
    });

    this.submitted = true;
  }
}
