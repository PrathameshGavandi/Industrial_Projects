using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PrismAPI.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public Registration registration { get; set; }
        public int RegistrationId { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

    }
}
