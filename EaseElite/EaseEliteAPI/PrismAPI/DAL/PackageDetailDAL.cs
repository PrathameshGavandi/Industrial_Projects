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
public class PackageDetailDAL
{
DbConnection conn = null;
public PackageDetailDAL()
{
conn = new DbConnection();
}
public List<PackageDetail> GetAllPackageDetail()
{
List<PackageDetail> packageDetailList = new List<PackageDetail>();
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("GetAllPackageDetail", con);
cmd.CommandType = CommandType.StoredProcedure;
SqlDataReader dr = cmd.ExecuteReader();
 while (dr.Read())
{
PackageDetail packageDetail = new PackageDetail();
packageDetail.PackageDetailId = Convert.ToInt32(dr["PackageDetailId"]);
packageDetail.registration = new Registration();
packageDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
//packageDetail.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
packageDetail.FlightNumber = Convert.ToString(dr["FlightNumber"]);
packageDetail.Date = Convert.ToString(dr["Date"]);
packageDetail.Time = Convert.ToString(dr["Time"]);
packageDetail.From1 = Convert.ToString(dr["From1"]);
packageDetail.To1 = Convert.ToString(dr["To1"]);
packageDetail.LoadCapacity = Convert.ToString(dr["LoadCapacity"]);
packageDetail.Status = Convert.ToString(dr["Status"]);
packageDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
packageDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
packageDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
packageDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
packageDetailList.Add(packageDetail);
}
con.Close();
return packageDetailList;
}
public PackageDetail GetPackageDetailById(int PackageDetailId)
{
PackageDetail packageDetail = new PackageDetail();
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("GetPackageDetailById" , con);
cmd.Parameters.Add("PackageDetailId", SqlDbType.Int).Value = PackageDetailId;
cmd.CommandType = CommandType.StoredProcedure;
 SqlDataReader dr = cmd.ExecuteReader();
if (dr.Read())
{
packageDetail.PackageDetailId = Convert.ToInt32(dr["PackageDetailId"]);
packageDetail.registration = new Registration();
packageDetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
//packageDetail.registration.RegistrationId = Convert.ToInt32(dr["RegistrationId1"]);
packageDetail.FlightNumber = Convert.ToString(dr["FlightNumber"]);
packageDetail.Date = Convert.ToString(dr["Date"]);
packageDetail.Time = Convert.ToString(dr["Time"]);
packageDetail.From1 = Convert.ToString(dr["From1"]);
packageDetail.To1 = Convert.ToString(dr["To1"]);
packageDetail.LoadCapacity = Convert.ToString(dr["LoadCapacity"]);
packageDetail.Status = Convert.ToString(dr["Status"]);
packageDetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
packageDetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
packageDetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
packageDetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
}
con.Close();
return packageDetail;
}
public string AddPackageDetail(PackageDetail packageDetail)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("AddPackageDetail", con);
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = packageDetail.RegistrationId;
cmd.Parameters.Add("FlightNumber", SqlDbType.NVarChar).Value = packageDetail.FlightNumber;
cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = packageDetail.Date;
cmd.Parameters.Add("Time", SqlDbType.NVarChar).Value = packageDetail.Time;
cmd.Parameters.Add("From1", SqlDbType.NVarChar).Value = packageDetail.From1;
cmd.Parameters.Add("To1", SqlDbType.NVarChar).Value = packageDetail.To1;
cmd.Parameters.Add("LoadCapacity", SqlDbType.NVarChar).Value = packageDetail.LoadCapacity;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = packageDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = packageDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = packageDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = packageDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = packageDetail.UpdatedBy;
Random r = new Random();
int num = r.Next();
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var PackageDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return PackageDetailId.ToString();
}
 [HttpPost]
public string UpdatePackageDetail(PackageDetail packageDetail)
{
 SqlConnection con = conn.OpenDbConnection();
 SqlCommand cmd = new SqlCommand("UpdatePackageDetail" , con);
cmd.Parameters.Add("PackageDetailId", SqlDbType.Int).Value = packageDetail.PackageDetailId;
cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = packageDetail.RegistrationId;
cmd.Parameters.Add("FlightNumber", SqlDbType.NVarChar).Value = packageDetail.FlightNumber;
cmd.Parameters.Add("Date", SqlDbType.NVarChar).Value = packageDetail.Date;
cmd.Parameters.Add("Time", SqlDbType.NVarChar).Value = packageDetail.Time;
cmd.Parameters.Add("From1", SqlDbType.NVarChar).Value = packageDetail.From1;
cmd.Parameters.Add("To1", SqlDbType.NVarChar).Value = packageDetail.To1;
cmd.Parameters.Add("LoadCapacity", SqlDbType.NVarChar).Value = packageDetail.LoadCapacity;
cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = packageDetail.Status;
cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = packageDetail.CreatedDate;
cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = packageDetail.CreatedBy;
cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = packageDetail.UpdatedDate;
cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = packageDetail.UpdatedBy;
cmd.CommandType = CommandType.StoredProcedure;
object result = cmd.ExecuteScalar();
var PackageDetailId = result.ToString();
con.Close();
if (result.ToString() == "0")
{
return "Failed";
}
 return PackageDetailId.ToString();
}
public String DeletePackageDetail(int PackageDetailId)
{
SqlConnection con = conn.OpenDbConnection();
SqlCommand cmd = new SqlCommand("DeletePackageDetail", con);
cmd.Parameters.Add("PackageDetailId", SqlDbType.Int).Value = PackageDetailId;
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
