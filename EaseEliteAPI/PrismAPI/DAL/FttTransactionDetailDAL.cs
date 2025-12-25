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
public class FttTransactionDetailDAL
{
DbConnection conn = null;
public FttTransactionDetailDAL()
{
conn = new DbConnection();
}
public List<FttTransactionDetail> GetAllFttTransactionDetail()
{
List<FttTransactionDetail> fttTransactionDetailList = new List<FttTransactionDetail>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllFttTransactionDetail", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
FttTransactionDetail fttTransactionDetail = new FttTransactionDetail();
fttTransactionDetail.FttTransactionDetailId = Convert.ToInt32(dr["FttTransactionDetailId"]);
fttTransactionDetail.registration = new Registration();
fttTransactionDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
fttTransactionDetail.registration.FName = Convert.ToString(dr["FName1"]);
fttTransactionDetail.fttSubscription = new FttSubscription();
fttTransactionDetail.fttSubscription.FttSubscriptionId = Convert.ToInt32(dr["FttSubscriptionId"]);
fttTransactionDetail.fttSubscription.Title = Convert.ToString(dr["Title1"]);
fttTransactionDetail.TransactionId = Convert.ToString(dr["TransactionId"]);
fttTransactionDetail.TransactionDate = Convert.ToString(dr["TransactionDate"]);
fttTransactionDetail.TransactionStatus = Convert.ToString(dr["TransactionStatus"]);
fttTransactionDetail.TransactionAmount = Convert.ToString(dr["TransactionAmount"]);
fttTransactionDetail.Status = Convert.ToString(dr["Status"]);
fttTransactionDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
fttTransactionDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
fttTransactionDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
fttTransactionDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
fttTransactionDetailList.Add(fttTransactionDetail);
}
con.Close();
return fttTransactionDetailList;
}
public FttTransactionDetail GetFttTransactionDetailById(int FttTransactionDetailId)
{
FttTransactionDetail fttTransactionDetail = new FttTransactionDetail();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetFttTransactionDetailById" , con);
cmd.Parameters.Add("FttTransactionDetailId", SqlDbType.Int).Value = FttTransactionDetailId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
fttTransactionDetail.FttTransactionDetailId = Convert.ToInt32(dr["FttTransactionDetailId"]);
fttTransactionDetail.registration = new Registration();
fttTransactionDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
fttTransactionDetail.registration.FName = Convert.ToString(dr["FName1"]);
fttTransactionDetail.fttSubscription = new FttSubscription();
fttTransactionDetail.fttSubscription.FttSubscriptionId = Convert.ToInt32(dr["FttSubscriptionId"]);
fttTransactionDetail.fttSubscription.Title = Convert.ToString(dr["Title1"]);
fttTransactionDetail.TransactionId = Convert.ToString(dr["TransactionId"]);
fttTransactionDetail.TransactionDate = Convert.ToString(dr["TransactionDate"]);
fttTransactionDetail.TransactionStatus = Convert.ToString(dr["TransactionStatus"]);
fttTransactionDetail.TransactionAmount = Convert.ToString(dr["TransactionAmount"]);
fttTransactionDetail.Status = Convert.ToString(dr["Status"]);
fttTransactionDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
fttTransactionDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
fttTransactionDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
fttTransactionDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return fttTransactionDetail;
}
public string AddFttTransactionDetail(FttTransactionDetail fttTransactionDetail)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddFttTransactionDetail", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = fttTransactionDetail.RegistrationId;
cmd.Parameters.Add("FttSubscriptionId", SqlDbType.Int).Value = fttTransactionDetail.FttSubscriptionId;
cmd.Parameters.Add("TransactionId", SqlDbType.NVarChar).Value = fttTransactionDetail.TransactionId;
cmd.Parameters.Add("TransactionDate", SqlDbType.NVarChar).Value = fttTransactionDetail.TransactionDate;
cmd.Parameters.Add("TransactionStatus", SqlDbType.NVarChar).Value = fttTransactionDetail.TransactionStatus;
cmd.Parameters.Add("TransactionAmount", SqlDbType.NVarChar).Value = fttTransactionDetail.TransactionAmount;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = fttTransactionDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = fttTransactionDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = fttTransactionDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = fttTransactionDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = fttTransactionDetail.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var FttTransactionDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return FttTransactionDetailId.ToString();
}
 [HttpPost]
public string UpdateFttTransactionDetail(FttTransactionDetail fttTransactionDetail)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateFttTransactionDetail" , con);
cmd.Parameters.Add("FttTransactionDetailId", SqlDbType.Int).Value = fttTransactionDetail.FttTransactionDetailId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = fttTransactionDetail.RegistrationId;
cmd.Parameters.Add("FttSubscriptionId", SqlDbType.Int).Value = fttTransactionDetail.FttSubscriptionId;
cmd.Parameters.Add("TransactionId", SqlDbType.NVarChar).Value = fttTransactionDetail.TransactionId;
cmd.Parameters.Add("TransactionDate", SqlDbType.NVarChar).Value = fttTransactionDetail.TransactionDate;
cmd.Parameters.Add("TransactionStatus", SqlDbType.NVarChar).Value = fttTransactionDetail.TransactionStatus;
cmd.Parameters.Add("TransactionAmount", SqlDbType.NVarChar).Value = fttTransactionDetail.TransactionAmount;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = fttTransactionDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = fttTransactionDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = fttTransactionDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = fttTransactionDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = fttTransactionDetail.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var FttTransactionDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return FttTransactionDetailId.ToString();
}
public String DeleteFttTransactionDetail(int FttTransactionDetailId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteFttTransactionDetail", con);
cmd.Parameters.Add("FttTransactionDetailId", SqlDbType.Int).Value = FttTransactionDetailId;
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
