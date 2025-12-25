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
public class AdmCompSubscriptionDAL
{
DbConnection conn = null;
public AdmCompSubscriptionDAL()
{
conn = new DbConnection();
}
public List<AdmCompSubscription> GetAllAdmCompSubscription()
{
List<AdmCompSubscription> admCompSubscriptionList = new List<AdmCompSubscription>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllAdmCompSubscription", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
AdmCompSubscription admCompSubscription = new AdmCompSubscription();
admCompSubscription.AdmCompSubscriptionld  = Convert.ToInt32(dr["AdmCompSubscriptionld "]);
admCompSubscription.Title = Convert.ToString(dr["Title"]);
admCompSubscription.SubTitle = Convert.ToString(dr["SubTitle"]);
admCompSubscription.Description = Convert.ToString(dr["Description"]);
admCompSubscription.Price = Convert.ToString(dr["Price"]);
admCompSubscription.PlanPeriod = Convert.ToString(dr["PlanPeriod"]);
admCompSubscription.Status = Convert.ToString(dr["Status"]);
admCompSubscription.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admCompSubscription.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admCompSubscription.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admCompSubscription.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
admCompSubscriptionList.Add(admCompSubscription);
}
con.Close();
return admCompSubscriptionList;
}
public AdmCompSubscription GetAdmCompSubscriptionById(int AdmCompSubscriptionld )
{
AdmCompSubscription admCompSubscription = new AdmCompSubscription();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetAdmCompSubscriptionById" , con);
cmd.Parameters.Add("AdmCompSubscriptionld ", SqlDbType.Int).Value = AdmCompSubscriptionld ;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
admCompSubscription.AdmCompSubscriptionld  = Convert.ToInt32(dr["AdmCompSubscriptionld "]);
admCompSubscription.Title = Convert.ToString(dr["Title"]);
admCompSubscription.SubTitle = Convert.ToString(dr["SubTitle"]);
admCompSubscription.Description = Convert.ToString(dr["Description"]);
admCompSubscription.Price = Convert.ToString(dr["Price"]);
admCompSubscription.PlanPeriod = Convert.ToString(dr["PlanPeriod"]);
admCompSubscription.Status = Convert.ToString(dr["Status"]);
admCompSubscription.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admCompSubscription.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admCompSubscription.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admCompSubscription.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return admCompSubscription;
}
public string AddAdmCompSubscription(AdmCompSubscription admCompSubscription)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddAdmCompSubscription", con);
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = admCompSubscription.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = admCompSubscription.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = admCompSubscription.Description;
cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = admCompSubscription.Price;
cmd.Parameters.Add("PlanPeriod", SqlDbType.NVarChar).Value = admCompSubscription.PlanPeriod;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admCompSubscription.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admCompSubscription.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admCompSubscription.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admCompSubscription.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admCompSubscription.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmCompSubscriptionld  = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmCompSubscriptionld .ToString();
}
 [HttpPost]
public string UpdateAdmCompSubscription(AdmCompSubscription admCompSubscription)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateAdmCompSubscription" , con);
cmd.Parameters.Add("AdmCompSubscriptionld ", SqlDbType.Int).Value = admCompSubscription.AdmCompSubscriptionld ;
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = admCompSubscription.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = admCompSubscription.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = admCompSubscription.Description;
cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = admCompSubscription.Price;
cmd.Parameters.Add("PlanPeriod", SqlDbType.NVarChar).Value = admCompSubscription.PlanPeriod;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admCompSubscription.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admCompSubscription.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admCompSubscription.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admCompSubscription.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admCompSubscription.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmCompSubscriptionld  = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmCompSubscriptionld .ToString();
}
public String DeleteAdmCompSubscription(int AdmCompSubscriptionld )
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteAdmCompSubscription", con);
cmd.Parameters.Add("AdmCompSubscriptionld ", SqlDbType.Int).Value = AdmCompSubscriptionld ;
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
