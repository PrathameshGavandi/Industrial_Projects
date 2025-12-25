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
    public class CarrierPurchasePlanController : ApiController
   {
   public Logger Log = null;
       public CarrierPurchasePlanController()
       {
       Log = Logger.GetLogger();
       }
CarrierPurchasePlanDAL carrierPurchasePlanDAL = new CarrierPurchasePlanDAL();
[HttpGet]
[ActionName("GetAllCarrierPurchasePlan")]
public List<CarrierPurchasePlan> GetAllCarrierPurchasePlan()
{
Log.writeMessage("CarrierPurchasePlanController GetAllCarrierPurchasePlan Start");
List<CarrierPurchasePlan> list = null;
try
{
list = carrierPurchasePlanDAL.GetAllCarrierPurchasePlan();
}
catch (Exception ex)
{
Log.writeMessage("CarrierPurchasePlanController GetAllCarrierPurchasePlan Error " + ex.Message);
}
Log.writeMessage("CarrierPurchasePlanController GetAllCarrierPurchasePlan End ");
return list;
}
 [HttpGet]
 [ActionName("GetCarrierPurchasePlanById")]
 public CarrierPurchasePlan GetCarrierPurchasePlanById(int CarrierPurchasePlanId )
{
Log.writeMessage("CarrierPurchasePlanController GetCarrierPurchasePlanById Start");
CarrierPurchasePlan carrierPurchasePlan = null;
try
{
carrierPurchasePlan = carrierPurchasePlanDAL.GetCarrierPurchasePlanById(CarrierPurchasePlanId);
}
catch (Exception ex)
{
Log.writeMessage("CarrierPurchasePlanController GetCarrierPurchasePlanById Error " + ex.Message);
}
Log.writeMessage("CarrierPurchasePlanController GetCarrierPurchasePlanById End");
return carrierPurchasePlan;
}
[HttpPost]
 [ActionName("AddCarrierPurchasePlan")]
 public IHttpActionResult AddCarrierPurchasePlan(CarrierPurchasePlan carrierPurchasePlan)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
carrierPurchasePlan.CreatedBy = "Admin";
carrierPurchasePlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
carrierPurchasePlan.UpdatedBy = "Admin";
carrierPurchasePlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = carrierPurchasePlanDAL.AddCarrierPurchasePlan(carrierPurchasePlan);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CarrierPurchasePlanController AddCarrierPurchasePlan Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateCarrierPurchasePlan")]
 public IHttpActionResult UpdateCarrierPurchasePlan(CarrierPurchasePlan carrierPurchasePlan)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
carrierPurchasePlan.CreatedBy = "Admin";
carrierPurchasePlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
carrierPurchasePlan.UpdatedBy = "Admin";
carrierPurchasePlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = carrierPurchasePlanDAL.UpdateCarrierPurchasePlan(carrierPurchasePlan);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CarrierPurchasePlanController UpdateCarrierPurchasePlan Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteCarrierPurchasePlan(int CarrierPurchasePlanId)
{
 try
 {
var result = carrierPurchasePlanDAL.DeleteCarrierPurchasePlan(CarrierPurchasePlanId);
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
Log.writeMessage("CarrierPurchasePlanController DeleteCarrierPurchasePlan Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
