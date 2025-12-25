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
public class CompanionTransactionDetailDAL
{
DbConnection conn = null;
public CompanionTransactionDetailDAL()
{
conn = new DbConnection();
}
public List<CompanionTransactionDetail> GetAllCompanionTransactionDetail()
{
List<CompanionTransactionDetail> companionTransactionDetailList = new List<CompanionTransactionDetail>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllCompanionTransactionDetail", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
CompanionTransactionDetail companionTransactionDetail = new CompanionTransactionDetail();
companionTransactionDetail.CompanionTransactionDetailId = Convert.ToInt32(dr["CompanionTransactionDetailId"]);
companionTransactionDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
companionTransactionDetail.CompanionSubscriptionId = Convert.ToInt32(dr["CompanionSubscriptionId"]);
companionTransactionDetail.TransactionId = Convert.ToString(dr["TransactionId"]);
companionTransactionDetail.TransactionDate = Convert.ToString(dr["TransactionDate"]);
companionTransactionDetail.TransactionStatus = Convert.ToString(dr["TransactionStatus"]);
companionTransactionDetail.TransactionAmount = Convert.ToString(dr["TransactionAmount"]);
companionTransactionDetail.Status = Convert.ToString(dr["Status"]);
companionTransactionDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
companionTransactionDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
companionTransactionDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
companionTransactionDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
companionTransactionDetailList.Add(companionTransactionDetail);
}
con.Close();
return companionTransactionDetailList;
}
public CompanionTransactionDetail GetCompanionTransactionDetailById(int CompanionTransactionDetailId)
{
CompanionTransactionDetail companionTransactionDetail = new CompanionTransactionDetail();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetCompanionTransactionDetailById" , con);
cmd.Parameters.Add("CompanionTransactionDetailId", SqlDbType.Int).Value = CompanionTransactionDetailId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
companionTransactionDetail.CompanionTransactionDetailId = Convert.ToInt32(dr["CompanionTransactionDetailId"]);
companionTransactionDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
companionTransactionDetail.CompanionSubscriptionId = Convert.ToInt32(dr["CompanionSubscriptionId"]);
companionTransactionDetail.TransactionId = Convert.ToString(dr["TransactionId"]);
companionTransactionDetail.TransactionDate = Convert.ToString(dr["TransactionDate"]);
companionTransactionDetail.TransactionStatus = Convert.ToString(dr["TransactionStatus"]);
companionTransactionDetail.TransactionAmount = Convert.ToString(dr["TransactionAmount"]);
companionTransactionDetail.Status = Convert.ToString(dr["Status"]);
companionTransactionDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
companionTransactionDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
companionTransactionDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
companionTransactionDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return companionTransactionDetail;
}
public string AddCompanionTransactionDetail(CompanionTransactionDetail companionTransactionDetail)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddCompanionTransactionDetail", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = companionTransactionDetail.RegistrationId;
cmd.Parameters.Add("CompanionSubscriptionId", SqlDbType.Int).Value = companionTransactionDetail.CompanionSubscriptionId;
cmd.Parameters.Add("TransactionId", SqlDbType.NVarChar).Value = companionTransactionDetail.TransactionId;
cmd.Parameters.Add("TransactionDate", SqlDbType.NVarChar).Value = companionTransactionDetail.TransactionDate;
cmd.Parameters.Add("TransactionStatus", SqlDbType.NVarChar).Value = companionTransactionDetail.TransactionStatus;
cmd.Parameters.Add("TransactionAmount", SqlDbType.NVarChar).Value = companionTransactionDetail.TransactionAmount;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = companionTransactionDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = companionTransactionDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = companionTransactionDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = companionTransactionDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = companionTransactionDetail.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CompanionTransactionDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CompanionTransactionDetailId.ToString();
}
 [HttpPost]
public string UpdateCompanionTransactionDetail(CompanionTransactionDetail companionTransactionDetail)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateCompanionTransactionDetail" , con);
cmd.Parameters.Add("CompanionTransactionDetailId", SqlDbType.Int).Value = companionTransactionDetail.CompanionTransactionDetailId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = companionTransactionDetail.RegistrationId;
cmd.Parameters.Add("CompanionSubscriptionId", SqlDbType.Int).Value = companionTransactionDetail.CompanionSubscriptionId;
cmd.Parameters.Add("TransactionId", SqlDbType.NVarChar).Value = companionTransactionDetail.TransactionId;
cmd.Parameters.Add("TransactionDate", SqlDbType.NVarChar).Value = companionTransactionDetail.TransactionDate;
cmd.Parameters.Add("TransactionStatus", SqlDbType.NVarChar).Value = companionTransactionDetail.TransactionStatus;
cmd.Parameters.Add("TransactionAmount", SqlDbType.NVarChar).Value = companionTransactionDetail.TransactionAmount;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = companionTransactionDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = companionTransactionDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = companionTransactionDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = companionTransactionDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = companionTransactionDetail.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CompanionTransactionDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CompanionTransactionDetailId.ToString();
}
public String DeleteCompanionTransactionDetail(int CompanionTransactionDetailId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteCompanionTransactionDetail", con);
cmd.Parameters.Add("CompanionTransactionDetailId", SqlDbType.Int).Value = CompanionTransactionDetailId;
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
