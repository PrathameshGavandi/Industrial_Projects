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
    public class FttSubscriptionController : ApiController
   {
   public Logger Log = null;
       public FttSubscriptionController()
       {
       Log = Logger.GetLogger();
       }
FttSubscriptionDAL fttSubscriptionDAL = new FttSubscriptionDAL();
[HttpGet]
[ActionName("GetAllFttSubscription")]
public List<FttSubscription> GetAllFttSubscription()
{
Log.writeMessage("FttSubscriptionController GetAllFttSubscription Start");
List<FttSubscription> list = null;
try
{
list = fttSubscriptionDAL.GetAllFttSubscription();
}
catch (Exception ex)
{
Log.writeMessage("FttSubscriptionController GetAllFttSubscription Error " + ex.Message);
}
Log.writeMessage("FttSubscriptionController GetAllFttSubscription End ");
return list;
}
 [HttpGet]
 [ActionName("GetFttSubscriptionById")]
 public FttSubscription GetFttSubscriptionById(int FttSubscriptionId )
{
Log.writeMessage("FttSubscriptionController GetFttSubscriptionById Start");
FttSubscription fttSubscription = null;
try
{
fttSubscription = fttSubscriptionDAL.GetFttSubscriptionById(FttSubscriptionId);
}
catch (Exception ex)
{
Log.writeMessage("FttSubscriptionController GetFttSubscriptionById Error " + ex.Message);
}
Log.writeMessage("FttSubscriptionController GetFttSubscriptionById End");
return fttSubscription;
}
[HttpPost]
 [ActionName("AddFttSubscription")]
 public IHttpActionResult AddFttSubscription(FttSubscription fttSubscription)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
fttSubscription.CreatedBy = "Admin";
fttSubscription.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
fttSubscription.UpdatedBy = "Admin";
fttSubscription.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = fttSubscriptionDAL.AddFttSubscription(fttSubscription);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("FttSubscriptionController AddFttSubscription Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateFttSubscription")]
 public IHttpActionResult UpdateFttSubscription(FttSubscription fttSubscription)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
fttSubscription.CreatedBy = "Admin";
fttSubscription.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
fttSubscription.UpdatedBy = "Admin";
fttSubscription.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = fttSubscriptionDAL.UpdateFttSubscription(fttSubscription);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("FttSubscriptionController UpdateFttSubscription Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteFttSubscription(int FttSubscriptionId)
{
 try
 {
var result = fttSubscriptionDAL.DeleteFttSubscription(FttSubscriptionId);
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
Log.writeMessage("FttSubscriptionController DeleteFttSubscription Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
