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
    public class FttTransactionDetailController : ApiController
   {
   public Logger Log = null;
       public FttTransactionDetailController()
       {
       Log = Logger.GetLogger();
       }
FttTransactionDetailDAL fttTransactionDetailDAL = new FttTransactionDetailDAL();
[HttpGet]
[ActionName("GetAllFttTransactionDetail")]
public List<FttTransactionDetail> GetAllFttTransactionDetail()
{
Log.writeMessage("FttTransactionDetailController GetAllFttTransactionDetail Start");
List<FttTransactionDetail> list = null;
try
{
list = fttTransactionDetailDAL.GetAllFttTransactionDetail();
}
catch (Exception ex)
{
Log.writeMessage("FttTransactionDetailController GetAllFttTransactionDetail Error " + ex.Message);
}
Log.writeMessage("FttTransactionDetailController GetAllFttTransactionDetail End ");
return list;
}
 [HttpGet]
 [ActionName("GetFttTransactionDetailById")]
 public FttTransactionDetail GetFttTransactionDetailById(int FttTransactionDetailId )
{
Log.writeMessage("FttTransactionDetailController GetFttTransactionDetailById Start");
FttTransactionDetail fttTransactionDetail = null;
try
{
fttTransactionDetail = fttTransactionDetailDAL.GetFttTransactionDetailById(FttTransactionDetailId);
}
catch (Exception ex)
{
Log.writeMessage("FttTransactionDetailController GetFttTransactionDetailById Error " + ex.Message);
}
Log.writeMessage("FttTransactionDetailController GetFttTransactionDetailById End");
return fttTransactionDetail;
}
[HttpPost]
 [ActionName("AddFttTransactionDetail")]
 public IHttpActionResult AddFttTransactionDetail(FttTransactionDetail fttTransactionDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
fttTransactionDetail.CreatedBy = "Admin";
fttTransactionDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
fttTransactionDetail.UpdatedBy = "Admin";
fttTransactionDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = fttTransactionDetailDAL.AddFttTransactionDetail(fttTransactionDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("FttTransactionDetailController AddFttTransactionDetail Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateFttTransactionDetail")]
 public IHttpActionResult UpdateFttTransactionDetail(FttTransactionDetail fttTransactionDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
fttTransactionDetail.CreatedBy = "Admin";
fttTransactionDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
fttTransactionDetail.UpdatedBy = "Admin";
fttTransactionDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = fttTransactionDetailDAL.UpdateFttTransactionDetail(fttTransactionDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("FttTransactionDetailController UpdateFttTransactionDetail Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteFttTransactionDetail(int FttTransactionDetailId)
{
 try
 {
var result = fttTransactionDetailDAL.DeleteFttTransactionDetail(FttTransactionDetailId);
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
Log.writeMessage("FttTransactionDetailController DeleteFttTransactionDetail Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
