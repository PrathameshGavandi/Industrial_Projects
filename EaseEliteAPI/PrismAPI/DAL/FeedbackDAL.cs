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
public class FeedbackDAL
{
DbConnection conn = null;
public FeedbackDAL()
{
conn = new DbConnection();
}
public List<Feedback> GetAllFeedback()
{
List<Feedback> feedbackList = new List<Feedback>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllFeedback", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
Feedback feedback = new Feedback();
feedback.FeedbackId = Convert.ToInt32(dr["FeedbackId"]);
feedback.registration = new Registration();
feedback.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
feedback.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
feedback.Description = Convert.ToString(dr["Description"]);
feedback.CreatedDate = Convert.ToString(dr["CreatedDate"]);
feedback.CreatedBy = Convert.ToString(dr["CreatedBy"]);
feedback.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
feedback.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

feedbackList.Add(feedback);
}
con.Close();
return feedbackList;
}
public Feedback GetFeedbackById(int FeedbackId)
{
Feedback feedback = new Feedback();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetFeedbackById" , con);
cmd.Parameters.Add("FeedbackId", SqlDbType.Int).Value = FeedbackId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
feedback.FeedbackId = Convert.ToInt32(dr["FeedbackId"]);
feedback.registration = new Registration();
feedback.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
feedback.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
feedback.Description = Convert.ToString(dr["Description"]);
feedback.CreatedDate = Convert.ToString(dr["CreatedDate"]);
feedback.CreatedBy = Convert.ToString(dr["CreatedBy"]);
feedback.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
feedback.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);

}
con.Close();
return feedback;
}
public string AddFeedback(Feedback feedback)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddFeedback", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = feedback.RegistrationId;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = feedback.Description;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = feedback.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = feedback.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = feedback.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = feedback.UpdatedBy;

Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var FeedbackId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return FeedbackId.ToString();
}
 [HttpPost]
public string UpdateFeedback(Feedback feedback)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateFeedback" , con);
cmd.Parameters.Add("FeedbackId", SqlDbType.Int).Value = feedback.FeedbackId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = feedback.registration.RegistrationId;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = feedback.Description;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = feedback.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = feedback.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = feedback.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = feedback.UpdatedBy;

cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var FeedbackId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return FeedbackId.ToString();
}
public String DeleteFeedback(int FeedbackId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteFeedback", con);
cmd.Parameters.Add("FeedbackId", SqlDbType.Int).Value = FeedbackId;
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
