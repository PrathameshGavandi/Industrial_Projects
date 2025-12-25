using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PrismAPI.Models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public Registration registration { get; set; }
        public int RegistrationId { get; set; }
        public string ContactNumber { get; set; }
        public string Image { get; set; }
        public string AlternativeEmail { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Status { get; set; }
        public string Passport { get; set; }
        public string AddressProof { get; set; }
        public string KycStatus { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }

    
}