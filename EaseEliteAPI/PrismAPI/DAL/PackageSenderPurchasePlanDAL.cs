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
public class PackageSenderPurchasePlanDAL
{
DbConnection conn = null;
public PackageSenderPurchasePlanDAL()
{
conn = new DbConnection();
}
public List<PackageSenderPurchasePlan> GetAllPackageSenderPurchasePlan()
{
List<PackageSenderPurchasePlan> packageSenderPurchasePlanList = new List<PackageSenderPurchasePlan>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllPackageSenderPurchasePlan", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
PackageSenderPurchasePlan packageSenderPurchasePlan = new PackageSenderPurchasePlan();
packageSenderPurchasePlan.PackageSenderPurchasePlanId = Convert.ToInt32(dr["PackageSenderPurchasePlanId"]);
packageSenderPurchasePlan.PackageSenderSubscriptionId = Convert.ToInt32(dr["PackageSenderSubscriptionId"]);
packageSenderPurchasePlan.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
packageSenderPurchasePlan.OfferedFor = Convert.ToString(dr["OfferedFor"]);
packageSenderPurchasePlan.NextRenewalDate = Convert.ToString(dr["NextRenewalDate"]);
packageSenderPurchasePlan.Status = Convert.ToString(dr["Status"]);
packageSenderPurchasePlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
packageSenderPurchasePlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
packageSenderPurchasePlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
packageSenderPurchasePlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
packageSenderPurchasePlanList.Add(packageSenderPurchasePlan);
}
con.Close();
return packageSenderPurchasePlanList;
}
public PackageSenderPurchasePlan GetPackageSenderPurchasePlanById(int PackageSenderPurchasePlanId)
{
PackageSenderPurchasePlan packageSenderPurchasePlan = new PackageSenderPurchasePlan();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetPackageSenderPurchasePlanById" , con);
cmd.Parameters.Add("PackageSenderPurchasePlanId", SqlDbType.Int).Value = PackageSenderPurchasePlanId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
packageSenderPurchasePlan.PackageSenderPurchasePlanId = Convert.ToInt32(dr["PackageSenderPurchasePlanId"]);
packageSenderPurchasePlan.PackageSenderSubscriptionId = Convert.ToInt32(dr["PackageSenderSubscriptionId"]);
packageSenderPurchasePlan.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
packageSenderPurchasePlan.OfferedFor = Convert.ToString(dr["OfferedFor"]);
packageSenderPurchasePlan.NextRenewalDate = Convert.ToString(dr["NextRenewalDate"]);
packageSenderPurchasePlan.Status = Convert.ToString(dr["Status"]);
packageSenderPurchasePlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
packageSenderPurchasePlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
packageSenderPurchasePlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
packageSenderPurchasePlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return packageSenderPurchasePlan;
}
public string AddPackageSenderPurchasePlan(PackageSenderPurchasePlan packageSenderPurchasePlan)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddPackageSenderPurchasePlan", con);
cmd.Parameters.Add("PackageSenderSubscriptionId", SqlDbType.Int).Value = packageSenderPurchasePlan.PackageSenderSubscriptionId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = packageSenderPurchasePlan.RegistrationId;
cmd.Parameters.Add("OfferedFor", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.OfferedFor;
cmd.Parameters.Add("NextRenewalDate", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.NextRenewalDate;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.Status;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.CreatedBy;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.CreatedDate;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var PackageSenderPurchasePlanId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return PackageSenderPurchasePlanId.ToString();
}
 [HttpPost]
public string UpdatePackageSenderPurchasePlan(PackageSenderPurchasePlan packageSenderPurchasePlan)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdatePackageSenderPurchasePlan" , con);
cmd.Parameters.Add("PackageSenderPurchasePlanId", SqlDbType.Int).Value = packageSenderPurchasePlan.PackageSenderPurchasePlanId;
cmd.Parameters.Add("PackageSenderSubscriptionId", SqlDbType.Int).Value = packageSenderPurchasePlan.PackageSenderSubscriptionId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = packageSenderPurchasePlan.RegistrationId;
cmd.Parameters.Add("OfferedFor", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.OfferedFor;
cmd.Parameters.Add("NextRenewalDate", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.NextRenewalDate;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.Status;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.CreatedBy;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.CreatedDate;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = packageSenderPurchasePlan.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var PackageSenderPurchasePlanId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return PackageSenderPurchasePlanId.ToString();
}
public String DeletePackageSenderPurchasePlan(int PackageSenderPurchasePlanId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeletePackageSenderPurchasePlan", con);
cmd.Parameters.Add("PackageSenderPurchasePlanId", SqlDbType.Int).Value = PackageSenderPurchasePlanId;
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
