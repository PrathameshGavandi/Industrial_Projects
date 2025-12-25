using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 namespace PrismAPI.Models
  {
public class CompanionDetail
  {
public int CompanionId { get; set; }
public Registration registration { get; set; }
public int RegistrationId { get; set; }
public string FlightNumber { get; set; }
public string Date { get; set; }
public string Time { get; set; }
public string From1 { get; set; }
public string To1 { get; set; }
public string UploadTicket { get; set; }
public string CreatedDate { get; set; }
public string CreatedBy { get; set; }
public string UpdatedDate { get; set; }
public string UpdatedBy { get; set; }
  }
}
