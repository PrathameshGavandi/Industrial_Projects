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
public class CompanionDetailDAL
{
DbConnection conn = null;
public CompanionDetailDAL()
{
conn = new DbConnection();
}
public List<CompanionDetail> GetAllCompanionDetail()
{
List<CompanionDetail> companionDetailList = new List<CompanionDetail>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllCompanionDetail", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
CompanionDetail companionDetail = new CompanionDetail();
companionDetail.CompanionId = Convert.ToInt32(dr["CompanionId"]);
companionDetail.registration = new Registration();
companionDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
//companionDetail.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
//companionDetail.FlightNumber = Convert.ToString(dr["FlightNumber"]);
companionDetail.Date = Convert.ToString(dr["Date"]);
companionDetail.Time = Convert.ToString(dr["Time"]);
companionDetail.From1 = Convert.ToString(dr["From1"]);
companionDetail.To1 = Convert.ToString(dr["To1"]);
companionDetail.UploadTicket = Convert.ToString(dr["UploadTicket"]);
companionDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
companionDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
companionDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
companionDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
companionDetailList.Add(companionDetail);
}
con.Close();
return companionDetailList;
}
public CompanionDetail GetCompanionDetailById(int CompanionId)
{
CompanionDetail companionDetail = new CompanionDetail();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetCompanionDetailById" , con);
cmd.Parameters.Add("CompanionId", SqlDbType.Int).Value = CompanionId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
companionDetail.CompanionId = Convert.ToInt32(dr["CompanionId"]);
companionDetail.registration = new Registration();
companionDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
//companionDetail.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
companionDetail.FlightNumber = Convert.ToString(dr["FlightNumber"]);
companionDetail.Date = Convert.ToString(dr["Date"]);
companionDetail.Time = Convert.ToString(dr["Time"]);
companionDetail.From1 = Convert.ToString(dr["From1"]);
companionDetail.To1 = Convert.ToString(dr["To1"]);
companionDetail.UploadTicket = Convert.ToString(dr["UploadTicket"]);
companionDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
companionDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
companionDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
companionDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return companionDetail;
}
public string AddCompanionDetail(CompanionDetail companionDetail)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddCompanionDetail", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = companionDetail.RegistrationId;
cmd.Parameters.Add("FlightNumber", SqlDbType.NVarChar).Value = companionDetail.FlightNumber;
cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = companionDetail.Date;
cmd.Parameters.Add("Time", SqlDbType.NVarChar).Value = companionDetail.Time;
cmd.Parameters.Add("From1", SqlDbType.NVarChar).Value = companionDetail.From1;
cmd.Parameters.Add("To1", SqlDbType.NVarChar).Value = companionDetail.To1;
cmd.Parameters.Add("UploadTicket", SqlDbType.NVarChar).Value = companionDetail.UploadTicket;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = companionDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = companionDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = companionDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = companionDetail.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CompanionId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CompanionId.ToString();
}
 [HttpPost]
public string UpdateCompanionDetail(CompanionDetail companionDetail)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateCompanionDetail" , con);
cmd.Parameters.Add("CompanionId", SqlDbType.Int).Value = companionDetail.CompanionId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = companionDetail.RegistrationId;
cmd.Parameters.Add("FlightNumber", SqlDbType.NVarChar).Value = companionDetail.FlightNumber;
cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = companionDetail.Date;
cmd.Parameters.Add("Time", SqlDbType.NVarChar).Value = companionDetail.Time;
cmd.Parameters.Add("From1", SqlDbType.NVarChar).Value = companionDetail.From1;
cmd.Parameters.Add("To1", SqlDbType.NVarChar).Value = companionDetail.To1;
cmd.Parameters.Add("UploadTicket", SqlDbType.NVarChar).Value = companionDetail.UploadTicket;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = companionDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = companionDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = companionDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = companionDetail.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var CompanionId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return CompanionId.ToString();
}
public String DeleteCompanionDetail(int CompanionId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteCompanionDetail", con);
cmd.Parameters.Add("CompanionId", SqlDbType.Int).Value = CompanionId;
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
