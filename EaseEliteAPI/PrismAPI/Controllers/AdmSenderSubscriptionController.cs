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
    public class AdmSenderSubscriptionController : ApiController
   {
   public Logger Log = null;
       public AdmSenderSubscriptionController()
       {
       Log = Logger.GetLogger();
       }
AdmSenderSubscriptionDAL admSenderSubscriptionDAL = new AdmSenderSubscriptionDAL();
[HttpGet]
[ActionName("GetAllAdmSenderSubscription")]
public List<AdmSenderSubscription> GetAllAdmSenderSubscription()
{
Log.writeMessage("AdmSenderSubscriptionController GetAllAdmSenderSubscription Start");
List<AdmSenderSubscription> list = null;
try
{
list = admSenderSubscriptionDAL.GetAllAdmSenderSubscription();
}
catch (Exception ex)
{
Log.writeMessage("AdmSenderSubscriptionController GetAllAdmSenderSubscription Error " + ex.Message);
}
Log.writeMessage("AdmSenderSubscriptionController GetAllAdmSenderSubscription End ");
return list;
}
 [HttpGet]
 [ActionName("GetAdmSenderSubscriptionById")]
 public AdmSenderSubscription GetAdmSenderSubscriptionById(int AdmSenderSubscriptionld  )
{
Log.writeMessage("AdmSenderSubscriptionController GetAdmSenderSubscriptionById Start");
AdmSenderSubscription admSenderSubscription = null;
try
{
admSenderSubscription = admSenderSubscriptionDAL.GetAdmSenderSubscriptionById(AdmSenderSubscriptionld );
}
catch (Exception ex)
{
Log.writeMessage("AdmSenderSubscriptionController GetAdmSenderSubscriptionById Error " + ex.Message);
}
Log.writeMessage("AdmSenderSubscriptionController GetAdmSenderSubscriptionById End");
return admSenderSubscription;
}
[HttpPost]
 [ActionName("AddAdmSenderSubscription")]
 public IHttpActionResult AddAdmSenderSubscription(AdmSenderSubscription admSenderSubscription)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admSenderSubscription.CreatedBy = "Admin";
admSenderSubscription.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admSenderSubscription.UpdatedBy = "Admin";
admSenderSubscription.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admSenderSubscriptionDAL.AddAdmSenderSubscription(admSenderSubscription);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmSenderSubscriptionController AddAdmSenderSubscription Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateAdmSenderSubscription")]
 public IHttpActionResult UpdateAdmSenderSubscription(AdmSenderSubscription admSenderSubscription)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admSenderSubscription.CreatedBy = "Admin";
admSenderSubscription.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admSenderSubscription.UpdatedBy = "Admin";
admSenderSubscription.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admSenderSubscriptionDAL.UpdateAdmSenderSubscription(admSenderSubscription);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmSenderSubscriptionController UpdateAdmSenderSubscription Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteAdmSenderSubscription(int AdmSenderSubscriptionld )
{
 try
 {
var result = admSenderSubscriptionDAL.DeleteAdmSenderSubscription(AdmSenderSubscriptionld );
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
Log.writeMessage("AdmSenderSubscriptionController DeleteAdmSenderSubscription Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
