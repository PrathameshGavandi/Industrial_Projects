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
    public class CompanionPurchasePlanController : ApiController
   {
   public Logger Log = null;
       public CompanionPurchasePlanController()
       {
       Log = Logger.GetLogger();
       }
CompanionPurchasePlanDAL companionPurchasePlanDAL = new CompanionPurchasePlanDAL();
[HttpGet]
[ActionName("GetAllCompanionPurchasePlan")]
public List<CompanionPurchasePlan> GetAllCompanionPurchasePlan()
{
Log.writeMessage("CompanionPurchasePlanController GetAllCompanionPurchasePlan Start");
List<CompanionPurchasePlan> list = null;
try
{
list = companionPurchasePlanDAL.GetAllCompanionPurchasePlan();
}
catch (Exception ex)
{
Log.writeMessage("CompanionPurchasePlanController GetAllCompanionPurchasePlan Error " + ex.Message);
}
Log.writeMessage("CompanionPurchasePlanController GetAllCompanionPurchasePlan End ");
return list;
}
 [HttpGet]
 [ActionName("GetCompanionPurchasePlanById")]
 public CompanionPurchasePlan GetCompanionPurchasePlanById(int CompanionPurchasePlanId )
{
Log.writeMessage("CompanionPurchasePlanController GetCompanionPurchasePlanById Start");
CompanionPurchasePlan companionPurchasePlan = null;
try
{
companionPurchasePlan = companionPurchasePlanDAL.GetCompanionPurchasePlanById(CompanionPurchasePlanId);
}
catch (Exception ex)
{
Log.writeMessage("CompanionPurchasePlanController GetCompanionPurchasePlanById Error " + ex.Message);
}
Log.writeMessage("CompanionPurchasePlanController GetCompanionPurchasePlanById End");
return companionPurchasePlan;
}
[HttpPost]
 [ActionName("AddCompanionPurchasePlan")]
 public IHttpActionResult AddCompanionPurchasePlan(CompanionPurchasePlan companionPurchasePlan)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
companionPurchasePlan.CreatedBy = "Admin";
companionPurchasePlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
companionPurchasePlan.UpdatedBy = "Admin";
companionPurchasePlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = companionPurchasePlanDAL.AddCompanionPurchasePlan(companionPurchasePlan);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CompanionPurchasePlanController AddCompanionPurchasePlan Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateCompanionPurchasePlan")]
 public IHttpActionResult UpdateCompanionPurchasePlan(CompanionPurchasePlan companionPurchasePlan)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
companionPurchasePlan.CreatedBy = "Admin";
companionPurchasePlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
companionPurchasePlan.UpdatedBy = "Admin";
companionPurchasePlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = companionPurchasePlanDAL.UpdateCompanionPurchasePlan(companionPurchasePlan);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CompanionPurchasePlanController UpdateCompanionPurchasePlan Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteCompanionPurchasePlan(int CompanionPurchasePlanId)
{
 try
 {
var result = companionPurchasePlanDAL.DeleteCompanionPurchasePlan(CompanionPurchasePlanId);
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
Log.writeMessage("CompanionPurchasePlanController DeleteCompanionPurchasePlan Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
