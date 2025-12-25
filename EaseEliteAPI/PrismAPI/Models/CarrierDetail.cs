using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 namespace PrismAPI.Models
  {
public class CarrierDetail
  {
public int CarrierDetailId { get; set; }
public Registration registration { get; set; }
public int RegistrationId { get; set; }
public string FlightNumber { get; set; }
public string Date { get; set; }
public string Time { get; set; }
public string From1 { get; set; }
public string To1 { get; set; }
public string LoadCapacity { get; set; }
public string Instrauction { get; set; }
public string Status { get; set; }
public string CreatedDate { get; set; }
public string CreatedBy { get; set; }
public string UpdatedDate { get; set; }
  }
}
