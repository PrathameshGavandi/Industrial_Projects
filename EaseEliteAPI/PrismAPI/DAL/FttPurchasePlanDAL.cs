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
public class FttPurchasePlanDAL
{
DbConnection conn = null;
public FttPurchasePlanDAL()
{
conn = new DbConnection();
}
public List<FttPurchasePlan> GetAllFttPurchasePlan()
{
List<FttPurchasePlan> fttPurchasePlanList = new List<FttPurchasePlan>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllFttPurchasePlan", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
FttPurchasePlan fttPurchasePlan = new FttPurchasePlan();
fttPurchasePlan.FttPurchasePlanId = Convert.ToInt32(dr["FttPurchasePlanId"]);
fttPurchasePlan.fttSubscription = new FttSubscription();
fttPurchasePlan.FttSubscriptionId = Convert.ToInt32(dr["FttSubscriptionId"]);
//fttPurchasePlan.fttSubscription.Title = Convert.ToString(dr["Title1"]);
fttPurchasePlan.registration = new Registration();
fttPurchasePlan.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
//fttPurchasePlan.registration.FName = Convert.ToString(dr["FName1"]);
fttPurchasePlan.OfferedFor = Convert.ToString(dr["OfferedFor"]);
fttPurchasePlan.NextRenewalDate = Convert.ToString(dr["NextRenewalDate"]);
fttPurchasePlan.Status = Convert.ToString(dr["Status"]);
fttPurchasePlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
fttPurchasePlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
fttPurchasePlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
fttPurchasePlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
fttPurchasePlanList.Add(fttPurchasePlan);
}
con.Close();
return fttPurchasePlanList;
}
public FttPurchasePlan GetFttPurchasePlanById(int FttPurchasePlanId)
{
FttPurchasePlan fttPurchasePlan = new FttPurchasePlan();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetFttPurchasePlanById" , con);
cmd.Parameters.Add("FttPurchasePlanId", SqlDbType.Int).Value = FttPurchasePlanId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
fttPurchasePlan.FttPurchasePlanId = Convert.ToInt32(dr["FttPurchasePlanId"]);
fttPurchasePlan.fttSubscription = new FttSubscription();
fttPurchasePlan.fttSubscription.FttSubscriptionId = Convert.ToInt32(dr["FttSubscriptionId"]);
fttPurchasePlan.fttSubscription.Title = Convert.ToString(dr["Title1"]);
fttPurchasePlan.registration = new Registration();
fttPurchasePlan.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
fttPurchasePlan.registration.FName = Convert.ToString(dr["FName1"]);
fttPurchasePlan.OfferedFor = Convert.ToString(dr["OfferedFor"]);
fttPurchasePlan.NextRenewalDate = Convert.ToString(dr["NextRenewalDate"]);
fttPurchasePlan.Status = Convert.ToString(dr["Status"]);
fttPurchasePlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
fttPurchasePlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
fttPurchasePlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
fttPurchasePlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return fttPurchasePlan;
}
public string AddFttPurchasePlan(FttPurchasePlan fttPurchasePlan)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddFttPurchasePlan", con);
cmd.Parameters.Add("FttSubscriptionId", SqlDbType.Int).Value = fttPurchasePlan.FttSubscriptionId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = fttPurchasePlan.RegistrationId;
cmd.Parameters.Add("OfferedFor", SqlDbType.NVarChar).Value = fttPurchasePlan.OfferedFor;
cmd.Parameters.Add("NextRenewalDate", SqlDbType.NVarChar).Value = fttPurchasePlan.NextRenewalDate;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = fttPurchasePlan.Status;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = fttPurchasePlan.CreatedBy;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = fttPurchasePlan.CreatedDate;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = fttPurchasePlan.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = fttPurchasePlan.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var FttPurchasePlanId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return FttPurchasePlanId.ToString();
}
 [HttpPost]
public string UpdateFttPurchasePlan(FttPurchasePlan fttPurchasePlan)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateFttPurchasePlan" , con);
cmd.Parameters.Add("FttPurchasePlanId", SqlDbType.Int).Value = fttPurchasePlan.FttPurchasePlanId;
cmd.Parameters.Add("FttSubscriptionId", SqlDbType.Int).Value = fttPurchasePlan.FttSubscriptionId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = fttPurchasePlan.RegistrationId;
cmd.Parameters.Add("OfferedFor", SqlDbType.NVarChar).Value = fttPurchasePlan.OfferedFor;
cmd.Parameters.Add("NextRenewalDate", SqlDbType.NVarChar).Value = fttPurchasePlan.NextRenewalDate;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = fttPurchasePlan.Status;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = fttPurchasePlan.CreatedBy;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = fttPurchasePlan.CreatedDate;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = fttPurchasePlan.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = fttPurchasePlan.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var FttPurchasePlanId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return FttPurchasePlanId.ToString();
}
public String DeleteFttPurchasePlan(int FttPurchasePlanId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteFttPurchasePlan", con);
cmd.Parameters.Add("FttPurchasePlanId", SqlDbType.Int).Value = FttPurchasePlanId;
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
