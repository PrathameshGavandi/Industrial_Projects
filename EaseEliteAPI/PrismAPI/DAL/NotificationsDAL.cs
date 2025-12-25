using System;
using System.Collections.Generic;
using System.Linq;
 using System.Web;
 using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;
using PrismAPI.DAL;
using System.Data.Common;
 namespace PrismAPI.DAL
{
public class NotificationsDAL
{
DbConnection conn = null;
public NotificationsDAL()
{
conn = new DbConnection();
}
public List<Notifications> GetAllNotifications()
{
List<Notifications> notificationsList = new List<Notifications>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllNotifications", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
Notifications notifications = new Notifications();
notifications.NotificationsId = Convert.ToInt32(dr["NotificationsId"]);
notifications.Message = Convert.ToString(dr["Message"]);
notifications.Status = Convert.ToString(dr["Status"]);
notifications.Status1 = Convert.ToString(dr["Status1"]);
notifications.CreatedDate = Convert.ToString(dr["CreatedDate"]);
notifications.CreatedBy = Convert.ToString(dr["CreatedBy"]);
notifications.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
notifications.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
notificationsList.Add(notifications);
}
con.Close();
return notificationsList;
}
public Notifications GetNotificationsById(int NotificationsId)
{
Notifications notifications = new Notifications();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetNotificationsById" , con);
cmd.Parameters.Add("NotificationsId", SqlDbType.Int).Value = NotificationsId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
notifications.NotificationsId = Convert.ToInt32(dr["NotificationsId"]);
notifications.Message = Convert.ToString(dr["Message"]);
notifications.Status = Convert.ToString(dr["Status"]);
notifications.Status1 = Convert.ToString(dr["Status1"]);
notifications.CreatedDate = Convert.ToString(dr["CreatedDate"]);
notifications.CreatedBy = Convert.ToString(dr["CreatedBy"]);
notifications.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
notifications.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return notifications;
}
public string AddNotifications(Notifications notifications)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddNotifications", con);
cmd.Parameters.Add("Message", SqlDbType.NVarChar).Value = notifications.Message;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = notifications.Status;
cmd.Parameters.Add("Status1", SqlDbType.NVarChar).Value = notifications.Status1;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = notifications.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = notifications.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = notifications.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = notifications.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var NotificationsId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return NotificationsId.ToString();
}
 [HttpPost]
public string UpdateNotifications(Notifications notifications)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateNotifications" , con);
cmd.Parameters.Add("NotificationsId", SqlDbType.Int).Value = notifications.NotificationsId;
cmd.Parameters.Add("Message", SqlDbType.NVarChar).Value = notifications.Message;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = notifications.Status;
cmd.Parameters.Add("Status1", SqlDbType.NVarChar).Value = notifications.Status1;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = notifications.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = notifications.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = notifications.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = notifications.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var NotificationsId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return NotificationsId.ToString();
}
public String DeleteNotifications(int NotificationsId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteNotifications", con);
cmd.Parameters.Add("NotificationsId", SqlDbType.Int).Value = NotificationsId;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return "Success";
}
}
}
