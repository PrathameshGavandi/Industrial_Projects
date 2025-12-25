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
    public class UserRoleController : ApiController
   {
   public Logger Log = null;
       public UserRoleController()
       {
       Log = Logger.GetLogger();
       }
UserRoleDAL userRoleDAL = new UserRoleDAL();
[HttpGet]
[ActionName("GetAllUserRole")]
public List<UserRole> GetAllUserRole()
{
Log.writeMessage("UserRoleController GetAllUserRole Start");
List<UserRole> list = null;
try
{
list = userRoleDAL.GetAllUserRole();
}
catch (Exception ex)
{
Log.writeMessage("UserRoleController GetAllUserRole Error " + ex.Message);
}
Log.writeMessage("UserRoleController GetAllUserRole End ");
return list;
}
 [HttpGet]
 [ActionName("GetUserRoleById")]
 public UserRole GetUserRoleById(int UserRoleId )
{
Log.writeMessage("UserRoleController GetUserRoleById Start");
UserRole userRole = null;
try
{
userRole = userRoleDAL.GetUserRoleById(UserRoleId);
}
catch (Exception ex)
{
Log.writeMessage("UserRoleController GetUserRoleById Error " + ex.Message);
}
Log.writeMessage("UserRoleController GetUserRoleById End");
return userRole;
}
[HttpPost]
 [ActionName("AddUserRole")]
 public IHttpActionResult AddUserRole(UserRole userRole)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
userRole.CreatedBy = "Admin";
userRole.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
userRole.UpdatedBy = "Admin";
userRole.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = userRoleDAL.AddUserRole(userRole);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("UserRoleController AddUserRole Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateUserRole")]
 public IHttpActionResult UpdateUserRole(UserRole userRole)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
userRole.CreatedBy = "Admin";
userRole.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
userRole.UpdatedBy = "Admin";
userRole.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = userRoleDAL.UpdateUserRole(userRole);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("UserRoleController UpdateUserRole Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteUserRole(int UserRoleId)
{
 try
 {
var result = userRoleDAL.DeleteUserRole(UserRoleId);
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
Log.writeMessage("UserRoleController DeleteUserRole Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
