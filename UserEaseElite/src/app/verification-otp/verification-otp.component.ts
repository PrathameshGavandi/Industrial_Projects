import { Component } from '@angular/core';

@Component({
  selector: 'app-verification-otp',
  templateUrl: './verification-otp.component.html',
  styleUrls: ['./verification-otp.component.scss']
})
export class VerificationOtpComponent {
  verification = {
    code1: '',
    code2: '',
    code3: '',
    code4: '',
    code5: '',
    code6: '',
  };

  constructor() {}

  verifyCode(): void {
    const code = `${this.verification.code1}${this.verification.code2}${this.verification.code3}${this.verification.code4}${this.verification.code5}${this.verification.code6}`;
    // Replace the following with your verification logic
    console.log('Verification Code:', code);

    // Simulate a verification process
    // Example: this.authService.verifyCode(code).subscribe(response => { ... });
  }

  resendCode(): void {
    // Logic to resend the code
    console.log('Resending Code');
    // Example: this.authService.resendCode().subscribe(response => { ... });
  }

  autoTab(event: Event, nextElement: string): void {
    const input = event.target as HTMLInputElement;
    if (input.value.length === 1) {
      const nextInput = document.querySelector(`input[name=${nextElement}]`) as HTMLInputElement;
      if (nextInput) {
        nextInput.focus();
      }
    }
  }
}
