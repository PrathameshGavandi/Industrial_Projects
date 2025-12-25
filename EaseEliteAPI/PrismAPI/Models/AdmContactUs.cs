using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 namespace PrismAPI.Models
  {
public class AdmContactUs
  {
public int ContactUsId { get; set; }
public string FullName { get; set; }
public string Email { get; set; }
public string MobileNo { get; set; }
public string MessageText { get; set; }
public string Status { get; set; }
public string CreatedDate { get; set; }
public string CreatedBy { get; set; }
public string UpdatedDate { get; set; }
public string UpdatedBy { get; set; }
  }
}
