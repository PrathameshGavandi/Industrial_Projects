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
    public class AdmContactUsController : ApiController
   {
   public Logger Log = null;
       public AdmContactUsController()
       {
       Log = Logger.GetLogger();
       }
AdmContactUsDAL admContactUsDAL = new AdmContactUsDAL();
[HttpGet]
[ActionName("GetAllAdmContactUs")]
public List<AdmContactUs> GetAllAdmContactUs()
{
Log.writeMessage("AdmContactUsController GetAllAdmContactUs Start");
List<AdmContactUs> list = null;
try
{
list = admContactUsDAL.GetAllAdmContactUs();
}
catch (Exception ex)
{
Log.writeMessage("AdmContactUsController GetAllAdmContactUs Error " + ex.Message);
}
Log.writeMessage("AdmContactUsController GetAllAdmContactUs End ");
return list;
}
 [HttpGet]
 [ActionName("GetAdmContactUsById")]
 public AdmContactUs GetAdmContactUsById(int ContactUsId )
{
Log.writeMessage("AdmContactUsController GetAdmContactUsById Start");
AdmContactUs admContactUs = null;
try
{
admContactUs = admContactUsDAL.GetAdmContactUsById(ContactUsId);
}
catch (Exception ex)
{
Log.writeMessage("AdmContactUsController GetAdmContactUsById Error " + ex.Message);
}
Log.writeMessage("AdmContactUsController GetAdmContactUsById End");
return admContactUs;
}
[HttpPost]
 [ActionName("AddAdmContactUs")]
 public IHttpActionResult AddAdmContactUs(AdmContactUs admContactUs)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admContactUs.CreatedBy = "Admin";
admContactUs.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admContactUs.UpdatedBy = "Admin";
admContactUs.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admContactUsDAL.AddAdmContactUs(admContactUs);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmContactUsController AddAdmContactUs Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateAdmContactUs")]
 public IHttpActionResult UpdateAdmContactUs(AdmContactUs admContactUs)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admContactUs.CreatedBy = "Admin";
admContactUs.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admContactUs.UpdatedBy = "Admin";
admContactUs.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admContactUsDAL.UpdateAdmContactUs(admContactUs);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmContactUsController UpdateAdmContactUs Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteAdmContactUs(int ContactUsId)
{
 try
 {
var result = admContactUsDAL.DeleteAdmContactUs(ContactUsId);
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
Log.writeMessage("AdmContactUsController DeleteAdmContactUs Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
