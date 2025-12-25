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
    public class CompanionDetailController : ApiController
   {
   public Logger Log = null;
       public CompanionDetailController()
       {
       Log = Logger.GetLogger();
       }
CompanionDetailDAL companionDetailDAL = new CompanionDetailDAL();
[HttpGet]
[ActionName("GetAllCompanionDetail")]
public List<CompanionDetail> GetAllCompanionDetail()
{
Log.writeMessage("CompanionDetailController GetAllCompanionDetail Start");
List<CompanionDetail> list = null;
try
{
list = companionDetailDAL.GetAllCompanionDetail();
}
catch (Exception ex)
{
Log.writeMessage("CompanionDetailController GetAllCompanionDetail Error " + ex.Message);
}
Log.writeMessage("CompanionDetailController GetAllCompanionDetail End ");
return list;
}
 [HttpGet]
 [ActionName("GetCompanionDetailById")]
 public CompanionDetail GetCompanionDetailById(int CompanionId )
{
Log.writeMessage("CompanionDetailController GetCompanionDetailById Start");
CompanionDetail companionDetail = null;
try
{
companionDetail = companionDetailDAL.GetCompanionDetailById(CompanionId);
}
catch (Exception ex)
{
Log.writeMessage("CompanionDetailController GetCompanionDetailById Error " + ex.Message);
}
Log.writeMessage("CompanionDetailController GetCompanionDetailById End");
return companionDetail;
}
[HttpPost]
 [ActionName("AddCompanionDetail")]
 public IHttpActionResult AddCompanionDetail(CompanionDetail companionDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
//companionDetail.CreatedBy = "Admin";
companionDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
companionDetail.UpdatedBy = "Admin";
companionDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = companionDetailDAL.AddCompanionDetail(companionDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CompanionDetailController AddCompanionDetail Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateCompanionDetail")]
 public IHttpActionResult UpdateCompanionDetail(CompanionDetail companionDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
//companionDetail.CreatedBy = "Admin";
companionDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
companionDetail.UpdatedBy = "Admin";
companionDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = companionDetailDAL.UpdateCompanionDetail(companionDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("CompanionDetailController UpdateCompanionDetail Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteCompanionDetail(int CompanionId)
{
 try
 {
var result = companionDetailDAL.DeleteCompanionDetail(CompanionId);
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
Log.writeMessage("CompanionDetailController DeleteCompanionDetail Error "  + ex.Message);
}
return Ok("Failed");
}
[HttpPost]
public async Task<IHttpActionResult> SaveCompanionDetailImage(int CompanionId)
{
try
{
if (!Request.Content.IsMimeMultipartContent())
throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
var provider = new MultipartMemoryStreamProvider();
await Request.Content.ReadAsMultipartAsync(provider);
foreach (var file in provider.Contents)
{
var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
var buffer = await file.ReadAsByteArrayAsync();
string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
//get the folder that's in
string theDirectory = Path.GetDirectoryName(fullPath);
theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
File.WriteAllBytes(theDirectory + "/Content/CompanionDetail" + "/" + CompanionId +"_" + filename, buffer);
//Do whatever you want with filename and its binary data.
// get existing rocrd
var companionDetail = companionDetailDAL.GetCompanionDetailById(CompanionId);
var filenamenew = CompanionId + "_" + filename;
if (companionDetail.UploadTicket.ToLower() != filenamenew.ToLower())
{
File.Delete(theDirectory + "/Content/CompanionDetail" + "/"+ companionDetail.UploadTicket);
companionDetail.UploadTicket = CompanionId +"_" + filename; 
var result = companionDetailDAL.UpdateCompanionDetail(companionDetail);
}
}
}
catch (Exception ex)
{
Log.writeMessage(ex.Message);
}
return Ok();
}
}
}
