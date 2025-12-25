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
    public class RegistrationController : ApiController
    {
        // GET: Registration
        public Logger Log = null;
        public RegistrationController()
        {
            Log = Logger.GetLogger();
        }
        RegistrationDAL registrationDAL = new RegistrationDAL();

        [HttpGet]
        [ActionName("GetAllRegistration")]

        public List<Registration> GetAllRegistration()
        {
            Log.writeMessage("RegistrationController GetAllRegistration Start");
            List<Registration> list = null;
            try
            {
                list = registrationDAL.GetAllRegistration();
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetAllRegistration Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetAllRegistration End");
            return list;

        }

        [HttpPost]
        [ActionName("AddRegistration")]
        public IHttpActionResult AddRegistration(Registration registration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                registration.CreatedBy = "Admin";
                registration.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                registration.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                registration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = registrationDAL.AddRegistration(registration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController AddRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateRegistration")]
        public IHttpActionResult UpdateRegistration(Registration registration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                registration.CreatedBy = "Admin";
                registration.UpdatedBy = "Admin";
                registration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = registrationDAL.UpdateRegistration(registration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController AddRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetRegistrationById")]
        public Registration GetRegistrationById(int RegistrationId)
        {
            Log.writeMessage("RegistrationController GetRegistrationById Start");
            Registration registration = null;
            try
            {
                registration = registrationDAL.GetRegistrationById(RegistrationId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationById End");
            return registration;
        }

        [HttpGet]
        [ActionName("GetRegistrationByEmail")]
        public Registration GetRegistrationByEmail(string Email)
        {
            Log.writeMessage("RegistrationController GetRegistrationByEmail Start");
            Registration registration = null;
            try
            {
                registration = registrationDAL.GetRegistrationByEmail(Email);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationByEmail Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationByEmail End");
            return registration;
        }

        [HttpGet]
        [ActionName("Login")]
        public Login Login(string Email, string Password)
        {
            Log.writeMessage("RegistrationController GetRegistrationById Start");
            Login user = null;
            try
            {
                user = registrationDAL.Login(Email, Password);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationById End");
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






        public IHttpActionResult DeleteRegistration(int RegistrationId)
        {
            try
            {
                var result = registrationDAL.DeleteRegistration(RegistrationId);

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
                Log.writeMessage("RegistrationController DeleteRegistration Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}