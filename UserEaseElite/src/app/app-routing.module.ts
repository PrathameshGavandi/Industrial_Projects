import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { CompanionDetailsComponent } from './companion-details/companion-details.component';
import { FirsttimeTravellerDetailsComponent } from './firsttime-traveller-details/firsttime-traveller-details.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AboutusComponent } from './aboutus/aboutus.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { CompanionSubscriptionComponent } from './companion-subscription/companion-subscription.component';
import { FeedbackComponent } from './feedback/feedback.component';
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
import { PaymentDetailComponent } from './payment-detail/payment-detail.component';
import { CarrierpanelComponent } from './carrierpanel/carrierpanel.component';
import { PackagesenderpanelComponent } from './packagesenderpanel/packagesenderpanel.component';
import { CarrierSubscriptionComponent } from './carrier-subscription/carrier-subscription.component';
import { PackageSubscriptionComponent } from './package-subscription/package-subscription.component';
import { PaymentDetail2Component } from './payment-detail2/payment-detail2.component';
import { PaymentDetail3Component } from './payment-detail3/payment-detail3.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { ViewComponent } from './view/view.component';
import { CarrierviewComponent } from './carrierview/carrierview.component';
import { CompanionviewComponent } from './companionview/companionview.component';
import { PackagesenderviewComponent } from './packagesenderview/packagesenderview.component';
import { KycComponent } from './kyc/kyc.component';





const routes: Routes = [

  {path:'userregistration', component:UserRegistrationComponent},
  {path:'companiondetails', component:CompanionDetailsComponent},
  {path:'fttdetails', component:FirsttimeTravellerDetailsComponent},
  {path:'home', component:HomeComponent},
  {path:'header', component:HeaderComponent},
  {path:'footer', component:FooterComponent},
  {path:'aboutus', component:AboutusComponent},
  {path:'packagesenderdetails', component:PackageSenderDetailsComponent},
  {path:'fttpanel', component:FttpanelComponent},
  {path:'companionpanel', component:CompanionpanelComponent},
  {path:'carrierpanel', component:CarrierpanelComponent},
  {path:'packagesenderdetails', component:PackagesenderpanelComponent},


  {path:'login', component:LoginComponent},
  {path:'forgotpassword', component:ForgotPasswordComponent},
  {path:'verificationotp', component:VerificationOtpComponent},
  
  {path:'feedback', component:  FeedbackComponent},
  // {path:'subscription', component: SubscriptionComponent},
  {path:'fttrequest', component: FttRequestComponent},
  {path:'fttsubscription', component: FttSubscriptionComponent},
  {path:'companionsubscription', component: CompanionSubscriptionComponent},
  {path:'carriersubscription', component: CarrierSubscriptionComponent},
  {path:'packagesendersubscription', component: PackageSubscriptionComponent},
  {path:'carrierdetails', component:CarrierDetailsComponent},
  {path:'payment', component:PaymentComponent},
  {path:'resetpassword', component:ResetPasswordComponent},
  {path:'paymentdetail', component:PaymentDetailComponent},
  {path:'paymentdetail2', component:PaymentDetail2Component},
  {path:'paymentdetail3', component:PaymentDetail3Component},
  {path:'packagesenderpanel', component:PackagesenderpanelComponent},
  {path:'adminpanel', component:AdminPanelComponent},
  {path:'view', component:ViewComponent},
  {path:'carrierview', component:CarrierviewComponent},
  {path:'companionview', component:CompanionviewComponent},
  {path:'packagesenderview', component:PackagesenderviewComponent},
  


  {path:'edit', component:EditComponent},
  {path:'kyc', component:KycComponent},
  
  

  { path: '', redirectTo: '/login', pathMatch: 'full' },
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
