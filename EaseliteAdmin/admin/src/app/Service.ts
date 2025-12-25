import { Component, OnInit } from        '@angular/core';
import { Injectable } from        '@angular/core';

import { Observable} from        'rxjs';
import { HttpRequest, HttpClient, HttpHeaders } from        '@angular/common/http';
import { AdmCompSubscription,AdmFttSubscription,AdmRegistration,AdmELInfo,AdmContactUs,
    AdmRole,AdmSenderSubscription,Offer,Refferal,UserKyc,UserProfile, Loginc,Registration,Notifications,Feedback } from        './Class';
import { GlobalVariable } from './Global';
//add name of class here

@Injectable({
providedIn:        'root'
})

export class WebService {
 


    httpOptions = {
        headers: new HttpHeaders({
               'Content-Type':  'application/json',
        "Access-Control-Allow-Headers": "Content-Type",
        "Access-Control-Allow-Methods":        'GET, POST, OPTIONS, DELETE,PUT',
        "Content-Security-Policy":        'upgrade-insecure-requests' 
         })
       };
  subscribe: any;
  GetAlloffer: any;
  SaveRoleImage: any;
constructor (private http: HttpClient){  }

Loginc(Email, Password): Observable<any> {
    return this.http.get<any>(GlobalVariable.SERVICE_API_URL + "AdmRegistration/Loginc?Email=" + Email + "&Password=" + Password);
}

// SendOtp(mobile: string): Observable<any> {
//     return this.http.get<any>(GlobalVariable.SERVICE_API_URL + "LoginCode/OtpNo?Mobile=" + mobile);
//   }


  SendOTPEmail(Email){
    return this.http.get<any>(GlobalVariable.SERVICE_API_URL +"AdmRegistration/SendOTPEmail?Email="+Email,this.httpOptions);
}


//AdmCarrierSubscription
AddAdmCarrierSubscription(AdmCarrierSubscription): Observable<any> {
 return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"AdmCarrierSubscription/AddAdmCarrierSubscription",AdmCarrierSubscription, this.httpOptions);
}
GetAllAdmCarrierSubscription()  {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmCarrierSubscription/GetAllAdmCarrierSubscription", this.httpOptions);


 
}
DeleteAdmCarrierSubscription(AdmCarrierSubscriptionld  ): Observable<any> {
    return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"AdmCarrierSubscription/DeleteAdmCarrierSubscription?AdmCarrierSubscriptionld="+AdmCarrierSubscriptionld  , this.httpOptions);
}
GetAdmCarrierSubscriptionById(AdmCarrierSubscriptionld  ): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmCarrierSubscription/GetAdmCarrierSubscriptionById?AdmCarrierSubscriptionld="+AdmCarrierSubscriptionld  , this.httpOptions);


}
UpdateAdmCarrierSubscription(AdmCarrierSubscription): Observable<any> {
 return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"AdmCarrierSubscription/UpdateAdmCarrierSubscription",AdmCarrierSubscription, this.httpOptions);
}
// SaveAdmCarrierSubscriptionImage(formdata,AdmCarrierSubscriptionld  ): Observable<any> {
// const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"AdmCarrierSubscription/SaveAdmCarrierSubscriptionImage?AdmCarrierSubscriptionld  ="+AdmCarrierSubscriptionld  , formdata, null );
// return this.http.request(uploadReq);
// }
//AdmCompSubscription
AddAdmCompSubscription(AdmCompSubscription): Observable<any> {
 return this.http.post<AdmCompSubscription>( GlobalVariable.SERVICE_API_URL +"AdmCompSubscription/AddAdmCompSubscription",AdmCompSubscription, this.httpOptions);
}
GetAllAdmCompSubscription()  {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmCompSubscription/GetAllAdmCompSubscription", this.httpOptions);
}
DeleteAdmCompSubscription(AdmCompSubscriptionld ): Observable<any> {
    return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"AdmCompSubscription/DeleteAdmCompSubscription?AdmCompSubscriptionld="+AdmCompSubscriptionld , this.httpOptions);
}
GetAdmCompSubscriptionById(AdmCompSubscriptionld ): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmCompSubscription/GetAdmCompSubscriptionById?AdmCompSubscriptionld="+AdmCompSubscriptionld , this.httpOptions);
}
UpdateAdmCompSubscription(AdmCompSubscription): Observable<any> {
 return this.http.post<AdmCompSubscription>( GlobalVariable.SERVICE_API_URL +"AdmCompSubscription/UpdateAdmCompSubscription",AdmCompSubscription, this.httpOptions);
}
SaveAdmCompSubscriptionImage(formdata,AdmCompSubscriptionld ): Observable<any> {
const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"AdmCompSubscription/SaveAdmCompSubscriptionImage?AdmCompSubscriptionld ="+AdmCompSubscriptionld , formdata, null );
return this.http.request(uploadReq);
}
// //AdmFttSubscription

AddAdmFttSubscription(AdmFttSubscription): Observable<any> {
 return this.http.post<AdmFttSubscription>( GlobalVariable.SERVICE_API_URL +"AdmFttSubscription/AddAdmFttSubscription",AdmFttSubscription, this.httpOptions);
}
GetAllAdmFttSubscription()  {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmFttSubscription/GetAllAdmFttSubscription", this.httpOptions);
}
DeleteAdmFttSubscription(AdmFttSubscriptionld): Observable<any> {
    return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"AdmFttSubscription/DeleteAdmFttSubscription?AdmFttSubscriptionld="+AdmFttSubscriptionld, this.httpOptions);
}
GetAdmFttSubscriptionById(AdmFttSubscriptionld): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmFttSubscription/GetAdmFttSubscriptionById?AdmFttSubscriptionld="+AdmFttSubscriptionld, this.httpOptions);
}
UpdateAdmFttSubscription(AdmFttSubscription): Observable<any> {
 return this.http.post<AdmFttSubscription>( GlobalVariable.SERVICE_API_URL +"AdmFttSubscription/UpdateAdmFttSubscription",AdmFttSubscription, this.httpOptions);
}
SaveAdmFttSubscriptionImage(formdata,AdmFttSubscriptionld): Observable<any> {
const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"AdmFttSubscription/SaveAdmFttSubscriptionImage?AdmFttSubscriptionld="+AdmFttSubscriptionld, formdata, null );
return this.http.request(uploadReq);
}
//AdmRegistration
AddAdmRegistration(AdmRegistration): Observable<any> {
 return this.http.post<AdmRegistration>( GlobalVariable.SERVICE_API_URL +"AdmRegistration/AddAdmRegistration",AdmRegistration, this.httpOptions);
}
GetAllAdmRegistration()  {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmRegistration/GetAllAdmRegistration", this.httpOptions);
}
DeleteAdmRegistration(AdmFttSubscriptionld): Observable<any> {
    return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"AdmRegistration/DeleteAdmRegistration?AdmFttSubscriptionld="+AdmFttSubscriptionld, this.httpOptions);
}
GetAdmRegistrationById(AdmRegistrationId): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmRegistration/GetAdmRegistrationById?AdmRegistrationId="+AdmRegistrationId, this.httpOptions);
}
UpdateAdmRegistration(AdmRegistration): Observable<any> {
 return this.http.post<AdmRegistration>( GlobalVariable.SERVICE_API_URL +"AdmRegistration/UpdateAdmRegistration",AdmRegistration, this.httpOptions);
}


SaveAdmRegistrationImage(formdata,AdmFttSubscriptionld): Observable<any> {
const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"AdmRegistration/SaveAdmRegistrationImage?AdmFttSubscriptionld="+AdmFttSubscriptionld, formdata, null );
return this.http.request(uploadReq);
}





// //AdmELInfo
AddAdmELInfo(AdmELInfo): Observable<any> {
 return this.http.post<AdmELInfo>( GlobalVariable.SERVICE_API_URL +"AdmELInfo/AddAdmELInfo",AdmELInfo, this.httpOptions);
}
GetAllAdmELInfo()  {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmELInfo/GetAllAdmELInfo", this.httpOptions);
}
DeleteAdmELInfo(AdmELInfoId): Observable<any> {
    return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"AdmELInfo/DeleteAdmELInfo?AdmELInfoId="+AdmELInfoId, this.httpOptions);
}
GetAdmELInfoById(AdmELInfoId): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmELInfo/GetAdmELInfoById?AdmELInfoId="+AdmELInfoId, this.httpOptions);
}
UpdateAdmELInfo(AdmELInfo): Observable<any> {
 return this.http.post<AdmELInfo>( GlobalVariable.SERVICE_API_URL +"AdmELInfo/UpdateAdmELInfo",AdmELInfo, this.httpOptions);
}
SaveAdmElinfoImage(formdata,AdmELInfoId): Observable<any> {
const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"AdmELInfo/SaveAdmELInfoImage?AdmELInfoId="+AdmELInfoId, formdata, null );
return this.http.request(uploadReq);
}
//AdmContactUs
AddAdmContactUs(AdmContactUs): Observable<any> {
 return this.http.post<AdmContactUs>( GlobalVariable.SERVICE_API_URL +"AdmContactUs/AddAdmContactUs",AdmContactUs, this.httpOptions);
}
GetAllAdmContactUs()  {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmContactUs/GetAllAdmContactUs", this.httpOptions);
}
DeleteAdmContactUs(ContactUsId): Observable<any> {
    return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"AdmContactUs/DeleteAdmContactUs?ContactUsId="+ContactUsId, this.httpOptions);
}
GetAdmContactUsById(ContactUsId): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmContactUs/GetAdmContactUsById?ContactUsId="+ContactUsId, this.httpOptions);
}
UpdateAdmContactUs(AdmContactUs): Observable<any> {
 return this.http.post<AdmContactUs>( GlobalVariable.SERVICE_API_URL +"AdmContactUs/UpdateAdmContactUs",AdmContactUs, this.httpOptions);
}
SaveAdmContactUsImage(formdata,ContactUsId): Observable<any> {
const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"AdmContactUs/SaveAdmContactUsImage?ContactUsId="+ContactUsId, formdata, null );
return this.http.request(uploadReq);
}
//AdmRole
AddAdmRole(AdmRole): Observable<any> {
 return this.http.post<AdmRole>( GlobalVariable.SERVICE_API_URL +"AdmRole/AddAdmRole",AdmRole, this.httpOptions);
}
GetAllAdmRole()  {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmRole/GetAllAdmRole", this.httpOptions);
}
DeleteAdmRole(AdmRoleId): Observable<any> {
    return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"AdmRole/DeleteAdmRole?AdmRoleId="+AdmRoleId, this.httpOptions);
}
GetAdmRoleById(AdmRoleId): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmRole/GetAdmRoleById?AdmRoleId="+AdmRoleId, this.httpOptions);
}
UpdateAdmRole(AdmRole): Observable<any> {
 return this.http.post<AdmRole>( GlobalVariable.SERVICE_API_URL +"AdmRole/UpdateAdmRole",AdmRole, this.httpOptions);
}
SaveAdmRoleImage(formdata,AdmRoleId): Observable<any> {
const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"AdmRole/SaveAdmRoleImage?AdmRoleId="+AdmRoleId, formdata, null );
return this.http.request(uploadReq);
}
//AdmSenderSubscription
AddAdmSenderSubscription(AdmSenderSubscription): Observable<any> {
 return this.http.post<AdmSenderSubscription>( GlobalVariable.SERVICE_API_URL +"AdmSenderSubscription/AddAdmSenderSubscription",AdmSenderSubscription, this.httpOptions);
}
GetAllAdmSenderSubscription()  {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmSenderSubscription/GetAllAdmSenderSubscription", this.httpOptions);
}
DeleteAdmSenderSubscription(AdmSenderSubscriptionld ): Observable<any> {
    return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"AdmSenderSubscription/DeleteAdmSenderSubscription?AdmSenderSubscriptionld="+AdmSenderSubscriptionld , this.httpOptions);
}
GetAdmSenderSubscriptionById(AdmSenderSubscriptionld ): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"AdmSenderSubscription/GetAdmSenderSubscriptionById?AdmSenderSubscriptionld="+AdmSenderSubscriptionld , this.httpOptions);
}
UpdateAdmSenderSubscription(AdmSenderSubscription): Observable<any> {
 return this.http.post<AdmSenderSubscription>( GlobalVariable.SERVICE_API_URL +"AdmSenderSubscription/UpdateAdmSenderSubscription",AdmSenderSubscription, this.httpOptions);
}
SaveAdmSenderSubscriptionImage(formdata,AdmSenderSubscriptionld ): Observable<any> {
const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"AdmSenderSubscription/SaveAdmSenderSubscriptionImage?AdmSenderSubscriptionld ="+AdmSenderSubscriptionld , formdata, null );
return this.http.request(uploadReq);
}







//Offer
AddOffer(Offer): Observable<any> {
 return this.http.post<Offer>( GlobalVariable.SERVICE_API_URL +"Offer/AddOffer",Offer, this.httpOptions);
}
GetAllOffer()  {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Offer/GetAllOffer", this.httpOptions);
}
DeleteOffer(Id): Observable<any> {
    return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"Offer/DeleteOffer?Id="+Id, this.httpOptions);
}
GetOfferById(Id): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Offer/GetOfferById?Id="+Id, this.httpOptions);
}
UpdateOffer(Offer): Observable<any> {
 return this.http.post<Offer>( GlobalVariable.SERVICE_API_URL +"Offer/UpdateOffer",Offer, this.httpOptions);
}
SaveOfferImage(formdata,Id): Observable<any> {
const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"Offer/SaveOfferImage?Id="+Id, formdata, null );
return this.http.request(uploadReq);
}
//userprofile

//UserProfile
AddUserProfile(UserProfile): Observable<any> {
    return this.http.post<UserProfile>( GlobalVariable.SERVICE_API_URL +"UserProfile/AddUserProfile",UserProfile, this.httpOptions);
   }
   GetAllUserProfile()  {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"UserProfile/GetAllUserProfile", this.httpOptions);
   }
   DeleteUserProfile(UserProfileId): Observable<any> {
       return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"UserProfile/DeleteUserProfile?UserProfileId="+UserProfileId, this.httpOptions);
   }
   GetUserProfileById(UserProfileId): Observable<any> {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"UserProfile/GetUserProfileById?UserProfileId="+UserProfileId, this.httpOptions);
   }
   UpdateUserProfile(UserProfile): Observable<any> {
    return this.http.post<UserProfile>( GlobalVariable.SERVICE_API_URL +"UserProfile/UpdateUserProfile",UserProfile, this.httpOptions);
   }
   SaveUserProfileImage(formdata,UserProfileId): Observable<any> {
   const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"UserProfile/SaveUserProfileImage?UserProfileId="+UserProfileId, formdata, null );
   return this.http.request(uploadReq);
   }
   SaveKycImage(formdata,UserprofileId): Observable<any> {
    const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"UserProfile/SaveKycImage?UserProfileId="+UserprofileId, formdata, null );
    return this.http.request(uploadReq);
    }
//registration
AddRegistration(Registration): Observable<any> {
    return this.http.post<Registration>(GlobalVariable.SERVICE_API_URL + "Registration/AddRegistration", Registration, this.httpOptions);
}
GetAllRegistration() {
    return this.http.get<any>(GlobalVariable.SERVICE_API_URL + "Registration/GetAllRegistration", this.httpOptions);
}
GetRegistrationByEmail(Email){
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Registration/GetRegistrationByEmail?Email="+Email,this.httpOptions);
  }
  DeleteRegistration(RegistrationId): Observable<any> {
    return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"Registration/DeleteRegistration?RegistrationId="+RegistrationId,this.httpOptions);
  }
  GetRegistrationById(RegistrationId): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Registration/GetRegistrationById?RegistrationId=" +RegistrationId, this.httpOptions);
  }
//   UpdateRegistration(Registration): Observable<any> {
//     return this.http.post<Registration>( GlobalVariable.SERVICE_API_URL +"Registration/UpdateRegistration",Registration, this.httpOptions);
//   }

AddFttSubscription(FttSubscription): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"FttSubscription/AddFttSubscription",FttSubscription, this.httpOptions);
   }
   GetAllFttSubscription()  {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"FttSubscription/GetAllFttSubscription", this.httpOptions);
   }
   DeleteFttSubscription(FttSubscriptionId): Observable<any> {
       return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"FttSubscription/DeleteFttSubscription?FttSubscriptionId="+FttSubscriptionId, this.httpOptions);
   }
   GetFttSubscriptionById(FttSubscriptionId): Observable<any> {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"FttSubscription/GetFttSubscriptionById?FttSubscriptionId="+FttSubscriptionId, this.httpOptions);
   }
   UpdateFttSubscription(FttSubscription): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"FttSubscription/UpdateFttSubscription",FttSubscription, this.httpOptions);
   }
   SaveFttSubscriptionImage(formdata,FttSubscriptionId): Observable<any> {
   const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"FttSubscription/SaveFttSubscriptionImage?FttSubscriptionId="+FttSubscriptionId, formdata, null );
   return this.http.request(uploadReq);
   }


// //Refferal
// AddRefferal(Refferal): Observable<any> {
//  return this.http.post<Refferal>( GlobalVariable.SERVICE_API_URL +"Refferal/AddRefferal",Refferal, this.httpOptions);
// }
// GetAllRefferal()  {
//     return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Refferal/GetAllRefferal", this.httpOptions);
// }
// DeleteRefferal(RefferalId): Observable<any> {
//     return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"Refferal/DeleteRefferal?RefferalId="+RefferalId, this.httpOptions);
// }
// GetRefferalById(RefferalId): Observable<any> {
//     return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Refferal/GetRefferalById?RefferalId="+RefferalId, this.httpOptions);
// }
// UpdateRefferal(Refferal): Observable<any> {
//  return this.http.post<Refferal>( GlobalVariable.SERVICE_API_URL +"Refferal/UpdateRefferal",Refferal, this.httpOptions);
// }
// SaveRefferalImage(formdata,RefferalId): Observable<any> {
// const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"Refferal/SaveRefferalImage?RefferalId="+RefferalId, formdata, null );
// return this.http.request(uploadReq);
// }
// //UserKyc
// AddUserKyc(UserKyc): Observable<any> {
//  return this.http.post<UserKyc>( GlobalVariable.SERVICE_API_URL +"UserKyc/AddUserKyc",UserKyc, this.httpOptions);
// }
// GetAllUserKyc()  {
//     return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"UserKyc/GetAllUserKyc", this.httpOptions);
// }
// DeleteUserKyc(UserKycId): Observable<any> {
//     return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"UserKyc/DeleteUserKyc?UserKycId="+UserKycId, this.httpOptions);
// }
// GetUserKycById(UserKycId): Observable<any> {
//     return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"UserKyc/GetUserKycById?UserKycId="+UserKycId, this.httpOptions);
// }
// UpdateUserKyc(UserKyc): Observable<any> {
//  return this.http.post<UserKyc>( GlobalVariable.SERVICE_API_URL +"UserKyc/UpdateUserKyc",UserKyc, this.httpOptions);
// }
// SaveUserKycImage(formdata,UserKycId): Observable<any> {
// const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"UserKyc/SaveUserKycImage?UserKycId="+UserKycId, formdata, null );
// return this.http.request(uploadReq);
// }
// //UserProfile
// AddUserProfile(UserProfile): Observable<any> {
//  return this.http.post<UserProfile>( GlobalVariable.SERVICE_API_URL +"UserProfile/AddUserProfile",UserProfile, this.httpOptions);
// }
// GetAllUserProfile()  {
//     return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"UserProfile/GetAllUserProfile", this.httpOptions);
// }
// DeleteUserProfile(UserProfileId): Observable<any> {
//     return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"UserProfile/DeleteUserProfile?UserProfileId="+UserProfileId, this.httpOptions);
// }
// GetUserProfileById(UserProfileId): Observable<any> {
//     return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"UserProfile/GetUserProfileById?UserProfileId="+UserProfileId, this.httpOptions);
// }
// UpdateUserProfile(UserProfile): Observable<any> {
//  return this.http.post<UserProfile>( GlobalVariable.SERVICE_API_URL +"UserProfile/UpdateUserProfile",UserProfile, this.httpOptions);
// }
// SaveUserProfileImage(formdata,UserProfileId): Observable<any> {
// const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"UserProfile/SaveUserProfileImage?UserProfileId="+UserProfileId, formdata, null );
// return this.http.request(uploadReq);
// }


//UserRole
AddUserRole(UserRole): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"UserRole/AddUserRole",UserRole, this.httpOptions);
   }
   GetAllUserRole()  {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"UserRole/GetAllUserRole", this.httpOptions);
   }
   DeleteUserRole(UserRoleId): Observable<any> {
       return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"UserRole/DeleteUserRole?UserRoleId="+UserRoleId, this.httpOptions);
   }
   GetUserRoleById(UserRoleId): Observable<any> {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"UserRole/GetUserRoleById?UserRoleId="+UserRoleId, this.httpOptions);
   }
   UpdateUserRole(UserRole): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"UserRole/UpdateUserRole",UserRole, this.httpOptions);
   }
   SaveUserRoleImage(formdata,UserRoleId): Observable<any> {
   const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"UserRole/SaveUserRoleImage?UserRoleId="+UserRoleId, formdata, null );
   return this.http.request(uploadReq);
   }


   //ftt transactiondetails
   AddFttTransactionDetail(FttTransactionDetail): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"FttTransactionDetail/AddFttTransactionDetail",FttTransactionDetail, this.httpOptions);
   }
   GetAllFttTransactionDetail()  {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"FttTransactionDetail/GetAllFttTransactionDetail", this.httpOptions);
   }
   DeleteFttTransactionDetail(FttTransactionDetailId): Observable<any> {
       return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"FttTransactionDetail/DeleteFttTransactionDetail?FttTransactionDetailId="+FttTransactionDetailId, this.httpOptions);
   }
   GetFttTransactionDetailById(FttTransactionDetailId): Observable<any> {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"FttTransactionDetail/GetFttTransactionDetailById?FttTransactionDetailId="+FttTransactionDetailId, this.httpOptions);
   }
   UpdateFttTransactionDetail(FttTransactionDetail): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"FttTransactionDetail/UpdateFttTransactionDetail",FttTransactionDetail, this.httpOptions);
   }
   SaveFttTransactionDetailImage(formdata,FttTransactionDetailId): Observable<any> {
   const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"FttTransactionDetail/SaveFttTransactionDetailImage?FttTransactionDetailId="+FttTransactionDetailId, formdata, null );
   return this.http.request(uploadReq);
   }

   //CompanionTransactionDetail
AddCompanionTransactionDetail(CompanionTransactionDetail): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"CompanionTransactionDetail/AddCompanionTransactionDetail",CompanionTransactionDetail, this.httpOptions);
   }
   GetAllCompanionTransactionDetail()  {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"CompanionTransactionDetail/GetAllCompanionTransactionDetail", this.httpOptions);
   }
   DeleteCompanionTransactionDetail(CompanionTransactionDetailId): Observable<any> {
       return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"CompanionTransactionDetail/DeleteCompanionTransactionDetail?CompanionTransactionDetailId="+CompanionTransactionDetailId, this.httpOptions);
   }
   GetCompanionTransactionDetailById(CompanionTransactionDetailId): Observable<any> {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"CompanionTransactionDetail/GetCompanionTransactionDetailById?CompanionTransactionDetailId="+CompanionTransactionDetailId, this.httpOptions);
   }
   UpdateCompanionTransactionDetail(CompanionTransactionDetail): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"CompanionTransactionDetail/UpdateCompanionTransactionDetail",CompanionTransactionDetail, this.httpOptions);
   }
   SaveCompanionTransactionDetailImage(formdata,CompanionTransactionDetailId): Observable<any> {
   const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"CompanionTransactionDetail/SaveCompanionTransactionDetailImage?CompanionTransactionDetailId="+CompanionTransactionDetailId, formdata, null );
   return this.http.request(uploadReq);
   }
   //CarrierTransactionDetail
   AddCarrierTransactionDetail(CarrierTransactionDetail): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"CarrierTransactionDetail/AddCarrierTransactionDetail",CarrierTransactionDetail, this.httpOptions);
   }
   GetAllCarrierTransactionDetail()  {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"CarrierTransactionDetail/GetAllCarrierTransactionDetail", this.httpOptions);
   }
   DeleteCarrierTransactionDetail(CarrierTransactionDetailId): Observable<any> {
       return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"CarrierTransactionDetail/DeleteCarrierTransactionDetail?CarrierTransactionDetailId="+CarrierTransactionDetailId, this.httpOptions);
   }
   GetCarrierTransactionDetailById(CarrierTransactionDetailId): Observable<any> {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"CarrierTransactionDetail/GetCarrierTransactionDetailById?CarrierTransactionDetailId="+CarrierTransactionDetailId, this.httpOptions);
   }
   UpdateCarrierTransactionDetail(CarrierTransactionDetail): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"CarrierTransactionDetail/UpdateCarrierTransactionDetail",CarrierTransactionDetail, this.httpOptions);
   }
   SaveCarrierTransactionDetailImage(formdata,CarrierTransactionDetailId): Observable<any> {
   const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"CarrierTransactionDetail/SaveCarrierTransactionDetailImage?CarrierTransactionDetailId="+CarrierTransactionDetailId, formdata, null );
   return this.http.request(uploadReq);
   }
   //PackageSenderTransactionDetail
   AddPackageSenderTransactionDetail(PackageSenderTransactionDetail): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"PackageSenderTransactionDetail/AddPackageSenderTransactionDetail",PackageSenderTransactionDetail, this.httpOptions);
   }
   GetAllPackageSenderTransactionDetail()  {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"PackageSenderTransactionDetail/GetAllPackageSenderTransactionDetail", this.httpOptions);
   }
   DeletePackageSenderTransactionDetail(PackageSenderTansactionDetailId): Observable<any> {
       return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"PackageSenderTransactionDetail/DeletePackageSenderTransactionDetail?PackageSenderTansactionDetailId="+PackageSenderTansactionDetailId, this.httpOptions);
   }
   GetPackageSenderTransactionDetailById(PackageSenderTansactionDetailId): Observable<any> {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"PackageSenderTransactionDetail/GetPackageSenderTransactionDetailById?PackageSenderTansactionDetailId="+PackageSenderTansactionDetailId, this.httpOptions);
   }
   UpdatePackageSenderTransactionDetail(PackageSenderTransactionDetail): Observable<any> {
    return this.http.post<any>( GlobalVariable.SERVICE_API_URL +"PackageSenderTransactionDetail/UpdatePackageSenderTransactionDetail",PackageSenderTransactionDetail, this.httpOptions);
   }
   SavePackageSenderTransactionDetailImage(formdata,PackageSenderTansactionDetailId): Observable<any> {
   const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"PackageSenderTransactionDetail/SavePackageSenderTransactionDetailImage?PackageSenderTansactionDetailId="+PackageSenderTansactionDetailId, formdata, null );
   return this.http.request(uploadReq);
   }

   //Notifications
AddNotifications(Notifications): Observable<any> {
    return this.http.post<Notifications>( GlobalVariable.SERVICE_API_URL +"Notifications/AddNotifications",Notifications, this.httpOptions);
   }
   GetAllNotifications()  {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Notifications/GetAllNotifications", this.httpOptions);
   }
   DeleteNotifications(NotificationsId): Observable<any> {
       return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"Notifications/DeleteNotifications?NotificationsId="+NotificationsId, this.httpOptions);
   }
   GetNotificationsById(NotificationsId): Observable<any> {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Notifications/GetNotificationsById?NotificationsId="+NotificationsId, this.httpOptions);
   }
  

//    GetRegistrationById(RegistrationId): Observable<any> {
//     return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Registration/GetRegistrationById?RegistrationId=" +RegistrationId, this.httpOptions);
//   }

   UpdateNotifications(Notifications): Observable<any> {
    return this.http.post<Notifications>( GlobalVariable.SERVICE_API_URL +"Notifications/UpdateNotifications",Notifications, this.httpOptions);
   }

   
   //Feedback
AddFeedback(Feedback): Observable<any> {
    return this.http.post<Feedback>( GlobalVariable.SERVICE_API_URL +"Feedback/AddFeedback",Feedback, this.httpOptions);
   }
   GetAllFeedback()  {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Feedback/GetAllFeedback", this.httpOptions);
   }
   DeleteFeedback(FeedbackId): Observable<any> {
       return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"Feedback/DeleteFeedback?FeedbackId="+FeedbackId, this.httpOptions);
   }
   GetFeedbackById(FeedbackId): Observable<any> {
       return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"Feedback/GetFeedbackById?FeedbackId="+FeedbackId, this.httpOptions);
   }
   UpdateFeedback(Feedback): Observable<any> {
    return this.http.post<Feedback>( GlobalVariable.SERVICE_API_URL +"Feedback/UpdateFeedback",Feedback, this.httpOptions);
   }

   

}

