export class AdmCarrierSubscription {
    AdmCarrierSubscriptionld: number;
    Title: string;
    SubTitle: string;
    Description: string;
    Price: string;
    PlanPeriod: string;
    Status: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;

}
export class AdmCompSubscription {
    AdmCompSubscriptionld: number;
    Title: string;
    SubTitle: string;
    Description: string;
    Price: string;
    PlanPeriod: string;
    Status: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class AdmFttSubscription {
    AdmFttSubscriptionld: number;
    Title: string;
    SubTitle: string;
    Description: string;
    Price: string;
    PlanPeriod: string;
    Status: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class AdmRegistration {
    AdmRegistrationId: number;

    Email: string;
    Password: string;
    EmailStatus: string;
    OTPNo: string;
    DefaultRole: number;
    RememberMe: string;
    Status: string;
    CreatedBy: string;
    CreatedDate: string;
    UpdatedBy: string;
    UpdatedDate: string;

}
export class AdmELInfo {
    AdmELInfoId: number;
    Address: string;
    Email: string;
    Contact: string;
    SiteName: string;
    WebsiteLink: string;
    Logo: string;
    Status: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class AdmContactUs {
    ContactUsId: number;
    FullName: string;
    Email: string;
    MobileNo: string;
    MessageText: string;
    Status: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class AdmRole {
    AdmRoleId: number;
    Title: string;
    Description: string;
    Status: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class AdmSenderSubscription {
    AdmSenderSubscriptionld: number;
    Title: string;
    SubTitle: string;
    Description: string;
    Price: string;
    PlanPeriod: string;
    Status: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class Offer {
    Id: number;
    Title: string;
    SubTitle: string;
    Description: string;
    DiscountInPercent: string;
    Status: string;
    Image: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class Refferal {
    RefferalId: number;
    admRegistration: AdmRegistration
    RegistrationId: number;
    UserReferralCode: string;
    UsedReferralCode: string;
    TotalReferred: string;
    MonthlyReferred: string;
    Status: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class UserKyc {
    UserKycId: number;
    userProfile: UserProfile
    UserProfileId: number;
    Passport: string;
    AddressProof: string;
    KycStatus: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
// export class UserProfile{
// UserProfileId: number;
// admRegistration: AdmRegistration
// RegistrationId: number;
// AlternativeEmail: string;
// Address: string;
// Country: string;
// Province: string;
// City: string;
// PostalCode: string;
// Status: string;
// Passport: string;
// AddressProof: string;
// KycStatus: string;
// CreatedDate: string;
// CreatedBy: string;
// UpdatedDate: string;
// UpdatedBy: string;
// }

export class Loginc {
    LoginId: number;
    Email: String;
    Password: String;
    RememberMe: String;
    CreatedBy: String;
    CreatedDate: String;
    UpdatedBy: string;
    UpdatedDate: String;
}

export class Registration {
    RegistrationId: number;
    FName: string;
    LName: string;
    Email: string;
    Password: string;
    confirmPassword: string;
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

export class UserProfile {
    UserProfileId: number;
    registration: Registration
    RegistrationId: number;
    ContactNumber: string;
    Image: string;
    AlternativeEmail: string;
    Address: string;
    Country: string;
    Province: string;
    City: string;
    PostalCode: string;
    Status: string;
    Passport: string;
    AddressProof: string;
    KycStatus: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}








export class TravelBooking {
    TravelBookingId: number;
    TravelId: number;
    VendorId: number;
    UserId: number;
    RegistrationId: number;
    NoOfSets: string;
    TravelDate: string;
    TotalPrice: string;
    Status: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
}

export class UserRole {
    UserRoleId: number;
    RoleId: number;
    RegistrationId: number;
    Status: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
}
export class Notifications{
    NotificationsId: number;
    Message: string;
    Status: string;
    Status1: string;
    CreatedDate: string;
    CreatedBy: string;
    UpdatedDate: string;
    UpdatedBy: string;
    }

    export class Feedback{
        FeedbackId: number;
        registration: Registration
        RegistrationId: number;
        Description: string;
        CreatedDate: string;
        CreatedBy: string;
        UpdatedDate: string;
        UpdatedBy: string;
        
        }
    

