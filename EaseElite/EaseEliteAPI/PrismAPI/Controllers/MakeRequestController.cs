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
    public class MakeRequestController : ApiController
   {
   public Logger Log = null;
       public MakeRequestController()
       {
       Log = Logger.GetLogger();
       }
MakeRequestDAL makeRequestDAL = new MakeRequestDAL();
[HttpGet]
[ActionName("GetAllMakeRequest")]
public List<MakeRequest> GetAllMakeRequest()
{
Log.writeMessage("MakeRequestController GetAllMakeRequest Start");
List<MakeRequest> list = null;
try
{
list = makeRequestDAL.GetAllMakeRequest();
}
catch (Exception ex)
{
Log.writeMessage("MakeRequestController GetAllMakeRequest Error " + ex.Message);
}
Log.writeMessage("MakeRequestController GetAllMakeRequest End ");
return list;
}
 [HttpGet]
 [ActionName("GetMakeRequestById")]
 public MakeRequest GetMakeRequestById(int MakeRequestId )
{
Log.writeMessage("MakeRequestController GetMakeRequestById Start");
MakeRequest makeRequest = null;
try
{
makeRequest = makeRequestDAL.GetMakeRequestById(MakeRequestId);
}
catch (Exception ex)
{
Log.writeMessage("MakeRequestController GetMakeRequestById Error " + ex.Message);
}
Log.writeMessage("MakeRequestController GetMakeRequestById End");
return makeRequest;
}
[HttpPost]
 [ActionName("AddMakeRequest")]
 public IHttpActionResult AddMakeRequest(MakeRequest makeRequest)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
makeRequest.CreatedBy = "Admin";
makeRequest.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
makeRequest.UpdatedBy = "Admin";
makeRequest.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = makeRequestDAL.AddMakeRequest(makeRequest);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("MakeRequestController AddMakeRequest Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateMakeRequest")]
 public IHttpActionResult UpdateMakeRequest(MakeRequest makeRequest)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
makeRequest.CreatedBy = "Admin";
makeRequest.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
makeRequest.UpdatedBy = "Admin";
makeRequest.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = makeRequestDAL.UpdateMakeRequest(makeRequest);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("MakeRequestController UpdateMakeRequest Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteMakeRequest(int MakeRequestId)
{
 try
 {
var result = makeRequestDAL.DeleteMakeRequest(MakeRequestId);
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
Log.writeMessage("MakeRequestController DeleteMakeRequest Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
