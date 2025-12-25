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
    public class FttDetailController : ApiController
   {
   public Logger Log = null;
       public FttDetailController()
       {
       Log = Logger.GetLogger();
       }
FttDetailDAL fttDetailDAL = new FttDetailDAL();
[HttpGet]
[ActionName("GetAllFttDetail")]
public List<FttDetail> GetAllFttDetail()
{
Log.writeMessage("FttDetailController GetAllFttDetail Start");
List<FttDetail> list = null;
try
{
list = fttDetailDAL.GetAllFttDetail();
}
catch (Exception ex)
{
Log.writeMessage("FttDetailController GetAllFttDetail Error " + ex.Message);
}
Log.writeMessage("FttDetailController GetAllFttDetail End ");
return list;
}
 [HttpGet]
 [ActionName("GetFttDetailById")]
 public FttDetail GetFttDetailById(int FttId )
{
Log.writeMessage("FttDetailController GetFttDetailById Start");
FttDetail fttDetail = null;
try
{
fttDetail = fttDetailDAL.GetFttDetailById(FttId);
}
catch (Exception ex)
{
Log.writeMessage("FttDetailController GetFttDetailById Error " + ex.Message);
}
Log.writeMessage("FttDetailController GetFttDetailById End");
return fttDetail;
}
[HttpPost]
 [ActionName("AddFttDetail")]
 public IHttpActionResult AddFttDetail(FttDetail fttDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
//fttDetail.CreatedBy = "Admin";
fttDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
fttDetail.UpdatedBy = "Admin";
fttDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = fttDetailDAL.AddFttDetail(fttDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("FttDetailController AddFttDetail Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateFttDetail")]
 public IHttpActionResult UpdateFttDetail(FttDetail fttDetail)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
//fttDetail.CreatedBy = "Admin";
fttDetail.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
fttDetail.UpdatedBy = "Admin";
fttDetail.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = fttDetailDAL.UpdateFttDetail(fttDetail);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("FttDetailController UpdateFttDetail Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteFttDetail(int FttId)
{
 try
 {
var result = fttDetailDAL.DeleteFttDetail(FttId);
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
Log.writeMessage("FttDetailController DeleteFttDetail Error "  + ex.Message);
}
return Ok("Failed");
}
[HttpPost]
public async Task<IHttpActionResult> SaveFttDetailImage(int FttId)
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
File.WriteAllBytes(theDirectory + "/Content/FttDetail" + "/" + FttId +"_" + filename, buffer);
//Do whatever you want with filename and its binary data.
// get existing rocrd
var fttDetail = fttDetailDAL.GetFttDetailById(FttId);
var filenamenew = FttId + "_" + filename;
if (fttDetail.UploadTicket.ToLower() != filenamenew.ToLower())
{
File.Delete(theDirectory + "/Content/FttDetail" + "/"+ fttDetail.UploadTicket);
fttDetail.UploadTicket = FttId +"_" + filename; 
var result = fttDetailDAL.UpdateFttDetail(fttDetail);
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
