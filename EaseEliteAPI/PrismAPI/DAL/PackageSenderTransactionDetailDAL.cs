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
public class PackageSenderTransactionDetailDAL
{
DbConnection conn = null;
public PackageSenderTransactionDetailDAL()
{
conn = new DbConnection();
}
public List<PackageSenderTransactionDetail> GetAllPackageSenderTransactionDetail()
{
List<PackageSenderTransactionDetail> packageSenderTransactionDetailList = new List<PackageSenderTransactionDetail>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllPackageSenderTransactionDetail", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
PackageSenderTransactionDetail packageSenderTransactionDetail = new PackageSenderTransactionDetail();
packageSenderTransactionDetail.PackageSenderTansactionDetailId = Convert.ToInt32(dr["PackageSenderTansactionDetailId"]);
packageSenderTransactionDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
packageSenderTransactionDetail.PackageSenderSubscriptionId = Convert.ToInt32(dr["PackageSenderSubscriptionId"]);
packageSenderTransactionDetail.TransactionId = Convert.ToString(dr["TransactionId"]);
packageSenderTransactionDetail.TransactionDate = Convert.ToString(dr["TransactionDate"]);
packageSenderTransactionDetail.TransactionStatus = Convert.ToString(dr["TransactionStatus"]);
packageSenderTransactionDetail.TransactionAmount = Convert.ToString(dr["TransactionAmount"]);
packageSenderTransactionDetail.Status = Convert.ToString(dr["Status"]);
packageSenderTransactionDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
packageSenderTransactionDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
packageSenderTransactionDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
packageSenderTransactionDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
packageSenderTransactionDetailList.Add(packageSenderTransactionDetail);
}
con.Close();
return packageSenderTransactionDetailList;
}
public PackageSenderTransactionDetail GetPackageSenderTransactionDetailById(int PackageSenderTansactionDetailId)
{
PackageSenderTransactionDetail packageSenderTransactionDetail = new PackageSenderTransactionDetail();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetPackageSenderTransactionDetailById" , con);
cmd.Parameters.Add("PackageSenderTansactionDetailId", SqlDbType.Int).Value = PackageSenderTansactionDetailId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
packageSenderTransactionDetail.PackageSenderTansactionDetailId = Convert.ToInt32(dr["PackageSenderTansactionDetailId"]);
packageSenderTransactionDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
packageSenderTransactionDetail.PackageSenderSubscriptionId = Convert.ToInt32(dr["PackageSenderSubscriptionId"]);
packageSenderTransactionDetail.TransactionId = Convert.ToString(dr["TransactionId"]);
packageSenderTransactionDetail.TransactionDate = Convert.ToString(dr["TransactionDate"]);
packageSenderTransactionDetail.TransactionStatus = Convert.ToString(dr["TransactionStatus"]);
packageSenderTransactionDetail.TransactionAmount = Convert.ToString(dr["TransactionAmount"]);
packageSenderTransactionDetail.Status = Convert.ToString(dr["Status"]);
packageSenderTransactionDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
packageSenderTransactionDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
packageSenderTransactionDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
packageSenderTransactionDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return packageSenderTransactionDetail;
}
public string AddPackageSenderTransactionDetail(PackageSenderTransactionDetail packageSenderTransactionDetail)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddPackageSenderTransactionDetail", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = packageSenderTransactionDetail.RegistrationId;
cmd.Parameters.Add("PackageSenderSubscriptionId", SqlDbType.Int).Value = packageSenderTransactionDetail.PackageSenderSubscriptionId;
cmd.Parameters.Add("TransactionId", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.TransactionId;
cmd.Parameters.Add("TransactionDate", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.TransactionDate;
cmd.Parameters.Add("TransactionStatus", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.TransactionStatus;
cmd.Parameters.Add("TransactionAmount", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.TransactionAmount;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var PackageSenderTansactionDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return PackageSenderTansactionDetailId.ToString();
}
 [HttpPost]
public string UpdatePackageSenderTransactionDetail(PackageSenderTransactionDetail packageSenderTransactionDetail)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdatePackageSenderTransactionDetail" , con);
cmd.Parameters.Add("PackageSenderTansactionDetailId", SqlDbType.Int).Value = packageSenderTransactionDetail.PackageSenderTansactionDetailId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = packageSenderTransactionDetail.RegistrationId;
cmd.Parameters.Add("PackageSenderSubscriptionId", SqlDbType.Int).Value = packageSenderTransactionDetail.PackageSenderSubscriptionId;
cmd.Parameters.Add("TransactionId", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.TransactionId;
cmd.Parameters.Add("TransactionDate", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.TransactionDate;
cmd.Parameters.Add("TransactionStatus", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.TransactionStatus;
cmd.Parameters.Add("TransactionAmount", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.TransactionAmount;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = packageSenderTransactionDetail.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var PackageSenderTansactionDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return PackageSenderTansactionDetailId.ToString();
}
public String DeletePackageSenderTransactionDetail(int PackageSenderTansactionDetailId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeletePackageSenderTransactionDetail", con);
cmd.Parameters.Add("PackageSenderTansactionDetailId", SqlDbType.Int).Value = PackageSenderTansactionDetailId;
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
