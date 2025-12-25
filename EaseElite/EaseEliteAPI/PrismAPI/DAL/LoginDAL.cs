//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//using System.Threading.Tasks;
//using System.Reflection;
//using System.IO;
//using System.Web.Http.Cors;
//using PrismAPI.DAL;
//using PrismAPI.Models;

//using MailKit.Net.Smtp;
//using MimeKit;
//using System.Net.Mail;

//namespace PrismAPI.Controllers
//{
//    public class LoginController : ApiController
//    {
//        // GET: Login
//        public Logger Log = null;
//        public LoginController()
//        {
//            Log = Logger.GetLogger();
//        }
//        LoginDAL LoginDAL = new LoginDAL();

//        [HttpGet]
//        [ActionName("Login")]
//        public Login Login(string Email, string Password)
//        {
//            Log.writeMessage("LoginController GetLoginById Start");
//            Login user = null;
//            try
//            {
//                user = LoginDAL.Login(Email, Password);
//            }
//            catch (Exception ex)
//            {
//                Log.writeMessage("LoginController GetLoginById Error " + ex.Message);
//            }
//            Log.writeMessage("LoginController GetLoginById End");
//            return user;
//        }




//        //[HttpGet]
//        //[ActionName("SendOTPEmail")]
//        //public async Task<IHttpActionResult> SendOTPEmail(string Email)
//        //{
//        //    try
//        //    {
//        //        // Configure SMTP client
//        //        using (var smtpClient = new SmtpClient())
//        //        {
//        //            await smtpClient.ConnectAsync("smtp.gmail.com", 465, true);

//        //            // Authenticate with Gmail
//        //            await smtpClient.AuthenticateAsync("testsumit19@gmail.com", "dyld bnbm auks eopc");

//        //            // Generate a 6-digit random OTP
//        //            Random random = new Random();
//        //            int otpValue = random.Next(100000, 999999);
//        //            string otp = otpValue.ToString();

//        //            // Create and send email message
//        //            var message = new MimeMessage();
//        //            message.From.Add(new MailboxAddress("Your Name", "testsumit19@gmail.com"));
//        //            message.To.Add(new MailboxAddress(Email, Email)); // Use the email address for both display name and email
//        //            message.Subject = "Your OTP Code";

//        //            message.Body = new TextPart("plain")
//        //            {
//        //                Text = "Your OTP Code is: " + otp
//        //            };

//        //            // Send email asynchronously
//        //            await smtpClient.SendAsync(message);
//        //            await smtpClient.DisconnectAsync(true);

//        //            return Ok(new { otp });
//        //        }
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        // Handle any exceptions here
//        //        return BadRequest("Failed to send email: " + ex.Message);
//        //    }
//        //}







//        //    public IHttpActionResult DeleteLogin(int LoginId)
//        //    {
//        //        try
//        //        {
//        //            var result = LoginDAL.DeleteLogin(LoginId);

//        //            if (result == "Success")
//        //            {
//        //                return Ok("Success");
//        //            }
//        //            else
//        //            {
//        //                return Ok("Failed");
//        //            }
//        //        }
//        //        catch (Exception ex)
//        //        {
//        //            Log.writeMessage("LoginController DeleteLogin Error " + ex.Message);
//        //        }
//        //        return Ok("Failed");
//        //    }
//        //}
//    }
//}