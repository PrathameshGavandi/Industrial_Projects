using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 namespace PrismAPI.Models
  {
public class UserKyc
  {
public int UserKycId { get; set; }
public UserProfile userProfile { get; set; }
public int UserProfileId { get; set; }
public string Passport { get; set; }
public string AddressProof { get; set; }
public string KycStatus { get; set; }
public string CreatedDate { get; set; }
public string CreatedBy { get; set; }
public string UpdatedDate { get; set; }
public string UpdatedBy { get; set; }
  }
}
