using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 namespace PrismAPI.Models
  {
public class Refferal
  {
public int RefferalId { get; set; }
public AdmRegistration admRegistration { get; set; }
public int RegistrationId { get; set; }
public string UserReferralCode { get; set; }
public string UsedReferralCode { get; set; }
public string TotalReferred { get; set; }
public string MonthlyReferred { get; set; }
public string Status { get; set; }
public string CreatedDate { get; set; }
public string CreatedBy { get; set; }
public string UpdatedDate { get; set; }
public string UpdatedBy { get; set; }
  }
}
