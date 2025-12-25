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
    public class CompanionTransactionDetailController : ApiController
   {
   public Logger Log = null;
       public CompanionTransactionDetailController()
       {
       Log = Logger.GetLogger();
       }
CompanionTransactionDetailDAL companionTransactionDetailDAL = new CompanionTransactionDetailDAL();
[HttpGet]
[ActionName("GetAllCompanionTransactionDetail")]
public List<CompanionTransactionDetail> GetAllCompanionTransactionDetail()
{
Log.writeMessage("CompanionTransactionDetailController GetAllCompanionTransactionDetail Start");
List<CompanionTransactionDetail> list = null;
try
{
list = companionTransactionDetailDAL.GetAllCompanionTransactionDetail();
}
catch (Exception ex)
{
Log.writeMessage("CompanionTransactionDetailController GetAllCompanionTransactionDetail Error " + ex.Message);
}
Log.writeMessage("CompanionTransactionDetailController GetAllCompanionTransactionDetail End ");
return list;
}
 [HttpGet]
 [ActionName("GetCompanionTransactionDetailById")]
 public CompanionTransactionDetail GetCompanionTransactionDetailById(int CompanionTransactionDetailId )
{
Log.writeMessage("CompanionTransactionDetailController GetCompanionTransactionDetailById Start");
CompanionTransactionDetail companionTransactionDetail = null;
try
{
companionTransactionDetail = companionTransactionDetailDAL.GetCompanionTransactionDetailById(CompanionTransactionDetailId);
}
catch (Exception ex)
{
Log.writeMessage("CompanionTransactionDetailController GetCompanionTransactionDetailById Error " + ex.Message);
}
Log.writeMessage("CompanionTransactionDetailController GetCompanionTransactionDetailById End");
return companionTransactionDetail;
}
[HttpPost]
 [ActionName("AddCompanionTransactionDetail")]
 public IHttpActionResult AddCompanionTransactionDetail(CompanionTransactionDetail companionTransactionDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
companionTransactionDetail.CreatedBy = "Admin";
companionTransactionDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
companionTransactionDetail.UpdatedBy = "Admin";
companionTransactionDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = companionTransactionDetailDAL.AddCompanionTransactionDetail(companionTransactionDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CompanionTransactionDetailController AddCompanionTransactionDetail Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateCompanionTransactionDetail")]
 public IHttpActionResult UpdateCompanionTransactionDetail(CompanionTransactionDetail companionTransactionDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
companionTransactionDetail.CreatedBy = "Admin";
companionTransactionDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
companionTransactionDetail.UpdatedBy = "Admin";
companionTransactionDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = companionTransactionDetailDAL.UpdateCompanionTransactionDetail(companionTransactionDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CompanionTransactionDetailController UpdateCompanionTransactionDetail Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteCompanionTransactionDetail(int CompanionTransactionDetailId)
{
 try
 {
var result = companionTransactionDetailDAL.DeleteCompanionTransactionDetail(CompanionTransactionDetailId);
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
Log.writeMessage("CompanionTransactionDetailController DeleteCompanionTransactionDetail Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
