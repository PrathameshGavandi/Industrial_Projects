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
public class CarrierTransactionDetailDAL
{
DbConnection conn = null;
public CarrierTransactionDetailDAL()
{
conn = new DbConnection();
}
public List<CarrierTransactionDetail> GetAllCarrierTransactionDetail()
{
List<CarrierTransactionDetail> carrierTransactionDetailList = new List<CarrierTransactionDetail>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllCarrierTransactionDetail", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
CarrierTransactionDetail carrierTransactionDetail = new CarrierTransactionDetail();
carrierTransactionDetail.CarrierTransactionDetailId = Convert.ToInt32(dr["CarrierTransactionDetailId"]);
carrierTransactionDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
carrierTransactionDetail.CarrierSubscriptionId = Convert.ToInt32(dr["CarrierSubscriptionId"]);
carrierTransactionDetail.TransactionId = Convert.ToString(dr["TransactionId"]);
carrierTransactionDetail.TransactionDate = Convert.ToString(dr["TransactionDate"]);
carrierTransactionDetail.TransactionStatus = Convert.ToString(dr["TransactionStatus"]);
carrierTransactionDetail.TransactionAmount = Convert.ToString(dr["TransactionAmount"]);
carrierTransactionDetail.Status = Convert.ToString(dr["Status"]);
carrierTransactionDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
carrierTransactionDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
carrierTransactionDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
carrierTransactionDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
carrierTransactionDetailList.Add(carrierTransactionDetail);
}
con.Close();
return carrierTransactionDetailList;
}
public CarrierTransactionDetail GetCarrierTransactionDetailById(int CarrierTransactionDetailId)
{
CarrierTransactionDetail carrierTransactionDetail = new CarrierTransactionDetail();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetCarrierTransactionDetailById" , con);
cmd.Parameters.Add("CarrierTransactionDetailId", SqlDbType.Int).Value = CarrierTransactionDetailId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
carrierTransactionDetail.CarrierTransactionDetailId = Convert.ToInt32(dr["CarrierTransactionDetailId"]);
carrierTransactionDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
carrierTransactionDetail.CarrierSubscriptionId = Convert.ToInt32(dr["CarrierSubscriptionId"]);
carrierTransactionDetail.TransactionId = Convert.ToString(dr["TransactionId"]);
carrierTransactionDetail.TransactionDate = Convert.ToString(dr["TransactionDate"]);
carrierTransactionDetail.TransactionStatus = Convert.ToString(dr["TransactionStatus"]);
carrierTransactionDetail.TransactionAmount = Convert.ToString(dr["TransactionAmount"]);
carrierTransactionDetail.Status = Convert.ToString(dr["Status"]);
carrierTransactionDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
carrierTransactionDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
carrierTransactionDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
carrierTransactionDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return carrierTransactionDetail;
}
public string AddCarrierTransactionDetail(CarrierTransactionDetail carrierTransactionDetail)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddCarrierTransactionDetail", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = carrierTransactionDetail.RegistrationId;
cmd.Parameters.Add("CarrierSubscriptionId", SqlDbType.Int).Value = carrierTransactionDetail.CarrierSubscriptionId;
cmd.Parameters.Add("TransactionId", SqlDbType.NVarChar).Value = carrierTransactionDetail.TransactionId;
cmd.Parameters.Add("TransactionDate", SqlDbType.NVarChar).Value = carrierTransactionDetail.TransactionDate;
cmd.Parameters.Add("TransactionStatus", SqlDbType.NVarChar).Value = carrierTransactionDetail.TransactionStatus;
cmd.Parameters.Add("TransactionAmount", SqlDbType.NVarChar).Value = carrierTransactionDetail.TransactionAmount;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = carrierTransactionDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = carrierTransactionDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = carrierTransactionDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = carrierTransactionDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = carrierTransactionDetail.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CarrierTransactionDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CarrierTransactionDetailId.ToString();
}
 [HttpPost]
public string UpdateCarrierTransactionDetail(CarrierTransactionDetail carrierTransactionDetail)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateCarrierTransactionDetail" , con);
cmd.Parameters.Add("CarrierTransactionDetailId", SqlDbType.Int).Value = carrierTransactionDetail.CarrierTransactionDetailId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = carrierTransactionDetail.RegistrationId;
cmd.Parameters.Add("CarrierSubscriptionId", SqlDbType.Int).Value = carrierTransactionDetail.CarrierSubscriptionId;
cmd.Parameters.Add("TransactionId", SqlDbType.NVarChar).Value = carrierTransactionDetail.TransactionId;
cmd.Parameters.Add("TransactionDate", SqlDbType.NVarChar).Value = carrierTransactionDetail.TransactionDate;
cmd.Parameters.Add("TransactionStatus", SqlDbType.NVarChar).Value = carrierTransactionDetail.TransactionStatus;
cmd.Parameters.Add("TransactionAmount", SqlDbType.NVarChar).Value = carrierTransactionDetail.TransactionAmount;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = carrierTransactionDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = carrierTransactionDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = carrierTransactionDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = carrierTransactionDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = carrierTransactionDetail.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CarrierTransactionDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CarrierTransactionDetailId.ToString();
}
public String DeleteCarrierTransactionDetail(int CarrierTransactionDetailId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteCarrierTransactionDetail", con);
cmd.Parameters.Add("CarrierTransactionDetailId", SqlDbType.Int).Value = CarrierTransactionDetailId;
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
