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
public class AdmCarrierSubscriptionDAL
{
DbConnection conn = null;
public AdmCarrierSubscriptionDAL()
{
conn = new DbConnection();
}
public List<AdmCarrierSubscription> GetAllAdmCarrierSubscription()
{
List<AdmCarrierSubscription> admCarrierSubscriptionList = new List<AdmCarrierSubscription>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllAdmCarrierSubscription", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
AdmCarrierSubscription admCarrierSubscription = new AdmCarrierSubscription();
admCarrierSubscription.AdmCarrierSubscriptionld   = Convert.ToInt32(dr["AdmCarrierSubscriptionld  "]);
admCarrierSubscription.Title = Convert.ToString(dr["Title"]);
admCarrierSubscription.SubTitle = Convert.ToString(dr["SubTitle"]);
admCarrierSubscription.Description = Convert.ToString(dr["Description"]);
admCarrierSubscription.Price = Convert.ToString(dr["Price"]);
admCarrierSubscription.PlanPeriod = Convert.ToString(dr["PlanPeriod"]);
admCarrierSubscription.Status = Convert.ToString(dr["Status"]);
admCarrierSubscription.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admCarrierSubscription.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admCarrierSubscription.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admCarrierSubscription.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
admCarrierSubscriptionList.Add(admCarrierSubscription);
}
con.Close();
return admCarrierSubscriptionList;
}
public AdmCarrierSubscription GetAdmCarrierSubscriptionById(int AdmCarrierSubscriptionld  )
{
AdmCarrierSubscription admCarrierSubscription = new AdmCarrierSubscription();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetAdmCarrierSubscriptionById" , con);
cmd.Parameters.Add("AdmCarrierSubscriptionld  ", SqlDbType.Int).Value = AdmCarrierSubscriptionld  ;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
admCarrierSubscription.AdmCarrierSubscriptionld   = Convert.ToInt32(dr["AdmCarrierSubscriptionld  "]);
admCarrierSubscription.Title = Convert.ToString(dr["Title"]);
admCarrierSubscription.SubTitle = Convert.ToString(dr["SubTitle"]);
admCarrierSubscription.Description = Convert.ToString(dr["Description"]);
admCarrierSubscription.Price = Convert.ToString(dr["Price"]);
admCarrierSubscription.PlanPeriod = Convert.ToString(dr["PlanPeriod"]);
admCarrierSubscription.Status = Convert.ToString(dr["Status"]);
admCarrierSubscription.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admCarrierSubscription.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admCarrierSubscription.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admCarrierSubscription.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return admCarrierSubscription;
}
public string AddAdmCarrierSubscription(AdmCarrierSubscription admCarrierSubscription)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddAdmCarrierSubscription", con);
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = admCarrierSubscription.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = admCarrierSubscription.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = admCarrierSubscription.Description;
cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = admCarrierSubscription.Price;
cmd.Parameters.Add("PlanPeriod", SqlDbType.NVarChar).Value = admCarrierSubscription.PlanPeriod;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admCarrierSubscription.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admCarrierSubscription.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admCarrierSubscription.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admCarrierSubscription.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admCarrierSubscription.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmCarrierSubscriptionld   = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmCarrierSubscriptionld  .ToString();
}
 [HttpPost]
public string UpdateAdmCarrierSubscription(AdmCarrierSubscription admCarrierSubscription)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateAdmCarrierSubscription" , con);
cmd.Parameters.Add("AdmCarrierSubscriptionld  ", SqlDbType.Int).Value = admCarrierSubscription.AdmCarrierSubscriptionld  ;
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = admCarrierSubscription.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = admCarrierSubscription.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = admCarrierSubscription.Description;
cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = admCarrierSubscription.Price;
cmd.Parameters.Add("PlanPeriod", SqlDbType.NVarChar).Value = admCarrierSubscription.PlanPeriod;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admCarrierSubscription.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admCarrierSubscription.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admCarrierSubscription.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admCarrierSubscription.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admCarrierSubscription.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmCarrierSubscriptionld   = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmCarrierSubscriptionld  .ToString();
}
public String DeleteAdmCarrierSubscription(int AdmCarrierSubscriptionld  )
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteAdmCarrierSubscription", con);
cmd.Parameters.Add("AdmCarrierSubscriptionld  ", SqlDbType.Int).Value = AdmCarrierSubscriptionld  ;
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
