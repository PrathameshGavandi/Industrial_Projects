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
public class AdmFttSubscriptionDAL
{
DbConnection conn = null;
public AdmFttSubscriptionDAL()
{
conn = new DbConnection();
}
public List<AdmFttSubscription> GetAllAdmFttSubscription()
{
List<AdmFttSubscription> admFttSubscriptionList = new List<AdmFttSubscription>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllAdmFttSubscription", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
AdmFttSubscription admFttSubscription = new AdmFttSubscription();
admFttSubscription.AdmFttSubscriptionld = Convert.ToInt32(dr["AdmFttSubscriptionld"]);
admFttSubscription.Title = Convert.ToString(dr["Title"]);
admFttSubscription.SubTitle = Convert.ToString(dr["SubTitle"]);
admFttSubscription.Description = Convert.ToString(dr["Description"]);
admFttSubscription.Price = Convert.ToString(dr["Price"]);
admFttSubscription.PlanPeriod = Convert.ToString(dr["PlanPeriod"]);
admFttSubscription.Status = Convert.ToString(dr["Status"]);
admFttSubscription.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admFttSubscription.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admFttSubscription.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admFttSubscription.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
admFttSubscriptionList.Add(admFttSubscription);
}
con.Close();
return admFttSubscriptionList;
}
public AdmFttSubscription GetAdmFttSubscriptionById(int AdmFttSubscriptionld)
{
AdmFttSubscription admFttSubscription = new AdmFttSubscription();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetAdmFttSubscriptionById" , con);
cmd.Parameters.Add("AdmFttSubscriptionld", SqlDbType.Int).Value = AdmFttSubscriptionld;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
admFttSubscription.AdmFttSubscriptionld = Convert.ToInt32(dr["AdmFttSubscriptionld"]);
admFttSubscription.Title = Convert.ToString(dr["Title"]);
admFttSubscription.SubTitle = Convert.ToString(dr["SubTitle"]);
admFttSubscription.Description = Convert.ToString(dr["Description"]);
admFttSubscription.Price = Convert.ToString(dr["Price"]);
admFttSubscription.PlanPeriod = Convert.ToString(dr["PlanPeriod"]);
admFttSubscription.Status = Convert.ToString(dr["Status"]);
admFttSubscription.CreatedDate = Convert.ToString(dr["CreatedDate"]);
admFttSubscription.CreatedBy = Convert.ToString(dr["CreatedBy"]);
admFttSubscription.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
admFttSubscription.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return admFttSubscription;
}
public string AddAdmFttSubscription(AdmFttSubscription admFttSubscription)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddAdmFttSubscription", con);
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = admFttSubscription.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = admFttSubscription.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = admFttSubscription.Description;
cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = admFttSubscription.Price;
cmd.Parameters.Add("PlanPeriod", SqlDbType.NVarChar).Value = admFttSubscription.PlanPeriod;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admFttSubscription.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admFttSubscription.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admFttSubscription.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admFttSubscription.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admFttSubscription.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmFttSubscriptionld = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmFttSubscriptionld.ToString();
}
 [HttpPost]
public string UpdateAdmFttSubscription(AdmFttSubscription admFttSubscription)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateAdmFttSubscription" , con);
cmd.Parameters.Add("AdmFttSubscriptionld", SqlDbType.Int).Value = admFttSubscription.AdmFttSubscriptionld;
cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = admFttSubscription.Title;
cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = admFttSubscription.SubTitle;
cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = admFttSubscription.Description;
cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = admFttSubscription.Price;
cmd.Parameters.Add("PlanPeriod", SqlDbType.NVarChar).Value = admFttSubscription.PlanPeriod;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admFttSubscription.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admFttSubscription.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admFttSubscription.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admFttSubscription.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admFttSubscription.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var AdmFttSubscriptionld = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return AdmFttSubscriptionld.ToString();
}
public String DeleteAdmFttSubscription(int AdmFttSubscriptionld)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteAdmFttSubscription", con);
cmd.Parameters.Add("AdmFttSubscriptionld", SqlDbType.Int).Value = AdmFttSubscriptionld;
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
