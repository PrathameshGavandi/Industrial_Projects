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
    public class PackageSenderTransactionDetailController : ApiController
   {
   public Logger Log = null;
       public PackageSenderTransactionDetailController()
       {
       Log = Logger.GetLogger();
       }
PackageSenderTransactionDetailDAL packageSenderTransactionDetailDAL = new PackageSenderTransactionDetailDAL();
[HttpGet]
[ActionName("GetAllPackageSenderTransactionDetail")]
public List<PackageSenderTransactionDetail> GetAllPackageSenderTransactionDetail()
{
Log.writeMessage("PackageSenderTransactionDetailController GetAllPackageSenderTransactionDetail Start");
List<PackageSenderTransactionDetail> list = null;
try
{
list = packageSenderTransactionDetailDAL.GetAllPackageSenderTransactionDetail();
}
catch (Exception ex)
{
Log.writeMessage("PackageSenderTransactionDetailController GetAllPackageSenderTransactionDetail Error " + ex.Message);
}
Log.writeMessage("PackageSenderTransactionDetailController GetAllPackageSenderTransactionDetail End ");
return list;
}
 [HttpGet]
 [ActionName("GetPackageSenderTransactionDetailById")]
 public PackageSenderTransactionDetail GetPackageSenderTransactionDetailById(int PackageSenderTansactionDetailId )
{
Log.writeMessage("PackageSenderTransactionDetailController GetPackageSenderTransactionDetailById Start");
PackageSenderTransactionDetail packageSenderTransactionDetail = null;
try
{
packageSenderTransactionDetail = packageSenderTransactionDetailDAL.GetPackageSenderTransactionDetailById(PackageSenderTansactionDetailId);
}
catch (Exception ex)
{
Log.writeMessage("PackageSenderTransactionDetailController GetPackageSenderTransactionDetailById Error " + ex.Message);
}
Log.writeMessage("PackageSenderTransactionDetailController GetPackageSenderTransactionDetailById End");
return packageSenderTransactionDetail;
}
[HttpPost]
 [ActionName("AddPackageSenderTransactionDetail")]
 public IHttpActionResult AddPackageSenderTransactionDetail(PackageSenderTransactionDetail packageSenderTransactionDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
packageSenderTransactionDetail.CreatedBy = "Admin";
packageSenderTransactionDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
packageSenderTransactionDetail.UpdatedBy = "Admin";
packageSenderTransactionDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = packageSenderTransactionDetailDAL.AddPackageSenderTransactionDetail(packageSenderTransactionDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("PackageSenderTransactionDetailController AddPackageSenderTransactionDetail Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdatePackageSenderTransactionDetail")]
 public IHttpActionResult UpdatePackageSenderTransactionDetail(PackageSenderTransactionDetail packageSenderTransactionDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
packageSenderTransactionDetail.CreatedBy = "Admin";
packageSenderTransactionDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
packageSenderTransactionDetail.UpdatedBy = "Admin";
packageSenderTransactionDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = packageSenderTransactionDetailDAL.UpdatePackageSenderTransactionDetail(packageSenderTransactionDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("PackageSenderTransactionDetailController UpdatePackageSenderTransactionDetail Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeletePackageSenderTransactionDetail(int PackageSenderTansactionDetailId)
{
 try
 {
var result = packageSenderTransactionDetailDAL.DeletePackageSenderTransactionDetail(PackageSenderTansactionDetailId);
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
Log.writeMessage("PackageSenderTransactionDetailController DeletePackageSenderTransactionDetail Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
