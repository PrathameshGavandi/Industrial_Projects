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
    public class AdmCarrierSubscriptionController : ApiController
   {
   public Logger Log = null;
       public AdmCarrierSubscriptionController()
       {
       Log = Logger.GetLogger();
       }
AdmCarrierSubscriptionDAL admCarrierSubscriptionDAL = new AdmCarrierSubscriptionDAL();
[HttpGet]
[ActionName("GetAllAdmCarrierSubscription")]
public List<AdmCarrierSubscription> GetAllAdmCarrierSubscription()
{
Log.writeMessage("AdmCarrierSubscriptionController GetAllAdmCarrierSubscription Start");
List<AdmCarrierSubscription> list = null;
try
{
list = admCarrierSubscriptionDAL.GetAllAdmCarrierSubscription();
}
catch (Exception ex)
{
Log.writeMessage("AdmCarrierSubscriptionController GetAllAdmCarrierSubscription Error " + ex.Message);
}
Log.writeMessage("AdmCarrierSubscriptionController GetAllAdmCarrierSubscription End ");
return list;
}
 [HttpGet]
 [ActionName("GetAdmCarrierSubscriptionById")]
 public AdmCarrierSubscription GetAdmCarrierSubscriptionById(int AdmCarrierSubscriptionld   )
{
Log.writeMessage("AdmCarrierSubscriptionController GetAdmCarrierSubscriptionById Start");
AdmCarrierSubscription admCarrierSubscription = null;
try
{
admCarrierSubscription = admCarrierSubscriptionDAL.GetAdmCarrierSubscriptionById(AdmCarrierSubscriptionld  );
}
catch (Exception ex)
{
Log.writeMessage("AdmCarrierSubscriptionController GetAdmCarrierSubscriptionById Error " + ex.Message);
}
Log.writeMessage("AdmCarrierSubscriptionController GetAdmCarrierSubscriptionById End");
return admCarrierSubscription;
}
[HttpPost]
 [ActionName("AddAdmCarrierSubscription")]
 public IHttpActionResult AddAdmCarrierSubscription(AdmCarrierSubscription admCarrierSubscription)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admCarrierSubscription.CreatedBy = "Admin";
admCarrierSubscription.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admCarrierSubscription.UpdatedBy = "Admin";
admCarrierSubscription.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admCarrierSubscriptionDAL.AddAdmCarrierSubscription(admCarrierSubscription);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmCarrierSubscriptionController AddAdmCarrierSubscription Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateAdmCarrierSubscription")]
 public IHttpActionResult UpdateAdmCarrierSubscription(AdmCarrierSubscription admCarrierSubscription)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admCarrierSubscription.CreatedBy = "Admin";
admCarrierSubscription.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admCarrierSubscription.UpdatedBy = "Admin";
admCarrierSubscription.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admCarrierSubscriptionDAL.UpdateAdmCarrierSubscription(admCarrierSubscription);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmCarrierSubscriptionController UpdateAdmCarrierSubscription Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteAdmCarrierSubscription(int AdmCarrierSubscriptionld  )
{
 try
 {
var result = admCarrierSubscriptionDAL.DeleteAdmCarrierSubscription(AdmCarrierSubscriptionld  );
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
Log.writeMessage("AdmCarrierSubscriptionController DeleteAdmCarrierSubscription Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
