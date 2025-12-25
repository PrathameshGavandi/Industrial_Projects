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
    public class AdmRoleController : ApiController
   {
   public Logger Log = null;
       public AdmRoleController()
       {
       Log = Logger.GetLogger();
       }
AdmRoleDAL admRoleDAL = new AdmRoleDAL();
[HttpGet]
[ActionName("GetAllAdmRole")]
public List<AdmRole> GetAllAdmRole()
{
Log.writeMessage("AdmRoleController GetAllAdmRole Start");
List<AdmRole> list = null;
try
{
list = admRoleDAL.GetAllAdmRole();
}
catch (Exception ex)
{
Log.writeMessage("AdmRoleController GetAllAdmRole Error " + ex.Message);
}
Log.writeMessage("AdmRoleController GetAllAdmRole End ");
return list;
}
 [HttpGet]
 [ActionName("GetAdmRoleById")]
 public AdmRole GetAdmRoleById(int AdmRoleId )
{
Log.writeMessage("AdmRoleController GetAdmRoleById Start");
AdmRole admRole = null;
try
{
admRole = admRoleDAL.GetAdmRoleById(AdmRoleId);
}
catch (Exception ex)
{
Log.writeMessage("AdmRoleController GetAdmRoleById Error " + ex.Message);
}
Log.writeMessage("AdmRoleController GetAdmRoleById End");
return admRole;
}
[HttpPost]
 [ActionName("AddAdmRole")]
 public IHttpActionResult AddAdmRole(AdmRole admRole)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admRole.CreatedBy = "Admin";
admRole.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admRole.UpdatedBy = "Admin";
admRole.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admRoleDAL.AddAdmRole(admRole);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmRoleController AddAdmRole Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateAdmRole")]
 public IHttpActionResult UpdateAdmRole(AdmRole admRole)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
admRole.CreatedBy = "Admin";
admRole.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
admRole.UpdatedBy = "Admin";
admRole.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = admRoleDAL.UpdateAdmRole(admRole);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("AdmRoleController UpdateAdmRole Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteAdmRole(int AdmRoleId)
{
 try
 {
var result = admRoleDAL.DeleteAdmRole(AdmRoleId);
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
Log.writeMessage("AdmRoleController DeleteAdmRole Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
