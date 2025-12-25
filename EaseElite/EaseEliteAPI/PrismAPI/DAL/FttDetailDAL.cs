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
public class FttDetailDAL
{
DbConnection conn = null;
public FttDetailDAL()
{
conn = new DbConnection();
}
public List<FttDetail> GetAllFttDetail()
{
List<FttDetail> fttDetailList = new List<FttDetail>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllFttDetail", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
FttDetail fttDetail = new FttDetail();
fttDetail.FttId = Convert.ToInt32(dr["FttId"]);
fttDetail.registration = new Registration();
fttDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                //fttDetail.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
                fttDetail.Date = Convert.ToString(dr["Date"]);
                fttDetail.FlightNumber = Convert.ToString(dr["FlightNumber"]);
                fttDetail.Time = Convert.ToString(dr["Time"]);
fttDetail.From1 = Convert.ToString(dr["From1"]);
fttDetail.To1 = Convert.ToString(dr["To1"]);
fttDetail.UploadTicket = Convert.ToString(dr["UploadTicket"]);
fttDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
fttDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
fttDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
fttDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
fttDetailList.Add(fttDetail);
}
con.Close();
return fttDetailList;
}
public FttDetail GetFttDetailById(int FttId)
{
FttDetail fttDetail = new FttDetail();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetFttDetailById" , con);
cmd.Parameters.Add("FttId", SqlDbType.Int).Value = FttId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
fttDetail.FttId = Convert.ToInt32(dr["FttId"]);
fttDetail.registration = new Registration();
fttDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
//fttDetail.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
fttDetail.FlightNumber = Convert.ToString(dr["FlightNumber"]);
fttDetail.Date = Convert.ToString(dr["Date"]);
fttDetail.Time = Convert.ToString(dr["Time"]);
fttDetail.From1 = Convert.ToString(dr["From1"]);
fttDetail.To1 = Convert.ToString(dr["To1"]);
fttDetail.UploadTicket = Convert.ToString(dr["UploadTicket"]);
fttDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
fttDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
fttDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
fttDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return fttDetail;
}
public string AddFttDetail(FttDetail fttDetail)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddFttDetail", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = fttDetail.RegistrationId;
cmd.Parameters.Add("FlightNumber", SqlDbType.NVarChar).Value = fttDetail.FlightNumber;

cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = fttDetail.Date;
cmd.Parameters.Add("Time", SqlDbType.NVarChar).Value = fttDetail.Time;
cmd.Parameters.Add("From1", SqlDbType.NVarChar).Value = fttDetail.From1;
cmd.Parameters.Add("To1", SqlDbType.NVarChar).Value = fttDetail.To1;
cmd.Parameters.Add("UploadTicket", SqlDbType.NVarChar).Value = fttDetail.UploadTicket;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = fttDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = fttDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = fttDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = fttDetail.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var FttId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return FttId.ToString();
}
 [HttpPost]
public string UpdateFttDetail(FttDetail fttDetail)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdateFttDetail" , con);
cmd.Parameters.Add("FttId", SqlDbType.Int).Value = fttDetail.FttId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = fttDetail.RegistrationId;
cmd.Parameters.Add("FlightNumber", SqlDbType.NVarChar).Value = fttDetail.FlightNumber;
cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = fttDetail.Date;
cmd.Parameters.Add("Time", SqlDbType.NVarChar).Value = fttDetail.Time;
cmd.Parameters.Add("From1", SqlDbType.NVarChar).Value = fttDetail.From1;
cmd.Parameters.Add("To1", SqlDbType.NVarChar).Value = fttDetail.To1;
cmd.Parameters.Add("UploadTicket", SqlDbType.NVarChar).Value = fttDetail.UploadTicket;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = fttDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = fttDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = fttDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = fttDetail.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var FttId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return FttId.ToString();
}
public String DeleteFttDetail(int FttId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeleteFttDetail", con);
cmd.Parameters.Add("FttId", SqlDbType.Int).Value = FttId;
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
