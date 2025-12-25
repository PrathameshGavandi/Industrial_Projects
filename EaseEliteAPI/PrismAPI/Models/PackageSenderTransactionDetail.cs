using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 namespace PrismAPI.Models
  {
public class PackageSenderTransactionDetail
  {
public int PackageSenderTansactionDetailId { get; set; }
public int RegistrationId { get; set; }
public int PackageSenderSubscriptionId { get; set; }
public string TransactionId { get; set; }
public string TransactionDate { get; set; }
public string TransactionStatus { get; set; }
public string TransactionAmount { get; set; }
public string Status { get; set; }
public string CreatedDate { get; set; }
public string CreatedBy { get; set; }
public string UpdatedDate { get; set; }
public string UpdatedBy { get; set; }
  }
}
