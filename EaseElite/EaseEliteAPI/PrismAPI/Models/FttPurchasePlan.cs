using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 namespace PrismAPI.Models
  {
public class FttPurchasePlan
  {
public int FttPurchasePlanId { get; set; }
public FttSubscription fttSubscription { get; set; }
public int FttSubscriptionId { get; set; }
public Registration registration { get; set; }
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
