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
public class CompanionPurchasePlanDAL
{
DbConnection conn = null;
public CompanionPurchasePlanDAL()
{
conn = new DbConnection();
}
public List<CompanionPurchasePlan> GetAllCompanionPurchasePlan()
{
List<CompanionPurchasePlan> companionPurchasePlanList = new List<CompanionPurchasePlan>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllCompanionPurchasePlan", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
CompanionPurchasePlan companionPurchasePlan = new CompanionPurchasePlan();
companionPurchasePlan.CompanionPurchasePlanId = Convert.ToInt32(dr["CompanionPurchasePlanId"]);
companionPurchasePlan.CompanionSubscriptionId = Convert.ToInt32(dr["CompanionSubscriptionId"]);
companionPurchasePlan.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
companionPurchasePlan.OfferedFor = Convert.ToString(dr["OfferedFor"]);
companionPurchasePlan.NextRenewalDate = Convert.ToString(dr["NextRenewalDate"]);
companionPurchasePlan.Status = Convert.ToString(dr["Status"]);
companionPurchasePlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
companionPurchasePlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
companionPurchasePlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
companionPurchasePlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
companionPurchasePlanList.Add(companionPurchasePlan);
}
con.Close();
return companionPurchasePlanList;
}
public CompanionPurchasePlan GetCompanionPurchasePlanById(int CompanionPurchasePlanId)
{
CompanionPurchasePlan companionPurchasePlan = new CompanionPurchasePlan();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetCompanionPurchasePlanById" , con);
cmd.Parameters.Add("CompanionPurchasePlanId", SqlDbType.Int).Value = CompanionPurchasePlanId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
companionPurchasePlan.CompanionPurchasePlanId = Convert.ToInt32(dr["CompanionPurchasePlanId"]);
companionPurchasePlan.CompanionSubscriptionId = Convert.ToInt32(dr["CompanionSubscriptionId"]);
companionPurchasePlan.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
companionPurchasePlan.OfferedFor = Convert.ToString(dr["OfferedFor"]);
companionPurchasePlan.NextRenewalDate = Convert.ToString(dr["NextRenewalDate"]);
companionPurchasePlan.Status = Convert.ToString(dr["Status"]);
companionPurchasePlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
companionPurchasePlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
companionPurchasePlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
companionPurchasePlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return companionPurchasePlan;
}
public string AddCompanionPurchasePlan(CompanionPurchasePlan companionPurchasePlan)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddCompanionPurchasePlan", con);
cmd.Parameters.Add("CompanionSubscriptionId", SqlDbType.Int).Value = companionPurchasePlan.CompanionSubscriptionId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = companionPurchasePlan.RegistrationId;
cmd.Parameters.Add("OfferedFor", SqlDbType.NVarChar).Value = companionPurchasePlan.OfferedFor;
cmd.Parameters.Add("NextRenewalDate", SqlDbType.NVarChar).Value = companionPurchasePlan.NextRenewalDate;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = companionPurchasePlan.Status;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = companionPurchasePlan.CreatedBy;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = companionPurchasePlan.CreatedDate;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = companionPurchasePlan.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = companionPurchasePlan.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CompanionPurchasePlanId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CompanionPurchasePlanId.ToString();
}
 [HttpPost]
public string UpdateCompanionPurchasePlan(CompanionPurchasePlan companionPurchasePlan)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateCompanionPurchasePlan" , con);
cmd.Parameters.Add("CompanionPurchasePlanId", SqlDbType.Int).Value = companionPurchasePlan.CompanionPurchasePlanId;
cmd.Parameters.Add("CompanionSubscriptionId", SqlDbType.Int).Value = companionPurchasePlan.CompanionSubscriptionId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = companionPurchasePlan.RegistrationId;
cmd.Parameters.Add("OfferedFor", SqlDbType.NVarChar).Value = companionPurchasePlan.OfferedFor;
cmd.Parameters.Add("NextRenewalDate", SqlDbType.NVarChar).Value = companionPurchasePlan.NextRenewalDate;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = companionPurchasePlan.Status;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = companionPurchasePlan.CreatedBy;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = companionPurchasePlan.CreatedDate;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = companionPurchasePlan.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = companionPurchasePlan.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CompanionPurchasePlanId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CompanionPurchasePlanId.ToString();
}
public String DeleteCompanionPurchasePlan(int CompanionPurchasePlanId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteCompanionPurchasePlan", con);
cmd.Parameters.Add("CompanionPurchasePlanId", SqlDbType.Int).Value = CompanionPurchasePlanId;
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
