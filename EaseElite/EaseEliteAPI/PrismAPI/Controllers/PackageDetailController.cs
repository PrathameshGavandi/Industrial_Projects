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
    public class PackageDetailController : ApiController
   {
   public Logger Log = null;
       public PackageDetailController()
       {
       Log = Logger.GetLogger();
       }
PackageDetailDAL packageDetailDAL = new PackageDetailDAL();
[HttpGet]
[ActionName("GetAllPackageDetail")]
public List<PackageDetail> GetAllPackageDetail()
{
Log.writeMessage("PackageDetailController GetAllPackageDetail Start");
List<PackageDetail> list = null;
try
{
list = packageDetailDAL.GetAllPackageDetail();
}
catch (Exception ex)
{
Log.writeMessage("PackageDetailController GetAllPackageDetail Error " + ex.Message);
}
Log.writeMessage("PackageDetailController GetAllPackageDetail End ");
return list;
}
 [HttpGet]
 [ActionName("GetPackageDetailById")]
 public PackageDetail GetPackageDetailById(int PackageDetailId )
{
Log.writeMessage("PackageDetailController GetPackageDetailById Start");
PackageDetail packageDetail = null;
try
{
packageDetail = packageDetailDAL.GetPackageDetailById(PackageDetailId);
}
catch (Exception ex)
{
Log.writeMessage("PackageDetailController GetPackageDetailById Error " + ex.Message);
}
Log.writeMessage("PackageDetailController GetPackageDetailById End");
return packageDetail;
}
[HttpPost]
 [ActionName("AddPackageDetail")]
 public IHttpActionResult AddPackageDetail(PackageDetail packageDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
packageDetail.CreatedBy = "Admin";
packageDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
packageDetail.UpdatedBy = "Admin";
packageDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = packageDetailDAL.AddPackageDetail(packageDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("PackageDetailController AddPackageDetail Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdatePackageDetail")]
 public IHttpActionResult UpdatePackageDetail(PackageDetail packageDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
packageDetail.CreatedBy = "Admin";
packageDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
packageDetail.UpdatedBy = "Admin";
packageDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = packageDetailDAL.UpdatePackageDetail(packageDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("PackageDetailController UpdatePackageDetail Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeletePackageDetail(int PackageDetailId)
{
 try
 {
var result = packageDetailDAL.DeletePackageDetail(PackageDetailId);
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
Log.writeMessage("PackageDetailController DeletePackageDetail Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
