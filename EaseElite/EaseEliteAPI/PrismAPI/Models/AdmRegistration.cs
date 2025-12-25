using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class AdmRegistration
    {
        public int AdmRegistrationId { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public string EmailStatus { get; set; }
        public string OTPNo { get; set; }
        // public string DefaultRole { get; set; }


        public string Status { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class Loginc
    {
       public int AdmRegistrationId { get; set; }
       public string Email { get; set; }
        public string Password { get; set; }
    
    // public string Role { get; set; }
    }

}