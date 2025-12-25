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
public class AdmSenderSubscriptionDAL
{
DbConnection conn = null;
public AdmSenderSubscriptionDAL()
{
conn = new DbConnection();
}
public List<AdmSenderSubscription> GetAllAdmSenderSubscription()
{
List<AdmSenderSubscription> admSenderSubscriptionList = new List<AdmSenderSubscription>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllAdmSenderSubscription", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
AdmSenderSubscription admSenderSubscription = new AdmSenderSubscription();
admSenderSubscription.AdmSenderSubscriptionld  = Convert.ToInt32(dr["AdmSenderSubscriptionld "]);
admSenderSubscription.Title = Convert.ToString(dr["Title"]);
admSenderSubscription.SubTitle = Convert.ToString(dr["SubTitle"]);
admSenderSubscription.Description = Convert.ToString(dr["Description"]);
admSenderSubscription.Price = Convert.ToString(dr["Price"]);
admSenderSubscription.PlanPeriod = Convert.ToString(dr["PlanPeriod"]);
admSenderSubscription.Status = Convert.ToString(dr["Status"]);
admSenderSubscription.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admSenderSubscription.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admSenderSubscription.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admSenderSubscription.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
admSenderSubscriptionList.Add(admSenderSubscription);
}
con.Close();
return admSenderSubscriptionList;
}
public AdmSenderSubscription GetAdmSenderSubscriptionById(int AdmSenderSubscriptionld )
{
AdmSenderSubscription admSenderSubscription = new AdmSenderSubscription();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetAdmSenderSubscriptionById" , con);
cmd.Parameters.Add("AdmSenderSubscriptionld ", SqlDbType.Int).Value = AdmSenderSubscriptionld ;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
admSenderSubscription.AdmSenderSubscriptionld  = Convert.ToInt32(dr["AdmSenderSubscriptionld "]);
admSenderSubscription.Title = Convert.ToString(dr["Title"]);
admSenderSubscription.SubTitle = Convert.ToString(dr["SubTitle"]);
admSenderSubscription.Description = Convert.ToString(dr["Description"]);
admSenderSubscription.Price = Convert.ToString(dr["Price"]);
admSenderSubscription.PlanPeriod = Convert.ToString(dr["PlanPeriod"]);
admSenderSubscription.Status = Convert.ToString(dr["Status"]);
admSenderSubscription.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admSenderSubscription.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admSenderSubscription.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admSenderSubscription.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return admSenderSubscription;
}
public string AddAdmSenderSubscription(AdmSenderSubscription admSenderSubscription)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddAdmSenderSubscription", con);
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = admSenderSubscription.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = admSenderSubscription.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = admSenderSubscription.Description;
cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = admSenderSubscription.Price;
cmd.Parameters.Add("PlanPeriod", SqlDbType.NVarChar).Value = admSenderSubscription.PlanPeriod;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admSenderSubscription.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admSenderSubscription.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admSenderSubscription.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admSenderSubscription.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admSenderSubscription.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmSenderSubscriptionld  = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmSenderSubscriptionld .ToString();
}
 [HttpPost]
public string UpdateAdmSenderSubscription(AdmSenderSubscription admSenderSubscription)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateAdmSenderSubscription" , con);
cmd.Parameters.Add("AdmSenderSubscriptionld ", SqlDbType.Int).Value = admSenderSubscription.AdmSenderSubscriptionld ;
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = admSenderSubscription.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = admSenderSubscription.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = admSenderSubscription.Description;
cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = admSenderSubscription.Price;
cmd.Parameters.Add("PlanPeriod", SqlDbType.NVarChar).Value = admSenderSubscription.PlanPeriod;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admSenderSubscription.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admSenderSubscription.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admSenderSubscription.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admSenderSubscription.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admSenderSubscription.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmSenderSubscriptionld  = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmSenderSubscriptionld .ToString();
}
public String DeleteAdmSenderSubscription(int AdmSenderSubscriptionld )
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteAdmSenderSubscription", con);
cmd.Parameters.Add("AdmSenderSubscriptionld ", SqlDbType.Int).Value = AdmSenderSubscriptionld ;
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
