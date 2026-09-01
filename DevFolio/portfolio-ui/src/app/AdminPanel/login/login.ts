import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { RouterModule, Router } from '@angular/router';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import Swal from 'sweetalert2';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule, RouterModule],
  templateUrl: './login.html',
  styleUrls: ['./login.scss']
})
export class LoginComponent {
  username = '';
  password = '';

  constructor(
    private http: HttpClient,
    private router: Router,
    private auth: AuthService
  ) {}

  login(form?: NgForm) {
    if (!this.username || !this.password) {
      Swal.fire({
        icon: 'warning',
        title: 'Incomplete!',
        text: 'Please enter both username and password',
        timer: 2000,
        showConfirmButton: false
      });
      return;
    }

    this.http.post<boolean>('http://localhost:8080/api/login', {
      username: this.username,
      password: this.password
    }).subscribe({
      next: (res) => {
        if(res) {
          this.auth.login();
          Swal.fire({
            icon: 'success',
            title: 'Login Successful',
            showConfirmButton: false,
            timer: 1500
          }).then(() => {
            this.router.navigate(['/profile']);
          });
        } else {
          Swal.fire({
            icon: 'error',
            title: 'Login Failed',
            text: 'Invalid username or password!',
            timer: 2000,
            showConfirmButton: false
          });
        }
      },
      error: () => {
        Swal.fire({
          icon: 'error',
          title: 'Server Error',
          text: 'Cannot reach server',
          timer: 2000,
          showConfirmButton: false
        });
      }
    });
  }
}
