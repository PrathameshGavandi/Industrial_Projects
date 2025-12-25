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
public class FttSubscriptionDAL
{
DbConnection conn = null;
public FttSubscriptionDAL()
{
conn = new DbConnection();
}
public List<FttSubscription> GetAllFttSubscription()
{
List<FttSubscription> fttSubscriptionList = new List<FttSubscription>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllFttSubscription", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
FttSubscription fttSubscription = new FttSubscription();
fttSubscription.FttSubscriptionId = Convert.ToInt32(dr["FttSubscriptionId"]);
fttSubscription.Title = Convert.ToString(dr["Title"]);
fttSubscription.SubTitle = Convert.ToString(dr["SubTitle"]);
fttSubscription.Description = Convert.ToString(dr["Description"]);
fttSubscription.Price = Convert.ToString(dr["Price"]);
fttSubscription.PlanPeriod = Convert.ToString(dr["PlanPeriod"]);
fttSubscription.Status = Convert.ToString(dr["Status"]);
fttSubscription.CreatedDate = Convert.ToString(dr["CreatedDate"]);
fttSubscription.CreatedBy = Convert.ToString(dr["CreatedBy"]);
fttSubscription.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
fttSubscription.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
fttSubscriptionList.Add(fttSubscription);
}
con.Close();
return fttSubscriptionList;
}
public FttSubscription GetFttSubscriptionById(int FttSubscriptionId)
{
FttSubscription fttSubscription = new FttSubscription();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetFttSubscriptionById" , con);
cmd.Parameters.Add("FttSubscriptionId", SqlDbType.Int).Value = FttSubscriptionId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
fttSubscription.FttSubscriptionId = Convert.ToInt32(dr["FttSubscriptionId"]);
fttSubscription.Title = Convert.ToString(dr["Title"]);
fttSubscription.SubTitle = Convert.ToString(dr["SubTitle"]);
fttSubscription.Description = Convert.ToString(dr["Description"]);
fttSubscription.Price = Convert.ToString(dr["Price"]);
fttSubscription.PlanPeriod = Convert.ToString(dr["PlanPeriod"]);
fttSubscription.Status = Convert.ToString(dr["Status"]);
fttSubscription.CreatedDate = Convert.ToString(dr["CreatedDate"]);
fttSubscription.CreatedBy = Convert.ToString(dr["CreatedBy"]);
fttSubscription.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
fttSubscription.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return fttSubscription;
}
public string AddFttSubscription(FttSubscription fttSubscription)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddFttSubscription", con);
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = fttSubscription.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = fttSubscription.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = fttSubscription.Description;
cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = fttSubscription.Price;
cmd.Parameters.Add("PlanPeriod", SqlDbType.NVarChar).Value = fttSubscription.PlanPeriod;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = fttSubscription.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = fttSubscription.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = fttSubscription.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = fttSubscription.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = fttSubscription.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var FttSubscriptionId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return FttSubscriptionId.ToString();
}
 [HttpPost]
public string UpdateFttSubscription(FttSubscription fttSubscription)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateFttSubscription" , con);
cmd.Parameters.Add("FttSubscriptionId", SqlDbType.Int).Value = fttSubscription.FttSubscriptionId;
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = fttSubscription.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = fttSubscription.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = fttSubscription.Description;
cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = fttSubscription.Price;
cmd.Parameters.Add("PlanPeriod", SqlDbType.NVarChar).Value = fttSubscription.PlanPeriod;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = fttSubscription.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = fttSubscription.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = fttSubscription.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = fttSubscription.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = fttSubscription.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var FttSubscriptionId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return FttSubscriptionId.ToString();
}
public String DeleteFttSubscription(int FttSubscriptionId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteFttSubscription", con);
cmd.Parameters.Add("FttSubscriptionId", SqlDbType.Int).Value = FttSubscriptionId;
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
