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
    public class AdmFttSubscriptionController : ApiController
   {
   public Logger Log = null;
       public AdmFttSubscriptionController()
       {
       Log = Logger.GetLogger();
       }
AdmFttSubscriptionDAL admFttSubscriptionDAL = new AdmFttSubscriptionDAL();
[HttpGet]
[ActionName("GetAllAdmFttSubscription")]
public List<AdmFttSubscription> GetAllAdmFttSubscription()
{
Log.writeMessage("AdmFttSubscriptionController GetAllAdmFttSubscription Start");
List<AdmFttSubscription> list = null;
try
{
list = admFttSubscriptionDAL.GetAllAdmFttSubscription();
}
catch (Exception ex)
{
Log.writeMessage("AdmFttSubscriptionController GetAllAdmFttSubscription Error " + ex.Message);
}
Log.writeMessage("AdmFttSubscriptionController GetAllAdmFttSubscription End ");
return list;
}
 [HttpGet]
 [ActionName("GetAdmFttSubscriptionById")]
 public AdmFttSubscription GetAdmFttSubscriptionById(int AdmFttSubscriptionld )
{
Log.writeMessage("AdmFttSubscriptionController GetAdmFttSubscriptionById Start");
AdmFttSubscription admFttSubscription = null;
try
{
admFttSubscription = admFttSubscriptionDAL.GetAdmFttSubscriptionById(AdmFttSubscriptionld);
}
catch (Exception ex)
{
Log.writeMessage("AdmFttSubscriptionController GetAdmFttSubscriptionById Error " + ex.Message);
}
Log.writeMessage("AdmFttSubscriptionController GetAdmFttSubscriptionById End");
return admFttSubscription;
}
[HttpPost]
 [ActionName("AddAdmFttSubscription")]
 public IHttpActionResult AddAdmFttSubscription(AdmFttSubscription admFttSubscription)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admFttSubscription.CreatedBy = "Admin";
admFttSubscription.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admFttSubscription.UpdatedBy = "Admin";
admFttSubscription.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admFttSubscriptionDAL.AddAdmFttSubscription(admFttSubscription);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmFttSubscriptionController AddAdmFttSubscription Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateAdmFttSubscription")]
 public IHttpActionResult UpdateAdmFttSubscription(AdmFttSubscription admFttSubscription)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admFttSubscription.CreatedBy = "Admin";
admFttSubscription.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admFttSubscription.UpdatedBy = "Admin";
admFttSubscription.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admFttSubscriptionDAL.UpdateAdmFttSubscription(admFttSubscription);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmFttSubscriptionController UpdateAdmFttSubscription Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteAdmFttSubscription(int AdmFttSubscriptionld)
{
 try
 {
var result = admFttSubscriptionDAL.DeleteAdmFttSubscription(AdmFttSubscriptionld);
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
Log.writeMessage("AdmFttSubscriptionController DeleteAdmFttSubscription Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
