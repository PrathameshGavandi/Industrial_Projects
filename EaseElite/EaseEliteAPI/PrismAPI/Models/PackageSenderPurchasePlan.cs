using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 namespace PrismAPI.Models
  {
public class PackageSenderPurchasePlan
  {
public int PackageSenderPurchasePlanId { get; set; }
public int PackageSenderSubscriptionId { get; set; }
public int RegistrationId { get; set; }
public string OfferedFor { get; set; }
public string NextRenewalDate { get; set; }
public string Status { get; set; }
public string CreatedBy { get; set; }
public string CreatedDate { get; set; }
public string UpdatedDate { get; set; }
public string UpdatedBy { get; set; }
  }
}
