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
    public class RefferalController : ApiController
   {
   public Logger Log = null;
       public RefferalController()
       {
       Log = Logger.GetLogger();
       }
RefferalDAL refferalDAL = new RefferalDAL();
[HttpGet]
[ActionName("GetAllRefferal")]
public List<Refferal> GetAllRefferal()
{
Log.writeMessage("RefferalController GetAllRefferal Start");
List<Refferal> list = null;
try
{
list = refferalDAL.GetAllRefferal();
}
catch (Exception ex)
{
Log.writeMessage("RefferalController GetAllRefferal Error " + ex.Message);
}
Log.writeMessage("RefferalController GetAllRefferal End ");
return list;
}
 [HttpGet]
 [ActionName("GetRefferalById")]
 public Refferal GetRefferalById(int RefferalId )
{
Log.writeMessage("RefferalController GetRefferalById Start");
Refferal refferal = null;
try
{
refferal = refferalDAL.GetRefferalById(RefferalId);
}
catch (Exception ex)
{
Log.writeMessage("RefferalController GetRefferalById Error " + ex.Message);
}
Log.writeMessage("RefferalController GetRefferalById End");
return refferal;
}
[HttpPost]
 [ActionName("AddRefferal")]
 public IHttpActionResult AddRefferal(Refferal refferal)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
refferal.CreatedBy = "Admin";
refferal.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
refferal.UpdatedBy = "Admin";
refferal.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = refferalDAL.AddRefferal(refferal);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("RefferalController AddRefferal Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateRefferal")]
 public IHttpActionResult UpdateRefferal(Refferal refferal)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
refferal.CreatedBy = "Admin";
refferal.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
refferal.UpdatedBy = "Admin";
refferal.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = refferalDAL.UpdateRefferal(refferal);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("RefferalController UpdateRefferal Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteRefferal(int RefferalId)
{
 try
 {
var result = refferalDAL.DeleteRefferal(RefferalId);
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
Log.writeMessage("RefferalController DeleteRefferal Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
