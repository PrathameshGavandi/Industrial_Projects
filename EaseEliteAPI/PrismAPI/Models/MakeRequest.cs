using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 namespace PrismAPI.Models
  {
public class MakeRequest
  {
public int MakeRequestId { get; set; }
public Registration registration { get; set; }
public int RegistrationId { get; set; }
public int TicketId { get; set; }
public string Status { get; set; }
public string CompAgree { get; set; }
public string FttAgree { get; set; }
public string TicketStatus { get; set; }
public string Feedback { get; set; }
public string Txt { get; set; }
public string CreatedDate { get; set; }
public string CreatedBy { get; set; }
public string UpdatedDate { get; set; }
public string UpdatedBy { get; set; }
  }
}
