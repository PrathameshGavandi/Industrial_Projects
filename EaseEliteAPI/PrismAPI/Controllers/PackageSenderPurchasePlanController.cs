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
    public class PackageSenderPurchasePlanController : ApiController
   {
   public Logger Log = null;
       public PackageSenderPurchasePlanController()
       {
       Log = Logger.GetLogger();
       }
PackageSenderPurchasePlanDAL packageSenderPurchasePlanDAL = new PackageSenderPurchasePlanDAL();
[HttpGet]
[ActionName("GetAllPackageSenderPurchasePlan")]
public List<PackageSenderPurchasePlan> GetAllPackageSenderPurchasePlan()
{
Log.writeMessage("PackageSenderPurchasePlanController GetAllPackageSenderPurchasePlan Start");
List<PackageSenderPurchasePlan> list = null;
try
{
list = packageSenderPurchasePlanDAL.GetAllPackageSenderPurchasePlan();
}
catch (Exception ex)
{
Log.writeMessage("PackageSenderPurchasePlanController GetAllPackageSenderPurchasePlan Error " + ex.Message);
}
Log.writeMessage("PackageSenderPurchasePlanController GetAllPackageSenderPurchasePlan End ");
return list;
}
 [HttpGet]
 [ActionName("GetPackageSenderPurchasePlanById")]
 public PackageSenderPurchasePlan GetPackageSenderPurchasePlanById(int PackageSenderPurchasePlanId )
{
Log.writeMessage("PackageSenderPurchasePlanController GetPackageSenderPurchasePlanById Start");
PackageSenderPurchasePlan packageSenderPurchasePlan = null;
try
{
packageSenderPurchasePlan = packageSenderPurchasePlanDAL.GetPackageSenderPurchasePlanById(PackageSenderPurchasePlanId);
}
catch (Exception ex)
{
Log.writeMessage("PackageSenderPurchasePlanController GetPackageSenderPurchasePlanById Error " + ex.Message);
}
Log.writeMessage("PackageSenderPurchasePlanController GetPackageSenderPurchasePlanById End");
return packageSenderPurchasePlan;
}
[HttpPost]
 [ActionName("AddPackageSenderPurchasePlan")]
 public IHttpActionResult AddPackageSenderPurchasePlan(PackageSenderPurchasePlan packageSenderPurchasePlan)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
packageSenderPurchasePlan.CreatedBy = "Admin";
packageSenderPurchasePlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
packageSenderPurchasePlan.UpdatedBy = "Admin";
packageSenderPurchasePlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = packageSenderPurchasePlanDAL.AddPackageSenderPurchasePlan(packageSenderPurchasePlan);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("PackageSenderPurchasePlanController AddPackageSenderPurchasePlan Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdatePackageSenderPurchasePlan")]
 public IHttpActionResult UpdatePackageSenderPurchasePlan(PackageSenderPurchasePlan packageSenderPurchasePlan)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
packageSenderPurchasePlan.CreatedBy = "Admin";
packageSenderPurchasePlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
packageSenderPurchasePlan.UpdatedBy = "Admin";
packageSenderPurchasePlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = packageSenderPurchasePlanDAL.UpdatePackageSenderPurchasePlan(packageSenderPurchasePlan);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("PackageSenderPurchasePlanController UpdatePackageSenderPurchasePlan Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeletePackageSenderPurchasePlan(int PackageSenderPurchasePlanId)
{
 try
 {
var result = packageSenderPurchasePlanDAL.DeletePackageSenderPurchasePlan(PackageSenderPurchasePlanId);
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
Log.writeMessage("PackageSenderPurchasePlanController DeletePackageSenderPurchasePlan Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
