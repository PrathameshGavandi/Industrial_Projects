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
    public class FeedbackController : ApiController
   {
   public Logger Log = null;
       public FeedbackController()
       {
       Log = Logger.GetLogger();
       }
FeedbackDAL feedbackDAL = new FeedbackDAL();
[HttpGet]
[ActionName("GetAllFeedback")]
public List<Feedback> GetAllFeedback()
{
Log.writeMessage("FeedbackController GetAllFeedback Start");
List<Feedback> list = null;
try
{
list = feedbackDAL.GetAllFeedback();
}
catch (Exception ex)
{
Log.writeMessage("FeedbackController GetAllFeedback Error " + ex.Message);
}
Log.writeMessage("FeedbackController GetAllFeedback End ");
return list;
}
 [HttpGet]
 [ActionName("GetFeedbackById")]
 public Feedback GetFeedbackById(int FeedbackId )
{
Log.writeMessage("FeedbackController GetFeedbackById Start");
Feedback feedback = null;
try
{
feedback = feedbackDAL.GetFeedbackById(FeedbackId);
}
catch (Exception ex)
{
Log.writeMessage("FeedbackController GetFeedbackById Error " + ex.Message);
}
Log.writeMessage("FeedbackController GetFeedbackById End");
return feedback;
}
[HttpPost]
 [ActionName("AddFeedback")]
 public IHttpActionResult AddFeedback(Feedback feedback)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
feedback.CreatedBy = "Admin";
feedback.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
feedback.UpdatedBy = "Admin";
feedback.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = feedbackDAL.AddFeedback(feedback);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("FeedbackController AddFeedback Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateFeedback")]
 public IHttpActionResult UpdateFeedback(Feedback feedback)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
feedback.CreatedBy = "Admin";
feedback.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
feedback.UpdatedBy = "Admin";
feedback.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = feedbackDAL.UpdateFeedback(feedback);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("FeedbackController UpdateFeedback Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteFeedback(int FeedbackId)
{
 try
 {
var result = feedbackDAL.DeleteFeedback(FeedbackId);
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
Log.writeMessage("FeedbackController DeleteFeedback Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
