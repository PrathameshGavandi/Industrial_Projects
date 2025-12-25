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
    public class AdmELInfoController : ApiController
   {
   public Logger Log = null;
       public AdmELInfoController()
       {
       Log = Logger.GetLogger();
       }
AdmELInfoDAL admELInfoDAL = new AdmELInfoDAL();
[HttpGet]
[ActionName("GetAllAdmELInfo")]
public List<AdmELInfo> GetAllAdmELInfo()
{
Log.writeMessage("AdmELInfoController GetAllAdmELInfo Start");
List<AdmELInfo> list = null;
try
{
list = admELInfoDAL.GetAllAdmELInfo();
}
catch (Exception ex)
{
Log.writeMessage("AdmELInfoController GetAllAdmELInfo Error " + ex.Message);
}
Log.writeMessage("AdmELInfoController GetAllAdmELInfo End ");
return list;
}
 [HttpGet]
 [ActionName("GetAdmELInfoById")]
 public AdmELInfo GetAdmELInfoById(int AdmELInfoId )
{
Log.writeMessage("AdmELInfoController GetAdmELInfoById Start");
AdmELInfo admELInfo = null;
try
{
admELInfo = admELInfoDAL.GetAdmELInfoById(AdmELInfoId);
}
catch (Exception ex)
{
Log.writeMessage("AdmELInfoController GetAdmELInfoById Error " + ex.Message);
}
Log.writeMessage("AdmELInfoController GetAdmELInfoById End");
return admELInfo;
}
[HttpPost]
 [ActionName("AddAdmELInfo")]
 public IHttpActionResult AddAdmELInfo(AdmELInfo admELInfo)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admELInfo.CreatedBy = "Admin";
admELInfo.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admELInfo.UpdatedBy = "Admin";
admELInfo.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admELInfoDAL.AddAdmELInfo(admELInfo);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmELInfoController AddAdmELInfo Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateAdmELInfo")]
 public IHttpActionResult UpdateAdmELInfo(AdmELInfo admELInfo)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admELInfo.CreatedBy = "Admin";
admELInfo.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admELInfo.UpdatedBy = "Admin";
admELInfo.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admELInfoDAL.UpdateAdmELInfo(admELInfo);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmELInfoController UpdateAdmELInfo Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteAdmELInfo(int AdmELInfoId)
{
 try
 {
var result = admELInfoDAL.DeleteAdmELInfo(AdmELInfoId);
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
Log.writeMessage("AdmELInfoController DeleteAdmELInfo Error "  + ex.Message);
}
return Ok("Failed");
}


        [HttpPost]
        public async Task<IHttpActionResult> SaveAdmElinfoImage(int AdmELInfoId)
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
                    File.WriteAllBytes(theDirectory + "/Content/Elinfo" + "/" + AdmELInfoId + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.
                    // get existing rocrd
                    var elinfo = admELInfoDAL.GetAdmELInfoById(AdmELInfoId);
                    var filenamenew = AdmELInfoId + "_" + filename;
                    if (elinfo.Logo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/Elinfo" + "/" + elinfo.Logo);
                        elinfo.Logo = AdmELInfoId + "_" + filename;
                        var result = admELInfoDAL.UpdateAdmELInfo(elinfo);
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
