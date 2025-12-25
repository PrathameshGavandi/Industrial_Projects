export class Registration {
    RegistrationId: number;
    FName: string;
    LName: string;
    Email: string;
    Password: string;
    confirmPassword:string;
    EmailStatus: string;
    OTPNo: string;
    DefaultRole: string;
    Status: string;
    CreatedBy: string;
    CreatedDate: string;
    UpdatedBy: string;
    UpdatedDate: string;
    Role: string;
    // Role: any;
}
export class FlightDetailsCompanion {
    DetailsId: number;
    name: string;
    flightNumber: number;
    date: string;
    time: string;
    from: string;
    to: string;
    ticket: string;
    CreatedBy: string;
    CreatedDate: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class FlightDetailsFirsttimeTraveller {
    DetailsId: number;
    // name: string;
    flightNumber: number;
    date: string;
    time: string;
    from: string;
    to: string;
    ticket: string;
    // Proofid: string;
    CreatedBy: string;
    CreatedDate: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class Companiondetails {
    DetailsId: number;
    // name: string;
    flightNumber: number;
    date: string;
    time: string;
    from: string;
    to: string;
    ticket: string;
    // Proofid: string;
    CreatedBy: string;
    CreatedDate: string;
    UpdatedDate: string;
    UpdatedBy: string;
}


export class PackageSenderDetails {
    // name: string;
    flightNumber: string;
    date: string;
    time: string;
    from: string;
    to: string;
    weight: number;
}
export class Carrierdetail{
    CarrierdetailId:Number;
    // name: String;
    flightNumber:String;
    date: String;
    time: String;
    from: String;
    to: String;
    kg:String;
    message:String;
    CreatedBy:String;
      CreatedDate:String;
      UpdatedBy:string;
      UpdatedDate:String;
    
  }
  export class PaymentDetail{
    PaymentId:Number;
    Name: String;
    Email:String;
    Amount: String;
    // PaymentDate: String;
   
    CreatedBy:String;
      CreatedDate:String;
      UpdatedBy:string;
      UpdatedDate:String;
  }

  export class Login {
    LoginId: number;
    Email: String;
    Password: String;
    Role: String;
}
export class FttRequest {
    Id: number;
    Name: String;
    Date: String;
    Time: String;
    Destination: String;
    CreatedBy: String;
    CreatedDate: String;
    UpdatedBy: string;
    UpdatedDate: String;
}
// export class Kyc {
//     Id: number;
//     Name: String;
//     Email: string;
//     Contact: string;
//     PanCard: string;
//     Address: string;
//     CreatedBy: String;
//     CreatedDate: String;
//     UpdatedBy: string;
//     UpdatedDate: String;

// }
export class Userprofile {
    UserProfileId: number;
    RegistrationId: number;
    Image:string;
    FirstName: String;
    LastName: string;
    Email:string;
    AlternativeEmail:string;
    ContactNumber: string;
    Address: string;
    Country:string;
    Province:string;
    City:string;
    PostalCode:string;
    Status:string;
    Passport:string;
    AddressProof:string;
    KycStatus:string;
    CreatedBy: String;
    CreatedDate: String;
    UpdatedBy: string;
    UpdatedDate: String;
   // Image: string;

}