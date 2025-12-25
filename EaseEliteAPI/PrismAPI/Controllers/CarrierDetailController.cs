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
    public class CarrierDetailController : ApiController
   {
   public Logger Log = null;
       public CarrierDetailController()
       {
       Log = Logger.GetLogger();
       }
CarrierDetailDAL carrierDetailDAL = new CarrierDetailDAL();
[HttpGet]
[ActionName("GetAllCarrierDetail")]
public List<CarrierDetail> GetAllCarrierDetail()
{
Log.writeMessage("CarrierDetailController GetAllCarrierDetail Start");
List<CarrierDetail> list = null;
try
{
list = carrierDetailDAL.GetAllCarrierDetail();
}
catch (Exception ex)
{
Log.writeMessage("CarrierDetailController GetAllCarrierDetail Error " + ex.Message);
}
Log.writeMessage("CarrierDetailController GetAllCarrierDetail End ");
return list;
}
 [HttpGet]
 [ActionName("GetCarrierDetailById")]
 public CarrierDetail GetCarrierDetailById(int CarrierDetailId )
{
Log.writeMessage("CarrierDetailController GetCarrierDetailById Start");
CarrierDetail carrierDetail = null;
try
{
carrierDetail = carrierDetailDAL.GetCarrierDetailById(CarrierDetailId);
}
catch (Exception ex)
{
Log.writeMessage("CarrierDetailController GetCarrierDetailById Error " + ex.Message);
}
Log.writeMessage("CarrierDetailController GetCarrierDetailById End");
return carrierDetail;
}
[HttpPost]
 [ActionName("AddCarrierDetail")]
 public IHttpActionResult AddCarrierDetail(CarrierDetail carrierDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
carrierDetail.CreatedBy = "Admin";
carrierDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
//carrierDetail.UpdatedBy = "Admin";
carrierDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = carrierDetailDAL.AddCarrierDetail(carrierDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CarrierDetailController AddCarrierDetail Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateCarrierDetail")]
 public IHttpActionResult UpdateCarrierDetail(CarrierDetail carrierDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
carrierDetail.CreatedBy = "Admin";
carrierDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
//carrierDetail.UpdatedBy = "Admin";
carrierDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = carrierDetailDAL.UpdateCarrierDetail(carrierDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CarrierDetailController UpdateCarrierDetail Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteCarrierDetail(int CarrierDetailId)
{
 try
 {
var result = carrierDetailDAL.DeleteCarrierDetail(CarrierDetailId);
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
Log.writeMessage("CarrierDetailController DeleteCarrierDetail Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
