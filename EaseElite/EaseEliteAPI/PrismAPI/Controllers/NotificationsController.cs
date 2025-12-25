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
    public class NotificationsController : ApiController
   {
   public Logger Log = null;
       public NotificationsController()
       {
       Log = Logger.GetLogger();
       }
NotificationsDAL notificationsDAL = new NotificationsDAL();
[HttpGet]
[ActionName("GetAllNotifications")]
public List<Notifications> GetAllNotifications()
{
Log.writeMessage("NotificationsController GetAllNotifications Start");
List<Notifications> list = null;
try
{
list = notificationsDAL.GetAllNotifications();
}
catch (Exception ex)
{
Log.writeMessage("NotificationsController GetAllNotifications Error " + ex.Message);
}
Log.writeMessage("NotificationsController GetAllNotifications End ");
return list;
}
 [HttpGet]
 [ActionName("GetNotificationsById")]
 public Notifications GetNotificationsById(int NotificationsId )
{
Log.writeMessage("NotificationsController GetNotificationsById Start");
Notifications notifications = null;
try
{
notifications = notificationsDAL.GetNotificationsById(NotificationsId);
}
catch (Exception ex)
{
Log.writeMessage("NotificationsController GetNotificationsById Error " + ex.Message);
}
Log.writeMessage("NotificationsController GetNotificationsById End");
return notifications;
}
[HttpPost]
 [ActionName("AddNotifications")]
 public IHttpActionResult AddNotifications(Notifications notifications)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
notifications.CreatedBy = "Admin";
notifications.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
notifications.UpdatedBy = "Admin";
notifications.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = notificationsDAL.AddNotifications(notifications);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("NotificationsController AddNotifications Error " + ex.Message);
}
return Ok(result);
}
[HttpPost]
 [ActionName("UpdateNotifications")]
 public IHttpActionResult UpdateNotifications(Notifications notifications)
 {
var result = "";
 try
 {
 if (!ModelState.IsValid)
 {
  return BadRequest(ModelState);
 }
notifications.CreatedBy = "Admin";
notifications.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
notifications.UpdatedBy = "Admin";
notifications.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
result = notificationsDAL.UpdateNotifications(notifications);
if (result.ToString() == "0")
{
return Ok("Failed");
}
}
catch (Exception ex)
{
Log.writeMessage("NotificationsController UpdateNotifications Error " + ex.Message);
}
return Ok(result);
}
 public IHttpActionResult DeleteNotifications(int NotificationsId)
{
 try
 {
var result = notificationsDAL.DeleteNotifications(NotificationsId);
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
Log.writeMessage("NotificationsController DeleteNotifications Error "  + ex.Message);
}
return Ok("Failed");
}
}
}
