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
    public class FttPurchasePlanController : ApiController
   {
   public Logger Log = null;
       public FttPurchasePlanController()
       {
       Log = Logger.GetLogger();
       }
FttPurchasePlanDAL fttPurchasePlanDAL = new FttPurchasePlanDAL();
[HttpGet]
[ActionName("GetAllFttPurchasePlan")]
public List<FttPurchasePlan> GetAllFttPurchasePlan()
{
Log.writeMessage("FttPurchasePlanController GetAllFttPurchasePlan Start");
List<FttPurchasePlan> list = null;
try
{
list = fttPurchasePlanDAL.GetAllFttPurchasePlan();
}
catch (Exception ex)
{
Log.writeMessage("FttPurchasePlanController GetAllFttPurchasePlan Error " + ex.Message);
}
Log.writeMessage("FttPurchasePlanController GetAllFttPurchasePlan End ");
return list;
}
 [HttpGet]
 [ActionName("GetFttPurchasePlanById")]
 public FttPurchasePlan GetFttPurchasePlanById(int FttPurchasePlanId )
{
Log.writeMessage("FttPurchasePlanController GetFttPurchasePlanById Start");
FttPurchasePlan fttPurchasePlan = null;
try
{
fttPurchasePlan = fttPurchasePlanDAL.GetFttPurchasePlanById(FttPurchasePlanId);
}
catch (Exception ex)
{
Log.writeMessage("FttPurchasePlanController GetFttPurchasePlanById Error " + ex.Message);
}
Log.writeMessage("FttPurchasePlanController GetFttPurchasePlanById End");
return fttPurchasePlan;
}
[HttpPost]
 [ActionName("AddFttPurchasePlan")]
 public IHttpActionResult AddFttPurchasePlan(FttPurchasePlan fttPurchasePlan)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
fttPurchasePlan.CreatedBy = "Admin";
fttPurchasePlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
fttPurchasePlan.UpdatedBy = "Admin";
fttPurchasePlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = fttPurchasePlanDAL.AddFttPurchasePlan(fttPurchasePlan);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("FttPurchasePlanController AddFttPurchasePlan Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateFttPurchasePlan")]
 public IHttpActionResult UpdateFttPurchasePlan(FttPurchasePlan fttPurchasePlan)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
fttPurchasePlan.CreatedBy = "Admin";
fttPurchasePlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
fttPurchasePlan.UpdatedBy = "Admin";
fttPurchasePlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = fttPurchasePlanDAL.UpdateFttPurchasePlan(fttPurchasePlan);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("FttPurchasePlanController UpdateFttPurchasePlan Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteFttPurchasePlan(int FttPurchasePlanId)
{
 try
 {
var result = fttPurchasePlanDAL.DeleteFttPurchasePlan(FttPurchasePlanId);
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
Log.writeMessage("FttPurchasePlanController DeleteFttPurchasePlan Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
