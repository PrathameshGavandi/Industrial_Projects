import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { HeaderComponent } from './header/header.component';
import { RegistrationComponent } from './registration/registration.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { FttlistComponent } from './fttlist/fttlist.component';
import { CompanionListComponent } from './companion-list/companion-list.component';
import { CarrierListComponent } from './carrier-list/carrier-list.component';
import { PackagesenderListComponent } from './packagesender-list/packagesender-list.component';
import { ContactComponent } from './contact/contact.component';
import { KycComponent } from './kyc/kyc.component';
import { OffersComponent } from './offers/offers.component';
import { AdmRoleComponent } from './adm-role/adm-role.component';
import { AddfttpComponent } from './addfttp/addfttp.component';
import { ReferredComponent } from './referred/referred.component';
import { AddCompanionComponent } from './add-companion/add-companion.component';
import { AddcarrierComponent } from './addcarrier/addcarrier.component';
import { AddpackageComponent } from './addpackage/addpackage.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { SenderlistComponent } from './senderlist/senderlist.component';
import { AdmELinfoComponent } from './adm-elinfo/adm-elinfo.component';
import { OfferlistComponent } from './offerlist/offerlist.component';
import { RoleListComponent } from './role-list/role-list.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { VerificationOtpComponent } from './verification-otp/verification-otp.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
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
import { AddRoleComponent } from './AdmRoleMaster/add-role/add-role.component';
import { UserFttComponent } from './UserList/user-ftt/user-ftt.component';
import { UserCarrierComponent } from './UserList/user-carrier/user-carrier.component';
import { UserPackageSenderComponent } from './UserList/user-package-sender/user-package-sender.component';
import { UserCompanionComponent } from './UserList/user-companion/user-companion.component';
import { FttTransactionComponent } from './TransactionDetails/ftt-transaction/ftt-transaction.component';
import { CompanionTransactionComponent } from './TransactionDetails/companion-transaction/companion-transaction.component';
import { CarrierTransactionComponent } from './TransactionDetails/carrier-transaction/carrier-transaction.component';
import { PackageSenderTransactionComponent } from './TransactionDetails/package-sender-transaction/package-sender-transaction.component';
import { UserNotificationsComponent } from './user-notifications/user-notifications.component';
import { NotificationsListComponent } from './notifications-list/notifications-list.component';
import { UpdateNotificationsComponent } from './update-notifications/update-notifications.component';
import { FeedbackListComponent } from './feedback-list/feedback-list.component';





@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    UserRegistrationComponent,
    AdminPanelComponent,
    HeaderComponent,
    RegistrationComponent,
    UserProfileComponent,
    FttlistComponent,
    CompanionListComponent,
    CarrierListComponent,
    PackagesenderListComponent,
    ContactComponent,
    KycComponent,
    OffersComponent,
    AdmRoleComponent,
    AddfttpComponent,
    ReferredComponent,
    AddCompanionComponent,
    AddcarrierComponent,
    AddpackageComponent,
    SenderlistComponent,
    AdmELinfoComponent,
    OfferlistComponent,
    RoleListComponent,
    VerificationOtpComponent,
    ResetPasswordComponent,
    ForgotPasswordComponent,
    DashboardComponent,
    AdmELinfoComponent,
    ElinfoListComponent,
    UpdateElinfoComponent,
    ViewElinfoComponent,
    ViewfttComponent,
    UpdatefttComponent,
    UpdatecompanionComponent,
    ViewcompanionComponent,
    UpdatecarrierComponent,
    ViewcarrierComponent,
    UpdatepackageComponent,
    ViewpackageComponent,
    RoleupdateComponent,
    UpdateofferComponent,
    AddRoleComponent,
    ForgotPasswordComponent,
    VerificationOtpComponent,
    ResetPasswordComponent,
    UserFttComponent,
    UserCarrierComponent,
    UserPackageSenderComponent,
    UserCompanionComponent,
    FttTransactionComponent,
    CompanionTransactionComponent,
    CarrierTransactionComponent,
    PackageSenderTransactionComponent,
    UserNotificationsComponent,
    NotificationsListComponent,
    UpdateNotificationsComponent,
    FeedbackListComponent,
 
   
 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,

    BrowserAnimationsModule,  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
