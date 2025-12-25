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
public class CarrierDetailDAL
{
DbConnection conn = null;
public CarrierDetailDAL()
{
conn = new DbConnection();
}
public List<CarrierDetail> GetAllCarrierDetail()
{
List<CarrierDetail> carrierDetailList = new List<CarrierDetail>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllCarrierDetail", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
CarrierDetail carrierDetail = new CarrierDetail();
carrierDetail.CarrierDetailId = Convert.ToInt32(dr["CarrierDetailId"]);
carrierDetail.registration = new Registration();
carrierDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
//carrierDetail.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
carrierDetail.FlightNumber = Convert.ToString(dr["FlightNumber"]);
carrierDetail.Date = Convert.ToString(dr["Date"]);
carrierDetail.Time = Convert.ToString(dr["Time"]);
carrierDetail.From1 = Convert.ToString(dr["From1"]);
carrierDetail.To1 = Convert.ToString(dr["To1"]);
carrierDetail.LoadCapacity = Convert.ToString(dr["LoadCapacity"]);
carrierDetail.Instrauction = Convert.ToString(dr["Instrauction"]);
carrierDetail.Status = Convert.ToString(dr["Status"]);
carrierDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
carrierDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
carrierDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
carrierDetailList.Add(carrierDetail);
}
con.Close();
return carrierDetailList;
}
public CarrierDetail GetCarrierDetailById(int CarrierDetailId)
{
CarrierDetail carrierDetail = new CarrierDetail();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetCarrierDetailById" , con);
cmd.Parameters.Add("CarrierDetailId", SqlDbType.Int).Value = CarrierDetailId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
carrierDetail.CarrierDetailId = Convert.ToInt32(dr["CarrierDetailId"]);
carrierDetail.registration = new Registration();
carrierDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
//carrierDetail.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
carrierDetail.FlightNumber = Convert.ToString(dr["FlightNumber"]);
carrierDetail.Date = Convert.ToString(dr["Date"]);
carrierDetail.Time = Convert.ToString(dr["Time"]);
carrierDetail.From1 = Convert.ToString(dr["From1"]);
carrierDetail.To1 = Convert.ToString(dr["To1"]);
carrierDetail.LoadCapacity = Convert.ToString(dr["LoadCapacity"]);
carrierDetail.Instrauction = Convert.ToString(dr["Instrauction"]);
carrierDetail.Status = Convert.ToString(dr["Status"]);
carrierDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
carrierDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
carrierDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
}
con.Close();
return carrierDetail;
}
public string AddCarrierDetail(CarrierDetail carrierDetail)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddCarrierDetail", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = carrierDetail.RegistrationId;
cmd.Parameters.Add("FlightNumber", SqlDbType.NVarChar).Value = carrierDetail.FlightNumber;
cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = carrierDetail.Date;
cmd.Parameters.Add("Time", SqlDbType.NVarChar).Value = carrierDetail.Time;
cmd.Parameters.Add("From1", SqlDbType.NVarChar).Value = carrierDetail.From1;
cmd.Parameters.Add("To1", SqlDbType.NVarChar).Value = carrierDetail.To1;
cmd.Parameters.Add("LoadCapacity", SqlDbType.NVarChar).Value = carrierDetail.LoadCapacity;
cmd.Parameters.Add("Instrauction", SqlDbType.NVarChar).Value = carrierDetail.Instrauction;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = carrierDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = carrierDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = carrierDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = carrierDetail.UpdatedDate;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CarrierDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CarrierDetailId.ToString();
}
 [HttpPost]
public string UpdateCarrierDetail(CarrierDetail carrierDetail)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateCarrierDetail" , con);
cmd.Parameters.Add("CarrierDetailId", SqlDbType.Int).Value = carrierDetail.CarrierDetailId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = carrierDetail.RegistrationId;
cmd.Parameters.Add("FlightNumber", SqlDbType.NVarChar).Value = carrierDetail.FlightNumber;
cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = carrierDetail.Date;
cmd.Parameters.Add("Time", SqlDbType.NVarChar).Value = carrierDetail.Time;
cmd.Parameters.Add("From1", SqlDbType.NVarChar).Value = carrierDetail.From1;
cmd.Parameters.Add("To1", SqlDbType.NVarChar).Value = carrierDetail.To1;
cmd.Parameters.Add("LoadCapacity", SqlDbType.NVarChar).Value = carrierDetail.LoadCapacity;
cmd.Parameters.Add("Instrauction", SqlDbType.NVarChar).Value = carrierDetail.Instrauction;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = carrierDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = carrierDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = carrierDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = carrierDetail.UpdatedDate;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CarrierDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CarrierDetailId.ToString();
}
public String DeleteCarrierDetail(int CarrierDetailId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteCarrierDetail", con);
cmd.Parameters.Add("CarrierDetailId", SqlDbType.Int).Value = CarrierDetailId;
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
