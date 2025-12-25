import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { HeaderComponent } from './header/header.component';
import { RegistrationComponent } from './registration/registration.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { FttlistComponent } from './fttlist/fttlist.component';
import { CarrierListComponent } from './carrier-list/carrier-list.component';
import { CompanionListComponent } from './companion-list/companion-list.component';
import { PackagesenderListComponent } from './packagesender-list/packagesender-list.component';
import { ContactComponent } from './contact/contact.component';
import { KycComponent } from './kyc/kyc.component';
import { OffersComponent } from './offers/offers.component';
import { AdmRoleComponent } from './adm-role/adm-role.component';
import { AddfttpComponent } from './addfttp/addfttp.component';
import { AddCompanionComponent } from './add-companion/add-companion.component';
import { AddcarrierComponent } from './addcarrier/addcarrier.component';
import { AddpackageComponent } from './addpackage/addpackage.component';
import { SenderlistComponent } from './senderlist/senderlist.component';
import { AdmELinfoComponent } from './adm-elinfo/adm-elinfo.component';
import { OfferlistComponent } from './offerlist/offerlist.component';
import { RoleListComponent } from './role-list/role-list.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { VerificationOtpComponent } from './verification-otp/verification-otp.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ElinfoListComponent } from './elinfo-list/elinfo-list.component';
import { UpdateElinfoComponent } from './update-elinfo/update-elinfo.component';
import { UpdatecarrierComponent } from './updatecarrier/updatecarrier.component';
import { UpdatecompanionComponent } from './updatecompanion/updatecompanion.component';
import { UpdatefttComponent } from './updateftt/updateftt.component';
import { UpdatepackageComponent } from './updatepackage/updatepackage.component';
import { ViewElinfoComponent } from './view-elinfo/view-elinfo.component';
import { ViewcarrierComponent } from './viewcarrier/viewcarrier.component';
import { ViewcompanionComponent } from './viewcompanion/viewcompanion.component';
import { ViewfttComponent } from './viewftt/viewftt.component';
import { ViewpackageComponent } from './viewpackage/viewpackage.component';
import { RoleupdateComponent } from './roleupdate/roleupdate.component';
import { UpdateofferComponent } from './updateoffer/updateoffer.component';
import { AuthGuard } from './authguard.service';
import { UserFttComponent } from './UserList/user-ftt/user-ftt.component';
import { UserCompanionComponent } from './UserList/user-companion/user-companion.component';
import { UserCarrierComponent } from './UserList/user-carrier/user-carrier.component';
import { UserPackageSenderComponent } from './UserList/user-package-sender/user-package-sender.component';
import { FttTransactionComponent } from './TransactionDetails/ftt-transaction/ftt-transaction.component';
import { CompanionTransactionComponent } from './TransactionDetails/companion-transaction/companion-transaction.component';
import { CarrierTransactionComponent } from './TransactionDetails/carrier-transaction/carrier-transaction.component';
import { PackageSenderTransactionComponent } from './TransactionDetails/package-sender-transaction/package-sender-transaction.component';
import { UserNotificationsComponent } from './user-notifications/user-notifications.component';
import { NotificationsListComponent } from './notifications-list/notifications-list.component';
import { UpdateNotificationsComponent } from './update-notifications/update-notifications.component';
import { FeedbackListComponent } from './feedback-list/feedback-list.component';



const routes: Routes = [
  {path:'login', component:LoginComponent},
  {path:'userregistration', component:UserRegistrationComponent},
  {path:'adminpanel', component:AdminPanelComponent,canActivate: [AuthGuard]},
  {path:'header', component:HeaderComponent},
  {path:'registration', component:RegistrationComponent},
  {path:'userprofile', component:UserProfileComponent},
    {path:'fttlist', component:FttlistComponent},
    {path:'companionlist', component:CompanionListComponent},
    {path:'carrierlist', component:CarrierListComponent},
    { path:'packagesenderlist', component: PackagesenderListComponent},
    {path:'contact', component:ContactComponent},
    {path:'kyc', component:KycComponent},
    {path:'offers', component:OffersComponent},
    {path:'admrole', component:AdmRoleComponent},
    {path:'addfttp', component:AddfttpComponent},
    {path:'addcompanion', component:AddCompanionComponent},
    {path:'addcarrier', component:AddcarrierComponent},
    {path:'addpackage', component:AddpackageComponent},
    {path:'senderlist', component:SenderlistComponent},
    {path:'admelinfo', component:AdmELinfoComponent},
    {path:'offerlist', component:OfferlistComponent},
    {path:'forgotpassword', component:ForgotPasswordComponent},
     {path:'rolelist', component:RoleListComponent},


    //  ,canActivate: [AuthGuard]
   
    {path:'verificationotp/:AdmRegistrationId', component:VerificationOtpComponent},
    {path:'resetpassword/:AdmRegistrationId', component:ResetPasswordComponent},
    //  {path:'admrolelist', component:RoleListComponent},
    {path:'dashboard', component:DashboardComponent},
    {path:'adminfo', component:AdmELinfoComponent},
    {path:'elinfolist', component:ElinfoListComponent},
    {path:'updateelinfo/:AdmELInfoId', component:UpdateElinfoComponent},
    {path:'viewelinfo/:AdmELInfoId', component:ViewElinfoComponent},
    {path:'updateftt/:AdmFttSubscriptionld', component:UpdatefttComponent},
    {path:'viewftt/:AdmFttSubscriptionld', component:ViewfttComponent},
    {path:'updatecompanion/:AdmCompSubscriptionld', component:UpdatecompanionComponent},
    {path:'viewcompanion/:AdmCompSubscriptionld', component:ViewcompanionComponent},
    {path:'updatecarrier/:AdmCarrierSubscriptionld', component:UpdatecarrierComponent},
    {path:'viewcarrier/:AdmCarrierSubscriptionld', component:ViewcarrierComponent},
    {path:'updatepackage/:AdmSenderSubscriptionld', component:UpdatepackageComponent},
    {path:'viewpackage/:AdmSenderSubscriptionld', component:ViewpackageComponent},
    {path:'roleupdate/:AdmRoleId', component:RoleupdateComponent},
    {path:'updateoffer/:Id', component:UpdateofferComponent},
    // {path:'viewoffer/:ld', component:ViewpackageComponent},
    {path:'resetpassword', component:ResetPasswordComponent},
    {path:'forgotpassword', component:ForgotPasswordComponent},
    {path:'userftt', component:UserFttComponent},
    {path:'usercompanion', component:UserCompanionComponent},
    {path:'usercarrier', component:UserCarrierComponent},
    {path:'userpackagesender', component:UserPackageSenderComponent},

    {path:'ftttransaction', component:FttTransactionComponent},
    {path:'companiontransaction', component:CompanionTransactionComponent},
    {path:'carriertransaction', component:CarrierTransactionComponent},
    {path:'packagesendertransaction', component:PackageSenderTransactionComponent},
  
    {path:'usernotifications', component:UserNotificationsComponent},
    {path:'notificationslist', component:NotificationsListComponent},
    {path:'updatenotifications/:NotificationsId  ', component:UpdateNotificationsComponent},
    {path:'feedbacklist', component:FeedbackListComponent},
  

    




  { path: '', redirectTo: '/login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  // imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
