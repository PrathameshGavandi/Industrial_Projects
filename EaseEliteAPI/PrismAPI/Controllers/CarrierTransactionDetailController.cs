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
    public class CarrierTransactionDetailController : ApiController
   {
   public Logger Log = null;
       public CarrierTransactionDetailController()
       {
       Log = Logger.GetLogger();
       }
CarrierTransactionDetailDAL carrierTransactionDetailDAL = new CarrierTransactionDetailDAL();
[HttpGet]
[ActionName("GetAllCarrierTransactionDetail")]
public List<CarrierTransactionDetail> GetAllCarrierTransactionDetail()
{
Log.writeMessage("CarrierTransactionDetailController GetAllCarrierTransactionDetail Start");
List<CarrierTransactionDetail> list = null;
try
{
list = carrierTransactionDetailDAL.GetAllCarrierTransactionDetail();
}
catch (Exception ex)
{
Log.writeMessage("CarrierTransactionDetailController GetAllCarrierTransactionDetail Error " + ex.Message);
}
Log.writeMessage("CarrierTransactionDetailController GetAllCarrierTransactionDetail End ");
return list;
}
 [HttpGet]
 [ActionName("GetCarrierTransactionDetailById")]
 public CarrierTransactionDetail GetCarrierTransactionDetailById(int CarrierTransactionDetailId )
{
Log.writeMessage("CarrierTransactionDetailController GetCarrierTransactionDetailById Start");
CarrierTransactionDetail carrierTransactionDetail = null;
try
{
carrierTransactionDetail = carrierTransactionDetailDAL.GetCarrierTransactionDetailById(CarrierTransactionDetailId);
}
catch (Exception ex)
{
Log.writeMessage("CarrierTransactionDetailController GetCarrierTransactionDetailById Error " + ex.Message);
}
Log.writeMessage("CarrierTransactionDetailController GetCarrierTransactionDetailById End");
return carrierTransactionDetail;
}
[HttpPost]
 [ActionName("AddCarrierTransactionDetail")]
 public IHttpActionResult AddCarrierTransactionDetail(CarrierTransactionDetail carrierTransactionDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
carrierTransactionDetail.CreatedBy = "Admin";
carrierTransactionDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
carrierTransactionDetail.UpdatedBy = "Admin";
carrierTransactionDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = carrierTransactionDetailDAL.AddCarrierTransactionDetail(carrierTransactionDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CarrierTransactionDetailController AddCarrierTransactionDetail Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateCarrierTransactionDetail")]
 public IHttpActionResult UpdateCarrierTransactionDetail(CarrierTransactionDetail carrierTransactionDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
carrierTransactionDetail.CreatedBy = "Admin";
carrierTransactionDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
carrierTransactionDetail.UpdatedBy = "Admin";
carrierTransactionDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = carrierTransactionDetailDAL.UpdateCarrierTransactionDetail(carrierTransactionDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CarrierTransactionDetailController UpdateCarrierTransactionDetail Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteCarrierTransactionDetail(int CarrierTransactionDetailId)
{
 try
 {
var result = carrierTransactionDetailDAL.DeleteCarrierTransactionDetail(CarrierTransactionDetailId);
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
Log.writeMessage("CarrierTransactionDetailController DeleteCarrierTransactionDetail Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
