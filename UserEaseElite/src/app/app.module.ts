import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { UserRegistrationComponent } from './user-registration/user-registration.component';

import { CompanionDetailsComponent } from './companion-details/companion-details.component';
import { FirsttimeTravellerDetailsComponent } from './firsttime-traveller-details/firsttime-traveller-details.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { CompanionSubscriptionComponent } from './companion-subscription/companion-subscription.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { FttRequestComponent } from './ftt-request/ftt-request.component';
import { FttSubscriptionComponent } from './ftt-subscription/ftt-subscription.component';
import { LoginComponent } from './login/login.component';
// import { SubscriptionComponent } from './subscription/subscription.component';
import { VerificationOtpComponent } from './verification-otp/verification-otp.component';


import { EditComponent } from './edit/edit.component';
import { PackageSenderDetailsComponent } from './package-sender-details/package-sender-details.component';
import { CarrierDetailsComponent } from './carrier-details/carrier-details.component';
import { PaymentComponent } from './payment/payment.component';
import { FttpanelComponent } from './fttpanel/fttpanel.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { CompanionpanelComponent } from './companionpanel/companionpanel.component';
import { CarrierpanelComponent } from './carrierpanel/carrierpanel.component';
import { PackagesenderpanelComponent } from './packagesenderpanel/packagesenderpanel.component';
import { PaymentDetail3Component } from './payment-detail3/payment-detail3.component';
import { PaymentDetail2Component } from './payment-detail2/payment-detail2.component';
import { CarrierSubscriptionComponent } from './carrier-subscription/carrier-subscription.component';
import { PackageSubscriptionComponent } from './package-subscription/package-subscription.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ViewComponent } from './view/view.component';
import { CarrierviewComponent } from './carrierview/carrierview.component';
import { CompanionviewComponent } from './companionview/companionview.component';
import { PackagesenderviewComponent } from './packagesenderview/packagesenderview.component';
import { KycComponent } from './kyc/kyc.component';

@NgModule({
  declarations: [
    AppComponent,
    UserRegistrationComponent,
   
    CompanionDetailsComponent,
    FirsttimeTravellerDetailsComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    AboutusComponent,
    LoginComponent,
    ForgotPasswordComponent,
    VerificationOtpComponent,
    CompanionSubscriptionComponent,
    FeedbackComponent,
 
    FttRequestComponent,
    FttSubscriptionComponent,
   
    EditComponent,
  
    PackageSenderDetailsComponent,
    CarrierDetailsComponent,
    PaymentComponent,
    FttpanelComponent,
    ResetPasswordComponent,
    CompanionpanelComponent,
    CarrierpanelComponent,
    PackagesenderpanelComponent,
    PaymentDetail3Component,
    PaymentDetail2Component,
    CarrierSubscriptionComponent,
    PackageSubscriptionComponent,
    AdminPanelComponent,
    ViewComponent,
    CarrierviewComponent,
    CompanionviewComponent,
    PackagesenderviewComponent,
    KycComponent,



  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
