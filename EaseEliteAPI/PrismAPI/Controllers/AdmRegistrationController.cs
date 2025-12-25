using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Web.Http.Cors;
using PrismAPI.DAL;
using PrismAPI.Models;

using MailKit.Net.Smtp;
using MimeKit;

namespace PrismAPI.Controllers
{
    public class AdmRegistrationController : ApiController
    {
        // GET: AdmRegistration
        public Logger Log = null;
        public AdmRegistrationController()
        {
            Log = Logger.GetLogger();
        }
        AdmRegistrationDAL AdmRegistrationDAL = new AdmRegistrationDAL();

        [HttpGet]
        [ActionName("GetAllAdmRegistration")]

        public List<AdmRegistration> GetAllAdmRegistration()
        {
            Log.writeMessage("AdmRegistrationController GetAllAdmRegistration Start");
            List<AdmRegistration> list = null;
            try
            {
                list = AdmRegistrationDAL.GetAllAdmRegistration();
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdmRegistrationController GetAllAdmRegistration Error " + ex.Message);
            }
            Log.writeMessage("AdmRegistrationController GetAllAdmRegistration End");
            return list;

        }

        [HttpPost]
        [ActionName("AddAdmRegistration")]
        public IHttpActionResult AddAdmRegistration(AdmRegistration AdmRegistration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                AdmRegistration.CreatedBy = "Admin";
                AdmRegistration.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                AdmRegistration.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                AdmRegistration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = AdmRegistrationDAL.AddAdmRegistration(AdmRegistration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("AdmRegistrationController AddAdmRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateAdmRegistration")]
        public IHttpActionResult UpdateAdmRegistration(AdmRegistration AdmRegistration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                AdmRegistration.CreatedBy = "Admin";
                AdmRegistration.UpdatedBy = "Admin";
                AdmRegistration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = AdmRegistrationDAL.UpdateAdmRegistration(AdmRegistration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("AdmRegistrationController AddAdmRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetAdmRegistrationById")]
        public AdmRegistration GetAdmRegistrationById(int AdmRegistrationId)
        {
            Log.writeMessage("AdmRegistrationController GetAdmRegistrationById Start");
            AdmRegistration AdmRegistration = null;
            try
            {
                AdmRegistration = AdmRegistrationDAL.GetAdmRegistrationById(AdmRegistrationId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdmRegistrationController GetAdmRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("AdmRegistrationController GetAdmRegistrationById End");
            return AdmRegistration;
        }

        [HttpGet]
        [ActionName("GetAdmRegistrationByEmail")]
        public AdmRegistration GetAdmRegistrationByEmail(string Email)
        {
            Log.writeMessage("AdmRegistrationController GetAdmRegistrationByEmail Start");
            AdmRegistration AdmRegistration = null;
            try
            {
                AdmRegistration = AdmRegistrationDAL.GetAdmRegistrationByEmail(Email);
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdmRegistrationController GetAdmRegistrationByEmail Error " + ex.Message);
            }
            Log.writeMessage("AdmRegistrationController GetAdmRegistrationByEmail End");
            return AdmRegistration;
        }

        [HttpGet]
        [ActionName("Loginc")]
        public Loginc Loginc(string Email, string Password)
        {
            Log.writeMessage("AdmRegistrationController Loginc Start");
           Loginc user = null;
           try
           {
               user = AdmRegistrationDAL.Loginc(Email, Password);
           }
           catch (Exception ex)
            {
                Log.writeMessage("AdmRegistrationController GetAdmRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("AdmRegistrationController Loginc End");
            return user;
        }




        [HttpGet]
        [ActionName("SendOTPEmail")]
        public async Task<IHttpActionResult>SendOTPEmail(string Email)
        {
            try
            {
                // Configure SMTP client
                using (var smtpClient = new SmtpClient())
                {
                    await smtpClient.ConnectAsync("smtp.gmail.com", 465, true);

                    // Authenticate with Gmail
                    await smtpClient.AuthenticateAsync("testsumit19@gmail.com", "dyld bnbm auks eopc");

                    // Generate a 6-digit random OTP
                    Random random = new Random();
                    int otpValue = random.Next(100000, 999999);
                    string otp = otpValue.ToString();

                    // Create and send email message
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("EaseElite", "info@easeelite.com"));
                    message.To.Add(new MailboxAddress(Email, Email)); // Use the email address for both display name and email
                    message.Subject = "OTP Verification From EaseElite";

                    message.Body = new TextPart("plain")
                    {
                        Text = "Thank you for signing up with EaseElite To complete your email verification, please use the One-Time Password (OTP) below: " + otp
                    };

                    // Send email asynchronously
                    await smtpClient.SendAsync(message);
                    await smtpClient.DisconnectAsync(true);

                    return Ok(new { otp });
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                return BadRequest("Failed to send email: " + ex.Message);
            }
        }







        public IHttpActionResult DeleteAdmRegistration(int AdmRegistrationId)
        {
            try
            {
                var result = AdmRegistrationDAL.DeleteAdmRegistration(AdmRegistrationId);

                if (result == "Success")
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdmRegistrationController DeleteAdmRegistration Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}