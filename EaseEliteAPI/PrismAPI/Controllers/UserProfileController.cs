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
namespace PrismAPI.Controllers
{
    public class UserProfileController : ApiController
   {
   public Logger Log = null;
       public UserProfileController()
       {
       Log = Logger.GetLogger();
       }
UserProfileDAL userProfileDAL = new UserProfileDAL();
[HttpGet]
[ActionName("GetAllUserProfile")]
public List<UserProfile> GetAllUserProfile()
{
Log.writeMessage("UserProfileController GetAllUserProfile Start");
List<UserProfile> list = null;
try
{
list = userProfileDAL.GetAllUserProfile();
}
catch (Exception ex)
{
Log.writeMessage("UserProfileController GetAllUserProfile Error " + ex.Message);
}
Log.writeMessage("UserProfileController GetAllUserProfile End ");
return list;
}
 [HttpGet]
 [ActionName("GetUserProfileById")]
 public UserProfile GetUserProfileById(int UserProfileId )
{
Log.writeMessage("UserProfileController GetUserProfileById Start");
UserProfile userProfile = null;
try
{
userProfile = userProfileDAL.GetUserProfileById(UserProfileId);
}
catch (Exception ex)
{
Log.writeMessage("UserProfileController GetUserProfileById Error " + ex.Message);
}
Log.writeMessage("UserProfileController GetUserProfileById End");
return userProfile;
}
[HttpPost]
 [ActionName("AddUserProfile")]
 public IHttpActionResult AddUserProfile(UserProfile userProfile)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
userProfile.CreatedBy = "Admin";
userProfile.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
userProfile.UpdatedBy = "Admin";
userProfile.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = userProfileDAL.AddUserProfile(userProfile);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("UserProfileController AddUserProfile Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateUserProfile")]
 public IHttpActionResult UpdateUserProfile(UserProfile userProfile)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
userProfile.CreatedBy = "Admin";
userProfile.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
userProfile.UpdatedBy = "Admin";
userProfile.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = userProfileDAL.UpdateUserProfile(userProfile);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("UserProfileController UpdateUserProfile Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteUserProfile(int UserProfileId)
{
 try
 {
var result = userProfileDAL.DeleteUserProfile(UserProfileId);
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
Log.writeMessage("UserProfileController DeleteUserProfile Error "  + ex.Message);
}
return Ok("Failed");
}


        [HttpPost]
        public IHttpActionResult ApproveUserKyc(int UserProfileId)
        {
            try
            {
                var result = userProfileDAL.ApproveUserKyc(UserProfileId);
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
                Log.writeMessage("UserProfileController ApproveUserKyc Error " + ex.Message);
            }
            return Ok("Failed");
        }


        [HttpPost]
public async Task<IHttpActionResult> SaveUserProfileImage(int UserProfileId)
{
try
{
if (!Request.Content.IsMimeMultipartContent())
throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
var provider = new MultipartMemoryStreamProvider();
await Request.Content.ReadAsMultipartAsync(provider);
foreach (var file in provider.Contents)
{
var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
var buffer = await file.ReadAsByteArrayAsync();
string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
//get the folder that's in
string theDirectory = Path.GetDirectoryName(fullPath);
theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
File.WriteAllBytes(theDirectory + "/Content/UserProfile" + "/" + UserProfileId +"_" + filename, buffer);
//Do whatever you want with filename and its binary data.
// get existing rocrd
var userProfile = userProfileDAL.GetUserProfileById(UserProfileId);
var filenamenew = UserProfileId + "_" + filename;
if (userProfile.Image.ToLower() != filenamenew.ToLower())
{
File.Delete(theDirectory + "/Content/UserProfile" + "/"+ userProfile.Image);
userProfile.Image = UserProfileId +"_" + filename; 
var result = userProfileDAL.UpdateUserProfile(userProfile);
}
}
}
catch (Exception ex)
{
Log.writeMessage(ex.Message);
}
return Ok();
}

        [HttpPost]
        public async Task<IHttpActionResult>SaveKycImage(int UserProfileId)
        {
            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);

                string fullPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath;
                string theDirectory = Path.GetDirectoryName(fullPath);
                theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));

                string kycDirectory = Path.Combine(theDirectory, "Content", "Kyc");

                // Ensure the directory exists
                if (!Directory.Exists(kycDirectory))
                {
                    Directory.CreateDirectory(kycDirectory);
                }

                foreach (var file in provider.Contents)
                {
                    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                    var buffer = await file.ReadAsByteArrayAsync();

                    string filePath = Path.Combine(kycDirectory, $"{UserProfileId}_{filename}");
                    File.WriteAllBytes(filePath, buffer);

                    var userProfile = userProfileDAL.GetUserProfileById(UserProfileId);
                    if (userProfile == null)
                    {
                        Log.writeMessage($"User profile with ID {UserProfileId} not found.");
                        return NotFound();
                    }

                    // Ensure registration is initialized
                    if (userProfile.registration == null)
                    {
                        Log.writeMessage("User profile's registration property is null. Initializing it.");
                        userProfile.registration = new Registration();
                    }

                    if (filename.Contains("PassP") && userProfile.Passport?.ToLower() != filename.ToLower())
                    {
                        string oldPassportPath = Path.Combine(kycDirectory, userProfile.Passport);
                        if (File.Exists(oldPassportPath))
                        {
                            File.Delete(oldPassportPath);
                        }
                        userProfile.Passport = $"{UserProfileId}_{filename}";
                    }
                    else if (filename.Contains("AddressP") && userProfile.AddressProof?.ToLower() != filename.ToLower())
                    {
                        string oldAddressPath = Path.Combine(kycDirectory, userProfile.AddressProof);
                        if (File.Exists(oldAddressPath))
                        {
                            File.Delete(oldAddressPath);
                        }
                        userProfile.AddressProof = $"{UserProfileId}_{filename}";
                    }

                    userProfileDAL.UpdateUserProfile(userProfile);
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage(ex.Message);
                return InternalServerError(ex); // Optionally return a more specific HTTP status code
            }
            return Ok();
        }


    }
}
