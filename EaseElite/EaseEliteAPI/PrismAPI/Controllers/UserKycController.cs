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
    public class UserKycController : ApiController
   {
   public Logger Log = null;
       public UserKycController()
       {
       Log = Logger.GetLogger();
       }
UserKycDAL userKycDAL = new UserKycDAL();
[HttpGet]
[ActionName("GetAllUserKyc")]
public List<UserKyc> GetAllUserKyc()
{
Log.writeMessage("UserKycController GetAllUserKyc Start");
List<UserKyc> list = null;
try
{
list = userKycDAL.GetAllUserKyc();
}
catch (Exception ex)
{
Log.writeMessage("UserKycController GetAllUserKyc Error " + ex.Message);
}
Log.writeMessage("UserKycController GetAllUserKyc End ");
return list;
}
 [HttpGet]
 [ActionName("GetUserKycById")]
 public UserKyc GetUserKycById(int UserKycId )
{
Log.writeMessage("UserKycController GetUserKycById Start");
UserKyc userKyc = null;
try
{
userKyc = userKycDAL.GetUserKycById(UserKycId);
}
catch (Exception ex)
{
Log.writeMessage("UserKycController GetUserKycById Error " + ex.Message);
}
Log.writeMessage("UserKycController GetUserKycById End");
return userKyc;
}
[HttpPost]
 [ActionName("AddUserKyc")]
 public IHttpActionResult AddUserKyc(UserKyc userKyc)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
userKyc.CreatedBy = "Admin";
userKyc.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
userKyc.UpdatedBy = "Admin";
userKyc.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = userKycDAL.AddUserKyc(userKyc);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("UserKycController AddUserKyc Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateUserKyc")]
 public IHttpActionResult UpdateUserKyc(UserKyc userKyc)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
userKyc.CreatedBy = "Admin";
userKyc.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
userKyc.UpdatedBy = "Admin";
userKyc.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = userKycDAL.UpdateUserKyc(userKyc);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("UserKycController UpdateUserKyc Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteUserKyc(int UserKycId)
{
 try
 {
var result = userKycDAL.DeleteUserKyc(UserKycId);
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
Log.writeMessage("UserKycController DeleteUserKyc Error "  + ex.Message);
}
return Ok("Failed");
}
//[HttpPost]
//public async Task<IHttpActionResult> SaveUserKycImage(int UserKycId)
//{
//try
//{
//if (!Request.Content.IsMimeMultipartContent())
//throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
//var provider = new MultipartMemoryStreamProvider();
//await Request.Content.ReadAsMultipartAsync(provider);
//foreach (var file in provider.Contents)
//{
//var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
//var buffer = await file.ReadAsByteArrayAsync();
//string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
////get the folder that's in
//string theDirectory = Path.GetDirectoryName(fullPath);
//theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
//File.WriteAllBytes(theDirectory + "/Content/UserKyc" + "/" + UserKycId +"_" + filename, buffer);
////Do whatever you want with filename and its binary data.
//// get existing rocrd
//var userKyc = userKycDAL.GetUserKycById(UserKycId);
//var filenamenew = UserKycId + "_" + filename;
//if (userKyc.Image.ToLower() != filenamenew.ToLower())
//{
//File.Delete(theDirectory + "/Content/UserKyc" + "/"+ userKyc.Image);
//userKyc.Image = UserKycId +"_" + filename; 
//var result = userKycDAL.UpdateUserKyc(userKyc);
//}
//}
//}
//catch (Exception ex)
//{
//Log.writeMessage(ex.Message);
//}
//return Ok();
//}
}
}
