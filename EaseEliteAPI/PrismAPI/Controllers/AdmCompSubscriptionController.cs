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
    public class AdmCompSubscriptionController : ApiController
   {
   public Logger Log = null;
       public AdmCompSubscriptionController()
       {
       Log = Logger.GetLogger();
       }
AdmCompSubscriptionDAL admCompSubscriptionDAL = new AdmCompSubscriptionDAL();
[HttpGet]
[ActionName("GetAllAdmCompSubscription")]
public List<AdmCompSubscription> GetAllAdmCompSubscription()
{
Log.writeMessage("AdmCompSubscriptionController GetAllAdmCompSubscription Start");
List<AdmCompSubscription> list = null;
try
{
list = admCompSubscriptionDAL.GetAllAdmCompSubscription();
}
catch (Exception ex)
{
Log.writeMessage("AdmCompSubscriptionController GetAllAdmCompSubscription Error " + ex.Message);
}
Log.writeMessage("AdmCompSubscriptionController GetAllAdmCompSubscription End ");
return list;
}
 [HttpGet]
 [ActionName("GetAdmCompSubscriptionById")]
 public AdmCompSubscription GetAdmCompSubscriptionById(int AdmCompSubscriptionld  )
{
Log.writeMessage("AdmCompSubscriptionController GetAdmCompSubscriptionById Start");
AdmCompSubscription admCompSubscription = null;
try
{
admCompSubscription = admCompSubscriptionDAL.GetAdmCompSubscriptionById(AdmCompSubscriptionld );
}
catch (Exception ex)
{
Log.writeMessage("AdmCompSubscriptionController GetAdmCompSubscriptionById Error " + ex.Message);
}
Log.writeMessage("AdmCompSubscriptionController GetAdmCompSubscriptionById End");
return admCompSubscription;
}
[HttpPost]
 [ActionName("AddAdmCompSubscription")]
 public IHttpActionResult AddAdmCompSubscription(AdmCompSubscription admCompSubscription)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admCompSubscription.CreatedBy = "Admin";
admCompSubscription.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admCompSubscription.UpdatedBy = "Admin";
admCompSubscription.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admCompSubscriptionDAL.AddAdmCompSubscription(admCompSubscription);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmCompSubscriptionController AddAdmCompSubscription Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateAdmCompSubscription")]
 public IHttpActionResult UpdateAdmCompSubscription(AdmCompSubscription admCompSubscription)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admCompSubscription.CreatedBy = "Admin";
admCompSubscription.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admCompSubscription.UpdatedBy = "Admin";
admCompSubscription.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admCompSubscriptionDAL.UpdateAdmCompSubscription(admCompSubscription);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmCompSubscriptionController UpdateAdmCompSubscription Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteAdmCompSubscription(int AdmCompSubscriptionld )
{
 try
 {
var result = admCompSubscriptionDAL.DeleteAdmCompSubscription(AdmCompSubscriptionld );
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
Log.writeMessage("AdmCompSubscriptionController DeleteAdmCompSubscription Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
