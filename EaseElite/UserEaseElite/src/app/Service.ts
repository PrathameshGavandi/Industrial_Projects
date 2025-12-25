import { Component, OnInit } from        '@angular/core';
import { Injectable } from        '@angular/core';
import { HttpRequest, HttpClient } from        '@angular/common/http';
import { Observable} from        'rxjs';
import { HttpHeaders } from        '@angular/common/http';

//add name of class here
// import { GlobalVariable } from        './Global';
import { Login,Registration, Userprofile } from './Class';
import { GlobalVariable } from './Global';
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
constructor (private http: HttpClient){  }




  
Login(Email, Password): Observable<any> {
    return this.http.get<Login>(GlobalVariable.SERVICE_API_URL + "Registration/Login?Email=" + Email + "&Password=" + Password);
}
SendOTPEmail(Email){
  return this.http.get<any>(GlobalVariable.SERVICE_API_URL +"Registration/SendOTPEmail?Email={Email}"+Email,this.httpOptions);
}
// SendOtp(mobile: string): Observable<any> {
//   return this.http.get<any>(GlobalVariable.SERVICE_API_URL + "LoginCode/OtpNo?Mobile=" + mobile);
// }
//Registration
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
  UpdateRegistration(Registration): Observable<any> {
    return this.http.post<Registration>( GlobalVariable.SERVICE_API_URL +"Registration/UpdateRegistration",Registration, this.httpOptions);
  } 


//UserProfile
AddUserProfile(UserProfile): Observable<any> {
  return this.http.post<Userprofile>(GlobalVariable.SERVICE_API_URL + "UserProfile/AddUserProfile",UserProfile, this.httpOptions);
}
UpdateUserProfile(Userprofile): Observable<any> {
  return this.http.post<Userprofile>( GlobalVariable.SERVICE_API_URL +"UserProfile/UpdateUserProfile",Userprofile, this.httpOptions);
} 
GetAllUserProfile() {
  return this.http.get<any>(GlobalVariable.SERVICE_API_URL + "UserProfile/GetAllUserProfile", this.httpOptions);
}
DeleteUserProfile(UserProfileId): Observable<any> {
  return this.http.delete<any>( GlobalVariable.SERVICE_API_URL +"UserProfile/DeleteUserProfile?UserProfileId="+UserProfileId,this.httpOptions);
}
SaveUserProfileImage(formdata,UserprofileId): Observable<any> {
  const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"Userprofile/SaveUserprofileImage?Userprofileld="+UserprofileId, formdata, null );
  return this.http.request(uploadReq);
  }
  SaveKycImage(formdata,UserprofileId): Observable<any> {
    const uploadReq = new  HttpRequest('Post',GlobalVariable.SERVICE_API_URL +"UserProfile/SaveKycImage?UserProfileId="+UserprofileId, formdata, null );
    return this.http.request(uploadReq);
    }
  GetUserprofileById(RegistrationId): Observable<any> {
    return this.http.get<any>( GlobalVariable.SERVICE_API_URL +"UserProfile/GetUserProfileById?UserProfileId=" +RegistrationId, this.httpOptions);
  }
}
