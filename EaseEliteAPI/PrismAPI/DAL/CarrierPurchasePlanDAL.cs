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
public class CarrierPurchasePlanDAL
{
DbConnection conn = null;
public CarrierPurchasePlanDAL()
{
conn = new DbConnection();
}
public List<CarrierPurchasePlan> GetAllCarrierPurchasePlan()
{
List<CarrierPurchasePlan> carrierPurchasePlanList = new List<CarrierPurchasePlan>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllCarrierPurchasePlan", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
CarrierPurchasePlan carrierPurchasePlan = new CarrierPurchasePlan();
carrierPurchasePlan.CarrierPurchasePlanId = Convert.ToInt32(dr["CarrierPurchasePlanId"]);
carrierPurchasePlan.CarrierSubscriptionId = Convert.ToInt32(dr["CarrierSubscriptionId"]);
carrierPurchasePlan.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
carrierPurchasePlan.OfferedFor = Convert.ToString(dr["OfferedFor"]);
carrierPurchasePlan.NextRenewalDate = Convert.ToString(dr["NextRenewalDate"]);
carrierPurchasePlan.Status = Convert.ToString(dr["Status"]);
carrierPurchasePlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
carrierPurchasePlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
carrierPurchasePlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
carrierPurchasePlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
carrierPurchasePlanList.Add(carrierPurchasePlan);
}
con.Close();
return carrierPurchasePlanList;
}
public CarrierPurchasePlan GetCarrierPurchasePlanById(int CarrierPurchasePlanId)
{
CarrierPurchasePlan carrierPurchasePlan = new CarrierPurchasePlan();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetCarrierPurchasePlanById" , con);
cmd.Parameters.Add("CarrierPurchasePlanId", SqlDbType.Int).Value = CarrierPurchasePlanId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
carrierPurchasePlan.CarrierPurchasePlanId = Convert.ToInt32(dr["CarrierPurchasePlanId"]);
carrierPurchasePlan.CarrierSubscriptionId = Convert.ToInt32(dr["CarrierSubscriptionId"]);
carrierPurchasePlan.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
carrierPurchasePlan.OfferedFor = Convert.ToString(dr["OfferedFor"]);
carrierPurchasePlan.NextRenewalDate = Convert.ToString(dr["NextRenewalDate"]);
carrierPurchasePlan.Status = Convert.ToString(dr["Status"]);
carrierPurchasePlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
carrierPurchasePlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
carrierPurchasePlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
carrierPurchasePlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return carrierPurchasePlan;
}
public string AddCarrierPurchasePlan(CarrierPurchasePlan carrierPurchasePlan)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddCarrierPurchasePlan", con);
cmd.Parameters.Add("CarrierSubscriptionId", SqlDbType.Int).Value = carrierPurchasePlan.CarrierSubscriptionId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = carrierPurchasePlan.RegistrationId;
cmd.Parameters.Add("OfferedFor", SqlDbType.NVarChar).Value = carrierPurchasePlan.OfferedFor;
cmd.Parameters.Add("NextRenewalDate", SqlDbType.NVarChar).Value = carrierPurchasePlan.NextRenewalDate;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = carrierPurchasePlan.Status;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = carrierPurchasePlan.CreatedBy;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = carrierPurchasePlan.CreatedDate;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = carrierPurchasePlan.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = carrierPurchasePlan.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CarrierPurchasePlanId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CarrierPurchasePlanId.ToString();
}
 [HttpPost]
public string UpdateCarrierPurchasePlan(CarrierPurchasePlan carrierPurchasePlan)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateCarrierPurchasePlan" , con);
cmd.Parameters.Add("CarrierPurchasePlanId", SqlDbType.Int).Value = carrierPurchasePlan.CarrierPurchasePlanId;
cmd.Parameters.Add("CarrierSubscriptionId", SqlDbType.Int).Value = carrierPurchasePlan.CarrierSubscriptionId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = carrierPurchasePlan.RegistrationId;
cmd.Parameters.Add("OfferedFor", SqlDbType.NVarChar).Value = carrierPurchasePlan.OfferedFor;
cmd.Parameters.Add("NextRenewalDate", SqlDbType.NVarChar).Value = carrierPurchasePlan.NextRenewalDate;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = carrierPurchasePlan.Status;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = carrierPurchasePlan.CreatedBy;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = carrierPurchasePlan.CreatedDate;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = carrierPurchasePlan.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = carrierPurchasePlan.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CarrierPurchasePlanId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CarrierPurchasePlanId.ToString();
}
public String DeleteCarrierPurchasePlan(int CarrierPurchasePlanId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteCarrierPurchasePlan", con);
cmd.Parameters.Add("CarrierPurchasePlanId", SqlDbType.Int).Value = CarrierPurchasePlanId;
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
